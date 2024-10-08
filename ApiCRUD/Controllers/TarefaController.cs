using ApiCRUD.Models;
using ApiCRUD.Models.Tarefa;
using ApiCRUD.Repositories.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace ApiCRUD

{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaController(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        /*
        * Método POST -> para criar uma nova tarefa
        */
  
        [HttpPost]
        public async Task<ActionResult<TarefaResponseDTO>> CriaTarefa(TarefaRequestDTO request)
        {
            TarefaResponseDTO result = await _tarefaRepository.Adicionar(request);

            return Ok(result);
        }

        /*
        * Método GET -> para buscar por determinada tarefa
        */

        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaResponseDTO>> BuscaPorId(int id)
        {
            try{

                TarefaResponseDTO result = await _tarefaRepository.BuscarPorId(id);

                return Ok(result);
                
            }catch(Exception e){
                return StatusCode(404, e.Message);
            }
        }

        /*
        * Método GET -> para buscar por todas as tarefas que existem
        */

        [HttpGet]
        public async Task<ActionResult<List<TarefaResponseDTO>>> BuscarTodasTarefas()
        {
            List<TarefaResponseDTO> resultado = await _tarefaRepository.BuscarTodasTarefas();
            return Ok(resultado);
        }

        /*
        * Método PUT -> para alterar determinada tarefa
        */

        [HttpPut("{id}")]
        public async Task<ActionResult<TarefaModel>> AlterarTarefa([FromBody] TarefaModel tarefa, int id)
        {

            tarefa.Id = id;
            TarefaModel tarefaModel = await _tarefaRepository.Atualizar(tarefa, id);

            return Ok(tarefaModel);
        }

        /*
        * Método PUT -> para realizar a deleção relacional de uma tarefa
        */

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> ApagarTarefa(int id)
        {
            bool resultado = await _tarefaRepository.Apagar(id);
            return Ok(resultado);
        }
        
    }
}