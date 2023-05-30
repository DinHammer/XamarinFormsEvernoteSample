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
    public class TestAuth : BaseTest
    {
        public TestAuth(string key, string strPhone, string strPsw, string strMoq)
        {
            this.strPhone = strPhone;
            this.strPsw = strPsw;
            this.isMoq = strMoq == "1" ? true : false;
        }

        [OneTimeSetUp]
        public void Init()
        {
            
            DalWebApi.Init(isMoq: isMoq);
        }

        [Test]
        public async Task TestLoggin()
        {
            
            ObjLoginIn objLoginIn = new ObjLoginIn(strPhone, strPsw);
            var vOut = await DalWebApi.Auth.GetLoggIn(objLoginIn);

            SimpleAssert(vOut.IsValid);
        }

        [Test]
        public async Task TestUserRefreshToken()
        {
            ObjLoginIn objLoginIn = new ObjLoginIn(strPhone, strPsw);
            var vTmp = await DalWebApi.Auth.GetLoggIn(objLoginIn);

            SimpleAssert(vTmp.IsValid);

            ObjRefreshTokenIn objIn = new ObjRefreshTokenIn(vTmp.Data.refresh);

            var vOut = await DalWebApi.Auth.RefreshToken(objIn);
            SimpleAssert(vOut.IsValid);
        }
    }
}
