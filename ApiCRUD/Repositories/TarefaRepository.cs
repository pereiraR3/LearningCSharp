using ApiCRUD.Data;
using ApiCRUD.Models;
using ApiCRUD.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiCRUD.Repositories;

public class TarefaRepository : ITarefaRepository
{
    
    private readonly ApiCRUDDBContext _dbContext;

    public TarefaRepository(ApiCRUDDBContext apiCruddbContext)
    {
        _dbContext = apiCruddbContext;
    }
    
    public async Task<TarefaModel> Adicionar(TarefaModel tarefa)
    {
        await _dbContext.Tarefas.AddAsync(tarefa);
        await _dbContext.SaveChangesAsync();
        return tarefa;
    }

    public async Task<List<TarefaModel>> BuscarTodasTarefas()
    {
        return await _dbContext.Tarefas
        .ToListAsync();
    }

    public async Task<TarefaModel> BuscarPorId(int id)
    {
        try
        {
            // Tenta encontrar o usuário com o ID fornecido
            return await _dbContext.Tarefas
            .Include(x => x.Usuario)
            .FirstOrDefaultAsync(x => x.Id == id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao buscar o usuário: {ex.Message}");
            return null; 
        }
    }

    public async Task<TarefaModel> Atualizar(TarefaModel tarefa, int id)
    {

        TarefaModel tarefaModel = await BuscarPorId(id);

        if (tarefaModel == null)
        {
            throw new Exception($"Usuário para o ID: {id} não foi encontrado");
        }
        
        tarefaModel.Nome = tarefa.Nome;
        tarefaModel.Descricao = tarefa.Descricao;
        tarefa.Status = tarefaModel.Status;
        
        _dbContext.Tarefas.Update(tarefaModel);
        await _dbContext.SaveChangesAsync();
        
        return tarefaModel;
    }

    public async Task<bool> Apagar(int id)
    {
        TarefaModel tarefaModel = await BuscarPorId(id);

        if (tarefaModel == null)
        {
            throw new Exception($"Usuário para o ID: {id} não foi encontrado");
        }
        
        _dbContext.Tarefas.Remove(tarefaModel);
        await _dbContext.SaveChangesAsync();
        
        return true;
        
    }
}