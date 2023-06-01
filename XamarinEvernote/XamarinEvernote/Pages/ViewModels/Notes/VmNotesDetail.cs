using Evernote.Abstractions.DataObjects;
using Evernote.DAL.WebApi;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static XamarinEvernote.Constants.ConstEnums;
using System.Windows.Input;
using XamarinEvernote.Staff.Services;
using XamarinEvernote.Models;
using Xamarin.Forms;
using XamarinEvernote.Constants;

namespace XamarinEvernote.Pages.ViewModels.Notes
{
    
    public class VmNotesDetail : BaseViewModel
    {

        


        private string _strTitle = string.Empty;
        public string StrTitle
        {
            get => Get(_strTitle);
            set => Set(value);
        }


        private string _strText = string.Empty;
        public string StrText
        {
            get => Get(_strText);
            set => Set(value);
        }

        private string _strDate = string.Empty;
        public string StrDate
        {
            get => Get(_strDate);
            set => Set(value);
        }

        public override async Task OnPageAppearing()
        {
            //return base.OnPageAppearing();

            var vNotes = prtGetNavigationParametr<ObjNote>(KeyNavigations.strSelectedNote);
            
            var vTokenAccess = await SrvAuth.Instance.GetTokenAccess();            
            string tokenAccess = vTokenAccess.Data;

            StrTitle = vNotes.Data.title;
            StrText = vNotes.Data.text;
            StrDate = vNotes.Data.strDateTime;

        }

        public ICommand CmdSave => MakeCommand(async () =>
        {
            if (IsBusy == true)
            {
                return;
            }
            IsBusy = true;
            

            await SrvNavigation.Instance.NavigateTo(TypePage.Notes, isNewNavigationStack: true);

            IsBusy = false;
        });
    }
}
