using Evernote.Abstractions.Staff.JsonConverters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace Evernote.Abstractions.DataObjects
{
    public class ObjNote
    {
        public ObjNote() { }
        public ObjNote(int id, string title, string text, bool isPrivate, DateTime dateTime)
        {
            this.id = id;
            this.title = title;
            this.text = text;
            this.isPrivate = isPrivate;
            this.dateTime = dateTime;
        }

        public int id;
        public string title;
        public string text;
        public bool isPrivate;
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime dateTime;
    }

    

    public class ObjNoteUpdateIn
    { }

    public class ObjNoteCreateIn
    { }

    public class ObjNoteIn
    {
        public ObjNoteIn(string tokenAccess)
        {
            TokenAccess = tokenAccess;
        }

        public string TokenAccess { get; private set; }
    }

    public class ObjNoteOneIn
    {
        public ObjNoteOneIn(string tokenAccess, int id)
        {
            TokenAccess = tokenAccess;
            Id = id.ToString();
        }

        public string TokenAccess { get; private set; }
        public string Id { get; private set; }
    }

    public class ObjNoteOut
    {
        public ObjNoteOut()
        {
            notes = new List<ObjNote>();
        }

        public List<ObjNote> notes;

        public int Count => notes.Count;

        public ObjNote GetFirst() => notes.First();
    }
}
