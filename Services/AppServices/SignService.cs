using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTOs.AppointmentDTOs;
using Domain.DTOs.FavoritesDTOs;
using Domain.DTOs.TestimonialDTOs;
using Domain.DTOs.TokenDTOs;
using Domain.DTOs.UserDTOs;
using Domain.Entities;
using Domain.Interfaces.AppServicesInterfaces;
using Domain.Interfaces.RepositoryInterfaces;
using Domain.Security;
using Microsoft.Extensions.Configuration;
using Services.Models;

namespace Services.AppServices
{
    public class SignService : ISignService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly SigningConfigurations _signConfig;
        private readonly TokenConfigurations _tokenConfig;
        private readonly IConfiguration _config;

        public SignService(IUserRepository userRepository, IMapper mapper, 
            SigningConfigurations signingConfigurations, TokenConfigurations tokenConfigurations, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _signConfig = signingConfigurations;
            _tokenConfig = tokenConfigurations;
            _config = configuration;
        }

        public async Task<object> SignInService(UserDTOLogin login, bool authenticated)
        {
            var user = await _userRepository.SelectCompleteAsync(login.Email);

            if (user == null)
                return null;

            if(!authenticated)
            {
                if (!BCrypt.Net.BCrypt.Verify(login.Password, user.Password))
                {
                    return new TokenDTO
                    {
                        Authenticated = false,
                        Message = "Senha de usuário incorreta"
                    };
                }
            }

            var identity = new ClaimsIdentity(
                new GenericIdentity(user.Email),
                new[]
                {
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.Email)
                }
            );
            DateTime createDate = DateTime.UtcNow;
            DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfig.Seconds);
            var handler = new JwtSecurityTokenHandler();

            string token = CreateToken(identity, createDate, expirationDate, handler);
            var successObject = SuccessObject(user, createDate, expirationDate, token);
            return successObject;
        }

        public async Task<object> SignUpService(UserDTOCreate user)
        {
            var model = _mapper.Map<UserModel>(user);
            model.Role = model.Role ?? "User";
            model.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
            var userResult = await _userRepository.InsertAsync(_mapper.Map<UserEntity>(model));

            if(userResult != null)
            {
                var userRegistered = await _userRepository.SelectCompleteAsync(userResult.Id);

                var identity = new ClaimsIdentity(
                new GenericIdentity(userRegistered.Email),
                new[]
                {
                    new Claim(ClaimTypes.Role, userRegistered.Role),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName, userRegistered.Email)
                }
            );
                DateTime createDate = DateTime.UtcNow;
                DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfig.Seconds);
                var handler = new JwtSecurityTokenHandler();

                string token = CreateToken(identity, createDate, expirationDate, handler);
                var successObject = SuccessObject(userRegistered, createDate, expirationDate, token);
                return successObject;
            } else
            {
                return new TokenDTO
                {
                    Authenticated = false,
                    Message = "Usuário não foi cadastrado"
                };
            }
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate,
            DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Issuer = _tokenConfig.Issuer,
                Audience = _tokenConfig.Audience,
                SigningCredentials = _signConfig.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });
            var token = handler.WriteToken(securityToken);
            return token;
        }

        private UserDTOSignResult SuccessObject(UserEntity user, DateTime createDate,
            DateTime expirationDate, string token)
        {
            return new UserDTOSignResult
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role,
                CreateAt = user.CreateAt,
                UpdateAt = user.UpdateAt,
                Avatar = user.Avatar,
                Appointments = _mapper.Map<IEnumerable<AppointmentDTOSimpleResult>>(user.Appointments),
                Testimonials = _mapper.Map<IEnumerable<TestimonialDTOSimpleResult>>(user.Testimonials),
                Favorites = _mapper.Map<IEnumerable<FavoritesDTOSimpleResult>>(user.Favorites),
                Token = new TokenDTO
                {
                    Authenticated = true,
                    Message = "Usuário autenticado com sucesso",
                    Token = token,
                    Created = createDate,
                    ExpirationDate = expirationDate
                }
            };
        }
    }
}
