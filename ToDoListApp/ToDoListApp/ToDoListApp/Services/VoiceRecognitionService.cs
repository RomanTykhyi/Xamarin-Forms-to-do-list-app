using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApp.Abstractions;
using Xamarin.Forms;

namespace ToDoListApp.Services
{
    public class VoiceRecognitionService : IVoiceRecognitionService
    {
        private ISpeechToText _speechRecognizer;

        public VoiceRecognitionService()
        {
            _speechRecognizer = DependencyService.Get<ISpeechToText>();
        }

        public async Task<string> WaitForSpeechToText()
        {
            return await _speechRecognizer.SpeechToTextAsync();
        }
    }
}
