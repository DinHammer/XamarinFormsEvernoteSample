using Evernote.Abstractions.DataObjects;
using Evernote.DAL.WebApi;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XamarinEvernote.Models;
using XamarinEvernote.Staff.Services;
using static XamarinEvernote.Constants.ConstEnums;

namespace XamarinEvernote.Pages.ViewModels.Notes
{
    /// <see cref="XamarinEvernote.Pages.Views.Notes.NotesPage"/>
    public class VmNotes : BaseViewModel
    {
        public override async Task OnPageAppearing()
        {
            //return base.OnPageAppearing();
            dataSource.Clear();

            var vTokenAccess = await SrvAuth.Instance.GetTokenAccess();
            if (vTokenAccess.IsValid == false)
            {
                dataCollection.MgcReplace(new MdlError(vTokenAccess.Message));
                return;
            }

            string tokenAccess = vTokenAccess.Data;

            var vNotes = await DalWebApi.Notes.GetAll(new ObjNoteIn(tokenAccess));
            if (vNotes.IsValid == false)
            {
                dataCollection.MgcReplace(new MdlError(vNotes.Message));
                return;
            }


            ObjNote objNote = null;
            for (int i = 0; i < vNotes.Data.Count; i++)
            { 
                objNote = vNotes.Data.notes[i];
                dataSource.Add(new MdlNoteOne(objNote));
            }

            dataCollection.MgcReplaceRange(dataSource);
        }

        public ICommand CmdAdd => MakeCommand(async () =>
        {
            if (IsBusy == true)
            {
                return;
            }
            IsBusy = true;

            await prtShowTbdMessage();

            IsBusy = false;
        });
    }
}
