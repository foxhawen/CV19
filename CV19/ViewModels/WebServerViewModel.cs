﻿using System.Windows.Input;
using CV19.Infrastructure.Commands;
using CV19.Services.Interfaces;
using CV19.ViewModels.Base;

namespace CV19.ViewModels
{
    internal class WebServerViewModel : ViewModel
    {
        private readonly IWebServerService _Server;

        #region Enabled

        public bool Enabled
        {
            get => _Server.Enabled;
            set
            {
                _Server.Enabled = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region StartCommand

        private ICommand _StartCommand;

        public ICommand StartCommand => _StartCommand
            ??= new LambdaCommand(OnStartCommandExcuted, CanStartCommandExcute);

        private bool CanStartCommandExcute(object p) => !Enabled;

        private void OnStartCommandExcuted(object p)
        {
            _Server.Start();
            OnPropertyChanged(nameof(Enabled));
        }

        #endregion

        #region StopCommand

        private ICommand _StopCommand;

        public ICommand StopCommand => _StopCommand
            ??= new LambdaCommand(OnStopCommandExcuted, CanStopCommandExcute);

        private bool CanStopCommandExcute(object p) => Enabled;

        private void OnStopCommandExcuted(object p)
        {
            _Server.Stop();
            OnPropertyChanged(nameof(Enabled));
        }

        #endregion

        public WebServerViewModel(IWebServerService Server) => _Server = Server;
        
    }
}