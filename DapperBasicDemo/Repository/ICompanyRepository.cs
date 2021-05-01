using DapperBasicDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperBasicDemo.Repository
{
    public interface ICompanyRepository
    {
        Company Find(int id);
        List<Company> GetAll();
        Company Add(Company company);
        Company Update(Company company);
        void Remove(int id);

    }
}
