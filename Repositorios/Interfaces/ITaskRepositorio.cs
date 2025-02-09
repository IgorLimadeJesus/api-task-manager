using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositorios.Interfaces
{
    public interface ITaskRepositorio
    {
        Task<List<TaskModel>> GetAllTaks();
        Task<TaskModel> GetTaskById(int id);
        Task<TaskModel> AddTask(TaskModel user);
        Task<TaskModel> UpdateTask(TaskModel user, int id);
        Task<bool> DeleteTask(int id);
    }
}
