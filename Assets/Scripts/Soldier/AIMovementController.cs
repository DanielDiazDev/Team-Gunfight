using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace Soldier
{
    public class AIMovementController : MovementController
    {
        private NavMeshAgent _agent;
        public float wanderRadius = 10f;    // Radio de movimiento aleatorio
        public float wanderTimer = 5f;      // Tiempo para cambiar de destino
        public float rotationSpeed = 3f;    // Velocidad de rotación del bot
        public float stoppingDistance = 1f; // Distancia mínima para considerar que ha llegado al destino
        private Vector3 _destination;
        private float _timer;
        public float maxFollowDistance = 15f; // Distancia máxima para seguir al objetivo
        private Vector3 _direction;
        private Transform _currentTarget; // Almacena el objetivo actual
        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _timer = wanderTimer;
            _destination = transform.position;
        }
        private void FixedUpdate()
        {
            if (_currentTarget != null) // Si hay un objetivo detectado
            {
                float distanceToTarget = Vector3.Distance(transform.position, _currentTarget.position);
                if (distanceToTarget <= maxFollowDistance)
                {
                    RotateTowardsTarget(_currentTarget);
                    // No mover si se está rotando hacia el objetivo
                }
                else
                {
                    // Deja de apuntar si el objetivo está fuera de rango
                    _currentTarget = null; // Dejar de apuntar
                }
            }
            else
            {
                Move(); // Solo moverse si no hay objetivo
            
            }
        }

        public override void Move()
        {
            _timer += Time.deltaTime;
            if (_timer >= wanderTimer || Vector3.Distance(transform.position, _destination) <= stoppingDistance)
            {
                _destination = RandomNavMeshLocation(wanderRadius);
                _timer = 0f;
            }
            _direction = (_destination - transform.position).normalized;
            Vector3 moveVelocity = _direction * _speedWalk;
            _rigidbody.velocity = new Vector3(moveVelocity.x, _rigidbody.velocity.y, moveVelocity.z);
        }

        private void Rotate(Vector3 direction)
        {
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
        private void RotateTowardsTarget(Transform target)
        {
            if (target != null)
            {
                Vector3 direction = (target.position - transform.position).normalized;
                Rotate(direction);
            }
        }
        // Método para establecer el objetivo actual
        public override void SetCurrentTarget(Transform target)
        {
            _currentTarget = target;
        }
        private Vector3 RandomNavMeshLocation(float radius)
        {
            var randomDirection = UnityEngine.Random.insideUnitSphere * radius;
            randomDirection += transform.position;
            NavMeshHit hit;
            if(NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
            {
                return hit.position;
            }
            return transform.position;
        }
    }
}