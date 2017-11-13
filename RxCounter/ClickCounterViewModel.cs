using System;
using ReactiveUI;
using System.Reactive.Linq;
using System.Reactive;

namespace RxCounter
{
    public class ClickCounterViewModel : ReactiveObject
    {
        public ClickCounterViewModel()
        {
            _setCount = ReactiveCommand.Create<int, Unit>(n =>
            {
                ClickCount = n;
                return Unit.Default;
            });
        }

        ReactiveCommand<int, Unit> _setCount;
        public ReactiveCommand<int, Unit> SetCount => _setCount;

        int _clickCount = 0;
        public int ClickCount
        {
            get { return _clickCount; }
            set { this.RaiseAndSetIfChanged(ref _clickCount, value); }
        }

    }
}
