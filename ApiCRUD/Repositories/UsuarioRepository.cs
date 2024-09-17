using ApiCRUD.Data;
using ApiCRUD.Models;
using ApiCRUD.Models.Usuario;
using ApiCRUD.Repositories.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiCRUD.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    
    private readonly ApiCRUDDBContext _dbContext;

    private readonly IMapper _mapper;

    public UsuarioRepository(ApiCRUDDBContext apiCruddbContext, IMapper mapper)
    {
        _dbContext = apiCruddbContext;
        _mapper = mapper;
    }
    

    public async Task<UsuarioResponseDTO> Adicionar(UsuarioRequestDTO request)
    {
        
        UsuarioModel usuario = new UsuarioModel(request);

        await _dbContext.Usuarios.AddAsync(usuario);

        await _dbContext.SaveChangesAsync();

        return _mapper.Map<UsuarioResponseDTO>(usuario);

    }

    public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
    {
        return await _dbContext.Usuarios.ToListAsync();
    }

    public async Task<UsuarioModel> BuscarPorId(int id)
    {
        try
        {
            // Tenta encontrar o usuário com o ID fornecido
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao buscar o usuário: {ex.Message}");
            return null; 
        }
    }

    public async Task<UsuarioModel> BuscarTarefasPorUsuarioId(int id)
    {
        // Buscar o usuário por Id de forma assíncrona
        var usuario = await _dbContext.Usuarios
                                    .Include(x => x.Tarefas) // Incluir a coleção de Tarefas
                                    .FirstOrDefaultAsync(x => x.Id == id);

        if (usuario == null)
        {
            throw new Exception("Usuário não encontrado");
        }

        // Retornar a coleção de tarefas do usuário encontrado
        return usuario;
    }

    public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
    {

        UsuarioModel usuarioModel = await BuscarPorId(id);

        if (usuarioModel == null)
        {
            throw new Exception($"Usuário para o ID: {id} não foi encontrado");
        }
        
        usuarioModel.Nome = usuario.Nome;
        usuarioModel.Email = usuario.Email;
        
        _dbContext.Usuarios.Update(usuarioModel);
        await _dbContext.SaveChangesAsync();
        
        return usuarioModel;
    }

    public async Task<bool> Apagar(int id)
    {
        UsuarioModel usuarioModel = await BuscarPorId(id);

        if (usuarioModel == null)
        {
            throw new Exception($"Usuário para o ID: {id} não foi encontrado");
        }
        
        _dbContext.Usuarios.Remove(usuarioModel);
        await _dbContext.SaveChangesAsync();
        
        return true;
        
    }
}