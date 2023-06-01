
namespace Evernote.WebApi.Models
{
    public class ObjNoteOut
    {
        public ObjNoteOut()
        {
            notes = new List<ObjNote>();
        }

        public List<ObjNote> notes;
        
    }

    public class ObjNote
    {
        public ObjNote() { }
        public ObjNote(int id, string title, string text, bool isPrivate, DateTime dateTime)
        {
            this.id = id;
            this.title = title;
            this.text = text;
            this.isPrivate = isPrivate;
            this.strDateTime = dateTime.ToString("yyyy MM dd HH mm ss");
        }

        public int id;
        public string title;
        public string text;
        public bool isPrivate;        
        public string strDateTime;
    }
}
