using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinEvernote.Staff
{
    public class SimpleTools : Evernote.DAL.Staff.SimpleTools
    {
        static readonly Lazy<SimpleTools> LazyInstance = new Lazy<SimpleTools>(() => new SimpleTools(), true);
        public static new SimpleTools Instance => LazyInstance.Value;
    }
}
