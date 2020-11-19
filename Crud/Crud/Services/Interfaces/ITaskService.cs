using System.Collections.Generic;
using Crud.Models;

namespace Crud.Services
{
    public interface ITaskService
    {
        void AddTask(TaskModel task);
        bool DeleteTask(TaskModel task);
        bool UpdateTask(TaskModel task);
        IEnumerable<TaskModel> GetAllTask();
        TaskModel GetTask(int taskId);
    }
}
