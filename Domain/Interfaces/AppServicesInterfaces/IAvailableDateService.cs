using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.AvailableDateDTOs;

namespace Domain.Interfaces.AppServicesInterfaces
{
    public interface IAvailableDateService
    {
        public Task<AvailableDateDTOSimpleResult> Get(Guid id);
        public Task<IEnumerable<AvailableDateDTOSimpleResult>> GetAll();
        public Task<AvailableDateDTOSimpleResult> GetComplete(Guid id);
        public Task<AvailableDateDTOSimpleResult> Create(AvailableDateDTOCreate date);
        public Task<bool> Delete(Guid id);
    }
}
