using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Soldier
{
    public abstract class MovementController : MonoBehaviour
    {
        protected float _speedWalk; //10
        protected float _speedRun; //20
        protected Animator _animator;
        protected Rigidbody _rigidbody;
        private ISoldier _soldier;
        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        public void Configure(ISoldier soldier, float speedWalk, float speedRun)
        {
            _soldier = soldier;
            _speedWalk = speedWalk;
            _speedRun = speedRun;

        }
        public abstract void Move();
        public virtual void SetCurrentTarget(Transform target)
        {
            Debug.Log("Esto es rotate");

        }
    }
}