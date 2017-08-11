using System.Threading.Tasks;

namespace ToDoListApp.Abstractions
{
    public interface ISpeechToText
    {
        Task<string> SpeechToTextAsync();
    }
}
