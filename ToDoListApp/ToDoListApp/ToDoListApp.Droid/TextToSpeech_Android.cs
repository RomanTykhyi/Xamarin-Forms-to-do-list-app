using System.Collections.Generic;
using ToDoListApp.Droid;
using ToDoListApp.Abstractions;
using Android.Speech.Tts;
using Xamarin.Forms;
using Java.Lang;
using Java.Util;
using ToDoListApp.Enums;

[assembly: Dependency(typeof(TextToSpeech_Android))]
namespace ToDoListApp.Droid
{
    public class TextToSpeech_Android : Object, ITextToSpeech, TextToSpeech.IOnInitListener
    {
        #region Properties
        public Language Language
        {
            get { return _language; }
            set
            {
                _language = value;

                if (_speaker == null)
                    _speaker = new TextToSpeech(Forms.Context, this);

                if (_language == Language.English)
                    _speaker.SetLanguage(Locale.Uk);

                else if (_language == Language.Ukrainian)
                    _speaker.SetLanguage(new Locale("UKR"));
            }
        }
        #endregion

        #region Methods        
        public void Speak(string text)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                _toSpeak = text;
                if (_speaker == null)
                {
                    _speaker = new TextToSpeech(Forms.Context, this);
                }
                else
                {
                    var p = new Dictionary<string, string>();
                    _speaker.Speak(_toSpeak, QueueMode.Flush, p);
                }
            }
        }
        #endregion

        #region IOnInitListener implementation
        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {                
                var p = new Dictionary<string, string>();

                if (_language == Language.English)
                    _speaker.SetLanguage(Locale.Uk);

                else if (_language == Language.Ukrainian)
                    _speaker.SetLanguage(new Locale("UKR"));

                _speaker.Speak(_toSpeak, QueueMode.Flush, p);
            }   
        }
        #endregion

        #region Fields
        private Language _language;
        private TextToSpeech _speaker;
        private string _toSpeak;
        #endregion
    }
 }