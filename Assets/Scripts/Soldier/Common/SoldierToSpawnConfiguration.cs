using UnityEngine;

namespace Soldier.Common
{
    [CreateAssetMenu(menuName = "Create SoldierToSpawnConfiguration", fileName = "SoldierToSpawnConfiguration")]
    public class SoldierToSpawnConfiguration : ScriptableObject
    {
        [SerializeField] private SoldierId _soldierId;
        [SerializeField] private float _speedWalk;
        [SerializeField] private float _speedRun;
        [SerializeField] private float _health;
        [SerializeField] private bool _isPlayer;
        [SerializeField] private int _score;
        public SoldierId SoldierId => _soldierId;
        public float SpeedWalk => _speedWalk;
        public float SpeedRun => _speedRun;
        public float Health => _health;
        public bool IsPlayer => _isPlayer;
        public int Score => _score;
    }
}