using System;
using System.Collections.Generic;
using System.Text;
using ProdAssist.Models;

namespace ProdAssist.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {
        private readonly Product _product;

        public int Group => _product.Group;
        public int SKU => _product.SKU;
        public string Categorie => _product.Categorie;
        public string Name => _product.Name;
        public string Sheet => _product.Sheet;
        public bool Active => _product.Active;

        public ProductViewModel( Product product)
        {
            _product = product;
        }
    }
}
