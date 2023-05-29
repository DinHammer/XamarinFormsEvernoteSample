using Evernote.Abstractions.DataObjects;
using Evernote.DAL.WebApi;
using System;
using System.Collections.Generic;
using System.Text;
using static XamarinEvernote.Constants.ConstEnums;
using System.Windows.Input;
using XamarinEvernote.Staff.Services;

namespace XamarinEvernote.Pages.ViewModels.Settings
{
    public class VmSettings : BaseViewModel
    {
        public ICommand CmdLogOut => MakeCommand(async () =>
        {
            if (IsBusy == true)
            {
                return;
            }
            IsBusy = true;
            
            await SrvNavigation.Instance.NavigateTo(TypePage.Login, isNewNavigationStack: true);

            IsBusy = false;
        });
    }
}
