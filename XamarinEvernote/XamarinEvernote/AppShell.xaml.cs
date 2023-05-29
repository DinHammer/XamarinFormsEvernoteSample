using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinEvernote.ViewModels;
using XamarinEvernote.Views;

namespace XamarinEvernote
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
