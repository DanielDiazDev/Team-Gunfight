using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace Soldier.Weapon
{
    public class AIWeaponController : WeaponController
    {
        [SerializeField] private float _radius;
        [SerializeField] private float _angle;
        [SerializeField] private LayerMask _soldierMask;
        [SerializeField] private LayerMask _obstacleMask;
        [SerializeField] private bool _canSeePlayer;
        private bool _weaponSelected;                                                    // [SerializeField] private Collider[] colliders;
        private void Start()
        {
            StartCoroutine(DetectEnemiesRoutine()); 
        }
        public override void ChangeWeapon()
        {
            if (!_weaponSelected)
            {
                SelectWeapon(UnityEngine.Random.Range(0, _weapons.Count()));
                _weaponSelected = true;
            }
            if (_canSeePlayer)
            {
                Shoot();
            }
        }

        public override void Shoot()
        {
            _weapons[_selectedWeaponIndex].Shoot(_firePoint, _team, _soldier.Id);
        }
        private IEnumerator DetectEnemiesRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.2f);
                DetectEnemies();
            }
        }
        private void DetectEnemies()
        {
            var colliders = Physics.OverlapSphere(transform.position, _radius, _soldierMask);
            _canSeePlayer = false;
            foreach (var collider in colliders)
            {
                var target = collider.transform;
                if(target == transform)
                {
                    continue;
                }
                var directionToTarget = (target.position - transform.position).normalized;
                var isDifferentTeam = target.gameObject.GetComponent<SoldierMediator>().Team != transform.gameObject.GetComponent<SoldierMediator>().Team;
                if (Vector3.Angle(transform.forward, directionToTarget) <= _angle / 2 && isDifferentTeam)
                {
                    if (!IsObstructed(target))
                    {
                        Debug.Log("Objetivo detectado: " + target.name);
                        _soldier.SetRotation(target);
                        _canSeePlayer = true;
                    }
                    else
                    {
                        Debug.Log("Objetivo obstruido: " + target.name);
                        _canSeePlayer = false;
                    }
                }
            }
        }
        // Método para verificar si hay una obstrucción entre el enemigo y el objetivo
        private bool IsObstructed(Transform target)
        {
            // Lanzamos un Raycast desde los ojos del enemigo hacia el objetivo para ver si algo bloquea la visión
            RaycastHit hit;
            if (Physics.Raycast(transform.position, (target.position - transform.position).normalized, out hit, _radius, _obstacleMask))
            {
                // Si el Raycast impacta con algo antes de llegar al objetivo, significa que está obstruido
                if (hit.transform != target)
                {
                    return true;  // Está obstruido
                }
            }

            return false;  // No está obstruido
        }
      
        private void OnDrawGizmos()
        {
            //Radio
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _radius);

            //Vision
            Gizmos.color = Color.blue;
            var leftBoundary = Quaternion.Euler(0, -_angle / 2, 0) * transform.forward * _radius;
            var rightBoundary = Quaternion.Euler(0, _angle / 2, 0) * transform.forward * _radius;
            Gizmos.DrawRay(transform.position, leftBoundary);
            Gizmos.DrawRay(transform.position, rightBoundary);
        }
    }
}