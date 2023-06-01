using System;
using System.Collections.Generic;
using System.Text;
using constString = Evernote.Abstractions.Constants.ConstText;

namespace Evernote.DAL.WebApi
{
    public class DalWebApi
    {

        public static void Init(bool isMoq = false, string base_uri = constString.WebApi.web_api_url)
        {
            if (isMoq == true)
            {
                Auth = new Moq.MoqAuth();
                Notes = new Moq.MoqNotes();                
            }
            else
            {
                Action.ActionStaff.Init(base_uri);

                Auth = new Action.ActionAuth();
                Notes = new Action.ActionNotes();
            }
        }


        public static IActionAuth Auth { get; private set; }
        public static IActionNotes Notes { get; private set; }
    }
}
