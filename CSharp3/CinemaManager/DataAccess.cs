using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManager
{
    public class DataAccess
    {
        CinemaEntitiesContainer context;
        public DataAccess(CinemaEntitiesContainer container)
        {
            context = container;
        }

        public int AddFilmShow(FilmShow filmShow)
        {
            return filmShow.Id;
        }

        public void UpdateFilmShow(FilmShow filmShow)
        {

        }

        public void DeleteFilmShow(FilmShow filmShow)
        {

        }
    }
}
