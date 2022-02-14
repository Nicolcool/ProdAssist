using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using ProdAssist.Commands;
using ProdAssist.Models;
using ProdAssist.Services;
using ProdAssist.Stores;

namespace ProdAssist.ViewModels
{
    public class ProductsListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ProductViewModel> _products;

        public IEnumerable<ProductViewModel> Products => _products;

        public ICommand NavigateCommand { get; }
        public ICommand AddProductCommand { get; }
        public ICommand LoadProductsCommand { get; }
        public ProductsListingViewModel(BDD bdd, NavigationService navigationService)
        {
            _products = new ObservableCollection<ProductViewModel>();
            NavigateCommand = new NavigateCommand(navigationService);
            AddProductCommand = new AddProductCommand(this, bdd);
            LoadProductsCommand = new LoadProductsCommand(this, bdd);
        }

        public static ProductsListingViewModel LoadViewModel(BDD bdd, NavigationService navigationService)
        {
            ProductsListingViewModel viewModel = new ProductsListingViewModel(bdd, navigationService);
            viewModel.LoadProductsCommand.Execute(null);
            return viewModel;
        }

        public void UpdateProducts(IEnumerable<Product> products)
        {
            _products.Clear();
            foreach (Product product in products)
            {
                ProductViewModel productViewModel = new ProductViewModel(product);
                _products.Add(productViewModel);
            }
        }

        private int _group;
        private int _sku;
        private string _categorie;
        private string _name;
        private string _sheet;
        private bool _active;
        public int Group
        {
            get
            {
                return _group;
            }
            set
            {
                _group = value;
                OnPropertyChanged(nameof(Group));
            }
        }
        public int SKU
        {
            get
            {
                return _sku;
            }
            set
            {
                _sku = value;
                OnPropertyChanged(nameof(SKU));
            }
        }
        public string Categorie
        {
            get
            {
                return _categorie;
            }
            set
            {
                _categorie = value;
                OnPropertyChanged(nameof(Categorie));
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Sheet
        {
            get
            {
                return _sheet;
            }
            set
            {
                _sheet = value;
                OnPropertyChanged(nameof(Sheet));
            }
        }
        public bool Active
        {
            get
            {
                return _active;
            }
            set
            {
                _active = value;
                OnPropertyChanged(nameof(Active));
            }
        }
    }
}
