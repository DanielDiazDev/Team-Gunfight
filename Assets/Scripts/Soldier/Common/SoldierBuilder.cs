using Inputs;
using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Soldier.Common
{
    public class SoldierBuilder
    {
        public enum InputMode
        {
            Unity,
            AI
        }
        public enum WeaponType
        {
            AssaultRifle,
            Shotgun,
            Pistol
        }
        private SoldierMediator _prefab;
        private Vector3 _position = Vector3.zero;
        private Quaternion _rotation = Quaternion.identity;
        private IInput _input;
        private SoldierToSpawnConfiguration _soldierConfiguration;
        private InputMode _inputMode;
        private WeaponType _weaponType;
        private Teams _team;

        public SoldierBuilder FromPrefab(SoldierMediator prefab)
        {
            _prefab = prefab;
            return this;
        }
        public SoldierBuilder WithTeam(Teams team)
        {
            _team = team;
            return this;
        }
        public SoldierBuilder WithPosition(Vector3 position)
        {
            _position = position;
            return this;
        }
        public SoldierBuilder WithRotation(Quaternion rotation)
        {
            _rotation = rotation;
            return this;
        }
        public SoldierBuilder WithInput(IInput input)
        {
            _input = input;
            return this;
        }
        public SoldierBuilder WithConfiguration(SoldierToSpawnConfiguration soldierConfiguration)
        {
            _soldierConfiguration = soldierConfiguration;
            return this;
        }
        public SoldierBuilder WithWeaponSelected(WeaponType weaponType)
        {
            _weaponType = weaponType;
            return this;
        }
        public SoldierBuilder WithInputMode(InputMode inputMode)
        {
            _inputMode = inputMode;
            return this;
        }
        private IInput GetInput(SoldierMediator soldierMediator)
        {
            if (_input != null)
            {
                return _input;
            }
            switch (_inputMode)
            {
                case InputMode.Unity:
                    return new UnityInputAdapter();
                case InputMode.AI:
                    return new AIInputAdapter(_prefab);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        public SoldierMediator Build()
        {
            var soldier = Object.Instantiate(_prefab, _position, _rotation);
            var soldierConfiguration = new SoldierConfiguration(GetInput(soldier),
                                                                   _soldierConfiguration.SpeedWalk,
                                                                   _soldierConfiguration.SpeedRun,
                                                                   _soldierConfiguration.Health,
                                                                   _soldierConfiguration.IsPlayer,
                                                                   _soldierConfiguration.Score,
                                                                   _team,
                                                                   (int)_weaponType
                                                                   );
            soldier.Configure(soldierConfiguration);
            return soldier;
        }
    }
    
}
