using Evernote.Abstractions;
using Evernote.Abstractions.DataObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evernote.DAL.WebApi.Moq
{
    public class MoqNotes : BaseMoq, IActionNotes
    {
        public Task<RequestResult> CreateOne(ObjNoteCreateIn data)
        {
            return Task.Run(() =>
            {
                return new RequestResult(RequestStatus.Ok);
            });
        }

        public Task<RequestResult<ObjNoteOut>> GetAll(ObjNoteIn data)
        {
            return Task.Run(() =>
            {
                ObjNoteOut result = new ObjNoteOut();
                result.notes.Add(new ObjNote(
                    id: 1,
                    title: "Заметка 1",
                    text: "Хорошая заметка 1",
                    isPrivate: false,
                    dateTime: DateTime.Now));

                result.notes.Add(new ObjNote(
                    id: 2,
                    title: "Заметка 2",
                    text: "Хорошая заметка 2",
                    isPrivate: false,
                    dateTime: DateTime.Now));

                result.notes.Add(new ObjNote(
                    id: 3,
                    title: "Заметка 3",
                    text: "Хорошая заметка 3",
                    isPrivate: true,
                    dateTime: DateTime.Now));

                return new RequestResult<ObjNoteOut>(result, RequestStatus.Ok);
            });
        }

        public Task<RequestResult<ObjNoteOut>> GetOne(ObjNoteIn data)
        {
            return Task.Run(() =>
            {
                ObjNoteOut result = new ObjNoteOut();
                result.notes.Add(new ObjNote(
                    id: 1,
                    title: "Заметка 1",
                    text: "Хорошая заметка 1",
                    isPrivate: false,
                    dateTime: DateTime.Now));                

                return new RequestResult<ObjNoteOut>(result, RequestStatus.Ok);
            });
        }

        public Task<RequestResult> UpdateOne(ObjNoteUpdateIn data)
        {
            return Task.Run(() =>
            {
                return new RequestResult(RequestStatus.Ok);
            });
        }
    }
}
