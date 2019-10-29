using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MusicListapi.Models;
using MusicListapi.Services;

namespace MusicListapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly SongService _songService;

        public SongController(SongService songService)
        {
            _songService = songService;
        }

        [HttpGet]
        public ActionResult<List<Song>> Get() =>
            _songService.Get();

        [HttpGet("{id:length(24)}", Name = "GetSong")]
        public ActionResult<Song> Get(string id)
        {
            var song = _songService.Get(id);

            if (song == null)
            {
                return NotFound("The song could not be found");
            }

            return song;
        }

        [HttpPost]
        public ActionResult<Song> Create([FromBody]Song song)
        {
            _songService.Create(song);
            return CreatedAtRoute("GetSong", new {id = song.Id.ToString()}, song);
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete([FromRoute]string id)
        {
            var song = _songService.Get(id);

            if (song == null)
            {
                return NotFound("The song could not be found");
            }
            
            _songService.Remove(song.Id);

            return NoContent();
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult<Song> UpdateState(string id, [FromBody] Song songIn)
        {
            var song = _songService.Get(id);

            if (song == null)
            {
                return NotFound("The song could not be found");
            }
            _songService.Update(id, songIn);

            return NoContent();
        }
    }
}