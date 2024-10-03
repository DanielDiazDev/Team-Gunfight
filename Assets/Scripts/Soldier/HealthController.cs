using Soldier.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Soldier
{
    public class HealthController : MonoBehaviour, IDamageable
    {
        [SerializeField] private float _health;
        private Dictionary<string, float> _damageTraker;
        private ISoldier _soldier;

        public Teams Team {  get; private set; }
        private void Awake()
        {
            _damageTraker = new Dictionary<string, float>();
        }

        public void Configure(ISoldier soldier, float health, Teams team)
        {
            _soldier = soldier;
            _health = health;
            Team = team;
        }
        private void Update()
        {
            
        }
        public void TakeDamage(float amount, string soldierId, Teams team)
        {
            _health = Mathf.Max(0, _health - amount);
            Debug.Log(_health);
            
            var isDeath = _health <= 0;
            var soldierWithMostDamageDo = CalculateDamageTraker(soldierId, amount);
            _soldier.OnDamageReceived(isDeath, soldierWithMostDamageDo, team);
        }

        private string CalculateDamageTraker(string soldierId, float amount)
        {
            if (_damageTraker.Keys.Contains(soldierId))
            {
                _damageTraker[soldierId] += amount;
            }
            else
            {
                _damageTraker.Add(soldierId, amount);
            }
            return _damageTraker.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
        }
    }
}