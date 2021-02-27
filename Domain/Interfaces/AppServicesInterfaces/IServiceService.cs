using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.ServiceDTOs;

namespace Domain.Interfaces.AppServicesInterfaces
{
    public interface IServiceService
    {
        Task<ServiceDTOSimpleResult> Get(Guid id);
        Task<ServiceDTOCompleteResult> GetCompleteById(Guid id);
        Task<ServiceDTOSimpleResult> GetByCode(string codigo);
        Task<IEnumerable<ServiceDTOSearchResult>> GetByName(string name, int qtd, string order);
        Task<IEnumerable<ServiceDTOSimpleResult>> GetAll();
        Task<ServiceDTOSimpleResult> Post(ServiceDTOCreate service);
        //Task<MunicipioDTO> Put(MunicipioDTOEntry municipio);
        Task<bool> Delete(Guid id);
    }
}
