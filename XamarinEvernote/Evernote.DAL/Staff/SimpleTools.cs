using System;
using System.Collections.Generic;
using System.Text;

namespace Evernote.DAL.Staff
{
    public class SimpleTools
    {
        static readonly Lazy<SimpleTools> LazyInstance = new Lazy<SimpleTools>(() => new SimpleTools(), true);
        public new static SimpleTools Instance => LazyInstance.Value;
    }
}
