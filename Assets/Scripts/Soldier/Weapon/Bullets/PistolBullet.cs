using UnityEngine;

namespace Soldier.Weapon.Bullets
{
    public class PistolBullet : Bullet
    {
        [SerializeField] private GameObject _impactEffectPrefab;
        [SerializeField] private float _bulletSpeed = 20f;
        protected override void DoStart()
        {
        }
        protected override void DoMove()
        {
            _rigidbody.velocity = _shootDirection * _bulletSpeed;
        }
        protected override void DoDestroy()
        {
        }
    }
}