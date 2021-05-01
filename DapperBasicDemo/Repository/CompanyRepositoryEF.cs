using DapperBasicDemo.Data;
using DapperBasicDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperBasicDemo.Repository
{
    public class CompanyRepositoryDapper : ICompanyRepository
    {
        private readonly ApplicationDbContext _db;

        public CompanyRepositoryDapper(ApplicationDbContext db)
        {
            _db = db;
        }

        public Company Add(Company company)
        {
            _db.Companies.Add(company);
            _db.SaveChanges();
            return company;
        }

        public Company Find(int id)
        {
            return _db.Companies.FirstOrDefault(c => c.CompanyId ==id);
        }

        public List<Company> GetAll()
        {
            return _db.Companies.ToList();
        }

        public void Remove(int id)
        {
            Company company = _db.Companies.FirstOrDefault(c => c.CompanyId == id);
            _db.Companies.Remove(company);
            _db.SaveChanges();
            return;
        }

        public Company Update(Company company)
        {
            _db.Companies.Update(company);
            _db.SaveChanges();
            return company;
        }
    }
}
