using DAL.EF;
using DAL.EF.Tables;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Reops
{
    internal class CategoryRepo : IRepo<Category, int, bool>
    {
        NEWSContext db;
        public CategoryRepo()
        {
            db = new NEWSContext();
        }
        public bool Create(Category obj)
        {
            db.Categories.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var category = Get(id);
            db.Categories.Remove(category);
            return db.SaveChanges() > 0;
        }

        public List<Category> Get()
        {
            return db.Categories.ToList();
        }

        public Category Get(int id)
        {
            return db.Categories.Find(id);
        }

        public bool Update(Category obj)
        {
            var category = Get(obj.Id);
            db.Entry(category).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
