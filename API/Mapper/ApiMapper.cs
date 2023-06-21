using API.Dtos;
using AutoMapper;
using Dependencias.Model;

namespace API.Mapper
{
    public class ApiMapper : Profile
    {
        public ApiMapper()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductUpdateDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserPostDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
            CreateMap<Carrito, CarritoDto>().ReverseMap();
            CreateMap<Carrito, CarritoPostDto>().ReverseMap();
        }
    }
}
