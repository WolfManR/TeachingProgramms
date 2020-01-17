using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManager
{
    public class FilmShowVM:INotifyPropertyChanged
    {
        private FilmShow Film;
        public FilmShowVM(FilmShow filmShow)
        {
            Film = filmShow;
        }
        public string FilmShowName 
        { 
            get=>Film.Name; 
            set 
            {
                if (Film.Name == value) return;
                
            }
        }
        public DateTime FilmShowStartTime { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
