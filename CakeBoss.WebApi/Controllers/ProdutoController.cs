using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using CakeBoss.WebApi.Data;
using CakeBoss.WebApi.Models;

namespace CakeBoss.WebApi.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController: ControllerBase
    {
		private readonly CakeBossContext _context;

		public ProdutoController(CakeBossContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            IQueryable<Produto> Query = _context.Tbl_Produtos.AsQueryable();
            List<Produto> Produtos = await Query.ToListAsync();

            return Ok(Produtos);
        }

        [HttpGet("byId/{Id}")]
        public async Task<ActionResult> GetById(int Id)
        {
            IQueryable<Produto> Query = _context.Tbl_Produtos.AsQueryable();
            Produto Produto = await Query.FirstOrDefaultAsync(p => p.Id == Id);
            
            return Ok(Produto);
        }

        [HttpGet("byKitId/{kitId}")]
        public async Task<ActionResult> GetByKitId(int kitId)
        {
            IQueryable<Produto> Query = _context.Tbl_Produtos.AsQueryable();
            List<Produto> Produtos = await Query.Where(p => p.KitId == kitId).ToListAsync();
            
            return Ok(Produtos);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Produto produto)
        {
            await _context.AddAsync(produto);
            
            if(await _context.SaveChangesAsync() > 0)
                return Ok(produto);
            
            return BadRequest("Não foi possível incluir produto.");
        }

        [HttpPut("byId/{Id}")]
        public async Task<ActionResult> Put(int Id, Produto produto)
        {
            IQueryable<Produto> Query = _context.Tbl_Produtos.AsQueryable();
            Produto produtoAux = await Query.FirstOrDefaultAsync(p => p.Id == Id);
            
            if(produtoAux is null)
                return BadRequest("Não foi possível encontrar produto.");
            
            _context.Update(produto);

            if(await _context.SaveChangesAsync() > 0)
                return Ok(produto);
            
            return BadRequest("Não foi possível incluir produto.");
        }

        [HttpDelete("byId/{Id}")]
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