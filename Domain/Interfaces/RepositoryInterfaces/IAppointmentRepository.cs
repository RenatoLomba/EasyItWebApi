using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.RepositoryInterfaces
{
    public interface IAppointmentRepository : IRepository<AppointmentEntity>
    {
        Task<AppointmentEntity> SelectCompleteAsync(Guid id);
    }
}
