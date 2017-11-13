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

            // Doesn't do anything
            MyButton.Events()
                .Click
                // .Count() Adding .Count() makes the app to stop working!
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

