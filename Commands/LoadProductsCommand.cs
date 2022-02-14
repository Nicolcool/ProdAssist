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
    public class LoadProductsCommand : AsyncCommandBase
    {
        private readonly BDD _bdd;
        private readonly ProductsListingViewModel _viewModel;

        public LoadProductsCommand(ProductsListingViewModel viewModel, BDD bdd)
        {
            _viewModel = viewModel;
            _bdd = bdd;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                IEnumerable<Product> products = await _bdd.GetAllProducts();
                _viewModel.UpdateProducts(products);
            }
            catch (Exception)
            {
                MessageBox.Show("Impossible de charger les produits.", "Échec", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
