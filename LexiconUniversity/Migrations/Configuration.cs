namespace LexiconUniversity.Migrations
{
    using LexiconUniversity.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LexiconUniversity.Models.LexiconUniversityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "LexiconUniversity.Models.LexiconUniversityContext";
        }

        protected override void Seed(Models.LexiconUniversityContext db)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Mi ller" }
            //    );
            //


            var students = new[] {
                new Student { FirstName = "Adam", LastName = "Pherson", Email = "adam@inter.net" },
                new Student { FirstName = "Bo", LastName = "Bosson", Email = "bo@inter.net" },
                new Student { FirstName = "George", LastName = "Gershwing", Email = "george@inter.net" },
                new Student { FirstName = "Juliet", LastName = "Johnson", Email = "juliet@inter.net" },
                new Student { FirstName = "Harold", LastName = "Haroldson", Email = "harold@inter.net" }
            };
            db.Students.AddOrUpdate(s => s.FirstName, students);
            db.SaveChanges();

            
            List<PhoneNumber> numbers = new List<PhoneNumber>();
            foreach (var student in students)
            {
                var random = new Random(student.Id);
                var nr = random.Next(10000000, 99999999).ToString();
                numbers.Add(new PhoneNumber { Number = nr, StudentId = student.Id });
            }
            db.PhoneNumbers.AddOrUpdate(p => p.Number, numbers.ToArray());
        }
    }
}
