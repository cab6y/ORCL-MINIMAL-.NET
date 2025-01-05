using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORCL_MINIMAL_.NET.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
