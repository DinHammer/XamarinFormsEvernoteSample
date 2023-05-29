using System.ComponentModel;
using Xamarin.Forms;
using XamarinEvernote.ViewModels;

namespace XamarinEvernote.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}