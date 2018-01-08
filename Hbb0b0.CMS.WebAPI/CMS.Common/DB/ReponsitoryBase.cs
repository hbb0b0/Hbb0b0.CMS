using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using MySql.Data.MySqlClient;

namespace CMS.Common.DB
{
    public abstract class ReponsitoryBase<T> : IRepository<T> where T : class
    {
        private IDbConnection m_Connection;
        public ReponsitoryBase(IDapperContext dapper)
        {
             m_Connection = new MySqlConnection(dapper.GetConnectionString());
        }
        public IDbConnection GetReadingConnection()
        {
            return m_Connection;
        }
        public T Get(object id, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return  m_Connection.Get<T>(id,transaction,commandTimeout);
        }

        public List<T> GetList()
        {
            return m_Connection.GetList<T>().AsList();
        }

        public PagedList<T> GetPagedList(int pageNumber, int rowsPerPage, string conditions, string orderby, out int total, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            var resultList = m_Connection.GetListPaged<T>(pageNumber, rowsPerPage, conditions, orderby, out total, parameters, transaction, commandTimeout);

            PagedList<T> pagedList = new PagedList<T>();

            pagedList.Items = resultList as List<T>;

            pagedList.TotalCount = total;

            return pagedList;
        }
       

    }
}
