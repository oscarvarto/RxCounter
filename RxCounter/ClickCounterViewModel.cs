using ReactiveUI;
using System.Threading.Tasks;
using System;
using System.Reactive;

namespace RxCounter
{
    public class ClickCounterViewModel : ReactiveObject
    {
        public ClickCounterViewModel()
        {

            _IOIntensiveCmd = ReactiveCommand.CreateFromTask(async () =>
            {
                Done = false;
                await Task.Delay(TimeSpan.FromSeconds(1.0));
                Done = true;
            });
        }

        readonly ReactiveCommand<Unit, Unit> _IOIntensiveCmd;
        public ReactiveCommand<Unit, Unit> IOIntensiveCmd => this._IOIntensiveCmd;

        bool _done = true;
        public bool Done
        {
            get { return _done; }
            set { this.RaiseAndSetIfChanged(ref _done, value); }
        }

    }
}
