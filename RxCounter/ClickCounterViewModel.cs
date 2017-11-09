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
            _IOIntensiveCmd = ReactiveCommand.CreateFromTask(async _ =>
            {
                await Task.Delay(TimeSpan.FromSeconds(1.0));
            });
        }

        readonly ReactiveCommand _IOIntensiveCmd;
        public ReactiveCommand IOIntensiveCmd => this._IOIntensiveCmd;
    }
}
