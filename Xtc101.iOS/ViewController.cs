using System;

using UIKit;
using GalaSoft.MvvmLight.Helpers;
using Xtc101.Core.ViewModels;

namespace Xtc101.iOS
{
	public partial class ViewController : UIViewController
	{
		private Binding<string, string> _textLabelBinding;
		private Binding _textFieldBinding;

		private MainViewModel Vm => Application.Locator.Main;

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			HideKeyboardHandling ();
			_textLabelBinding = this.SetBinding (
				() => Vm.PreviousMessage,
				() => SubmittedMessage.Text);

			_textFieldBinding = this.SetBinding (
				() => MessageText.Text)
				.UpdateSourceTrigger ("EditingDidEnd")
				.WhenSourceChanges (() => Vm.Message = MessageText.Text);

			SubmitMessage.SetCommand("TouchUpInside", Vm.MessageCommand);
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		void HideKeyboardHandling ()
		{
			MessageText.ShouldReturn = textField => {
				textField.ResignFirstResponder ();
				return true;
			};
			var g = new UITapGestureRecognizer (() => View.EndEditing (true));
			g.CancelsTouchesInView = false;
			//for iOS5
			View.AddGestureRecognizer (g);
		}
	}
}

