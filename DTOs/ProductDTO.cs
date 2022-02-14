using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProdAssist.DTOs
{
    public class ProductDTO
    {
        [Key]
        public Guid Id { get; set; }
        public int Group { get; set; }
        public int SKU { get; set; }
        public string Categorie { get; set; }
        public string Name { get; set; }
        public string Sheet { get; set; }
        public bool Active { get; set; }
    }
}
