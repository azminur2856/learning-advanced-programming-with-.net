namespace DAL.Migrations
{
    using DAL.EF.Tables;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF.NEWSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.EF.NEWSContext context)
        {
            // Seed Categories first (fixed IDs)
            //var categories = new List<Category>
            //{
            //    new Category { Id = 1, Name = "Science" },
            //    new Category { Id = 2, Name = "International politics" },
            //    new Category { Id = 3, Name = "Crime" },
            //    new Category { Id = 4, Name = "Entertainment" },
            //    new Category { Id = 5, Name = "Sports" }
            //};

            //categories.ForEach(c => context.Categories.AddOrUpdate(x => x.Id, c));
            //context.SaveChanges();

            //// Generate 1000 random news
            //var random = new Random();
            //var newsList = new List<News>();

            //for (int i = 1; i <= 1000; i++)
            //{
            //    var categoryId = random.Next(1, 6); // random between 1 and 5
            //    var title = $"Sample News {i} - {categories[categoryId - 1].Name}";
            //    var date = DateTime.Now.AddDays(-random.Next(0, 365)); // last 1 year

            //    newsList.Add(new News
            //    {
            //        Title = title,
            //        Cid = categoryId,
            //        Date = date
            //    });
            //}

            //newsList.ForEach(n => context.News.AddOrUpdate(x => x.Title, n));
            //context.SaveChanges();

            //base.Seed(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
