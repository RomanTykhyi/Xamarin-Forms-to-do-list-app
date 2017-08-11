using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp.Abstractions
{
    public interface IVoiceRecognitionService
    {
        Task<string> WaitForSpeechToText();
    }
}
