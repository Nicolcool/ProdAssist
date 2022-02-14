using System;
using System.Collections.Generic;
using System.Text;

namespace ProdAssist.Models
{
    public class Product
    {
        public int Group { get; }
        public int SKU { get; }
        public string Categorie { get; }
        public string Name { get; }
        public string Sheet { get; }
        public bool Active { get; }

        public Product(int group, int sku, string categorie, string name, string sheet, bool active)
        {
            Group = group;
            SKU = sku;
            Categorie = categorie;
            Name = name;
            Sheet = sheet;
            Active = active;
        }
    }
}
