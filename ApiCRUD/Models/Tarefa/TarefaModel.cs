using ApiCRUD.Enums;
using ApiCRUD.Models.Tarefa;

namespace ApiCRUD.Models;

public class TarefaModel
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Descricao { get; set;}

    public StatusTarefa Status { get; set; }

    public int UsuarioId { get; set; }

    public virtual UsuarioModel? Usuario { get; set; }

    public TarefaModel(){}

    public TarefaModel(TarefaRequestDTO request, UsuarioModel usuario){

        this.Nome = request.Nome;

        this.Descricao = request.Descricao;

        this.Status = request.Status;

        this.UsuarioId = request.UsuarioId;

        this.Usuario = usuario;
        
    }

}