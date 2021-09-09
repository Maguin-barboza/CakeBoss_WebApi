using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


using CakeBoss.WebApi.Data;
using CakeBoss.WebApi.Models;
using CakeBoss.WebApi.DTOs;

namespace CakeBoss.WebApi.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    public class KitController: ControllerBase
    {
		private readonly CakeBossContext _context;

		public KitController(CakeBossContext context)
        {
            _context = context;
            
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            IQueryable<Kit> Query = _context.Tbl_Kits.AsQueryable();
            List<Kit> kits = await Query.ToListAsync();

            return Ok(kits);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById(int Id)
        {
            IQueryable<Kit> Query = _context.Tbl_Kits.AsQueryable();
            Kit kit = await Query.Where(k => k.Id == Id)
                                 .Include(k => k.ProdutosKit)
                                 .ThenInclude(pk => pk.Produto)
                                 .ThenInclude(p => p.Imgens)
                                 .FirstOrDefaultAsync();
            
            return Ok(kit);
        }

        [HttpPost]
        public ActionResult Post(Kit kit)
        {
            _context.Add(kit);
            
            if(_context.SaveChanges() > 0)
                return Ok(kit);
            
            return BadRequest("Não foi possível incluir kit.");
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult> Put(int Id, Kit kit)
        {
            IQueryable<Kit> Query = _context.Tbl_Kits.AsQueryable();
            Kit kitAux = await Query.AsNoTracking().FirstOrDefaultAsync(p => p.Id == Id);
            
            if(kitAux is null)
                return BadRequest("Não foi possível encontrar kit.");
            
            _context.Update(kit);

            if(_context.SaveChanges() > 0)
                return Ok(kit);
            
            return BadRequest("Não foi possível alterar kit.");
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            IQueryable<Kit> Query = _context.Tbl_Kits.AsQueryable();
            Kit kit = await Query.FirstOrDefaultAsync(k => k.Id == Id);
            
            _context.Remove(kit);

            if(await _context.SaveChangesAsync() > 0)
                return Ok($"Kit {kit.Descricao} excluído com sucesso.");
            
            return BadRequest("Não foi possível concluir a exclusão do kit.");
        }
    }
}