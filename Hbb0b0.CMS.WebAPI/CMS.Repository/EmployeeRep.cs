using CMS.Common;
using CMS.Common.DB;
using CMS.DTO;
using CMS.IRepository;
using CMS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
namespace CMS.Repository
{
    public class EmployeeRep : ReponsitoryBase<EmployeeModel>, IEmployeeRep
    {
        private static object m_sync_Object = new object();
        public EmployeeRep(IDapperContext dapper) : base(dapper)
        {

        }

        public PagedList<EmployeeDTO> Query(QueryCondition<EmployeeQuery> query)
        {

            lock (m_sync_Object)
            {
                PagedList<EmployeeDTO> pagedList = new PagedList<EmployeeDTO>();
                #region sql

                var sql = new StringBuilder("SELECT SQL_CALC_FOUND_ROWS * from employees ");

                #endregion

                sql.AppendLine(" Where 1=1");

                if (!string.IsNullOrEmpty(query.Param.Name))
                {
                    if (query.Param.Name.IndexOf(" ")>0)
                    {
                        var names = query.Param.Name.Split(" ");

                        sql.AppendLine(string.Format(" and (First_Name like '{0}' or last_Name like '{1}')", query.GetLikeValue(names[0]), query.GetLikeValue(names[1])));
                    }
                    else
                    {
                        sql.AppendLine(string.Format(" and (First_Name like '{0}' or last_Name like '{0}')", query.GetLikeValue(query.Param.Name)));
                    }
                }

                if (!string.IsNullOrEmpty(query.Param.Emp_No))
                {
                    sql.AppendLine(string.Format(" and emp_no = @Emp_No"));
                }

                if(!string.IsNullOrEmpty(query.Param.Gender))
                {
                    sql.AppendLine(string.Format(" and gender = @Gender"));
                }

                DateTime? hire_date_start = null;
                DateTime? hire_date_end = null;
                if (query.Param.Hire_Date_Range != null)
                {
                    if (query.Param.Hire_Date_Range[0].HasValue)
                    {
                        hire_date_start = query.Param.Hire_Date_Range[0];
                        sql.AppendLine(string.Format(" and hire_date >= @Hire_Date_Range_Start"));
                    }
                    if (query.Param.Hire_Date_Range[1].HasValue)
                    {
                        hire_date_end = query.Param.Hire_Date_Range[1];
                        sql.AppendLine(string.Format(" and hire_date <= @Hire_Date_Range_End"));
                    }
                }

                DateTime? birth_date_start = null;
                DateTime? birth_date_end = null;
                if (query.Param.Birth_Date_Range != null)
                {
                    if (query.Param.Birth_Date_Range[0].HasValue)
                    {
                        birth_date_start = query.Param.Birth_Date_Range[0];
                        sql.AppendLine(string.Format(" and birth_date >= @Birth_Date_Range_Start"));
                    }
                    if (query.Param.Birth_Date_Range[1].HasValue)
                    {
                        birth_date_end = query.Param.Birth_Date_Range[1];
                        sql.AppendLine(string.Format(" and birth_date <= @Birth_Date_Range_End"));
                    }
                }

                sql.AppendLine(" order by emp_no desc");
                sql.AppendLine($" LIMIT {(query.pageInfo.PageIndex-1) * query.pageInfo.PageSize},{query.pageInfo.PageSize}");
                sql.Append(";");
                var connection = this.GetReadingConnection();
                var result = connection.Query<EmployeeDTO>(sql.ToString(),
                    new
                    {
                        Emp_No = query.Param.Emp_No,
                        Hire_Date_Range_Start= hire_date_start,
                        Hire_Date_Range_End = hire_date_end,
                        Birth_Date_Range_Start = birth_date_start,
                        Birth_Date_Range_End = birth_date_end,
                        Gender = query.Param.Gender

                    }).AsList();
                pagedList.Items = result;
                pagedList.TotalCount = connection.ExecuteScalar<int>("SELECT FOUND_ROWS();");

                return pagedList;
            }
        }
    }
}
