using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XamarinEvernote.Staff.Services;

using static XamarinEvernote.App;


using srvNavigation = XamarinEvernote.Staff.Services.SrvNavigation;
using srvAuth = XamarinEvernote.Staff.Services.SrvAuth;
using srvDialog = XamarinEvernote.Staff.Services.SrvDialog;
using static XamarinEvernote.Constants.ConstEnums;
using dtObj = Evernote.Abstractions.DataObjects;
using Evernote.Abstractions.DataObjects;
using Evernote.Abstractions;
using System.Threading.Tasks;
using XamarinEvernote.Constants;
using Evernote.DAL.WebApi;

namespace XamarinEvernote
{
    public partial class App : Application
    {

        public enum TypeAppStart
        {
            tpRelize,
            tpDebug,
            tpDebugLogin,
            tpDebugMain,            
        }

        //bool useMock = false;
        bool useMock = true;

        public static TypeAppStart typeAppStart = TypeAppStart.tpRelize;

        public App()
        {
            InitializeComponent();
            Xamarin.Essentials.VersionTracking.Track();

#if DEBUG
            //typeAppStart=TypeAppStart.tpRelize;
            //typeAppStart = TypeAppStart.tpDebugLogin;
            typeAppStart = TypeAppStart.tpDebugMain;
            

#endif

            
            MainPage = new AppShell();
        }

        protected override async void OnStart()
        {
            srvDialog.Init(this);
            DalWebApi.Init(isMoq: useMock);

            bool IsFirstLaunchForCurrentBuild = Xamarin.Essentials.VersionTracking.IsFirstLaunchForCurrentBuild;
            bool IsFirstLaunchForCurrentVersion = Xamarin.Essentials.VersionTracking.IsFirstLaunchForCurrentVersion;


            if (IsFirstLaunchForCurrentBuild || IsFirstLaunchForCurrentVersion)
            {
                srvAuth.Instance.ClearAll();
            }

            switch (typeAppStart)
            {
                case TypeAppStart.tpDebugLogin:
                    await srvNavigation.Instance.NavigateTo(TypePage.Login, isNewNavigationStack: true);
                    break;
                case TypeAppStart.tpDebugMain:
                    await NavigateToWithAuth(TypePage.Notes);
                    break;
                default:
                    var vTRefresh = await srvAuth.Instance.GetTokenRefresh();
                    if (!vTRefresh.IsValid)
                    {
                        await srvNavigation.Instance.NavigateTo(TypePage.Login, isNewNavigationStack: true);
                        return;
                    }

                    var vRefresh = await DalWebApi.Auth.RefreshToken(new ObjRefreshTokenIn(vTRefresh.Data));
                    if (!vRefresh.IsValid)
                    {
                        await srvNavigation.Instance.NavigateTo(TypePage.Login, isNewNavigationStack: true);
                        return;
                    }
                    else
                    {
                        await srvAuth.Instance.SetTokens(vRefresh.Data);
                        //await srvAuth.Instance.SetTokenRefresh(vRefresh.Data.refresh);
                    }

                    await srvNavigation.Instance.NavigateTo(TypePage.Notes, isNewNavigationStack: true);
                    break;
            }

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        async Task<RequestResult> NavigateToWithAuth(
            TypePage page,
            string strPhone = ConstStrings.KeyMoq.strPhone,
            string strPassword = ConstStrings.KeyMoq.strPassoword,
            bool isNewNavigationStack = true)
        {
            var vToken = await srvAuth.Instance.GetTokenRefresh();                        

            if (vToken.IsValid==false)
            {
                var vLogIn = await DalWebApi.Auth.GetLoggIn(new ObjLoginIn(strPhone, strPassword));
                if (!vLogIn.IsValid)
                {
                    await srvNavigation.Instance.NavigateTo(TypePage.Login, isNewNavigationStack: true);
                    return new RequestResult();
                }
                else
                {
                    
                    var vSetToken = await srvAuth.Instance.SetTokens(vLogIn.Data);                    

                    await srvNavigation.Instance.NavigateTo(page, isNewNavigationStack: isNewNavigationStack);
                }
            }
            else
            {

                var vRefresh = await DalWebApi.Auth.RefreshToken(new dtObj.ObjRefreshTokenIn(vToken.Data));
                if (vRefresh.IsValid)
                {
                    var vLocalRefresh = await srvAuth.Instance.SetTokens(vRefresh.Data);
                    await srvNavigation.Instance.NavigateTo(page, isNewNavigationStack: isNewNavigationStack);
                    return new RequestResult();
                }
                else
                {
                    await srvNavigation.Instance.NavigateTo(TypePage.Login, isNewNavigationStack: true);
                    return new RequestResult();
                }

            }

            return new RequestResult(RequestStatus.Ok);
        }
    }
}
