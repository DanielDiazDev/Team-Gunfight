using UnityEngine;

namespace Inputs
{
    public class UnityInputAdapter : IInput
    {
        public Vector3 GetDirection()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            return new Vector3(horizontal, vertical);
        }

        public bool IsFireActionPressed()
        {
            return Input.GetButton("Fire1");
        }
    }
}