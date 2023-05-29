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

        
        protected static Task prtShowTbdMessage()
            => ShowAlert("", "TBD", "Dobre!!!");


        

        #endregion
    }
}
