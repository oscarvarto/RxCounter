using ReactiveUI;
using System;
using System.Reactive.Linq;

namespace RxCounter
{
    public class ClickCounterViewModel : ReactiveObject
    {
        public ClickCounterViewModel(IObservable<EventArgs> clickObs)
        {
             _clickCount = clickObs
                .Scan(0, (count, _) => count + 1)
                .ToProperty(this, vm => vm.ClickCount);
        }

        ObservableAsPropertyHelper<int> _clickCount;
        public int ClickCount => _clickCount.Value;
    }
}
