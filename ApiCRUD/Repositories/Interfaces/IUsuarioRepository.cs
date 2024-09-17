using ApiCRUD.Models;
using ApiCRUD.Models.Usuario;

namespace ApiCRUD.Repositories.Interfaces;

public interface IUsuarioRepository
{

    Task<List<UsuarioModel>> BuscarTodosUsuarios();
    
    Task<UsuarioModel> BuscarPorId(int id);
    
    Task<UsuarioModel> BuscarTarefasPorUsuarioId(int id);

    Task<UsuarioResponseDTO> Adicionar(UsuarioRequestDTO usuario);
    
    Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id);

    Task<bool> Apagar(int id);

}