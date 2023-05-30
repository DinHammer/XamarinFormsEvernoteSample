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

            int id = 0;

            Int32.TryParse(Content, out id);

            var vTokenAccess = await SrvAuth.Instance.GetTokenAccess();
            

            string tokenAccess = vTokenAccess.Data;

            //DalWebApi.Notes.GetOne(new ObjNoteIn())

            StrDate = DateTime.Now.ToString("yyyy MMMM dd");
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
