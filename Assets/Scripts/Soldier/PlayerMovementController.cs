using UnityEngine;

namespace Soldier
{
    public class PlayerMovementController : MovementController
    {
        private Vector3 _movement;
        private void Update()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            _movement = new Vector3(horizontal, vertical, 0);
        }
        private void FixedUpdate()
        {
            Move();
        }
        public override void Move()
        {
            var velocity = Input.GetKey(KeyCode.LeftShift) ? _speedRun : _speedWalk;
            _rigidbody.velocity = _movement.y * velocity * transform.forward
                + _movement.x * velocity * transform.right
                + new Vector3(0, _rigidbody.velocity.y, 0);
        }
    }
}