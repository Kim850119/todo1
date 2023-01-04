using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Reflection.Metadata;

namespace todo1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        string cnStr = @"Server=LAPTOP-A1U05AHA\SQLEXPRESS;Database=教學資料庫;Trusted_Connection=True;TrustServerCertificate=true;User ID=sa;Password=humx841229";

        [HttpGet]
        public Customers Get()
        {

            using (var conn = new SqlConnection(cnStr))
            {
                conn.Open();
                string sql = "SELECT * FROM Customers";
                //CustomersData是盒子  Customers是盒子的模型
                //List 盒子
                Customers CustomersData = conn.Query<Customers>(sql).First();
                return CustomersData;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter">巧顆粒</param>
        /// <returns></returns>
        [HttpPost]

        public int Create(Customers parameter)
        {
            var sql =
    @"
                Insert into Customers 
                (
                   [Phone],[CustomerID],[Address],[CompenyName],[City]
                ) 
                values 
                (
                   @Phone,@CustomerID,@Address,@CompenyName,@City
                );
            ";
            using (var conn = new SqlConnection(cnStr))
            {
                conn.Open();

                int Customer = conn.Execute(sql, parameter);
                return Customer;
            }
        }

        [HttpPost]
        public int Update(Customers Address)
        {//紅紅的點點叫中斷點
            using (var conn = new SqlConnection(cnStr))
            {
                conn.Open();

                var sql = @"Update Customers Set Address = @Address WHERE Phone = @Phone";

                int z = conn.Execute(sql, Address);
                return z;
            }
        }

        [HttpPost]
        public int Delete(Customers City)
        {
            using (var conn = new SqlConnection(cnStr))
            {
                conn.Open();
                var sql = @"Delete From Customers WHERE City = @City";

                int a = conn.Execute(sql, City);
                return a;
            }

        }



    }
}
