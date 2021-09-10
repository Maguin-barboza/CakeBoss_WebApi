using AutoMapper;

using CakeBoss.WebApi.Models;
using CakeBoss.WebApi.DTOs;


namespace CakeBoss.WebApi.Helpers
{
    public class CakeBossProfile: Profile
    {
        public CakeBossProfile()
        {
            CreateMap<Produto, ProdutoDTO>();

            CreateMap<Imagem, ImagemDTO>();

            CreateMap<Kit, KitDTO>();

            CreateMap<ProdutoKit, ProdutoKitDTO>();
        }
    }
}