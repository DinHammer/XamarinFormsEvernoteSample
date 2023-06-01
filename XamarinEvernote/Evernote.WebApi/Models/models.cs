namespace Evernote.WebApi.Models
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
        public DateTime dateTime;
    }
}
