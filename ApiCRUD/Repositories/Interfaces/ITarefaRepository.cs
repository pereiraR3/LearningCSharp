using ApiCRUD.Models;
using ApiCRUD.Models.Tarefa;

namespace ApiCRUD.Repositories.Interfaces;

public interface ITarefaRepository
{

    Task<List<TarefaResponseDTO>> BuscarTodasTarefas();
    
    Task<TarefaResponseDTO> BuscarPorId(int id);
    
    Task<TarefaResponseDTO> Adicionar(TarefaRequestDTO request);
    
    Task<TarefaModel> Atualizar(TarefaModel tarefa, int id);
    
    Task<bool> Apagar(int id);

}