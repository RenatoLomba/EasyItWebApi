using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTOs.AppointmentDTOs;
using Domain.Entities;
using Domain.Interfaces.AppServicesInterfaces;
using Domain.Interfaces.RepositoryInterfaces;
using Services.Models;

namespace Services.AppServices
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _rep;
        private readonly IMapper _mapper;
        private readonly IAvailableHourRepository _hourRep;

        public AppointmentService(IAppointmentRepository repository, IMapper mapper, IAvailableHourRepository hourRepository)
        {
            _rep = repository;
            _mapper = mapper;
            _hourRep = hourRepository;
        }

        public async Task<AppointmentDTOSimpleResult> Create(AppointmentDTOCreate appointment)
        {
            var model = _mapper.Map<AppointmentModel>(appointment);
            model.Date = new DateTime(appointment.DateInfo.Year, appointment.DateInfo.Month, appointment.DateInfo.Day, appointment.DateInfo.Hour, appointment.DateInfo.Minutes, 0);
            var result = await _rep.InsertAsync(_mapper.Map<AppointmentEntity>(model));
            var deleteHour = result != null ? await _hourRep.DeleteAsync(appointment.DateInfo.AvailableHourId) : false;
            var appointmentCreated = await _rep.SelectCompleteAsync(result.Id);
            return deleteHour ? _mapper.Map<AppointmentDTOSimpleResult>(appointmentCreated) : null;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _rep.DeleteAsync(id);
        }

        public async Task<IEnumerable<AppointmentDTOSimpleResult>> GetAll()
        {
            var result = await _rep.SelectAsync();
            return _mapper.Map<IEnumerable<AppointmentDTOSimpleResult>>(result);
        }

        public async Task<AppointmentDTOSimpleResult> GetById(Guid id)
        {
            var result = await _rep.SelectAsync(id);
            return _mapper.Map<AppointmentDTOSimpleResult>(result);
        }
    }
}
