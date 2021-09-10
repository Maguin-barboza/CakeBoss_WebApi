using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

using CakeBoss.WebApi.Data;
using CakeBoss.WebApi.Models;
using CakeBoss.WebApi.DTOs;


namespace CakeBoss.WebApi.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    public class ImagemController: ControllerBase
    {
		private readonly CakeBossContext _context;
		private readonly IMapper _mapper;

		public ImagemController(CakeBossContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            IQueryable<Imagem> Query = _context.Tbl_Imagens.AsQueryable();
            List<Imagem> imagens = await Query.ToListAsync();

            return Ok(_mapper.Map<List<ImagemDTO>>(imagens));
        }

        [HttpGet("byId/{Id}")]
        public async Task<ActionResult> GetById(int Id)
        {
            IQueryable<Imagem> Query = _context.Tbl_Imagens.AsQueryable();
            Imagem imagem = await Query.FirstOrDefaultAsync(i => i.Id == Id);
            
            return Ok(_mapper.Map<Imagem>(imagem));
        }

        [HttpGet("byProdutoId/{produtoId}")]
        public async Task<ActionResult> GetByProdutoId(int produtoId)
        {
            IQueryable<Imagem> Query = _context.Tbl_Imagens.AsQueryable();
            List<Imagem> imagens = await Query.Where(i => i.ProdutoId == produtoId).ToListAsync();
            
            return Ok(_mapper.Map<List<ImagemDTO>>(imagens));
        }

        [HttpPost]
        public async Task<ActionResult> Post(Imagem imagem)
        {
            await _context.AddAsync(imagem);
            
            if(await _context.SaveChangesAsync() > 0)
                return Ok(imagem);
            
            return BadRequest("Não foi possível incluir a imagem.");
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult> Put(int Id, Imagem imagem)
        {
            IQueryable<Imagem> Query = _context.Tbl_Imagens.AsQueryable();
            Imagem imagemAux = await Query.FirstOrDefaultAsync(i => i.Id == Id);
            
            if(imagemAux is null)
                return BadRequest("Não foi possível encontrar a imagem.");
            
            _context.Update(imagem);

            if(await _context.SaveChangesAsync() > 0)
                return Ok(imagem);
            
            return BadRequest("Não foi possível incluir a imagem.");
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            IQueryable<Imagem> Query = _context.Tbl_Imagens.AsQueryable();
            Imagem imagem = await Query.FirstOrDefaultAsync(i => i.Id == Id);
            
            _context.Remove(imagem);

            if(await _context.SaveChangesAsync() > 0)
                return Ok($"Imagem {imagem.Id} do produto {imagem.Produto.Descricao} excluída com sucesso.");
            
            return BadRequest("Não foi possível concluir a exclusão da imagem.");
        }
    }
}