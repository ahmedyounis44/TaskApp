using Microsoft.EntityFrameworkCore;
using TaskApp.Data.Context;
using TaskApp.Data.Models;

namespace TaskApp.Data
{
    public class ClasessService
    {
        
        private DataBaseContext DbContext;
        
        public ClasessService(DataBaseContext dbContext)
        {
            this.DbContext = dbContext;
        }
      
        public async Task<List<Classes>> GetListAsync()
        {
            return await DbContext.Classes.ToListAsync();
        }

       
        public async Task<Classes> AddAsync(Classes obj)
        {
            try
            {
                DbContext.Classes.Add(obj);
                await DbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return obj;
        }

       
        public async Task<Classes> UpdateAsync(Classes obj)
        {
            try
            {
                var productExist = DbContext.Classes.FirstOrDefault(p => p.Id == obj.Id);
                if (productExist != null)
                {
                    DbContext.Classes.Update(obj);
                    await DbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return obj;
        }

       
        public async Task DeleteAsync(Classes obj)
        {
            try
            {
                DbContext.Classes.Remove(obj);
                await DbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
       
    }
}