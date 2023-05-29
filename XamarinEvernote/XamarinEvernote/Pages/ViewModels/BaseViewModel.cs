using Evernote.Abstractions;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using XamarinEvernote.Staff;
using static XamarinEvernote.Constants.ConstEnums;

namespace XamarinEvernote.Pages.ViewModels
{
    public class BaseViewModel : CoreViewModel
    {
        #region Fields
        private TypePage _thisPage;
        #endregion

        #region Properties

        private string StrPage => _thisPage.ToString();
        public MgcObservableCollection<object> dataCollection { get; set; }

        //public bool IsTest { get; private set; }

        #endregion


        #region Constructors
        public BaseViewModel()
        {
            dataCollection = new MgcObservableCollection<object>();
            //IsTest = isTest;
        }

        public BaseViewModel(TypePage pages) : this()
        {
            _thisPage = pages;

        }

        #endregion

        #region Methods

        protected void prtAddItemsInDataSource(IList<object> dataSource, IList<object> items)
        {
            foreach (var item in items)
            {
                dataSource.Add(item);
            }
        }

        /*protected void prtSetError<T>(RequestResult<T> requestResult) where T : class
        {
            SetError(requestResult.Message);
        }
        protected void prtSetError(RequestResult requestResult)
        {
            SetError(requestResult.Message);
        }
        private void SetError(string str)
        {
            dataCollection.MgcReplace(new mdl.MdlError(str));
        }*/

        protected void prtAdd2DataCollection(IList<object> dataSources)
        {
            dataCollection.MgcReplaceRange(dataSources);
            dataSources.Clear(); ;
        }

        /*protected async Task<RequestResult<mdl.MdlPersonalData>> prtGetPersonalData()
        {
            var vToken = await srvAuth.Instance.GetTokenAccess();
            if (!vToken.IsValid)
            {
                return new RequestResult<mdl.MdlPersonalData>(null, vToken.Status, vToken.Message);
            }
            var vAcountId = await srvAuth.Instance.GetAccountId();
            if (!vAcountId.IsValid)
            {
                return new RequestResult<mdl.MdlPersonalData>(null, vAcountId.Status, vAcountId.Message);
            }
            return new RequestResult<mdl.MdlPersonalData>(new mdl.MdlPersonalData(vToken.Data, vAcountId.Data), RequestStatus.Ok);
        }*/
        protected static Task prtShowTbdMessage()
            => ShowAlert("ololoPishPish", "TBD", "Dobre!!!");


        /*protected void prtOnPageAppearingTrackError<T>(
            string strFunctionName,
            RequestResult<T> requestResult
            ) where T : class
        {
            prtTrackError<T>(nameof(OnPageAppearing), strFunctionName, requestResult);
        }*/

        /*protected void prtTrackError<T>(
            string strPlace,
            string strFunctionName,
            RequestResult<T> requestResult
            ) where T : class
        {
            if (IsTest)
            {
                return;
            }

            string strStatus = requestResult.Status.ToString();
            Exception ex = new Exception($"{StrPage}::{strPlace}::{strFunctionName}::{strStatus}");

            IDictionary<string, string> parametrs = new Dictionary<string, string>();
            parametrs.Add(nameof(requestResult.Message), requestResult.Message);

            srvAppCenter.Instance.TrackError(ex, parametrs);
        }*/

        /*protected void prtTrackEvent<T>(
            string strFunctionName,
            RequestResult<T> requestResult
            ) where T : class
        {
            if (IsTest)
            {
                return;
            }

            string strTrackIdentificator = $"{StrPage}::{strFunctionName}";

            IDictionary<string, string> parametrs = new Dictionary<string, string>();
            parametrs.Add(nameof(requestResult.Status), requestResult.Status.ToString());
            parametrs.Add(nameof(requestResult.Message), requestResult.Message);

            srvAppCenter.Instance.TrackEvent(strTrackIdentificator, parametrs);
        }*/

        #endregion
    }
}
