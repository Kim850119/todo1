using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Numerics;

namespace todo1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        string CnStr = @"Server=LAPTOP-A1U05AHA\SQLEXPRESS;Database=教學資料庫;Trusted_Connection=True;TrustServerCertificate=true;User ID=sa;Password=humx841229";
        [HttpGet]
        public List<Employee> Get()
        {
            using(var conn=new SqlConnection(CnStr))
            {
                conn.Open();
                string sql = "SELECT * FROM Employee";
                List<Employee> EmployeeData = conn.Query<Employee>(sql).ToList();
                return EmployeeData;
            }
        }

        [HttpPost]
        public int Create(Employee parament)
        {
            var sql = @"Insert into Employee
                (
                   [Id], [FirstName], [LastName], [Address], [HomePhone],[CellPhone]
                )
                values
                (
                   @Id,@FirstName,@LastName,@Address,@HomePhone,@CellPhone
                );
            ";

            using (var conn = new SqlConnection(CnStr))
            {
                conn.Open();

                int v = conn.Execute(sql, parament);
                return v;
            }
        }

        [HttpPost]

        public int Update(Employee id)
        {
            var sql = @"update Employee set Id = @Id where HomePhone = @HomePhone";
            using(var conn = new SqlConnection(CnStr))
            {
                conn.Open();

                int update = conn.Execute(sql, id);
                return update;
            }
            
        }


        [HttpPost]

        public int Delete(Employee address)
        {
            var sql = @"delete from Employee where LastName = @LastName";
            using (var conn = new SqlConnection(CnStr))
            {
                conn.Open();

                int delete = conn.Execute(sql, address);
                return delete;
            }

        }



    }

    
}
