using MetaGame.Actions;

namespace MetaGame.Architecture.Models
{
    public interface IModel : IActionRunner
    {
        public string Name { get; }
        void Tick(float deltaTime);
        void FixedTick(float deltaTime);
    }
}