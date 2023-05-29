using Evernote.Abstractions;
using Evernote.Abstractions.DataObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evernote.DAL.WebApi.Action
{
    public class ActionAuth : BaseAction, IActionAuth
    {
        public Task<RequestResult<ObjLoginOut>> GetLoggIn(ObjLoginIn data)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<ObjRefreshTokenOut>> RefreshToken(ObjRefreshTokenIn data)
        {
            throw new NotImplementedException();
        }
    }
}
