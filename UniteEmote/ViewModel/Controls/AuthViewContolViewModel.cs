﻿using System;
using System.Windows.Input;
using Appccelerate.EventBroker;
using Appccelerate.EventBroker.Handlers;
using UniteEmote.Model.Command;
using UniteEmote.Model.EventArguments;
using UniteEmote.Static;
using UniteEmote.Utility;

namespace UniteEmote.ViewModel.Controls
{
    [Serializable]
    public class AuthViewControlViewModel : HubViewModel
    {
        #region Fields
        [field: NonSerialized]
        private EventHandler<ShowAuthViewEventArgs> _showAuthView;
        [field: NonSerialized]
        public readonly BoolToStringConverter HubViewMethodBoolToStringConverter = new BoolToStringConverter("Allocate", "DeAllocate");

        private ICommand _showAuthViewButton_ClickCommand;
        #endregion

        #region Properties
        public event EventHandler<ShowAuthViewEventArgs> ShowAuthView
        {
            add => _showAuthView += value;
            remove => _showAuthView -= value;
        }
        public bool IsAllocated { get; set; }

        public bool IsAllViewAllocated => PluginConfig.HubViewManager.IsAllViewsAllocated(UI.HubView.Type.AuthImage);

        public string ButtonText => HubViewMethodBoolToStringConverter.Convert(!IsAllocated) + " AuthImage";

        public ICommand ShowAuthViewButton_ClickCommand
        {
            get
            {
                return _showAuthViewButton_ClickCommand ?? (_showAuthViewButton_ClickCommand = new RelayCommand<AuthViewControlViewModel>(
                           x =>
                           {
                               ShowAuthViewButton_SendMsgAndClick(this, new ToggleAuthViewEventArgs { SourceGuid = x.ControlIdentifier });
                           },x => PluginConfig.HubViewManager.DoAllViewsHaveSameIsAllocated(UI.HubView.Type.AuthImage)));
            }
        }
        #endregion

        public AuthViewControlViewModel()
        {
            MessagingEventBroker.GlobalEventBroker.Register(this);
            _showAuthView += PluginConfig.HubViewManager.EventCommandInvoker;
            CommandManager.InvalidateRequerySuggested();
        }


        #region Methods

        public void Start()
        {

        }

        public void ShowAuthViewButton_SendMsgAndClick(object sender, ToggleAuthViewEventArgs eventArgs)
        {
            PluginConfig.RuntimeContext.MessageSender.TrySendMessage(
                new CommandWraper<ToggleAuthViewEventArgs>(eventArgs).ToMessage());
        }

        [EventSubscription("topic://" + "ToggleAuthViewEventArgs", typeof(OnPublisher))]
        public void ShowAuthViewButton_Click(object sender, ToggleAuthViewEventArgs eventArgs)
        {
            var localArgs = new ShowAuthViewEventArgs
            {
                SenderControlIdentifier = eventArgs.SourceGuid,
                HubViewType = UI.HubView.Type.AuthImage,
                HubViewMethod = HubViewMethodBoolToStringConverter.Convert(!IsAllViewAllocated),
                IsOnAllDisplays = true,
            };

            IsAllocated = !IsAllViewAllocated;
            _showAuthView?.Invoke(this, localArgs);
            NotifyPropertyChanged("ButtonText");
        }
        #endregion

    }
}
