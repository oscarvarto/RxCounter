using ReactiveUI;
using System.Threading.Tasks;
using System;
using System.Reactive;

namespace RxCounter
{
    public class ClickCounterViewModel : ReactiveObject
    {
        int _clickCount = 0;
        public int ClickCount
        {
            get { return _clickCount; }
            set
            {
                Console.WriteLine($"Hello from ClickCount setter: {value}");
                this.RaiseAndSetIfChanged(ref _clickCount, value);
            }
        }
    }
}
