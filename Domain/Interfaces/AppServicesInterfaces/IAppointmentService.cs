using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.AppointmentDTOs;

namespace Domain.Interfaces.AppServicesInterfaces
{
    public interface IAppointmentService
    {
        public Task<AppointmentDTOSimpleResult> Create(AppointmentDTOCreate appointment);
        public Task<AppointmentDTOSimpleResult> GetById(Guid id);
        public Task<IEnumerable<AppointmentDTOSimpleResult>> GetAll();
        public Task<bool> Delete(Guid id);
    }
}
