namespace MRSDataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MovieRepository
    {
        MRSDataAccess.Entity.MovieRentalSystemEntities myDBContext;
        public IEnumerable<Entity.MovieInformation> GetAllMovies()
        {
           
            myDBContext = new Entity.MovieRentalSystemEntities();
            IEnumerable<Entity.MovieInformation> Movies = myDBContext.MovieInformations.OrderBy(u => u.MovieName);
            return Movies;
        }

        public int DeleteMovie(int mid)
        {
            myDBContext = new Entity.MovieRentalSystemEntities();
            int status=myDBContext.DeleteMovieByID(mid);
            return status;
        }

        public IEnumerable<Entity.Language> GetAllLanguages()
        {

            myDBContext = new Entity.MovieRentalSystemEntities();
            IEnumerable<Entity.Language> languages = myDBContext.Languages.OrderBy(u => u.LanguageName);
            return languages;
        }


        public int DeleteLanguage(int lid)
        {
            myDBContext = new Entity.MovieRentalSystemEntities();
            try
            {
                int status = myDBContext.DeleteLanguageByID(lid);
                return status;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CountMovie(int uid)
        {
            myDBContext= new Entity.MovieRentalSystemEntities();
            var count = new System.Data.Objects.ObjectParameter("count", typeof(int));
            myDBContext.CountMoviePerUser(uid, count);
            int c = (int)count.Value;
            //call stored procedure CountMoviePerUser 
            //return count
            return c;
        }

        public int CheckStock(int mid)
        {
            myDBContext = new Entity.MovieRentalSystemEntities();
            var stock = new System.Data.Objects.ObjectParameter("stock", typeof(int));
            myDBContext.CheckMovieStock(mid, stock);
            int c = (int)stock.Value;
            return c;
        }
        
    }
}
