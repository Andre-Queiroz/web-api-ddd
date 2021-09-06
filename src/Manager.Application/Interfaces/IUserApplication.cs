using System.Threading.Tasks;
using Manager.Application.Dto;
using System.Collections.Generic;

namespace Manager.Application.Interfaces
{
    public interface IUserApplication
    {
        Task<UserDTO> Create(UserDTO userDTO);
        Task<UserDTO> Update(UserDTO userDTO);
        Task Remove(long id);
        Task<UserDTO> Get(long id);
        Task<List<UserDTO>> Get();
        Task<List<UserDTO>> SearchByName(string name);
        Task<List<UserDTO>> SearchByEmail(string email);
        Task<UserDTO> GetByEmail(string email);
    }
}