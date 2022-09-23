using Microsoft.EntityFrameworkCore;
using TaskApp.Data.Context;
using TaskApp.Data.Models;

namespace TaskApp.Data
{
    public class CountriesService
    {
        
        private DataBaseContext DbContext;
        
        public CountriesService(DataBaseContext dbContext)
        {
            this.DbContext = dbContext;
        }
      
        public async Task<List<Countries>> GetListAsync()
        {
            return await DbContext.Countries.ToListAsync();
        }

       
        public async Task<Countries> AddAsync(Countries obj)
        {
            try
            {
                DbContext.Countries.Add(obj);
                await DbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return obj;
        }

       
        public async Task<Countries> UpdateAsync(Countries obj)
        {
            try
            {
                var productExist = DbContext.Countries.FirstOrDefault(p => p.Id == obj.Id);
                if (productExist != null)
                {
                    DbContext.Countries.Update(obj);
                    await DbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return obj;
        }

       
        public async Task DeleteAsync(Countries obj)
        {
            try
            {
                DbContext.Countries.Remove(obj);
                await DbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
       
    }
}