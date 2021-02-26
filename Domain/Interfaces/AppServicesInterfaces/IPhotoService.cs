using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.PhotoDTOs;

namespace Domain.Interfaces.AppServicesInterfaces
{
    public interface IPhotoService
    {
        public Task<PhotoDTOSimpleResult> Get(Guid id);
        public Task<IEnumerable<PhotoDTOSimpleResult>> GetAll();
        public Task<PhotoDTOSimpleResult> Create(PhotoDTOCreate photo);
        public Task<bool> Delete(Guid id);
    }
}
