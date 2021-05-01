using Dapper;
using DapperBasicDemo.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DapperBasicDemo.Repository
{
    public class CompanyRepositoryDap : ICompanyRepository
    {
        private IDbConnection db;

        public CompanyRepositoryDap(IConfiguration configuration)
        {
            this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public Company Add(Company company)
        {
            var sql = "INSERT INTO Companies (Name, Address, City, State, PostalCode) VALUES(@Name, @Address, @City, @State, @PostalCode);" 
                + "SELECT CAST(SCOPE_IDENTITY() as int)";
            //var id = db.Query<int>(sql, new 
            //                    { @Name=company.Name, 
            //                      @Address=company.Address, 
            //                      @City=company.City, 
            //                      @State = company.State, 
            //                      @PostalCode = company.PostalCode}).Single();
            var id = db.Query<int>(sql, company).Single();
            company.CompanyId = id;
            return company;

        }

        public Company Find(int id)
        {
            var sql = "SELECT * FROM Companies WHERE CompanyId = @CompanyId";
            return db.Query<Company>(sql, new { @CompanyId =id}).Single();
        }

        public List<Company> GetAll()
        {
            var sql = "SELECT * FROM Companies";
            return db.Query<Company>(sql).ToList();
        }

        public void Remove(int id)
        {
            var sql = "DELETE FROM Companies WHERE CompanyId = @Id";
            db.Execute(sql, new { @Id = id });
        }

        public Company Update(Company company)
        {
            var sql = "UPDATE Companies SET Name = @Name, Address = @Address, City= @City, "
                    + "State = @State, PostalCode = @PostalCode WHERE CompanyId = @CompanyId";
            db.Execute(sql, company);
            return company;
        }
    }
}
