using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinEvernote.Models;
using XamarinEvernote.Pages.ViewModels;
using XamarinEvernote.Pages.ViewModels.Notes;
using XamarinEvernote.Staff.DataTemplates;

namespace XamarinEvernote.Pages.Views.Notes
{

    /// <see cref="XamarinEvernote.Pages.ViewModels.Notes.VmNotes"/>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesPage : ContentPage
    {
        public NotesPage()
        {
            InitializeComponent();
            collectionView.ItemTemplate = new TemplateSelection();
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

        class TemplateSelection : DataTemplateSelector
        {
            protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
            {
                if (item is MdlNoteOne mdlNoteOne)
                {
                    return new DtNote(mdlNoteOne);
                }
                else if (item is MdlError mdlError)
                {
                    return new DtError(mdlError);
                }
                else
                {
                    return new DtEmpty();
                }
            }
        }
    }
}