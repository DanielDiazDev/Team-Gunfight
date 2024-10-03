using System.Collections.Generic;
using UnityEngine;

namespace Soldier.Common
{
    public class TeamManager : MonoBehaviour
    {
        [SerializeField] private SoldiersConfiguration _soldiersConfiguration;
        [SerializeField] private SoldierInstaller _soldierInstaller;
        [SerializeField] private SoldierToSpawnConfiguration _soldierConfiguration;
        [SerializeField] private Transform _allySpawnPoint;
        [SerializeField] private Transform _enemySpawnPoint;
        private List<SoldierMediator> _allySoldiers = new List<SoldierMediator>();
        private List<SoldierMediator> _enemysoldiers = new List<SoldierMediator>();
        private SoldierFactory _soldierFactory;
        private SoldierBuilder _soldierBuilder;
        private static TeamManager _instance;

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            _soldierFactory = new SoldierFactory(Instantiate(_soldiersConfiguration));
        }
        public static TeamManager Instance()
        {
            return _instance;
        }

  
        private void Update()
        {
            //if(Input.GetKeyDown(KeyCode.B))
            //{
            //    InitialSpawn();
            //}
        }
        public void InitialSpawn()
        {
            var soldierPlayer = _soldierInstaller.SpawnUserSoldier();
            //_soldierBuilder = _soldierFactory.Create(_soldierConfiguration.SoldierId.Value)
            //    .WithConfiguration(_soldierConfiguration)
            //    .WithWeaponSelected(SoldierBuilder.WeaponType.AssaultRifle)
            //    .WithTeam(Teams.Ally)
            //    .WithPosition(_allySpawnPoint.position)
            //    .WithInputMode(SoldierBuilder.InputMode.AI);
         //   var soldierAllyBot = _soldierBuilder.Build();
            _allySoldiers.Add(soldierPlayer);
          //  _allySoldiers.Add(soldierAllyBot);
            _soldierBuilder = _soldierFactory.Create(_soldierConfiguration.SoldierId.Value)
               .WithConfiguration(_soldierConfiguration)
               .WithWeaponSelected(SoldierBuilder.WeaponType.AssaultRifle)
               .WithTeam(Teams.Enemy)
               .WithPosition(_enemySpawnPoint.position)
               .WithInputMode(SoldierBuilder.InputMode.AI);
            var soldierEnemyBot = _soldierBuilder.Build();
            _enemysoldiers.Add(soldierEnemyBot);
        }
    }
}