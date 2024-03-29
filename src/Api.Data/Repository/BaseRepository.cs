using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api.Data.Context;
using Api.Domain.Interfaces;
using Api.Domain.Entities;

namespace Api.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MyContext _context;
        private DbSet<T> _dataset;
        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }
        public async Task<T> InsertAsync(T item)
        {
            try
            {
                if (item.Id == 0)
                {
                    item.CreatedAt = DateTime.UtcNow;
                    item.UpdatedAt = DateTime.UtcNow;
                    _dataset.Add(item);
                    await _context.SaveChangesAsync();
                }
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
                if (result == null)
                    return false;
                _dataset.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await _dataset.AnyAsync(p => p.Id.Equals(id));
        }

        public async Task<T?> SelectAsync(int id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return await _dataset.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<T?> UpdateAsync(T item)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));
                if (result == null)
                    return null;
                item.UpdatedAt = DateTime.UtcNow;
                item.CreatedAt = result.CreatedAt;
                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
