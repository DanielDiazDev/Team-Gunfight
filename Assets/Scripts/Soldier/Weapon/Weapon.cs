using Soldier.Common;
using Soldier.Weapon.Bullets;
using System.Collections;
using UnityEngine;

namespace Soldier.Weapon
{
    public abstract class Weapon : MonoBehaviour
    {
        public WeaponData weaponData;
        protected int currentAmmo;
        protected bool isReloading = false;
        protected float nextFireTime = 0f;

        private void Start()
        {
            currentAmmo = weaponData.maxAmmo;
        }

        public abstract void Shoot(Transform firePoint, Teams team, string soldierId);

        public virtual IEnumerator Reload()
        {
            if (isReloading || currentAmmo == weaponData.maxAmmo) yield break;
            isReloading = true;

            Debug.Log(weaponData.weaponName + " is reloading...");
            yield return new WaitForSeconds(weaponData.reloadTime);

            currentAmmo = weaponData.maxAmmo;
            isReloading = false;
        }

        public virtual void SwitchWeapon()
        {
            Debug.Log("Switched to: " + weaponData.weaponName);
        }
    }

}