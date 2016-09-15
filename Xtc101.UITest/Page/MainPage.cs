using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;

namespace Xtc101.UITest.Page
{
    public class MainPage
    {
        private string _text;
        private string _message;
        private readonly IApp _app;

        public MainPage(IApp app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));
            _app = app;
        }

        public string Text
        {
            get
            {
                _text = _app.Query(c => c.Marked("MessageText")).First().Text;
                return _text;
            }
            set
            {
                _app.EnterText(c => c.Marked("MessageText"), value);
                _text = value;
            }
        }

        public string Message
        {
            get
            {
               _message = _app.Query(c => c.Marked("SubmittedMessage")).First().Text;
                return _message;
            }
        }

        public void SendMessage()
        {
            _app.Tap(c => c.Marked("SubmitMessage"));
        }
    }
}
