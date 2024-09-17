using System.Text.Json.Serialization;
using ApiCRUD.Models.Tarefa;
using ApiCRUD.Models.Usuario;

namespace ApiCRUD.Models;

public class UsuarioModel
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }

    [JsonIgnore]
    public List<TarefaModel> Tarefas { get; set; }

    public UsuarioModel(){}

    public UsuarioModel(UsuarioRequestDTO request){
        this.Nome = request.Nome;
        this.Email = request.Email;
        this.Tarefas = new List<TarefaModel>();
    }


}