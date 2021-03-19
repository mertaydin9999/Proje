using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Proje
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public Command SelectedNoteChangedCommand { get; }
        string selectedNote;
        public string SelectedNote
        {
            get => selectedNote;
            set
            {
                selectedNote = value;
                var args = new PropertyChangedEventArgs(nameof(SelectedNote));
                PropertyChanged?.Invoke(this, args);
            }
        }
        public MainPageViewModel()
        {
            Notes = new ObservableCollection<string>();
            SelectedNoteChangedCommand = new Command(async () =>
            {
                var detailVM = new DetailPageViewModel(SelectedNote);
                var detailPage = new DetailPage();
                detailPage.BindingContext = detailVM;
                await Application.Current.MainPage.Navigation.PushModalAsync(detailPage);
            });

            EraseNoteCommand = new Command(() =>
            {
                NoteText = string.Empty;
            });

            SaveNoteCommand = new Command(() =>
            {
                Notes.Add(NoteText);

                NoteText = string.Empty;
            });
        }

        public ObservableCollection<string> Notes { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        string noteText;
        public string NoteText
        {
            get => noteText;
            set
            {
                noteText = value;
                var args = new PropertyChangedEventArgs( nameof(NoteText));
                PropertyChanged?.Invoke(this,args);
            }
        }
        public Command SaveNoteCommand { get; set; }
        public Command EraseNoteCommand { get; }
    }
}
