using ApiCRUD.Enums;
using ApiCRUD.Models.Usuario;

namespace ApiCRUD.Models.Tarefa
{
    public record TarefaRequestDTO
    (
        string? Nome,

        string? Descricao,

        StatusTarefa Status, 
        
        int UsuarioId
    );
    
}