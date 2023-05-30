using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinEvernote.Pages.ViewModels;

namespace XamarinEvernote.Pages.Views.Notes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesDetailPage : ContentPage
    {
        public NotesDetailPage()
        {
            InitializeComponent();
        }

        #region OnPageAction

        BaseViewModel baseViewModel => BindingContext as BaseViewModel;

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Task.Run(async () =>
            {
                await Task.Delay(XamarinEvernote.Constants.ConstNumeric.event_handler_loop);
                if (baseViewModel != null)
                {
                    await baseViewModel.OnPageAppearing();
                }
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Task.Run(async () =>
            {
                await Task.Delay(XamarinEvernote.Constants.ConstNumeric.event_handler_loop);
                if (baseViewModel != null)
                {
                    await baseViewModel.OnPageDisappearing();
                }
            });
        }

        #endregion
    }
}