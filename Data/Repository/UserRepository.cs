using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        private readonly DbSet<UserEntity> _dataset;
        public UserRepository(MyContext context) : base(context)
        {
            _dataset = context.Set<UserEntity>();
        }

        public async Task<UserEntity> SelectAsync(string email)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(u => u.Email.Equals(email));
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserEntity> SelectCompleteAsync(Guid id)
        {
            try
            {
                return await _dataset
                    .Include(u => u.Testimonials)
                    .Include(u => u.Appointments).ThenInclude(a => a.Service)
                    .SingleOrDefaultAsync(u => u.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserEntity> SelectCompleteAsync(string email)
        {
            try
            {
                return await _dataset
                    .Include(u => u.Testimonials)
                    .Include(u => u.Appointments).ThenInclude(a => a.Service).ThenInclude(a => a.Expert)
                    .SingleOrDefaultAsync(u => u.Email.Equals(email));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
