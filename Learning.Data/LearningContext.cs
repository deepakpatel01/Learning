using Learning.Data.Mappers;
using Learning.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Data
{
    public class LearningContext: DbContext
    {
        public LearningContext(): base("LearningConnection")
        {
        }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StudentMapper());

            base.OnModelCreating(modelBuilder);
        }
    }
}
