using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Manager.Application.Dto;
using Manager.Application.Interfaces;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;

namespace Manager.Application.Services
{
    public class UserServices : IUserApplication
    {

        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserServices(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDTO> Create(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            var newUser = await _userRepository.Create(user);
            return _mapper.Map<UserDTO>(newUser);
        }

        public async Task<UserDTO> Update(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            var updatedUser = await _userRepository.Update(user);
            return _mapper.Map<UserDTO>(updatedUser);
        }

        public async Task Remove(long id)
        {
            await _userRepository.Remove(id);
        }

        public async Task<UserDTO> Get(long id)
        {
            var user = await _userRepository.Get();
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<List<UserDTO>> Get()
        {
            var allUsers = await _userRepository.Get();
            return _mapper.Map<List<UserDTO>>(allUsers);
        }


        public async Task<List<UserDTO>> SearchByEmail(string email)
        {
            var allUsers = await _userRepository.SearchByEmail(email);
            return _mapper.Map<List<UserDTO>>(allUsers);
        }

        public async Task<List<UserDTO>> SearchByName(string name)
        {
            var allUsers = await _userRepository.SearchByEmail(name);
            return _mapper.Map<List<UserDTO>>(allUsers);
        }
        public async Task<UserDTO> GetByEmail(string email)
        {
            var user = await _userRepository.GetByEmail(email);
            return _mapper.Map<UserDTO>(user);
        }

    }
}