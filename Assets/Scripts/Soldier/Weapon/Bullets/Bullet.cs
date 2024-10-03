using Soldier.Common;
using System.Collections;
using UnityEngine;

namespace Soldier.Weapon.Bullets
{
    public abstract class Bullet : MonoBehaviour, IDamageable
    {
        protected Vector3 _shootDirection;
        protected Rigidbody _rigidbody;

        private string _soldierId;

        public Teams Team { get; private set; }
        public void Configure(Vector3 shootDirection, Teams team, string soldierId)
        {
            _shootDirection = shootDirection;
            Team = team;
            _soldierId = soldierId;
        }
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            DoStart();
            StartCoroutine(DestroyIn(5));
        }

        protected abstract void DoStart();

        private void FixedUpdate()
        {
            DoMove();
        }
        protected abstract void DoMove();
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent<IDamageable>(out var damageable))
            {
                if (damageable.Team == Team)
                {
                    return;
                }
                damageable.TakeDamage(90, _soldierId, Team);

            }
        }
        public void TakeDamage(float amount, string soldierId, Teams team)
        {
            DestroyBullet();
        }

        private IEnumerator DestroyIn(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            DestroyBullet();
        }

        private void DestroyBullet()
        {
            DoDestroy();
            Destroy(gameObject);
        }
        protected abstract void DoDestroy();

        

        
    }
}