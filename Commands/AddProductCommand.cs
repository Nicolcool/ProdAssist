using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ProdAssist.Models;
using ProdAssist.ViewModels;

namespace ProdAssist.Commands
{
    public class AddProductCommand : AsyncCommandBase
    {
        private readonly ProductsListingViewModel _productsListingViewModel;
        private readonly BDD _bdd;

        public AddProductCommand(ProductsListingViewModel productsListingViewModel,BDD bdd)
        {
            _productsListingViewModel = productsListingViewModel;
            _bdd = bdd;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            Product product = new Product(
                _productsListingViewModel.Group,
                _productsListingViewModel.SKU,
                _productsListingViewModel.Categorie,
                _productsListingViewModel.Name,
                _productsListingViewModel.Sheet,
                _productsListingViewModel.Active);

            try
            {
                await _bdd.AddProduct(product);
                MessageBox.Show("Produit ajouté !", "Succés", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Impossible d'ajouter le produit.", "Échec", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
