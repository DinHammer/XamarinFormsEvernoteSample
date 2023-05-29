using System;
using System.Collections.Generic;
using System.Text;

namespace Evernote.DAL.WebApi
{
    public class DalWebApi
    {

        public static void Init(bool isMoq = false)
        {
            if (isMoq == true)
            {
                Auth = new Moq.MoqAuth();
                Notes = new Moq.MoqNotes();                
            }
            else
            {
                Auth = new Action.ActionAuth();
                Notes = new Action.ActionNotes();
            }
        }


        public static IActionAuth Auth { get; private set; }
        public static IActionNotes Notes { get; private set; }
    }
}
