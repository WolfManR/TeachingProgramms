using System.Collections.Generic;
using System.Data.Entity;

namespace CinemaManager
{
    public class DataAccess
    {
        CinemaEntitiesContainer context;
        public DataAccess(CinemaEntitiesContainer container)
        {
            context = container;
        }

        public IEnumerable<FilmShow> GetFilmShows() => context.FilmShows;
        public IEnumerable<Order> GetOrders() => context.Orders;

        public void AddFilmShow(FilmShow filmShow)
        {
            context.FilmShows.Add(filmShow);
            context.SaveChanges();
        }

        public void UpdateFilmShow(FilmShow filmShow)
        {
            context.FilmShows.Attach(filmShow);
            context.Entry(filmShow).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteFilmShow(FilmShow filmShow)
        {
            if (context.Entry(filmShow).State == EntityState.Detached) context.FilmShows.Attach(filmShow);
            context.FilmShows.Remove(filmShow);
            context.SaveChanges();
        }

        public void AddOrder(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }
    }
}
