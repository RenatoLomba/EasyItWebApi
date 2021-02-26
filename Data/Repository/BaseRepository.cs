using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        //private readonly MyContext _context;
        private readonly DbSet<T> _dataset;
        private readonly IMapper _mapper;
        protected MyContext _context;

        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataset = context.Set<T>();
        }

        public BaseRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(i => i.Id.Equals(id));
                if(result == null)
                {
                    return false;
                } else
                {
                    _dataset.Remove(result);
                    await _context.SaveChangesAsync();
                    return true;
                }
            } catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> InsertAsync(T item)
        {
            try
            {
                item.Id = Guid.NewGuid();
                item.CreateAt = DateTime.UtcNow;
                item.UpdateAt = null;

                _dataset.Add(item);
                await _context.SaveChangesAsync();
            } catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(i => i.Id.Equals(id));
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return await _dataset.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(i => i.Id.Equals(item.Id));
                if (result == null)
                {
                    return null;
                }
                else
                {

                    item = Merge<T>(result, item);
                    item.CreateAt = result.CreateAt;
                    item.UpdateAt = DateTime.UtcNow;

                    _context.Entry(result).CurrentValues.SetValues(item);
                    await _context.SaveChangesAsync();

                    return await _dataset.SingleOrDefaultAsync(i => i.Id.Equals(item.Id));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //MESCLA TODOS OS DADOS E ATRIBUTOS DO OBJETO ORIGEM NO OBJETO DESTINO
        public static T Merge<T>(T target, T source)
        {
            typeof(T)
                .GetProperties()
                .Select((PropertyInfo x) => new KeyValuePair<PropertyInfo, object>(x, x.GetValue(source, null)))
                .Where((KeyValuePair<PropertyInfo, object> x) => x.Value != null).ToList()
                .ForEach((KeyValuePair<PropertyInfo, object> x) => x.Key.SetValue(target, x.Value, null));

            //return the modified copy of Target
            return target;
        }
    }
}
