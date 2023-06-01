
using Evernote.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Evernote.WebApi.Controllers
{
    //[Route("api/[controller]/[actions]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        [HttpGet]
        [Route("Notes/GetAll")]
        public async Task<ActionResult<ObjNoteOut>> GetNotesAll()
        {
            List<ObjNote> notes = new List<ObjNote>();
            notes.Add(new ObjNote(
                id: 1,
                title: "Заметка 1",
                text: "Хорошая заметка 1",
                isPrivate: false,
                dateTime: DateTime.Now));

            notes.Add(new ObjNote(
                id: 2,
                title: "Заметка 2",
                text: "Хорошая заметка 2",
                isPrivate: false,
                dateTime: DateTime.Now));

            notes.Add(new ObjNote(
                id: 3,
                title: "Заметка 3",
                text: "Хорошая заметка 3",
                isPrivate: true,
                dateTime: DateTime.Now));

            ObjNoteOut result = new ObjNoteOut();
            result.notes = notes;

            //string strOut = JsonConvert.SerializeObject(result);

            return Ok(result);
        }


        /*// GET: api/<NotesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<NotesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NotesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<NotesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NotesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
