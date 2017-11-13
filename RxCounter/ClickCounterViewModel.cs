using ReactiveUI;

namespace RxCounter
{
    public class ClickCounterViewModel : ReactiveObject
    {

        public ClickCounterViewModel()
        {
            _increaseCount = ReactiveCommand.Create(() => ClickCount++);
        }

        int _clickCount = 0;
        public int ClickCount
        {
            get { return _clickCount; }
            set { this.RaiseAndSetIfChanged(ref _clickCount, value); }
        }

        ReactiveCommand _increaseCount;
        public ReactiveCommand IncreaseCount => _increaseCount;
    }
}
