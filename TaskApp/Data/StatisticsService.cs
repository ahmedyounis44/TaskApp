using Microsoft.EntityFrameworkCore;
using TaskApp.Data.Context;
using TaskApp.Data.Models;

namespace TaskApp.Data
{
    public class StatisticsService
    {
        
        private DataBaseContext DbContext;
        
        public StatisticsService(DataBaseContext dbContext)
        {
            this.DbContext = dbContext;
        }
      
        public async Task<List<Studentsperclass>> Studentsperclass()
        {
            return await DbContext.Students.Include(c=>c.ClassData).GroupBy(x=>x.ClassData.Class_Name).Select(x=> new Studentsperclass() {Count= x.Count(),Name=x.Key} ).ToListAsync();
        }

        public async Task<List<Studentspercountry>> Studentspercountry()
        {
            return await DbContext.Students.Include(c => c.CountryData).GroupBy(x => x.CountryData.Name).Select(x => new Studentspercountry() { Count = x.Count(), Name = x.Key }).ToListAsync();
        }


        public async Task<double> StudentsAvargeAge()
        {
            
            return await DbContext.Students.AverageAsync(dt => (DateTime.Now.Year - dt.Date_Of_Birth.Year));
        }

    }
}