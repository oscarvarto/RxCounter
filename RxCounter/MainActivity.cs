using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using Android.App;
using Android.OS;
using Android.Widget;
using ReactiveUI;
using System.Reactive.Threading.Tasks;

namespace RxCounter
{
    [Activity(Label = "RxCounter", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : ReactiveActivity<ClickCounterViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            ViewModel = new ClickCounterViewModel();

            this.WireUpControls();

            /* Doesn't do anything
            _count = MyButton.Events()
                .Click
                .Select(_ => Unit.Default)
                .Count()
                .Do(n => Console.WriteLine($"Count {n}"))
                .ToProperty(this, v => v.Count, 0);
            */

            /* Exception: Index expressions are supported only with constants
            this.WhenAnyObservable(v => v.MyButton.Events().Click)
                .Select(_ => Unit.Default).Count()
                .Subscribe(n =>
                {
                    Console.WriteLine($"Inside Subscribe: {n}");
                    ViewModel.ClickCount = n;
                });
            */

            this.OneWayBind(
                this.ViewModel,
                m => m.ClickCount,
                v => v.MyButton.Text,
                n => $"{n} clicks");
        }

        public Button MyButton { get; private set; }

        ObservableAsPropertyHelper<int> _count;
        public int Count => _count.Value;
    }
}

