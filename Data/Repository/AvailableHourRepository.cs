using System;
using System.Collections.Generic;
using System.Text;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class AvailableHourRepository : BaseRepository<AvailableHourEntity>, IAvailableHourRepository
    {
        private readonly DbSet<AvailableHourEntity> _dataSet;

        public AvailableHourRepository(MyContext context) : base(context)
        {
            _dataSet = context.Set<AvailableHourEntity>();
        }
    }
}
