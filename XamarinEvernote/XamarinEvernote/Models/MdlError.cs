using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinEvernote.Models
{
    public class MdlError
    {

        public MdlError(string message) 
        {
            Message = message;
        }
        public string Message { get; private set; }
    }
}
