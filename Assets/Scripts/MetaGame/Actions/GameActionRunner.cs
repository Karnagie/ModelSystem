using MetaGame.Architecture.Models;
using MetaGame.Architecture.Wrappers;
using MetaGame.GameEssence;

namespace MetaGame.Actions
{
    public class GameActionRunner : IActionRunner
    {
        private readonly Game _game;
        
        public GameActionRunner(Game game)
        {
            _game = game;
        }
        public AliveObject[] AliveObjects => FindAliveObjects();
        public IModel[] Models => FindModels();
        
        public void Execute(GameAction<GameActionRunner> action)
        {
            action.Act(this);
        }

        private AliveObject[] FindAliveObjects()
        {
            var models = _game.FindModelsByBaseType(typeof(AliveObject));
            var objects = new AliveObject[models.Length];

            for(int i = 0; i < models.Length; i++)
            {
                objects[i] = (AliveObject) models[i];
            }
            
            return objects;
        }
        
        private IModel[] FindModels()
        {
            var models = _game.FindModels(typeof(IModel));
            return models;
        }
    }
}