﻿using Microsoft.EntityFrameworkCore;
using WebApiToDoApp.Data;
using WebApiToDoApp.Models;
using WebApiToDoApp.ViewModels;

namespace WebApiToDoApp.Services
{
    public interface IToDoService
    {
        Task<IEnumerable<ToDoViewModel>> GetAllAsync();
        Task<ToDoViewModel?> CreateAsync(ToDoViewModel toDo);
        Task<ToDoViewModel?> EditAsync(UpdateToDoViewModel updateToDo);
        Task<ToDoViewModel?> DeleteAsync(int id);
    }

    public class ToDoService : IToDoService
    {
        private readonly AppDbContext _db;

        public ToDoService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ToDoViewModel>> GetAllAsync()
        {
            return await _db.Tasks.AsNoTracking().Select(t => new ToDoViewModel
            {
                Title = t.Title,
                Discription = t.Discription,
                IsCompleted = t.IsCompleted
            }).ToListAsync();
        }

        public async Task<ToDoViewModel?> CreateAsync(ToDoViewModel toDo)
        {
            try
            {
                await _db.Tasks.AddAsync(new ToDo
                {
                    Title = toDo.Title, 
                    Discription = toDo.Discription,
                    IsCompleted = toDo.IsCompleted
                });
                await _db.SaveChangesAsync();

                return toDo;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ToDoViewModel?> EditAsync(UpdateToDoViewModel updateToDo)
        {
            try
            {
                var toDo = await _db.Tasks.FirstOrDefaultAsync(u => u.Id == updateToDo.Id);

                if (toDo == null) return null;

                toDo.Title = updateToDo.Title;
                toDo.Discription = updateToDo.Discription;
                toDo.IsCompleted = updateToDo.IsCompleted;
                await _db.SaveChangesAsync();

                return new ToDoViewModel {
                    Title = toDo.Title,
                    Discription = toDo.Discription,
                    IsCompleted = toDo.IsCompleted
                };
            }
            catch
            {
                return null;
            }
        }

        public async Task<ToDoViewModel?> DeleteAsync(int id)
        {
            try
            {
                var toDo = await _db.Tasks.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);

                if (toDo == null) return null;

                _db.Tasks.Remove(new ToDo() { Id = id });
                await _db.SaveChangesAsync();

                return new ToDoViewModel {
                    Title = toDo.Title,
                    Discription = toDo.Discription,
                    IsCompleted = toDo.IsCompleted
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}