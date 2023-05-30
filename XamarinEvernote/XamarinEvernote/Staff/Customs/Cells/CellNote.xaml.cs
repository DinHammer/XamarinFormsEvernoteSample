using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinEvernote.Models;

namespace XamarinEvernote.Staff.Customs.Cells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CellNote : ContentView
    {
        public CellNote(MdlNoteOne data)
        {
            InitializeComponent();

            lblTitle.Text = data.Title;
            lblText.Text = data.Text;
            lblData.Text = data.Date;
            tapGesture.Command = data.Cmd;
            tapGesture.CommandParameter = data;
        }
    }
}