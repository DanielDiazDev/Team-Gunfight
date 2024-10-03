using System;
using System.Collections.Generic;
using UnityEngine;

namespace Soldier
{
    [CreateAssetMenu(menuName = "Create SoldiersConfiguration", fileName = "SoldiersConfiguration")]
    public class SoldiersConfiguration : ScriptableObject
    {
        [SerializeField] private SoldierMediator[] _soldiersPrefab;
        private Dictionary<string, SoldierMediator> _idToSoldierPrefab;

        private void Awake()
        {
            _idToSoldierPrefab = new Dictionary<string, SoldierMediator>();
            foreach(var soldier in _soldiersPrefab)
            {
                _idToSoldierPrefab.Add(soldier.Id, soldier);
            }
        }
        public SoldierMediator GetSoldierById(string id)
        {
            if(!_idToSoldierPrefab.TryGetValue(id, out var soldier))
            {
                throw new Exception($"Soldier {id} not found");
            }
            return soldier;
        }
    }
}

