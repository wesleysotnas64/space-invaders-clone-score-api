using Microsoft.AspNetCore.Mvc;
using space_invaders_clone_score_api.Request;
using space_invaders_clone_score_api.TRA;
using space_invaders_clone_score_api.Data;
using space_invaders_clone_score_api.Entities;


namespace space_invaders_clone_score_api.Controllers
{
    [ApiController]
    [Route("space-invader-api/")]
    public class PlayerController : ControllerBase
    {
        private DBManager _dbManager;

        public PlayerController()
        {
            if(_dbManager == null) _dbManager = new DBManager();
        }

        [HttpGet("get-score-list/{key}")]
        public IActionResult GetScoreList(string key)
        {
            if (string.IsNullOrEmpty(key)) return BadRequest("Key cannot be null or empty.");

            if (!new PlayerTRA().VerifyKey(key)) return BadRequest("Invalid key provided.");

            List<Player> players = _dbManager.GetPlayers();

            return Ok(players);
        }

        [HttpPost("submit-score")]
        public IActionResult SubmitANewScore([FromBody] SubmitScoreRequest submitScoreRequest)
        {
            if (string.IsNullOrEmpty(submitScoreRequest.Key)) return BadRequest("Key cannot be null or empty.");

            if (!new PlayerTRA().VerifyKey(submitScoreRequest.Key)) return BadRequest("Invalid key provided.");

            if (!new PlayerTRA().VerifyScore(submitScoreRequest.Score)) return BadRequest("Invalid score provided.");

            try
            {
                _dbManager.AddPlayer(new Player() { Name = submitScoreRequest.Name, Score = submitScoreRequest.Score });
                return Ok("Score submitted successfully!");
            }
            catch
            {
                return BadRequest("Error: Database connection.");
            }
        }
    }
}
