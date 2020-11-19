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


        /*public IEnumerable<TaskModel> Find<TValue>(Expression<Func<TaskModel, bool>> predicate = null, Expression<Func<TaskModel, TValue>> orderBy = null)
        {
            var query = _dbConnection.Table<TaskModel>();

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = query.OrderBy<TValue>(orderBy);

            return query.Table.();
        }*/

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

        public bool Delete(int taskId)
        {
            bool isDeleted = false;
            try
            {
                _dbConnection.Delete(taskId);
                isDeleted = true;
            }
            catch (Exception ex)
            {

            }

            return isDeleted;
        }
    }
}
