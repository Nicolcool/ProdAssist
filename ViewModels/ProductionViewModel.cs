using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProdAssist.Commands;
using ProdAssist.Services;
using ProdAssist.Stores;

namespace ProdAssist.ViewModels
{
    public class ProductionViewModel : ViewModelBase
    {
        public ICommand NavigateCommand { get; }
        public ProductionViewModel(NavigationService navigationService)
        {
            NavigateCommand = new NavigateCommand(navigationService);
        }
    }
}
