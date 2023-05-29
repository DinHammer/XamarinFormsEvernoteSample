using Evernote.Abstractions.Constants;
using Evernote.Abstractions.DataObjects;
using Evernote.DAL.WebApi;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using XamarinEvernote.Constants;
using XamarinEvernote.Staff.Services;
using static XamarinEvernote.Constants.ConstEnums;

namespace XamarinEvernote.Pages.ViewModels.Auth
{
    public class VmLogin : BaseViewModel
    {
        private string strPhone = string.Empty;
        private string strPassword = string.Empty;

        public string StrPhone
        {
            get => Get(strPhone);
            set=> Set(value);
        }

        public string StrPassword
        {
            get=> Get(strPassword);
            set=> Set(value);
        }

        public VmLogin(): base() 
        {
#if DEBUG
            switch (App.typeAppStart)
            {
                case App.TypeAppStart.tpDebugLogin:
                    StrPhone = ConstStrings.KeyMoq.strPhone;
                    StrPassword = ConstStrings.KeyMoq.strPassoword;
                    break;
            }
#endif
        }

        public ICommand CmdLogin => MakeCommand(async () =>
        {
            if (IsBusy == true)
            {
                return;
            }
            IsBusy = true;

            ObjLoginIn objLoginIn = new ObjLoginIn(StrPhone, StrPassword);
            var vOut = await DalWebApi.Auth.GetLoggIn(objLoginIn);
            if (!vOut.IsValid)
            {
                IsBusy = false;
                return;
            }

            var vTokens = await SrvAuth.Instance.SetTokens(vOut.Data);
            if (!vTokens.IsValid)
            {
                IsBusy = false;
                return;
            }

            await ShowAlert("", "Вы успешно прошли регистрацию", "Добро пожаловать");

            await SrvNavigation.Instance.NavigateTo(TypePage.Notes, isNewNavigationStack: true);
            IsBusy = false;
        });
    }
}
