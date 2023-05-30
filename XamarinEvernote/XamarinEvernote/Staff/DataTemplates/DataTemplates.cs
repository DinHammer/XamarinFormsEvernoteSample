using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinEvernote.Models;
using XamarinEvernote.Staff.Customs.Cells;

namespace XamarinEvernote.Staff.DataTemplates
{

    public class DtError : DataTemplate
    {
        public DtError(MdlError data) : base(() => CreateView(data)) { }
        static View CreateView(MdlError data)
        {
            CellError cell = new CellError();
            return cell;
        }
    }

    public class DtNote : DataTemplate
    {
        public DtNote(MdlNoteOne data) : base(() => CreateView(data)) { }
        static View CreateView(MdlNoteOne data)
        {
            CellNote cell = new CellNote(data);            
            return cell;
        }
    }

    public class DtEmpty : DataTemplate
    {
        public DtEmpty() : base(() => CreateView()) { }
        static View CreateView()
        {
            CellEmpty cell = new CellEmpty();
            return cell;
        }
    }
}
