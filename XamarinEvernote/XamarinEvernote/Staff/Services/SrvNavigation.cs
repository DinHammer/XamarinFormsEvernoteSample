using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinEvernote.Pages.ViewModels;
using constEnums = XamarinEvernote.Constants.ConstEnums;


namespace XamarinEvernote.Staff.Services
{
    public class SrvNavigation
    {
        static readonly Lazy<SrvNavigation> LazyInstance = new Lazy<SrvNavigation>(() => new SrvNavigation(), true);
        public static SrvNavigation Instance => LazyInstance.Value;

        public async Task NavigateTo(
            constEnums.TypePage page,
            Dictionary<string, object> parametrs = default,
            bool isNewNavigationStack = false)
        {
            string strPage = $"{page.ToString()}Page";

            if (isNewNavigationStack)
            {
                strPage = $"//{strPage}";
            }

            if (parametrs!=default)
            {
                string strNavigationParams = JsonConvert.SerializeObject(parametrs);                
                strPage = $"{strPage}?{nameof(BaseViewModel.Content)}={strNavigationParams}";
            }

            await Shell.Current.GoToAsync(strPage);
        }
    }
}
