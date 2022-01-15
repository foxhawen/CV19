using System;
using CV19.Infrastructure.Commands.Base;

namespace CV19.Infrastructure.Commands
{
    internal class LambdaCommand : Command
    {
        private readonly Action<object> _Excute;
        private readonly Func<object, bool> _CanExecute;

        public LambdaCommand(Action<object> Excute, Func<Object, bool> CanExecute = null)
        {
            _Excute = Excute ?? throw new ArgumentNullException(nameof(Excute));
            _CanExecute = CanExecute;
        }

        public override bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;

        public override void Execute(object parameter)
        {
            if(!CanExecute(parameter)) return;
            _Excute(parameter);
        }
    }
}
