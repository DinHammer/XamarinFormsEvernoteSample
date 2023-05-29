using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using constEnums = XamarinEvernote.Constants.ConstEnums;

namespace XamarinEvernote.Staff.Services
{
    public class SrvNavigation
    {
        static readonly Lazy<SrvNavigation> LazyInstance = new Lazy<SrvNavigation>(() => new SrvNavigation(), true);
        public static SrvNavigation Instance => LazyInstance.Value;

        public async Task NavigateTo(
            constEnums.TypePage page,
            bool isNewNavigationStack = false,
            string strNavigationParams = "")
        {
            string strPage = $"{page.ToString()}Page";

            if (isNewNavigationStack)
            {
                strPage = $"//{strPage}";
            }

            if (strNavigationParams != "")
            {
                strPage = $"{strPage}?{strNavigationParams}";
            }

            await Shell.Current.GoToAsync(strPage);
        }
    }
}
