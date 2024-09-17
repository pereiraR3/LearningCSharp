using ApiCRUD.Models;
using ApiCRUD.Models.Usuario;
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

        /*
        * Método POST -> para criar um novo usuario
        */

        [HttpPost]
        public async Task<ActionResult<UsuarioResponseDTO>> AdicionarUsuario(UsuarioRequestDTO request)
        {
            UsuarioResponseDTO novoUsuario = await _usuarioRepository.Adicionar(request);
            return Ok(novoUsuario);
        }

        /*
        * Método GET -> para buscar por todos os usuarios
        */

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
        {
            List<UsuarioModel> usuarios = await _usuarioRepository.BuscarTodosUsuarios();
            return Ok(usuarios);
        }


        /*
        * Método GET -> para buscar por um determinado usuario
        */

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarTodosUsuarios(int id)
        {
            UsuarioModel usuario = await _usuarioRepository.BuscarPorId(id);
            return Ok(usuario);
        }


        /*
        * Método GET -> para buscar todas as tarefas de determinado usuario
        */
        [HttpGet("/tarefasPorUsuario/{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarTodasTarefasPorUsuarioId(int id)
        {
            
            UsuarioModel usuario = await _usuarioRepository.BuscarTarefasPorUsuarioId(id);
            return Ok(usuario);
        }

        /*
        * Método PUT -> para alterar a um determinado usuario 
        */

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> AlterarUsuario([FromBody] UsuarioModel usuario, int id)
        {
            usuario.Id = id;
            UsuarioModel novoUsuario = await _usuarioRepository.Atualizar(usuario, id);
            return Ok(novoUsuario);
        }


        /*
        * Método DELETE -> para realizar a deleção lógica de determinado usuario
        */

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> ApagarUsuario(int id)
        {
            bool resultado = await _usuarioRepository.Apagar(id);
            return Ok(resultado);
        }
        
    }
   
}