using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using Android.App;
using Android.OS;
using Android.Widget;
using ReactiveUI;

namespace RxCounter
{
    [Activity(Label = "RxCounter", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : ReactiveActivity<ClickCounterViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            this.WireUpControls();
            ViewModel = new ClickCounterViewModel();

            MyButton.Events()
                .Click
                .Scan(0, (count, _) => (count + 1) % 10)
                .InvokeCommand(this.ViewModel, vm => vm.SetCount);

            this.OneWayBind(
                this.ViewModel,
                m => m.ClickCount,
                v => v.MyButton.Text,
                n => $"{n} clicks");
        }

        public Button MyButton { get; private set; }
    }
}

