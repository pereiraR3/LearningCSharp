using AutoMapper;
using ApiCRUD.Models;
using ApiCRUD.Models.Tarefa;
using ApiCRUD.Models.Usuario;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {

        CreateMap<TarefaModel, TarefaResponseDTO>();
            
        CreateMap<UsuarioModel, UsuarioResponseDTO>();
            
    }
}

