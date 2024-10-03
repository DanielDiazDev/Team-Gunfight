using Inputs;
using Soldier.Common;
using System;
using UnityEngine;

namespace Soldier
{
    public class SoldierInstaller : MonoBehaviour
    {
        [SerializeField] private bool _useAI;
        [SerializeField] private SoldiersConfiguration _soldiersConfiguration;
        [SerializeField] private SoldierToSpawnConfiguration _soldierConfiguration;
        [SerializeField] private Transform _playerSpawnPoint;
        private SoldierBuilder _soldierBuilder;
        private static SoldierInstaller _instance;

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            var soldierFactory = new SoldierFactory(Instantiate(_soldiersConfiguration));
            _soldierBuilder = soldierFactory.Create(_soldierConfiguration.SoldierId.Value)
                .WithConfiguration(_soldierConfiguration)
                .WithTeam(Teams.Ally)
                .WithPosition(_playerSpawnPoint.position);
        }
        public static SoldierInstaller Instance()
        {
            return _instance;
        }
        private void Start()
        {
            WeaponSelectionView.OnWeaponSelectedEvent += WeaponSelected;
        }
        private void OnDestroy()
        {
            WeaponSelectionView.OnWeaponSelectedEvent -= WeaponSelected;
        }
        public SoldierMediator SpawnUserSoldier()
        {
            return _soldierBuilder.Build();
        }
        private void WeaponSelected()
        {
            var weaponIndex = PlayerPrefs.GetInt("WeaponIndex");
            _soldierBuilder.WithWeaponSelected((SoldierBuilder.WeaponType)weaponIndex);
            
        }
    }
}

