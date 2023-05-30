using Evernote.Abstractions;
using Evernote.Abstractions.DataObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evernote.DAL.WebApi
{
    public interface IActionAuth
    {
        Task<RequestResult<ObjRefreshTokenOut>> RefreshToken(ObjRefreshTokenIn data);
        Task<RequestResult<ObjLoginOut>> GetLoggIn(ObjLoginIn data);
    }

    public interface IActionNotes
    {
        Task<RequestResult<ObjNoteOut>> GetAll(ObjNoteIn data);
        Task<RequestResult<ObjNoteOut>> GetOne(ObjNoteIn data);
        Task<RequestResult> UpdateOne(ObjNoteUpdateIn data);
        Task<RequestResult> CreateOne(ObjNoteCreateIn data);
    }
}
