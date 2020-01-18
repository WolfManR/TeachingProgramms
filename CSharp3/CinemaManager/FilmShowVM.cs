using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CinemaManager
{
    public class FilmShowVM : INotifyPropertyChanged
    {
        private FilmShow film;
        DataAccess dataAccess;

        public FilmShowVM(FilmShow filmShow, DataAccess dataAccess)
        {
            film = filmShow;
            this.dataAccess = dataAccess;
        }
        public string FilmShowName
        {
            get => film.Name;
            set
            {
                if (film.Name == value) return;
                film.Name = value;
                OnPropertyChanged();
            }
        }
        public DateTime FilmShowStartTime
        {
            get => film.StartTime; 
            set
            {
                if(film.StartTime == value) return;
                film.StartTime = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            dataAccess.UpdateFilmShow(film);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
