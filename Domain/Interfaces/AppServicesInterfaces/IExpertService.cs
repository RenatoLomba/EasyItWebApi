using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.ExpertDTOs;

namespace Domain.Interfaces.AppServicesInterfaces
{
    public interface IExpertService
    {
        Task<ExpertDTOSimpleResult> Get(Guid id);
        Task<ExpertDTOCompleteResult> GetComplete(Guid id);
        Task<IEnumerable<ExpertDTOSimpleResult>> GetByLocation(string location);
        Task<IEnumerable<ExpertDTOSimpleResult>> GetAll();
        Task<ExpertDTOSimpleResult> CreateExpert(ExpertDTOCreate expert);
        Task<ExpertDTOSimpleResult> UpdateExpert(ExpertDTOUpdate expert);
        Task<bool> Delete(Guid id);
    }
}
