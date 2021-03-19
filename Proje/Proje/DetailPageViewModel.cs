using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Proje
{
    public class DetailPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DetailPageViewModel(string note)
        {
            DismissPageCommand = new Command(async() =>
            {
                await Application.Current.MainPage.Navigation.PopModalAsync();   
            });
            NoteText = note;
        }

        string noteText;
        public string NoteText
        {
            get => noteText;
            set
            {
                noteText = value;
                var args = new PropertyChangedEventArgs(nameof(NoteText));
                PropertyChanged?.Invoke(this, args);
            }
        }
        public Command DismissPageCommand { get; }

        
    }
}
