using Common;
using Common.Score;
using Soldier.Common;
using System;
using System.Diagnostics;
using System.Linq;

namespace Battle.GameStates
{
    public class BattleState : IGameState
    {
        private bool _spawned;
        private float _timer;
        private GameStateController _gameStateController;

        public BattleState(GameStateController gameStateController)
        {
            _gameStateController = gameStateController;
        }

        public void Start()
        {
            Timer.OnTimerUpdateEvent += GetTimer;
        }

        public void Update()
        {
            if (!_spawned)
            {
                TeamManager.Instance().InitialSpawn();
                _spawned = true;
            }
            Timer.Instance().StartTimer();
            if(_timer <= 0)
            {
                CheckResult();
            }
        }
        public void Exit()
        {
            Timer.OnTimerUpdateEvent -= GetTimer;
        }
        private void GetTimer(float timer) //Analizar nombre
        {
            _timer = timer;
        }
        private void CheckResult()
        {
            var teamScores = ScoreSystem.Instance().GetTotalScoresByTeam();
            var teamWithBestScore = teamScores.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
            if(teamWithBestScore == Teams.Ally)
            {
                _gameStateController.SwithState(new VictoryState());
            }
            else
            {
                _gameStateController.SwithState(new DefeatState());
            }
        }
        
    }
}