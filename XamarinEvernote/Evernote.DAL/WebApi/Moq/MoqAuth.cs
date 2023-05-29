using Evernote.Abstractions;
using Evernote.Abstractions.DataObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evernote.DAL.WebApi.Moq
{
    public class MoqAuth : BaseMoq, IActionAuth
    {
        public Task<RequestResult<ObjLoginOut>> GetLoggIn(ObjLoginIn data)
        {
            return Task.Run(() =>
            {
                ObjLoginOut result = new ObjLoginOut("ololo", "pishPish");

                return new RequestResult<ObjLoginOut>(result, RequestStatus.Ok);
            });
        }

        public Task<RequestResult<ObjRefreshTokenOut>> RefreshToken(ObjRefreshTokenIn data)
        {
            return Task.Run(() =>
            {
                ObjRefreshTokenOut result = new ObjRefreshTokenOut("pishPish","ololo");

                return new RequestResult<ObjRefreshTokenOut>(result, RequestStatus.Ok);
            });
        }
    }
}
