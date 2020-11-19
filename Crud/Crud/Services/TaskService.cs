using System.Collections.Generic;
using Crud.Models;
using Crud.Repository;

namespace Crud.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void AddTask(TaskModel task)
        {
            _taskRepository.Add(task);
        }

        public bool DeleteTask(int taskId)
        {
            return _taskRepository.Delete(taskId);
        }

        public IEnumerable<TaskModel> GetAllTask()
        {
            return _taskRepository.GetAllAsync();
        }

        public bool UpdateTask(TaskModel task)
        {
            return _taskRepository.Update(task);
        }

        public TaskModel GetTask(int taskId)
        {
            return _taskRepository.Get(taskId);
        }
    }
}
