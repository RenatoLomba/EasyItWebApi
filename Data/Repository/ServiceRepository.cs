using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class ServiceRepository : BaseRepository<ServiceEntity>, IServiceRepository
    {
        private readonly DbSet<ServiceEntity> _dataset;
        public ServiceRepository(MyContext context) : base(context)
        {
            _dataset = context.Set<ServiceEntity>();
        }

        public async Task<IEnumerable<ServiceEntity>> SearchAsync(string name, int qtd, string order)
        {
            try
            {
                var result = await _dataset
                    .Include(s => s.Expert)
                    .Where(s => EF.Functions.Like(s.Name, string.Format("%{0}%", name)))
                    .Take(qtd)
                    .ToListAsync();
                switch(order)
                {
                    case "name":
                        result = result.OrderBy(s => s.Expert.Name).ToList();
                        break;
                    case "stars":
                        result = result.OrderBy(s => s.Expert.Stars).ToList();
                        break;
                    case "olds":
                        result = result.OrderByDescending(s => s.CreateAt).ToList();
                        break;
                    default:
                        result = result.OrderBy(s => s.CreateAt).ToList();
                        break;
                }
                return result;
            } catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ServiceEntity> SelectAsync(string codigo)
        {
            try
            {
                var result = await _dataset.FirstOrDefaultAsync(s => s.Code.Equals(codigo));
                return result;
            } catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ServiceEntity> SelectComplete(Guid id)
        {
            try
            {
                var result = await _dataset.Include(s => s.Expert).FirstOrDefaultAsync(s => s.Id.Equals(id));
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
