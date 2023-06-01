using Evernote.Abstractions.DataObjects;
using Evernote.DAL.WebApi;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evernote.NUnit.TestWebApi
{
    public class TestMain : BaseTest
    {
        [OneTimeSetUp]
        public async Task Init()
        {
            string strServerPath = "https://127.0.0.1:32774";

            DalWebApi.Init(isMoq: false, base_uri: strServerPath);
            
        }

        [Test]
        public async Task TestGetAll()
        {
            var vOut = await DalWebApi.Notes.GetAll(new ObjNoteIn(""));
            SimpleAssert(vOut.IsValid);
        }


    }
}


