using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Repositorios
{
    public class UserRepositorio : IUserRepositorio
    {
        private readonly TaskManagerDBContext _dbContext;

        public UserRepositorio(TaskManagerDBContext taskManagerDBContext) 
        { 
            _dbContext = taskManagerDBContext;
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> GetUserById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserModel> AddUser(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            
           UserModel userById = await GetUserById(id);

            if (userById == null)
            {
                throw new Exception($"Usuario para o ID: {id} Não foi encontrado no Banco de Dados.");
            }

            userById.Nome = user.Nome;
            userById.Email = user.Email;
          
            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();

            return userById;
        }


        public async Task<bool> DeleteUser(int id)
        {
            UserModel userById = await GetUserById(id);

            if (userById == null)
            {
                throw new Exception($"Usuario para o ID: {id} Não foi encontrado no Banco de Dados.");
            }

            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
