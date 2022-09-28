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
    public class RibbonViewControlViewModel : HubViewModel
    {
        #region Fields
        [field: NonSerialized]
        private EventHandler<ShowRibbonViewEventArgs> _showRibbonView;
        [field: NonSerialized]
        public readonly BoolToStringConverter HubViewMethodBoolToStringConverter = new BoolToStringConverter("Allocate", "DeAllocate");

        private ICommand _showRibbonViewButton_ClickCommand;
        #endregion

        #region Properties
        public event EventHandler<ShowRibbonViewEventArgs> ShowRibbonView
        {
            add => _showRibbonView += value;
            remove => _showRibbonView -= value;
        }

        public bool IsAllocated { get; set; }
 
        public string ButtonText => HubViewMethodBoolToStringConverter.Convert(!IsAllocated) + " Presentation With Ribbon";

        public ICommand ShowRibbonViewButton_ClickCommand
        {
            get
            {
                return _showRibbonViewButton_ClickCommand ?? (_showRibbonViewButton_ClickCommand = new RelayCommand<RibbonViewControlViewModel>(
                           x =>
                           {
                               ShowRibbonViewButton_SendMsgAndClick(this, new ShowRibbonViewEventArgs
                               {
                                   ViewModel = x,
                                   SenderControlIdentifier = ControlIdentifier,
                                   HubViewType = UI.HubView.Type.Presentation, //change to ribbon
                                   HubViewMethod = HubViewMethodBoolToStringConverter.Convert(!IsAllocated),
                                   IsOnAllDisplays = true,
                               });
                           }));
            }
        }
        #endregion

        public RibbonViewControlViewModel()
        {
            MessagingEventBroker.GlobalEventBroker.Register(this);
            _showRibbonView += PluginConfig.HubViewManager.EventCommandInvoker;
            CommandManager.InvalidateRequerySuggested();
        }


        #region Methods

        public void ShowRibbonViewButton_SendMsgAndClick(object sender, ShowRibbonViewEventArgs eventArgs)
        {
            PluginConfig.RuntimeContext.MessageSender.TrySendMessage(
                new CommandWraper<ShowRibbonViewEventArgs>(eventArgs).ToMessage());
            ShowRibbonViewButton_Click(sender, eventArgs);
        }

        [EventSubscription("topic://" + "ShowRibbonViewEventArgs", typeof(OnUserInterface))]
        public void ShowRibbonViewButton_Click(object sender, ShowRibbonViewEventArgs eventArgs)
        {
            _showRibbonView?.Invoke(this, eventArgs);
        }



        #endregion

    }
}
