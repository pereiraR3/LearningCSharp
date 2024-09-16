using ApiCRUD.Data;
using ApiCRUD.Models;
using ApiCRUD.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiCRUD.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    
    private readonly ApiCRUDDBContext _dbContext;

    public UsuarioRepository(ApiCRUDDBContext apiCruddbContext)
    {
        _dbContext = apiCruddbContext;
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


    public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
    {
        await _dbContext.Usuarios.AddAsync(usuario);
        await _dbContext.SaveChangesAsync();
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