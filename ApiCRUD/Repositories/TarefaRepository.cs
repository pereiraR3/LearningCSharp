using ApiCRUD.Data;
using ApiCRUD.Models;
using ApiCRUD.Models.Tarefa;
using ApiCRUD.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace ApiCRUD.Repositories;

public class TarefaRepository : ITarefaRepository
{
    
    private readonly ApiCRUDDBContext _dbContext;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IMapper _mapper;


    public TarefaRepository(ApiCRUDDBContext apiCruddbContext, IUsuarioRepository usuarioRepository, IMapper mapper)
    {
        _dbContext = apiCruddbContext;
        _usuarioRepository = usuarioRepository;
        _mapper = mapper;
    }
    
    public async Task<TarefaResponseDTO> Adicionar(TarefaRequestDTO request)
    {

        UsuarioModel usuario = await _usuarioRepository.BuscarPorId(request.UsuarioId);

        if (usuario == null)
        {
            throw new Exception($"Usuário para o ID: {request.UsuarioId} não foi encontrado");
        }

        TarefaModel tarefa = new TarefaModel(request, usuario);

        await _dbContext.Tarefas.AddAsync(tarefa);

        await _dbContext.SaveChangesAsync();

        return _mapper.Map<TarefaResponseDTO>(tarefa);

    }

    public async Task<List<TarefaResponseDTO>> BuscarTodasTarefas()
    {
        var tarefas =  await _dbContext.Tarefas.ToListAsync();

        return _mapper.Map<List<TarefaResponseDTO>>(tarefas);
    }

    public async Task<TarefaResponseDTO> BuscarPorId(int id)
    {
        try
        {
            var tarefa = await _dbContext.Tarefas
            .Include(x => x.Usuario)
            .FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<TarefaResponseDTO>(tarefa);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao buscar o usuário: {ex.Message}");
            return null; 
        }
    }

    public async Task<TarefaModel> Atualizar(TarefaModel tarefa, int id)
    {

        TarefaModel tarefaModel = _mapper.Map<TarefaModel>(await BuscarPorId(id));

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
        TarefaModel tarefaModel = _mapper.Map<TarefaModel>(await BuscarPorId(id));

        if (tarefaModel == null)
        {
            throw new Exception($"Usuário para o ID: {id} não foi encontrado");
        }
        
        _dbContext.Tarefas.Remove(tarefaModel);
        await _dbContext.SaveChangesAsync();
        
        return true;
        
    }
}