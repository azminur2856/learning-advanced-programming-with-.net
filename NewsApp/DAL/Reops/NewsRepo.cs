using DAL.EF;
using DAL.EF.Tables;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace DAL.Reops
{
    internal class NewsRepo : IRepo<News, int, bool>, INewsFeatures
    {
        NEWSContext db;
        public NewsRepo()
        {
            db = new NEWSContext();
        }
        public bool Create(News obj)
        {
            db.News.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var news = Get(id);
            db.News.Remove(news);
            return db.SaveChanges() > 0;
        }

        public List<News> Get()
        {
            return db.News.ToList();
        }

        public News Get(int id)
        {
            return db.News.Find(id);
        }

        public bool Update(News obj)
        {
            var news = Get(obj.Id);
            db.Entry(news).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
        public List<News> GetByCategory(string category)
        {
            var data = (from n in db.News
                        join c in db.Categories on n.Cid equals c.Id
                        where c.Name.ToLower() == category.ToLower()
                        select n).ToList();
            return data;
        }

        public List<News> GetByCategoryAndDate(string category, string date)
        {
            if (!DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                                        DateTimeStyles.None, out DateTime dt))
            {
                return new List<News>();
            }

            DateTime start = dt.Date;
            DateTime end = start.AddDays(1);

            var catLower = (category ?? string.Empty).Trim().ToLower();

            var data = db.News
                         .Include(n => n.Category)
                         .Where(n => n.Date >= start && n.Date < end
                                     && n.Category != null && n.Category.Name.ToLower() == catLower)
                         .ToList();

            return data;
        }


        public List<News> GetByDate(string date)
        {
            DateTime dt;
            if (DateTime.TryParse(date, out dt))
            {
                var data = db.News
                             .Where(n => DbFunctions.TruncateTime(n.Date) == dt.Date)
                             .ToList();
                return data;
            }
            return new List<News>();
        }
    }
}