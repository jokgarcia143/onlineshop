﻿namespace OnlineShop.App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            _ = GoToAsync("//LoginPage"); //Route
        }
    }
}
