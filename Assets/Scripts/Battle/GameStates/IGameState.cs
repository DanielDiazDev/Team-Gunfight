namespace Battle.GameStates
{
    public interface IGameState
    {
        void Start();
        void Update();
        void Exit();
    }
}