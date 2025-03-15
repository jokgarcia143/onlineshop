using Android.Webkit;
using OnlineShop.App.MVVM.Views.Product;
using OnlineShop.App.Services.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnlineShop.App.MVVM.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        //Define Properties
        private ObservableCollection<ProductsDTO> _products;
        public ObservableCollection<ProductsDTO> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }
        private bool _isLoaded = false;
        public bool IsLoaded
        {
            get => _isLoaded;
            set => SetProperty(ref _isLoaded, value);
        }
        //Define Commands
        public ICommand AllProductsCommand { get; set; }
        //Define Constructor
        public HomeViewModel()
        {
            AllProductsCommand = new Command<object>(AllProducts);
        }

        //Define Methods
        private async void AllProducts(object product)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ProductPage());
        }
    }
}
