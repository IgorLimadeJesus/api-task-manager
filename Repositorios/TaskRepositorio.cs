using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Repositorios
{
    public class TaskRepositorio : ITaskRepositorio
    {
        private readonly TaskManagerDBContext _dbContext;

        public TaskRepositorio(TaskManagerDBContext taskManagerDBContext) 
        { 
            _dbContext = taskManagerDBContext;
        }

        public async Task<List<TaskModel>> GetAllTaks()
        {
            return await _dbContext.Tasks.ToListAsync();
        }

        public async Task<TaskModel> GetTaskById(int id)
        {
            return await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TaskModel> AddTask(TaskModel task)
        {
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();

            return task;
        }

        public async Task<TaskModel> UpdateTask(TaskModel task, int id)
        {

            TaskModel TaskById = await GetTaskById(id);

            if (TaskById == null)
            {
                throw new Exception($"Usuario para o ID: {id} Não foi encontrado no Banco de Dados.");
            }

            TaskById.Name = TaskById.Name;
            TaskById.Description = TaskById.Description;
            TaskById.taskStatus = TaskById.taskStatus;
            TaskById.UserId = TaskById.UserId;
          
            _dbContext.Tasks.Update(TaskById);
            await _dbContext.SaveChangesAsync();

            return TaskById;
        }


        public async Task<bool> DeleteTask(int id)
        {
            TaskModel TaskById = await GetTaskById(id);

            if (TaskById == null)
            {
                throw new Exception($"Tarefa para o ID: {id} Não foi encontrado no Banco de Dados.");
            }

            _dbContext.Tasks.Remove(TaskById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
