using System;
using UnityEngine;

namespace Soldier
{
    public class JumpController : MonoBehaviour
    {
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _radius;
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private float _gravity; //  -9.81f;
        private Rigidbody _rigidbody;
        [SerializeField] private bool _isGrounded;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        private void Update()
        {
            CheckGround();
            if (_isGrounded && Input.GetButtonDown("Jump")) // El input hacerle un metodo en los inputs
            {
                Jump();
            }
            ApplyGravity();
        }

        private void CheckGround()
        {
            _isGrounded = Physics.CheckSphere(_groundCheck.position, _radius, _groundMask);
        }
        private void Jump()
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
        private void ApplyGravity()
        {
            if (!_isGrounded)
            {
                _rigidbody.AddForce(Vector3.up * _gravity, ForceMode.Acceleration);
            }
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_groundCheck.position, _radius);
        }
    }
}