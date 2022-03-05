namespace MetaGame.Actions
{
    public abstract class GameAction<T> where  T : IActionRunner
    {
        protected abstract void Prepare(T runner);

        public void Act(T runner)
        {
            Prepare(runner);
            Perform();
            Log();
        }

        protected abstract void Perform();

        protected abstract void Log();
    }
}