using System.Collections.Generic;
using System.Threading.Tasks;
using Manager.Domain.Entities;

namespace Manager.Infra.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        // Obter o usuário com exatamente o mesmo e-mail passado por parâmetro.
        Task<User> GetByEmail(string email);
        // Faz a busca por e-mails que contém uma sequência específica de caracteres.
        Task<List<User>> SearchByEmail(string email);
        Task<List<User>> SearchByName(string name);
    }
}