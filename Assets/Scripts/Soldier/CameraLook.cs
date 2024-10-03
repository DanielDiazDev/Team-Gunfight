using UnityEngine;

namespace Soldier
{
    public class CameraLook : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Transform _player;
        private float _rotationX = 0f;
        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            // _rotationX = transform.localEulerAngles.x;

        }
        private void Update()
        {
            var mouseX = Input.GetAxis("Mouse X") * _speed * Time.deltaTime;
            var mouseY = Input.GetAxis("Mouse Y") * _speed * Time.deltaTime;

            _rotationX -= mouseY;
            _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);
            transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
            _player.Rotate(Vector3.up * mouseX);
        }
    }
}