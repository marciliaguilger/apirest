using Dev.IO.Business.Models;
using System;
using System.Threading.Tasks;

namespace Dev.IO.Business.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId);
    }
}
