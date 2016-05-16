using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Xtc101.Core.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		private string _message;
		private string _previousMessage;

		public MainViewModel()
		{
			MessageCommand = new RelayCommand(SubmitMessage);
		}

		public RelayCommand MessageCommand { get; private set; }

		private void SubmitMessage()
		{
			PreviousMessage = _message;
		}

		public string PreviousMessage
		{
			get { return _previousMessage; }
			set
			{
				_previousMessage = value;
				RaisePropertyChanged(propertyName: nameof(PreviousMessage));
			}
		}

		public string Message
		{
			get { return _message; }
			set
			{
				_message = value;
				RaisePropertyChanged(propertyName: nameof(Message));
			}
		}
	}}

