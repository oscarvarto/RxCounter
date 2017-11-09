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

            this.BindCommand(
                ViewModel,
                vm => vm.IOIntensiveCmd,
                ma => ma.MyButton);

            ViewModel
                .IOIntensiveCmd
                .IsExecuting
                .Select(b => b ? "Disabled" : "Enabled")
                .BindTo(MyButton, btn => btn.Text);
        }

        public Button MyButton { get; private set; }
    }
}

