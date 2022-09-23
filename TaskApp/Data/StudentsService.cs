using Microsoft.EntityFrameworkCore;
using TaskApp.Data.Context;
using TaskApp.Data.Models;

namespace TaskApp.Data
{
    public class StudentsService
    {
        
        private DataBaseContext DbContext;
        
        public StudentsService(DataBaseContext dbContext)
        {
            this.DbContext = dbContext;
        }
      
        public async Task<List<Students>> GetListAsync()
        {
            return await DbContext.Students.Include(x=>x.ClassData).Include(x=>x.CountryData).ToListAsync();
        }

       
        public async Task<Students> AddAsync(Students obj)
        {
            try
            {
                DbContext.Students.Add(obj);
                await DbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return obj;
        }

       
        public async Task<Students> UpdateAsync(Students obj)
        {
            try
            {
                var productExist = DbContext.Students.FirstOrDefault(p => p.Id == obj.Id);
                if (productExist != null)
                {
                    DbContext.Students.Update(obj);
                    await DbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return obj;
        }

       
        public async Task DeleteAsync(Students obj)
        {
            try
            {
                DbContext.Students.Remove(obj);
                await DbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
       
    }
}