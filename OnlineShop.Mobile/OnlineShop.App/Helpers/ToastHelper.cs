using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.App.Helpers
{
    public static class ToastHelper
    {
        public static async Task ShowToast(string message)
        {
            //Show Toast
            string text = message;
            ToastDuration duration = ToastDuration.Short;
            double fontSize = 14;
            var toast = Toast.Make(text, duration, fontSize);
            await toast.Show();
        }
    }
}
