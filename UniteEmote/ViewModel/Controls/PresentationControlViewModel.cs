using System;
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
    public class PresentationControlViewModel : HubViewModel
    {
        #region Fields
        [field: NonSerialized]
        private EventHandler<ShowPresentationViewEventArgs> _showPresentationView;

        [field: NonSerialized]
        public readonly BoolToStringConverter HubViewMethodBoolToStringConverter = new BoolToStringConverter("Allocate", "DeAllocate");

        private ICommand _showPresentationViewButton_ClickCommand;
        #endregion

        #region Properties
        public event EventHandler<ShowPresentationViewEventArgs> ShowPresentationView
        {
            add => _showPresentationView += value;
            remove => _showPresentationView -= value;
        }
        public bool IsAllocated { get; set; }

        public bool IsAllViewAllocated => PluginConfig.HubViewManager.IsAllViewsAllocated(UI.HubView.Type.Presentation);

        public string ButtonText => HubViewMethodBoolToStringConverter.Convert(!IsAllocated) + " Presentation";

        public ICommand ShowPresentationViewButton_ClickCommand
        {
            get
            {
                return _showPresentationViewButton_ClickCommand ?? (_showPresentationViewButton_ClickCommand = new RelayCommand<PresentationControlViewModel>(
                           x =>
                           {
                               ShowPresentationViewButton_SendMsgAndClick(this, new TogglePresentationViewEventArgs { SourceGuid = x.ControlIdentifier });
                           }, x => PluginConfig.HubViewManager.DoAllViewsHaveSameIsAllocated(UI.HubView.Type.AuthImage)));
            }
        }

        #endregion

        public PresentationControlViewModel()
        {
            MessagingEventBroker.GlobalEventBroker.Register(this);
            _showPresentationView += PluginConfig.HubViewManager.EventCommandInvoker;
            CommandManager.InvalidateRequerySuggested();
        }


        #region Methods

        public void ShowPresentationViewButton_SendMsgAndClick(object sender, TogglePresentationViewEventArgs eventArgs)
        {
            PluginConfig.RuntimeContext.MessageSender.TrySendMessage(
                new CommandWraper<TogglePresentationViewEventArgs>(eventArgs).ToMessage());
        }

        [EventSubscription("topic://" + "TogglePresentationViewEventArgs", typeof(OnUserInterface))]
        public void ShowPresentationViewButton_Click(object sender, TogglePresentationViewEventArgs eventArgs)
        {
            var localArgs = new ShowPresentationViewEventArgs
            {
                SenderControlIdentifier = eventArgs.SourceGuid,
                HubViewType = UI.HubView.Type.Presentation,
                HubViewMethod = HubViewMethodBoolToStringConverter.Convert(!IsAllViewAllocated),
                IsOnAllDisplays = true,
            };

            IsAllocated = !IsAllViewAllocated;
            _showPresentationView?.Invoke(this, localArgs);
            NotifyPropertyChanged("ButtonText");
        }



        #endregion

    }
}
