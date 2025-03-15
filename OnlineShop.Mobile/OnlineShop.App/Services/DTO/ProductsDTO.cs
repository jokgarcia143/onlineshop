using OnlineShop.App.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.App.Services.DTO
{
    public class ProductsDTO : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public double Qty { get; set; } = 1;

        private bool _IsAvailable;
        public bool IsAvailable
        {
            get => _IsAvailable;
            set
            {
                if (_IsAvailable != value)
                {
                    _IsAvailable = value;
                    OnPropertyChanged(nameof(IsAvailable));
                    OnPropertyChanged(nameof(AvailableColor));
                }
            }
        }
        public Color AvailableColor
        {
            get
            {
                if (IsAvailable)
                {
                    return Color.FromArgb("#00C569");
                }
                return Color.FromArgb("#FFB900");
            }
        }
        private string AvailableText
        {
            get
            {
                if (IsAvailable)
                {
                    return "Available";
                }
                return "Out of Stock";
            }
        }
    }
}
