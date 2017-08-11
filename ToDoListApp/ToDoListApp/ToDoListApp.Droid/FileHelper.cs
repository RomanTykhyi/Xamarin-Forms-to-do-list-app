using System;
using System.IO;
using Xamarin.Forms;
using ToDoListApp.Droid;
using ToDoListApp.Abstractions;

[assembly: Dependency(typeof(FileHelper))]

namespace ToDoListApp.Droid
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}