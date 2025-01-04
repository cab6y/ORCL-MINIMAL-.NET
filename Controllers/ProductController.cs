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
               
                Product product = new Product();
                product.Id = Guid.NewGuid();
                product.Name = input.Name;
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

                return get;
            }
            catch
            {
                return new List<Product>();
            }
        }
    }
}
