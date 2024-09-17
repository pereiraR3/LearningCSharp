using ApiCRUD.Models.Usuario;
using ApiCRUD.Enums;

namespace ApiCRUD.Models.Tarefa
{
    public record  TarefaResponseDTO
    (
        
         int Id,

         string? Nome,

         string? Descricao,

         StatusTarefa Status,

         int? UsuarioId,

        UsuarioModel? Usuario
        
        // public TarefaResponseDTO(TarefaModel tarefa){
        //     Id = tarefa.Id;
        //     Nome = tarefa.Nome;
        //     Descricao = tarefa.Descricao;
        //     Status = tarefa.Status;
        //     UsuarioId = tarefa.UsuarioId;
        //     Usuario = tarefa.Usuario;  // Associação com o usuário
        // }


    );
    

}