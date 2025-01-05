using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using System.Threading.Tasks;
using System;
using ORCL_MINIMAL_.NET.Models;
using ORCL_MINIMAL_.NET.EFCore;
using System.Linq;
using System.Collections.Generic;

namespace ORCL_MINIMAL_.NET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        public ORCLContext _dbcontext = new ORCLContext();
        [HttpPost]
        public async Task<bool> Post(CreateProduct input )
        {
            try
            {
                var getCategory = _dbcontext.Categories.Where(x => x.Name == input.CategoryName).FirstOrDefault();
                if (getCategory == null) return false;
                Product product = new Product();
                product.Id = Guid.NewGuid();
                product.Name = input.Name;
                product.CategoryId = getCategory.Id;
                _dbcontext.Products.Add(product);
                _dbcontext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        [HttpGet]
        public async Task<List<Product>> List()
        {
            try
            {
                var get = _dbcontext.Products.ToList();
                foreach(var item in get)
                {
                    item.Category = _dbcontext.Categories.Where(x => x.Id == item.CategoryId).FirstOrDefault();
                }
                return get;
            }
            catch
            {
                return new List<Product>();
            }
        }
        [HttpDelete]
        public async Task<bool> Delete(string name)
        {
            try
            {
                var get = _dbcontext.Products.Where(x=>x.Name == name).FirstOrDefault();
                _dbcontext.Products.Remove(get);
                _dbcontext.SaveChanges(true);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
