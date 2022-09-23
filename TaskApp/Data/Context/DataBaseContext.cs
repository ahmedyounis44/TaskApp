using Microsoft.EntityFrameworkCore;
using TaskApp.Data.Models;

namespace TaskApp.Data.Context
{
    public class DataBaseContext : DbContext
    {
        
        public DataBaseContext(DbContextOptions<DataBaseContext> options): base(options)
        {
        }
       
        public DbSet<Students> Students { get; set; }
        public DbSet<Classes> Classes { get; set; }
        public DbSet<Countries> Countries { get; set; }


        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is BasicData<int>
                            && (x.State == EntityState.Added || x.State == EntityState.Modified));

           
            var dateNow = DateTime.Now;
            foreach (var entry in modifiedEntries)
            {
                if (entry.Entity is BasicData<int> entity)
                {
                    if (entry.State == EntityState.Added)
                    {
                      
                        entity.CreatedDate = entity.ModifiedDate = dateNow;
                    }
                    else
                    {
                      
                        Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                        entity.ModifiedDate = dateNow;
                    }
                }
            }

            return base.SaveChanges();
        }
        

     
        public Task<int> SaveChangesAsync()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is BasicData<int>
                            && (x.State == EntityState.Added || x.State == EntityState.Modified));

            var dateNow = DateTime.Now;
            foreach (var entry in modifiedEntries)
            {
                if (entry.Entity is BasicData<int> entity)
                {
                    if (entry.State == EntityState.Added)
                    {
                       
                        entity.CreatedDate = entity.ModifiedDate = dateNow;
                    }
                    else
                    {
                       
                        Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                       
                        entity.ModifiedDate = dateNow;
                    }
                }
            }

            return base.SaveChangesAsync();
        }

      


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Classes>().HasData(GetClasses());
            modelBuilder.Entity<Countries>().HasData(GetCountrues());
            modelBuilder.Entity<Students>().HasData(GetStudents());
            base.OnModelCreating(modelBuilder);
        }

       

        private List<Classes> GetClasses()
        {
            return new List<Classes>
            {
                new Classes {Id=1, Class_Name = "Class A",CreatedDate=new DateTime(2022,09,23),ModifiedDate=new DateTime(2022,09,23)},
                new Classes {Id=2,  Class_Name = "Class B",CreatedDate=new DateTime(2022,09,23),ModifiedDate=new DateTime(2022,09,23)},
                new Classes {Id=3, Class_Name = "Class C",CreatedDate=new DateTime(2022,09,23),ModifiedDate=new DateTime(2022,09,23)},
              
            };
        }


        private List<Countries> GetCountrues()
        {
            return new List<Countries>
            {
                new Countries {Id=4,  Name = "Oman",CreatedDate=new DateTime(2022,09,23),ModifiedDate=new DateTime(2022,09,23)},
                new Countries {Id=5,  Name = "Egypt",CreatedDate=new DateTime(2022,09,23),ModifiedDate=new DateTime(2022,09,23)},
                new Countries {Id=6, Name = "KSA",CreatedDate=new DateTime(2022,09,23),ModifiedDate=new DateTime(2022,09,23)},

            };
        }

        private List<Students> GetStudents()
        {
            return new List<Students>
            {
                new Students {Id=1,  Name = "Ahmed",Date_Of_Birth= new DateTime(1993,11,13),Class_Id=1,Country_Id=4,Image="1.jpg",CreatedDate=new DateTime(2022,09,23),ModifiedDate=new DateTime(2022,09,23)},
                new Students {Id=2,  Name = "Mohamed",Date_Of_Birth=new DateTime(1980,11,13),Class_Id=2,Country_Id=5,Image="2.jpg",CreatedDate=new DateTime(2022,09,23),ModifiedDate=new DateTime(2022,09,23)},
                new Students {Id=3, Name = "Younis",Date_Of_Birth=new DateTime(1999,11,13),Class_Id=3,Country_Id=6,Image="3.jpg",CreatedDate=new DateTime(2022,09,23),ModifiedDate=new DateTime(2022,09,23)},
                new Students {Id=4, Name = "Sama",Date_Of_Birth=new DateTime(1994,11,13),Class_Id=2,Country_Id=4, Image = "6.jpg",CreatedDate=new DateTime(2022,09,23),ModifiedDate=new DateTime(2022,09,23)},
                new Students {Id=5, Name = "Said",Date_Of_Birth=new DateTime(1988,11,13),Class_Id=1,Country_Id=5, Image = "4.jpg",CreatedDate=new DateTime(2022,09,23),ModifiedDate=new DateTime(2022,09,23)},
                new Students {Id=6, Name = "Ali",Date_Of_Birth=new DateTime(2000,11,13),Class_Id=3,Country_Id=6, Image = "5.jpg",CreatedDate=new DateTime(2022,09,23),ModifiedDate=new DateTime(2022,09,23)},
            };
        }

    }
}
