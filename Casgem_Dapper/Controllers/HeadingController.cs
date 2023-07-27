using Casgem_Dapper.DAL.Entities;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Casgem_Dapper.Controllers
{
    public class HeadingController : Controller
    {
        private readonly string _connectionString = "Server=BURAK\\SQLEXPRESS;initial Catalog=CasgemDbDapper;integrated Security=true";

        public async Task<IActionResult> Index()
        {
            await using var connection = new SqlConnection(_connectionString);
            var values = await connection.QueryAsync<Headings>("Select * From Heading");
            return View(values);
        }
   
        [HttpGet]
        public async Task<IActionResult> AddHeading()
        {
            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> AddHeading(Headings headings)
        {
            await using var connection = new SqlConnection(_connectionString);
            var query = $"INSERT INTO Heading(HeadingName,HeadingStatus) Values ('{headings.HeadingName}','True')";
            await connection.QueryAsync(query);
            return RedirectToAction("Index");
        }
        [HttpGet]

        public async Task<IActionResult> UpdateHeading(int id)
        {
            await using var connection = new SqlConnection(_connectionString);

            var values = await connection.QueryFirstAsync<Headings>($"Select * From Heading Where HeadingID='{id}'");

            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateHeading(Headings headings)
        {
            await using var connection = new SqlConnection(_connectionString);
            var query = $"Update Heading set HeadingName=('{headings.HeadingName}' where HeadingID=,'True')";
            await connection.QueryAsync(query);
            return RedirectToAction("Index");
        }
    }
}