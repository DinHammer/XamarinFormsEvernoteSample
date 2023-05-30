using Evernote.Abstractions.DataObjects;
using Evernote.DAL.WebApi;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evernote.NUnit.TestWebApi
{
    [TestFixture]
    [TestFixtureSource(typeof(InitTestClient), nameof(InitTestClient.FixtureParams))]
    public class TestNotes : BaseTest
    {
        public TestNotes(string key, string strPhone, string strPsw, string strMoq)
        {
            this.strPhone = strPhone;
            this.strPsw = strPsw;
            this.isMoq = strMoq == "1" ? true : false;
        }

        string strTokenAccess = String.Empty;

        [OneTimeSetUp]
        public async Task Init()
        {
            DalWebApi.Init(isMoq: isMoq);
            var vTokenAccess = await GetTokenAccess();
            SimpleRequestResult(vTokenAccess);
            strTokenAccess = vTokenAccess.Data;            
        }

        [Test]
        public async Task TestGetAll()
        {
            var vOut = await DalWebApi.Notes.GetAll(new ObjNoteIn(strTokenAccess));
            SimpleAssert(vOut.IsValid);
        }
    }
}
