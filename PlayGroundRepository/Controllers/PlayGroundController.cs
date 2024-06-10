using Microsoft.AspNetCore.Mvc;
using PlayGroundLib;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlayGroundRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayGroundController : ControllerBase
    {
        private PlayGroundRepo _repo;
        public PlayGroundController(PlayGroundRepo repo)
        {
            _repo = repo;
        }

        // GET: api/<PlayGroundController>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<PlayGround>> Get()
        {
            IEnumerable<PlayGround> playGrounds = _repo.GetAllPlayGrounds();

            if (playGrounds is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(playGrounds);
            }
        }

        // GET api/<PlayGroundController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<PlayGround> Get(int id)
        {
            PlayGround playGround = _repo.GetPlayGroundById(id);

            if (playGround is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(playGround);
            }
           
        }

        // POST api/<PlayGroundController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult< PlayGround> Post([FromBody] PlayGround playGround)
        {
            try 
                {
                PlayGround newPlayGround = _repo.AddPlayGr(playGround);
                return CreatedAtAction(nameof(Get), new { id = newPlayGround.Id }, newPlayGround);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<PlayGroundController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<PlayGround> Put(int id, [FromBody] PlayGround playGround)
        {
            try
                {
                PlayGround updatedPlayGround = _repo.UpdatePlayGround(playGround, id);
                return Ok(updatedPlayGround);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
