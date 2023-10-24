using BlogAnimalApi.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Repository<T> where T : class
    {
        protected readonly BlogAnimalContext context;
        private readonly DbSet<T> dbSet;

        public Repository(BlogAnimalContext _context)
        {
            context = _context;
            dbSet = context.Set<T>();
        }

        public async Task<List<T>> getAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> getOne(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task delOne(int id)
        {
            var delEntity = await dbSet.FindAsync(id);
            if(delEntity != null)
            {
                dbSet.Remove(delEntity);
                await context.SaveChangesAsync();
            }
        }

        public async Task<T> update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> add(T entity)
        {
            await dbSet.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
