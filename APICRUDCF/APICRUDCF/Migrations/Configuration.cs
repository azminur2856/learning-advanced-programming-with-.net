namespace APICRUDCF.Migrations
{
    using APICRUDCF.EF.Tables;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<APICRUDCF.EF.UMSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(APICRUDCF.EF.UMSContext context)
        {
            string[] departments = { "Computer Science", "CoE", "EEE", "BBA", "IPE" };
            foreach(var dept in departments)
            {
                context.Departments.AddOrUpdate(
                    d => d.Name,
                    new EF.Tables.Department { Name = dept }
                );
            }

            Random rnd = new Random();
            for (int i = 1; i <= 5000; i++)
            {
                var s = new Student()
                {
                    Name = Guid.NewGuid().ToString().Substring(0, 11),
                    Cgpa = (float)Math.Round(rnd.NextDouble() * 4, 2),
                    DeptId = rnd.Next(1, 6)
                };
                context.Students.AddOrUpdate(
                    st => new { st.Name, st.DeptId },
                    s
                );
            }
            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
