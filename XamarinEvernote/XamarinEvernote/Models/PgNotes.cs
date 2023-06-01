using Evernote.Abstractions.DataObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace XamarinEvernote.Models
{
    public class MdlNoteOne
    {
        private ObjNote _objNote;

        public MdlNoteOne(ObjNote objNote, ICommand cmd)
        {
            _objNote = objNote;
            Cmd= cmd;
        }

        public ObjNote GetNote() => _objNote;

        public int Id => _objNote.id;
        public string Title => _objNote.title;
        public string Text => _objNote.text;
        public string Date => _objNote.strDateTime;

        public ICommand Cmd { get; private set; }
    }
}
