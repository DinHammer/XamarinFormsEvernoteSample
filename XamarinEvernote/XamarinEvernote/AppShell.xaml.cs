using System;
using System.Collections.Generic;
using Xamarin.Forms;

using viewNotes = XamarinEvernote.Pages.Views.Notes;

namespace XamarinEvernote
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(viewNotes.NotesDetailPage), typeof(viewNotes.NotesDetailPage));
        }

    }
}
