using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LexiconUniversity.Models
{
    public class LexiconUniversityContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public LexiconUniversityContext() : base("name=LexiconUniversityContext")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
    }
}
