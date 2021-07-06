using BowlingAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace BowlingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BowlingController : ControllerBase
    {
        private readonly IBowlingGame _bowlingGame;
        public BowlingController(IBowlingGame bowlingGame)
        {
            _bowlingGame = bowlingGame;
        }

        [HttpGet]
        public ActionResult<BowlingScore> GetGame()
        {
            // return GameCalculator.GetTable();
            return _bowlingGame.GetScore();
        }
        [HttpPost()]
        public ActionResult<BowlingScore> Bowl([FromBody] KnockedPins knockedPins)
        {
            // return GameCalculator.Roll(pins);
            
            return _bowlingGame.Roll(knockedPins.Pins);
        }

    }
}