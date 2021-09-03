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

        [HttpGet("byId/{Id}")]
        public async Task<ActionResult> GetById(int Id)
        {
            IQueryable<Kit> Query = _context.Tbl_Kits.AsQueryable();
            Kit kit = await Query.FirstOrDefaultAsync(k => k.Id == Id);
            
            return Ok(kit);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Kit kit)
        {
            await _context.AddAsync(kit);
            
            if(await _context.SaveChangesAsync() > 0)
                return Ok(kit);
            
            return BadRequest("Não foi possível incluir kit.");
        }

        [HttpPut("byId/{Id}")]
        public async Task<ActionResult> Put(int Id, Kit kit)
        {
            IQueryable<Kit> Query = _context.Tbl_Kits.AsQueryable();
            Kit kitAux = await Query.FirstOrDefaultAsync(p => p.Id == Id);
            
            if(kitAux is null)
                return BadRequest("Não foi possível encontrar kit.");
            
            _context.Update(kit);

            if(await _context.SaveChangesAsync() > 0)
                return Ok(kit);
            
            return BadRequest("Não foi possível incluir kit.");
        }

        [HttpDelete("byId/{Id}")]
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