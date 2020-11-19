using System.Collections.Generic;
using Crud.Models;

namespace Crud.Repository
{
    public interface ITaskRepository
    {
        IEnumerable<TaskModel> GetAllAsync();
        TaskModel Get(int taskId);
        void Add(TaskModel task);
        bool Delete(TaskModel task);
        bool Update(TaskModel task);
    }
}
