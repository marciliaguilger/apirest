using AutoMapper;
using Dev.IO.Api.ViewModels;
using Dev.IO.Business.Models;

namespace Dev.IO.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap(); //reverse map permite que o de para seja revertido TAMBEM
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
        }

    }
}
