using System;
using System.Collections.Generic;
using System.Text;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class PhotoRepository : BaseRepository<PhotoEntity>, IPhotoRepository
    {
        private readonly DbSet<PhotoEntity> _dataset;
        public PhotoRepository(MyContext context) : base(context)
        {
            _dataset = context.Set<PhotoEntity>();
        }
    }
}
