using Evernote.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Evernote.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        // GET: api/<NotesController>
        [HttpGet]
        public IEnumerable<ObjNote> Get()
        {
            List<ObjNote> output = new List<ObjNote>();
            output.Add(new ObjNote(
                id: 1,
                title: "Заметка 1",
                text: "Хорошая заметка 1",
                isPrivate: false,
                dateTime: DateTime.Now));

            output.Add(new ObjNote(
                id: 2,
                title: "Заметка 2",
                text: "Хорошая заметка 2",
                isPrivate: false,
                dateTime: DateTime.Now));

            output.Add(new ObjNote(
                id: 3,
                title: "Заметка 3",
                text: "Хорошая заметка 3",
                isPrivate: true,
                dateTime: DateTime.Now));

            return output;
        }

        
    }
}
