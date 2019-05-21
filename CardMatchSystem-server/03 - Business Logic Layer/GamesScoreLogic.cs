using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMatch
{
    public class GamesScoreLogic : BaseLogic
    {

        //Get list of all scores
        public List<GamesScoreModel> GetAllScores()
        {
            var query = from gr in DB.GameScores
                        select new GamesScoreModel
                        {
                            id = gr.ScoreID,
                            userId = gr.UserID,
                            gameDateTime = gr.GameDateTime,
                            gameDuration = gr.GameDuration,
                            moves = gr.GameMoves
                        };
            return query.ToList();
        }

        //Add Game Result
        public GamesScoreModel AddGameScore(GamesScoreModel gameScoreModel)
        {
            DateTime nowTime = DateTime.Now;
            GameScore gameScore = new GameScore
            {
                UserID = gameScoreModel.userId,
                GameDateTime = nowTime,
                GameDuration = gameScoreModel.gameDuration,
                GameMoves = gameScoreModel.moves
            };
            DB.GameScores.Add(gameScore);
            DB.SaveChanges();
            gameScoreModel.id = gameScore.ScoreID;
            return gameScoreModel;
        }
    }
}
