
namespace Battle.GameStates
{
    public class DefeatState : IGameState
    {
        public void Start()
        {
            string derrota = "Perdiste";
        }
        public void Update()
        {
        }
        public void Exit()
        {
        }
    }
    public class VictoryState : IGameState
    {
        public void Start()
        {
            string victoria = "Ganaste";
        }

        public void Update()
        {
        }
        public void Exit()
        {
        }
    }
}