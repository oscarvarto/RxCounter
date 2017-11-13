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

            SetContentView(Resource.Layout.Main);

            this.WireUpControls();
            ViewModel = new ClickCounterViewModel();

            MyButton.Events()
                .Click
                .Select(_ => Unit.Default)
                .InvokeCommand(this.ViewModel, vm => vm.IncreaseCount);

            this.OneWayBind(
                this.ViewModel,
                m => m.ClickCount,
                v => v.MyButton.Text,
                n => $"{n} clicks");
        }

        public Button MyButton { get; private set; }
    }
}

