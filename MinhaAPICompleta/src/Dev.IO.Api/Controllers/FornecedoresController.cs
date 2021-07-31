using AutoMapper;
using Dev.IO.Api.ViewModels;
using Dev.IO.Business.Interfaces;
using Dev.IO.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dev.IO.Api.Controllers
{
    [Route("api/[controller]")]
    public  class FornecedoresController : MainController
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;
        private readonly IFornecedorService _fornecedorService;
        public FornecedoresController(IFornecedorRepository fornecedorRepository,
                                        IEnderecoRepository enderecoRepository,
                                        IMapper mapper,
                                        IFornecedorService fornecedorService,
                                        INotificator notificator) : base (notificator)
        {
            _fornecedorRepository = fornecedorRepository;
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
            _fornecedorService = fornecedorService;
        }

        [HttpGet]
        public async Task<IEnumerable<FornecedorViewModel>> ObterTodos()
        {
            var fornecedor = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());
            return fornecedor;
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<FornecedorViewModel>> ObterPorId(Guid id)
        {
            var fornecedor = await ObterFornecedorProdutosEndereco(id);
            if (fornecedor == null) return NotFound();
            return fornecedor;
        }
        
        [HttpGet("obter-endereco/{id:guid}")]
        public async Task<ActionResult<EnderecoViewModel>> ObterEnderecoPorId(Guid id)
        {
            return _mapper.Map<EnderecoViewModel>(await _enderecoRepository.ObterPorId(id));
        }
        
        [HttpPost]
        public async Task<ActionResult<FornecedorViewModel>> Adicionar(FornecedorViewModel fornecedorViewModel)
        {
            //validar os parametros dos data annotations
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _fornecedorService.Adicionar(_mapper.Map<Fornecedor>(fornecedorViewModel));

            return CustomResponse(fornecedorViewModel);
        }
        
        [HttpPut("{id:guid}")]

        //não precisa especificar sem vem from route ou query, o asp net 2.2 entende que vem da rota quando especificado no verbo.
        public async Task<ActionResult<FornecedorViewModel>> Atualizar(Guid id, FornecedorViewModel fornecedorViewModel)
        {
            if (id != fornecedorViewModel.Id)
            {
                NotifyError("Current id is different from original id");
                return CustomResponse(fornecedorViewModel);
            }
            
            //validar os parametros dos data annotations
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _fornecedorService.Atualizar( _mapper.Map<Fornecedor>(fornecedorViewModel));
            return CustomResponse(fornecedorViewModel);
        }
        [HttpPut("atualizar-endereco/{id:guid}")]
        public async Task<ActionResult<EnderecoViewModel>> AtualizarEndereco(Guid id, EnderecoViewModel enderecoViewModel)
        {
            if (id != enderecoViewModel.Id)
            {
                NotifyError("Current id is different from original id");
                return CustomResponse(enderecoViewModel);
            }
            //validar os parametros dos data annotations
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _fornecedorService.Atualizar( _mapper.Map<Fornecedor>(enderecoViewModel));
            return CustomResponse(enderecoViewModel);
        }
        [HttpDelete("{id:guid}")]

        //não precisa especificar sem vem from route ou query, o asp net 2.2 entende que vem da rota quando especificado no verbo.
        public async Task<ActionResult<FornecedorViewModel>> Excluir(Guid id)
        {
            var fornecedorViewModel = await ObterFornecedorEndereco(id);
            if (fornecedorViewModel == null) return NotFound();
            await _fornecedorService.Remover(id);

            return CustomResponse();
        }
        public async Task<FornecedorViewModel> ObterFornecedorProdutosEndereco(Guid id)
        {
            return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorProdutosEndereco(id));
        }
        public async Task<FornecedorViewModel> ObterFornecedorEndereco(Guid id)
        {
            return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorEndereco(id));
        }
    }
}