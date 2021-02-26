using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTOs.AvailableDateDTOs;
using Domain.DTOs.AvailableHourDTOs;
using Domain.Entities;
using Domain.Interfaces.AppServicesInterfaces;
using Domain.Interfaces.RepositoryInterfaces;
using Services.Models;

namespace Services.AppServices
{
    public class AvailableDateService : IAvailableDateService
    {
        private readonly IAvailableDateRepository _dateRep;
        private readonly IAvailableHourRepository _hourRep;
        private readonly IMapper _mapper;

        public AvailableDateService(
            IAvailableDateRepository dateRep, 
            IAvailableHourRepository hourRep,
            IMapper mapper)
        {
            _dateRep = dateRep;
            _hourRep = hourRep;
            _mapper = mapper;
        }
        public async Task<AvailableDateDTOSimpleResult> Create(AvailableDateDTOCreate date)
        {
            var dateModel = _mapper.Map<AvailableDateModel>(date);
            var dateResult = _mapper.Map<AvailableDateDTOSimpleResult>(await _dateRep.InsertAsync(_mapper.Map<AvailableDateEntity>(dateModel)));
            if(dateResult != null)
            {
                if(dateResult.Id != Guid.Empty)
                {
                    foreach(var hour in date.AvailableHours)
                    {
                        var hourModel = _mapper.Map<AvailableHourModel>(hour);
                        hourModel.AvailableDateId = dateResult.Id;
                        var hourResult = _mapper.Map<AvailableHourDTOSimpleResult>(await _hourRep.InsertAsync(_mapper.Map<AvailableHourEntity>(hourModel)));
                        dateResult.AvailableHours = dateResult.AvailableHours.Append(hourResult);
                    }
                }
            }
            return dateResult;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _dateRep.DeleteAsync(id);
        }

        public async Task<AvailableDateDTOSimpleResult> Get(Guid id)
        {
            var result = await _dateRep.SelectAsync(id);
            return _mapper.Map<AvailableDateDTOSimpleResult>(result);
        }

        public async Task<IEnumerable<AvailableDateDTOSimpleResult>> GetAll()
        {
            var result = await _dateRep.SelectAsync();
            return _mapper.Map<IEnumerable<AvailableDateDTOSimpleResult>>(result);
        }

        public async Task<AvailableDateDTOSimpleResult> GetComplete(Guid id)
        {
            var result = await _dateRep.SelectCompleteAsync(id);
            return _mapper.Map<AvailableDateDTOSimpleResult>(result);
        }
    }
}
