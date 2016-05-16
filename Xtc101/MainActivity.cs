﻿using Android.App;
using Android.Widget;
using Android.OS;
using GalaSoft.MvvmLight.Helpers;
using Xtc101.Core.ViewModels;

namespace Xtc101.Droid
{
	[Activity(Label = "MvvmLightBindings.Droid", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		private EditText _editMessage;
		private Button _messageButton;
		private Binding<string, string> _messageBinding;
		private Binding<string, string> _textViewBinding;
		private TextView _previousMessage;

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

		public EditText EditMessage
		{
			get
			{
				return _editMessage
					?? (_editMessage = FindViewById<EditText>(Resource.Id.MessageText));
			}
		}
		public TextView PreviousMessage
		{
			get
			{
				return _previousMessage
					?? (_previousMessage = FindViewById<TextView>(Resource.Id.SubmittedMessage));
			}
		}
		public Button MessageButton
		{
			get
			{
				return _messageButton
					?? (_messageButton = FindViewById<Button>(Resource.Id.SubmitMessage));
			}
		}
	}
}


