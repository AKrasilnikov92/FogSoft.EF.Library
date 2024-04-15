using Microsoft.EntityFrameworkCore;
using FogSoft.EF.Library.Entities;
using Task = FogSoft.EF.Library.Entities.Task;

namespace FogSoft.EF.Library
{
    /// <summary>
    /// Предоставляет методы для работы с задачами и пользователями.
    /// </summary>
    class TaskManager
    {
        /// <summary>
        /// Добавлить задачу в БД.
        /// </summary>
        /// <param name="sub">Наименование задачи</param>
        /// <param name="desc">Описание задачи</param>
        public Task AddTask(string sub, string desc)
        {
            using ApplicationContext context = new();
            var task = new Task { Subject = sub, Description = desc };
            context.Tasks.Add(task);
            context.SaveChanges();

            return task;
        }

        /// <summary>
        /// Добавлить пользователя в БД.
        /// </summary>
        /// <param name="name">Имя пользователя</param>
        public User AddUser(string name)
        {
            using ApplicationContext context = new();
            var user = new User { Name = name };
            context.Users.Add(user);
            context.SaveChanges();

            return user;
        }

        /// <summary>
        /// Назначить исполнителя на задачу.
        /// </summary>
        /// <param name="taskId">ID задачи</param>
        /// <param name="userId">ID пользователя</param>
        public Task AssignUser(long taskId, long userId)
        {
            using ApplicationContext context = new();
            var assigneeUser = context.Users.FirstOrDefault(u => u.Id == userId);
            var task = context.Tasks.FirstOrDefault(t => t.Id == taskId);

            if (task != null && assigneeUser != null)
            {
                task.Users?.Add(assigneeUser);
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Task or user not found!");
            }

            return task;
        }

        /// <summary>
        /// Освободить пользователя от задачи.
        /// </summary>
        /// <param name="taskId">Id задачи</param>
        /// <param name="userId">Id пользователя</param>
        /// <exception cref="ArgumentException"></exception>
        public Task UnassigneeUser(long taskId, long userId)
        {
            using ApplicationContext context = new();
            var task = context.Tasks.FirstOrDefault(t => t.Id == taskId);
            var unassigneeUser = context.Users.FirstOrDefault(u => u.Id == userId);

            if (task != null && unassigneeUser != null)
            {
                task.Users?.Remove(unassigneeUser);
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Task or user not found!");
            }

            return task;
        }

        /// <summary>
        /// Удалить пользователя.
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <exception cref="Exception"></exception>
        public void DeleteUser(long userId)
        {
            using ApplicationContext context = new();
            var user = context.Users?.FirstOrDefault(u => u.Id == userId);

            if (user != null)
            {
                context.Remove(user);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("User not found.");
            }
        }

        /// <summary>
        /// Удалить задачу.
        /// </summary>
        /// <param name="taskId">Id задачи</param>
        /// <exception cref="Exception"></exception>
        public void DeleteTask(long taskId)
        {
            using ApplicationContext context = new();
            var task = context.Tasks.FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            {
                context.Remove(task);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Task not found.");
            }

        }

        /// <summary>
        /// Вернуть массив задач.
        /// </summary>
        /// <returns>Возвращает массив задач.</returns>
        public Task[] GetAllTask()
        {
            using ApplicationContext context = new();
            return context.Tasks.ToArray();
        }

        /// <summary>
        /// Вернуть задачи, назначенные на конкретного исполнителя.
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <returns>Возвращает массив задач, назначенных на конкретного пользователя.</returns>
        public Task[] GetByAssignee(long userId)
        {
            using ApplicationContext context = new();
            var users = context.Users.FirstOrDefault(u => u.Id == userId);

            return users.Tasks.ToArray();
        }
    }
}