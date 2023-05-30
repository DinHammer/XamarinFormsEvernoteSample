using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Evernote.NUnit
{
    public class InitTestClient
    {
        public static IEnumerable FixtureParams
        {
            get
            {
                yield return new TestFixtureData(
                    "TestUsver1",
                    "MyNumber",
                    "test123",
                    "1");
                yield return new TestFixtureData(
                    "TestUsver2",
                    "MyNumber",
                    "test123",
                    "1");

            }
        }
    }
}
