using System;
using System.Collections.Generic;
using Crud.Models;
using Crud.Services.Dependencies;
using SQLite;

namespace Crud.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private SQLiteConnection _dbConnection;

        public TaskRepository(IDbConnection db)
        {
            _dbConnection = db.GetConnection();
            _dbConnection.CreateTable<TaskModel>();
        }

        public IEnumerable<TaskModel> GetAllAsync()
        {
            try
            {
                return _dbConnection.Table<TaskModel>().ToList();
            }
            catch (Exception ex)
            {

            }

            return null;
        }

        public TaskModel Get(int taskId)
        {
            try
            {
                return _dbConnection.Find<TaskModel>(taskId);
            }
            catch (Exception ex)
            {

            }

            return null;
        }

        public bool Update(TaskModel task)
        {
            bool isUpdated = false;
            try
            {
                _dbConnection.Update(task);
                isUpdated = true;
            }
            catch (Exception ex)
            {

            }

            return isUpdated;
        }

        public void Add(TaskModel task)
        {
            try
            {
                _dbConnection.Insert(task);
            }
            catch (Exception ex)
            {

            }
        }

        public bool Delete(TaskModel task)
        {
            bool isDeleted = false;
            try
            {
                _dbConnection.Delete(task);
                isDeleted = true;
            }
            catch (Exception ex)
            {

            }

            return isDeleted;
        }
    }
}
