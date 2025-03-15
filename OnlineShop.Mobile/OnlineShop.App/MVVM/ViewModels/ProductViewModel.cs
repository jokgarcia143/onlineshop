using OnlineShop.App.Helpers;
using OnlineShop.App.MVVM.Views.Product;
using OnlineShop.App.Services.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnlineShop.App.MVVM.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        //Define Properties
        private ObservableCollection<ProductsDTO> _products = new ObservableCollection<ProductsDTO>();
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
        //APi Properties
        private readonly HttpClient _httpClient;

        //Define Commands
        public ICommand ProductDetailsCommand { get; set; }
        //Define Constructor
        public ProductViewModel()
        {
            ProductDetailsCommand = new Command<ProductsDTO>(ProductDetails);
            _httpClient = new HttpClient();
            GetProducts();
            //Test Products
            //_ = ProductSeeding();
        }

        private async Task GetProducts()
        {
            //API Call
            IsLoading = true;
            ErrorMessage = string.Empty;

            try
            {
                var response = await _httpClient.GetAsync($"http://10.0.2.2:5143/api/product/getproducts");
                if (response.IsSuccessStatusCode)
                {
                    var products = await response.Content.ReadFromJsonAsync<List<ProductsDTO>>();
                    if(products != null)
                    {
                        Products = new ObservableCollection<ProductsDTO>(products);
                    }
                    else
                    {
                        ErrorMessage = "Failed to load products";
                        await ToastHelper.ShowToast(ErrorMessage);
                    }
                }
                else
                {
                    ErrorMessage = "Failed to load products";
                    await ToastHelper.ShowToast(ErrorMessage);
                }
                
            }
            catch (Exception ex)
            {
                ErrorMessage = $"An error occurred: {ex.Message}";
                await ToastHelper.ShowToast(ErrorMessage);
            }
            IsLoading = false;
        }

        private async Task ProductSeeding()
        {
            await LoadProducts();
        }
        //Defione Methods
        private async void ProductDetails(ProductsDTO product)
        {
            //await Application.Current.MainPage.Navigation.PopModalAsync(new ProductPage());
        }
        //Dummy Data
        async Task LoadProducts()
        {
            await Task.Delay(500);
            Products.Clear();
            Products.Add(new ProductsDTO
            {
                Name = "BeoPlay Speaker",
                Description = "Bang and Olufsen",
                SKU = "SKU001",
                Price = 100,
                ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image1.png"
            });
            Products.Add(new ProductsDTO() { Name = "Leather Wristwatch", Description = "Tag Heuer", Price = 450, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image2.png" });
            Products.Add(new ProductsDTO() { Name = "Smart Bluetooth Speaker", Description = "Google LLC", Price = 900, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image3.png" });
            Products.Add(new ProductsDTO() { Name = "Smart Luggage", Description = "Smart Inc", Price = 1200, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image4.png" });
            Products.Add(new ProductsDTO() { Name = "Smart Bluetooth Speaker", Description = "Bang and Olufsen", Price = 90, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image1.png" });
            Products.Add(new ProductsDTO() { Name = "B&o Desk Lamp", Description = "Bang and Olufsen", Price = 450, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image7.png" });
            Products.Add(new ProductsDTO() { Name = "BeoPlay Stand Speaker", Description = "Bang and Olufse", Price = 3000, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image8.png" });
            Products.Add(new ProductsDTO() { Name = "Airpods", Description = "B&o Phone Case", Price = 30, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image9.png" });
        }
    }
}
