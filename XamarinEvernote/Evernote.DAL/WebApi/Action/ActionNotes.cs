using Evernote.Abstractions;
using Evernote.Abstractions.DataObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evernote.DAL.WebApi.Action
{
    public class ActionNotes : BaseAction, IActionNotes
    {
        public Task<RequestResult> CreateOne(ObjNoteCreateIn data)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<ObjNoteOut>> GetAll(ObjNoteIn data)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult> UpdateOne(ObjNoteUpdateIn data)
        {
            throw new NotImplementedException();
        }
    }
}
