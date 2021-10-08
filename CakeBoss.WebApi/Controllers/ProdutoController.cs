using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

using CakeBoss.WebApi.Data;
using CakeBoss.WebApi.Models;
using CakeBoss.WebApi.DTOs;
using CakeBoss.WebApi.Helpers;

namespace CakeBoss.WebApi.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController: ControllerBase
    {
		private readonly CakeBossContext _context;
		private readonly IMapper _mapper;

		public ProdutoController(CakeBossContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] PageConfig pageConfig)
        {
            IQueryable<Produto> Query = _context.Tbl_Produtos.AsQueryable();

            if(pageConfig.ByIdProduto is not null)
                Query = Query.Where(p => p.Id == pageConfig.ByIdProduto);
            
            if(pageConfig.byDescProd != string.Empty)
                Query = Query.Where(p => p.Descricao.Contains(pageConfig.byDescProd));
            
            if(pageConfig.PrMin > 0 )
                Query = Query.Where(p => p.Preco >= pageConfig.PrMin);
            
            if(pageConfig.PrMax > 0)
                Query = Query.Where(p => p.Preco <= pageConfig.PrMax);
            

            if(pageConfig.OrderByIdProduto)
                Query = Query.OrderBy(p => p.Id);
            
            if(pageConfig.OrderByDesc)
                Query = Query.OrderBy(p => p.Descricao);
            
            if(pageConfig.OrderByPreco)
                Query = Query.OrderBy(p => p.Preco);
            
            List<Produto> produtos = await Query.Pagination(Response, pageConfig);
            return Ok(_mapper.Map<List<ProdutoDTO>>(produtos));
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById(int Id)
        {
            IQueryable<Produto> Query = _context.Tbl_Produtos.AsQueryable();
            Produto produto = await Query.Where(p => p.Id == Id)
                                         .Include(p => p.Imagens)
                                         .FirstOrDefaultAsync();
            
            return Ok(_mapper.Map<ProdutoDTO>(produto));
        }

        [HttpPost]
        public async Task<ActionResult> Post(Produto produto)
        {
            await _context.AddAsync(produto);
            
            if(await _context.SaveChangesAsync() > 0)
                return Ok(produto);
            
            return BadRequest("Não foi possível incluir produto.");
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult> Put(int Id, Produto produto)
        {
            IQueryable<Produto> Query = _context.Tbl_Produtos.AsQueryable();
            Produto produtoAux = await Query.AsNoTracking().FirstOrDefaultAsync(p => p.Id == Id);
            
            if(produtoAux is null)
                return BadRequest("Não foi possível encontrar produto.");
            
            _context.Update(produto);

            if(await _context.SaveChangesAsync() > 0)
                return Ok(produto);
            
            return BadRequest("Não foi possível incluir produto.");
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            IQueryable<Produto> Query = _context.Tbl_Produtos.AsQueryable();
            Produto produto = await Query.FirstOrDefaultAsync(p => p.Id == Id);
            
            _context.Remove(produto);

            if(await _context.SaveChangesAsync() > 0)
                return Ok($"Produto {produto.Descricao} excluído com sucesso.");
            
            return BadRequest("Não foi possível concluir a exclusão do produto.");
        }
    }
}