using ApiCRUD.Models;
using ApiCRUD.Repositories.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace ApiCRUD

{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
        {
            List<UsuarioModel> usuarios = await _usuarioRepository.BuscarTodosUsuarios();
            return Ok(usuarios);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarTodosUsuarios(int id)
        {
            UsuarioModel usuario = await _usuarioRepository.BuscarPorId(id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> AdicionarUsuario(UsuarioModel usuario)
        {
            UsuarioModel novoUsuario = await _usuarioRepository.Adicionar(usuario);
            return Ok(novoUsuario);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> AdicionarUsuario([FromBody] UsuarioModel usuario, int id)
        {
            usuario.Id = id;
            UsuarioModel novoUsuario = await _usuarioRepository.Adicionar(usuario, id);
            return Ok(novoUsuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> ApagarUsuario(int id)
        {
            bool resultado = await _usuarioRepository.Apagar(id);
            return Ok(resultado);
        }
        
    }
   
}