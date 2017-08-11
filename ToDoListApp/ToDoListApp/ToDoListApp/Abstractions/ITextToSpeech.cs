using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApp.Enums;

namespace ToDoListApp.Abstractions
{
    public interface ITextToSpeech
    {
        void Speak(string text);
        Language Language { get; set; }        
    }
}
