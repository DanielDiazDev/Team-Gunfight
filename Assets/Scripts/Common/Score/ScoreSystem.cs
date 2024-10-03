using Soldier;
using Soldier.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Common.Score
{
    public class ScoreSystem : MonoBehaviour
    {
        private class SoldierScore
        {
            public int score;
            public Teams team;
            public SoldierScore(int score, Teams team)
            {
                this.score = score;
                this.team = team;
            }
        }
        private Dictionary<string, SoldierScore> _soldierScores;
        private static ScoreSystem _instance;

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            _soldierScores = new Dictionary<string, SoldierScore>();
        }
        public static ScoreSystem Instance()
        {
            return _instance;
        }
        private void Start()
        {
            SoldierMediator.OnSoldierRegisterEvent += InitializeScoresOfPlayers;
            SoldierMediator.OnSoldierDeathEvent += AddScore;
        }
        private void OnDestroy()
        {
            SoldierMediator.OnSoldierRegisterEvent -= InitializeScoresOfPlayers;
            SoldierMediator.OnSoldierDeathEvent -= AddScore;

        }
        private void InitializeScoresOfPlayers(int score, Teams team, string soldierId, int instance)
        {
            if(_soldierScores.ContainsKey(soldierId))
            {
                _soldierScores[soldierId] = new SoldierScore(score, team);
            }
            else
            {
                _soldierScores.Add(soldierId, new SoldierScore(score, team));
            }
        }
        private void AddScore(int score, Teams team, string soldierId, int instance)
        {
            if (_soldierScores.ContainsKey(soldierId))
            {
                _soldierScores[soldierId] = new SoldierScore(score, team);
            }
            else
            {
                _soldierScores.Add(soldierId, new SoldierScore(score, team));
            }
            var teamScores = GetTotalScoresByTeam();
            foreach (var teamScore in teamScores)
            {
                Debug.Log($"Equipo {teamScore.Key} tiene {teamScore.Value} puntos.");
            }
        }
        public Dictionary<Teams, int> GetTotalScoresByTeam()
        {
            return _soldierScores.GroupBy(s => s.Value.team)
                .ToDictionary(g => g.Key, g => g.Sum(s => s.Value.score));
        }
    }
}
