using OnlineShop.App.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnlineShop.App.MVVM.ViewModels
{
    //Notify Property
    [AddINotifyPropertyChangedInterface]
    public class UserPageViewModel
    {
        //Data Binding
        public List<SystemUser> Users { get; set; }
        public SystemUser CurrentUser { get; set; }
        
        //Commands
        public ICommand AddOrUpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public UserPageViewModel() 
        {
            AddOrUpdateCommand = new Command(async () =>
            {
                App._userRepository.AddOrUpdate(CurrentUser);
                Console.WriteLine(App._userRepository.statusMessage);
                RefreshRecords();
            });

            DeleteCommand = new Command(() => 
            {
                App._userRepository.DeleteUser(CurrentUser.Id);
                RefreshRecords();
            });
        }

       
        private async void RefreshRecords() 
        {
            Users = await App._userRepository.GetUsers();
        }
    }
}
