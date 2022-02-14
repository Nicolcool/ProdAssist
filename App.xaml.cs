using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using ProdAssist.DbContexts;
using ProdAssist.Exceptions;
using ProdAssist.Models;
using ProdAssist.Services;
using ProdAssist.Services.ProductConflictValidators;
using ProdAssist.Services.ProductCreator;
using ProdAssist.Stores;
using ProdAssist.ViewModels;

namespace ProdAssist
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private const string CONNECTION_STRING = "Data Source=products.db";
        private readonly BDD _bdd;
        private readonly ProductsDbContextFactory _productsDbContextFactory;

        public App()
        {
            _productsDbContextFactory = new ProductsDbContextFactory(CONNECTION_STRING);
            IProductProvider productProvider = new DatabaseProductProvider(_productsDbContextFactory);
            IProductCreator productCreator = new DatabaseProductCreator(_productsDbContextFactory);
            IProductConflictValidator productConflictValidator = new DatabaseProductConflictValidator(_productsDbContextFactory);

            ProductBook productBook = new ProductBook(productProvider, productCreator, productConflictValidator);
            _bdd = new BDD("Produits", productBook);
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            using (ProductsDbContext dbContext = _productsDbContextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }

            _navigationStore.CurrentViewModel = CreateProductListingViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private ProductsListingViewModel CreateProductListingViewModel()
        {
            return new ProductsListingViewModel(_bdd, new NavigationService(_navigationStore, CreateProductionViewModel));
        }

        private ProductionViewModel CreateProductionViewModel()
        {
            return new ProductionViewModel(new NavigationService(_navigationStore, CreateProductListingViewModel));
        }
    }
}
