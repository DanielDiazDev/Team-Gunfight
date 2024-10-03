using UnityEngine;

namespace Inputs
{
    public interface IInput
    {
        Vector3 GetDirection();
        bool IsFireActionPressed();
    }
}