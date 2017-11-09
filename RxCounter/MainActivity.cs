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

            /*
            MyButton.Events()
                    .Click
                    .Select(_ => Unit.Default)
                    .InvokeCommand(ViewModel.IncrementClickCount);

            this.OneWayBind(
                this.ViewModel,
                vm => vm.ClickCount,
                ma => ma.MyButton.Text,
                n => $"{n} clicks"
            );
            */

            MyButton.Events()
                    .Click
                    .Select(_ => Unit.Default)
                    .InvokeCommand(ViewModel.IOIntensiveCmd);

            this.OneWayBind(
                this.ViewModel,
                vm => vm.Done,
                ma => ma.MyButton.Enabled
            );

            this.OneWayBind(
                this.ViewModel,
                vm => vm.Done,
                ma => ma.MyButton.Text,
                b => b ? "Enabled" : "Disabled"
            );

        }

        public Button MyButton { get; private set; }
    }
}

