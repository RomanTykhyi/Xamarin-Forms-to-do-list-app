using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp.Abstractions
{
    public interface IItemAnnouncementService
    {
        void AnnounceItemInEngish(string title, string notes, bool done);
        void AnnounceItemInUkrainian(string title, string notes, bool done);
        void SayItemSavedInEnglish();
        void SayItemSavedInUkrainian();
        void SayItemDeletedInEnglish();
        void SayItemDeletedInUkrainian();
    }
}
