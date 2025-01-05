using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ORCL_MINIMAL_.NET.EFCore;
using ORCL_MINIMAL_.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORCL_MINIMAL_.NET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        public ORCLContext _context = new ORCLContext();
        [HttpPost]
        public async Task<bool> PostAsync(CreateCategory input)
        {
            try
            {
                var category = new Category();
                category.Id = Guid.NewGuid();
                category.Name = input.Name;
                await _context.AddAsync(category);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {

#if DEBUG
                throw new Exception(ex.InnerException.Message);
#else
                throw new Exception(ex.Message);
#endif
            }
        }
        [HttpGet]
        public async Task<List<Category>> ListAsync()
        {
            try
            {
                return await _context.Categories.ToListAsync();
            }
            catch (Exception ex)
            {

#if DEBUG
                throw new Exception(ex.InnerException.Message);
#else
                throw new Exception(ex.Message);
#endif
            }
        }

        [HttpDelete]
        public async Task<bool> DeleteByNameAsync(string name)
        {
            try
            {
                var find =  _context.Categories.Where(x=>x.Name == name).FirstOrDefault();
                if (find == null) return false;
                 _context.Categories.Remove(find);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

#if DEBUG
                throw new Exception(ex.InnerException.Message);
#else
                throw new Exception(ex.Message);
#endif
            }
        }

    }
}
