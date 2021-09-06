using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq; // .Where(x => x.Id == id)
using Manager.Infra.Interfaces;
using Manager.Infra.Context;
// dotnet add .\Manager.Infra.csproj reference ..\Manager.Domain\Manager Domain.csproj (linkar projetos)
using Manager.Domain.Entities;

namespace Manager.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        /*  
         *  Recebe _context via injeção de dependências pela
         *  classe que faz as operações do EntityFramework.
         */
        private readonly ManagerContext _context;

        public BaseRepository(ManagerContext context)
        {
            _context = context;
        }

        /*
         *  Utiliza o _context para adicionar a entidade 
         *  e salva-la.
         *  
         *  obs: Os objetos do EFCore são trackeados. Quando executar o
         *  SaveChangesAsync(), o banco de dados irá gerar o Id e retornar
         *  esse objeto com Id para mim.
         */

        public virtual async Task<T> Create(T obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        /*
         *  .Entry(obj) trackeia o objeto e depois setamos o estado
         *  dele para alterado.
         */
        public virtual async Task<T> Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return obj;
        }

        /*
         *  Primeiro verifica se o objeto existe no banco de dados.
         *  Se existir, remove.
         */
        public virtual async Task Remove(long id)
        {
            var obj = await Get(id);

            if (obj != null)
            {
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
        }

        /*
         *  Seta o objeto (na tabela T), não o tracker.
         *  .AsNoTracking() porque só vai retornar, não precisa trackear (melhora a eficiência).
         *  .Where(x => x.Id == id) onde o Id da tabela do banco for igual ao id passado por parâmetro.
         *  .ToListAsync() faz o SELECT no banco.
         *  .FirstOrDefault() retorna só um elemento.
         */
        public virtual async Task<T> Get(long id)
        {
            var obj = await _context.Set<T>()
                                    .AsNoTracking()
                                    .Where(x => x.Id == id)
                                    .ToListAsync();

            return obj.FirstOrDefault();
        }

        /*
         *  Seta a tabela, sem trackear e faz um
         *  SELECT *.
         */
        public virtual async Task<List<T>> Get()
        {
            return await _context.Set<T>()
                                .AsNoTracking()
                                .ToListAsync();
        }
    }
}