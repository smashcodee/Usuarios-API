using AutoMapper;
using Usuarios.Data.Dto;
using Usuarios.Model;

namespace Usuarios.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile() 
        {
            CreateMap<CreateUsuarioDto, Usuario>();
            CreateMap<UpdateUsuarioDto, Usuario>();
            CreateMap<Usuario, ReadUsuarioDto>();
        }
    }
}
