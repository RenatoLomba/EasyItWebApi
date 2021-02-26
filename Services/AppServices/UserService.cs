using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTOs.UserDTOs;
using Domain.Entities;
using Domain.Interfaces.AppServicesInterfaces;
using Domain.Interfaces.RepositoryInterfaces;
using Services.Models;

namespace Services.AppServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _userRepository.DeleteAsync(id);
        }

        public async Task<UserDTOSimpleResult> Get(Guid id)
        {
            var result = await _userRepository.SelectAsync(id);
            return _mapper.Map<UserDTOSimpleResult>(result);
        }

        public async Task<IEnumerable<UserDTOSimpleResult>> GetAll()
        {
            var result = await _userRepository.SelectAsync();
            return _mapper.Map<IEnumerable<UserDTOSimpleResult>>(result);
        }

        public async Task<UserDTOCompleteResult> GetComplete(Guid id)
        {
            var result = await _userRepository.SelectCompleteAsync(id);
            return _mapper.Map<UserDTOCompleteResult>(result);
        }

        public async Task<UserDTOSimpleResult> Put(UserDTOUpdate user)
        {
            var model = _mapper.Map<UserModel>(user);
            model.Password = model.Password != null ? BCrypt.Net.BCrypt.HashPassword(model.Password) : null;
            var result = await _userRepository.UpdateAsync(_mapper.Map<UserEntity>(model));
            return _mapper.Map<UserDTOSimpleResult>(result);
        }
    }
}
