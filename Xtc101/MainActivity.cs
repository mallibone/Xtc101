using Android.App;
using Android.Widget;
using Android.OS;
using GalaSoft.MvvmLight.Helpers;
using Xtc101.Core.ViewModels;

namespace Xtc101.Droid
{
	[Activity(Label = "Xtc101.Droid", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
	    // ReSharper disable NotAccessedField.Local
		private Binding<string, string> _messageBinding;
		private Binding<string, string> _textViewBinding;
	    // ReSharper restore NotAccessedField.Local

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

            _messageBinding = this.SetBinding(() => Vm.Message,() => EditMessage.Text, BindingMode.TwoWay);

			MessageButton.SetCommand("Click", Vm.MessageCommand);

			_textViewBinding = this.SetBinding(() => Vm.PreviousMessage, () => PreviousMessage.Text);

		}

		public MainViewModel Vm => App.Locator.Main;

		public EditText EditMessage => FindViewById<EditText>(Resource.Id.MessageText);
	    public TextView PreviousMessage => FindViewById<TextView>(Resource.Id.SubmittedMessage);
	    public Button MessageButton => FindViewById<Button>(Resource.Id.SubmitMessage);
	}
}


