using Inputs;
using Soldier.Common;
using Soldier.Weapon;
using System;
using UnityEngine;

namespace Soldier
{
    public class SoldierMediator : MonoBehaviour, ISoldier
    {
        [SerializeField] private MovementController _movementController;
        [SerializeField] private HealthController _healthController;
        [SerializeField] private WeaponController _weaponController;
        [SerializeField] private SoldierId _soldierId;
        public string Id => _soldierId.Value;
        public Teams Team => _team;

        private IInput _input;
        private Vector2 _direction;
        private int _score;
        private Teams _team;
        public static event Action<int, Teams, string, int> OnSoldierRegisterEvent;
        public static event Action<int, Teams, string, int> OnSoldierDeathEvent;
        public void Configure(SoldierConfiguration soldierConfiguration)
        {
            _input = soldierConfiguration.Input;
            _movementController.Configure(this, soldierConfiguration.SpeedWalk, soldierConfiguration.SpeedRun);
            _healthController.Configure(this, soldierConfiguration.Health, soldierConfiguration.Team);
           _weaponController.Configure(this, soldierConfiguration.WeaponIndex, soldierConfiguration.Team);
            _score = soldierConfiguration.Score;
            _team = soldierConfiguration.Team;
            OnSoldierRegisterEvent?.Invoke(0, _team, _soldierId.Value, GetInstanceID());
        }
        private void Update()
        {
          //  _direction = _input.GetDirection();
            TryShoot();
        }

        private void TryShoot()
        {
            if (_input.IsFireActionPressed())
            {
              //  _weaponController.TryShoot();
            }
        }

        private void FixedUpdate()
        {
         //   _movementController.Move(_direction);

        }

        public void OnDamageReceived(bool isDeath, string soldierId, Teams team)  //Agregar el equipo del que lo mato desde la bala
        {
            if (isDeath)
            {
                Destroy(gameObject);
                OnSoldierDeathEvent?.Invoke(_score, team, soldierId, GetInstanceID());
            }
        }

        public void SetRotation(Transform target)
        {
            _movementController.SetCurrentTarget(target);
        }
    }
}

