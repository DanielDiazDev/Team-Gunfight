using UnityEngine;
namespace Soldier
{
    [CreateAssetMenu(menuName = "Create SoldierId", fileName = "SoldierId")]
    public class SoldierId : ScriptableObject
    {
        [SerializeField] private string _value;
        public string Value => _value;
    }
}
