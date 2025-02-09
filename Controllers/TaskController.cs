using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {

        private readonly ITaskRepositorio _taskRepoitorio;
        public TaskController(ITaskRepositorio userRepositorio)
        {
            _taskRepoitorio = userRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> GetAllTasks()
        {
            List<TaskModel>tasks = await _taskRepoitorio.GetAllTaks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<UserModel>>> GetTasById(int id)
        {
            TaskModel task = await _taskRepoitorio.GetTaskById(id);
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> Cadastrar([FromBody] TaskModel taskModel)
        {
            TaskModel task = await _taskRepoitorio.AddTask(taskModel);

            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskModel>> Atualizar([FromBody] TaskModel taskModel, int id)
        {
            taskModel.Id = id;
            TaskModel tasks = await _taskRepoitorio.UpdateTask(taskModel, id);

            return Ok(tasks);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskModel>> Apagar(int id)
        {
            bool apagado = await _taskRepoitorio.DeleteTask(id);

            return Ok(apagado);
        }
    }
}
