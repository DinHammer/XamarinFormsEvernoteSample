using Evernote.Abstractions;
using Evernote.Abstractions.DataObjects;
using Evernote.DAL.WebApi;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evernote.NUnit
{
    public class BaseTest
    {
        protected string strPhone { get; set; }
        protected string strPsw { get; set; }

        protected bool isMoq { get; set; }


        protected void SimpleRequestResult(RequestResult requestResult)
        {
            SimpleAssert(requestResult.IsValid, requestResult.Message);
        }

        protected void SimpleRequestResult<T>(RequestResult<T> requestResult) where T : class
        {
            SimpleAssert(requestResult.IsValid, requestResult.Message);
        }

        protected void SimpleAssert(bool is_valid, string message = "")
        {
            Assert.True(is_valid, message);
        }


        protected async Task<RequestResult<string>> GetTokenAccess()
        {
            var result = await DalWebApi.Auth.GetLoggIn(new ObjLoginIn(strPhone, strPsw));

            if (result.IsValid == true)
            {
                return new RequestResult<string>(result.Data.access, RequestStatus.Ok);
            }
            else 
            {
                return new RequestResult<string>(String.Empty, result.Status, result.Message);
            }
        }
    }
}
