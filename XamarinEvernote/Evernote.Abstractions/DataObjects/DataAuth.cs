using System;
using System.Collections.Generic;
using System.Text;

namespace Evernote.Abstractions.DataObjects
{
    public class ObjRefreshTokenIn
    {
        public ObjRefreshTokenIn(string strToken)
        {
            this.refresh = strToken;
        }

        //[JsonProperty("refresh")]
        public string refresh { get; set; }
    }

    public class ObjRefreshTokenOut
    {
        public ObjRefreshTokenOut(string refresh, string access)
        {
            this.refresh = refresh;
            this.access = access;
        }
        public string refresh { get; set; }
        public string access { get; set; }
    }

    public class ObjLoginIn
    {
        public ObjLoginIn() { }
        public ObjLoginIn(string phone, string password)
        {
            this.phone = phone;
            this.password = password;
        }
        public string phone { get; set; }
        public string password { get; set; }
    }
    public class ObjLoginOut
    {
        public ObjLoginOut() { }
        public ObjLoginOut(string refresh, string access) 
        {
            this.refresh = refresh;
            this.access= access;
        }
        public string refresh { get; set; }
        public string access { get; set; }
    }    
}
