using ApiCRUD.Models.Usuario;
using ApiCRUD.Enums;

namespace ApiCRUD.Models.Tarefa
{
    public record TarefaResponseDTO
    (
        
        int Id,
        string? Nome,
        string? Descricao,
        StatusTarefa Status, 
        int? UsuarioId,
        UsuarioModel? Usuario 
    );
    

}