using ReactiveUI;
using System.Threading.Tasks;
using System;
using System.Reactive;

namespace RxCounter
{
    public class ClickCounterViewModel : ReactiveObject
    {
        /*
        byte _clickCount = 0;

        public byte ClickCount
        {
            get { return _clickCount; }
            set { this.RaiseAndSetIfChanged(ref _clickCount, value); }
        }


        public ReactiveCommand IncrementClickCount =>
            ReactiveCommand.Create(() => ClickCount++);
        */


        public ClickCounterViewModel()
        {

            _IOIntensiveCmd = ReactiveCommand.CreateFromTask(async _ =>
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
