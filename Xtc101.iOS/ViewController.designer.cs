// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Xtc101.iOS
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField MessageText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton SubmitMessage { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel SubmittedMessage { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (MessageText != null) {
				MessageText.Dispose ();
				MessageText = null;
			}
			if (SubmitMessage != null) {
				SubmitMessage.Dispose ();
				SubmitMessage = null;
			}
			if (SubmittedMessage != null) {
				SubmittedMessage.Dispose ();
				SubmittedMessage = null;
			}
		}
	}
}
