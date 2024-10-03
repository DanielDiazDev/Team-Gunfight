using UnityEngine;

namespace Soldier.Weapon
{
    [CreateAssetMenu(fileName = "NewWeaponData", menuName = "Weapon/Weapon Data")]
    public class WeaponData : ScriptableObject
    {
        public string weaponName;
        public float damage;
        public float fireRate;
        public int maxAmmo;
        public float reloadTime;
        public bool hasZoom;
        public GameObject bulletPrefab;
        public float zoomFOV;  // Solo relevante para armas con zoom
    }
}