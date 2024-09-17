using ApiCRUD.Models;

namespace ApiCRUD.Models.Usuario
{
    public class UsuarioResponseDTO
    {
        public int Id { get; init; }
        public string? Nome { get; init; }
        public string Email { get; init; }
        public List<TarefaModel> Tarefas { get; init; }

        public UsuarioResponseDTO(UsuarioModel usuario)
        {
            Id = usuario.Id;
            Nome = usuario.Nome;
            Email = usuario.Email;
            Tarefas = usuario.Tarefas.ToList(); 
        }
    }
}
