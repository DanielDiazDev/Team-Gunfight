using Soldier.Common;
using Soldier.Weapon.Bullets;
using UnityEngine;

namespace Soldier.Weapon
{
    public class Rifle : Weapon
    {
        public override void Shoot(Transform firePoint, Teams team, string soldierId)
        {
            if (Time.time < nextFireTime || isReloading || currentAmmo <= 0)
                return;

            Debug.Log(weaponData.weaponName + " shot fired!");
            currentAmmo--;
            nextFireTime = Time.time + weaponData.fireRate;
            // Instanciar la bala
            GameObject bulletInstance = Instantiate(weaponData.bulletPrefab, firePoint.position, firePoint.rotation);

            // Configurar la bala (dirección y equipo)
            Bullet bullet = bulletInstance.GetComponent<Bullet>();
            Vector3 shootDirection = firePoint.forward; // Dirección de disparo (enfrente del cañón)
            bullet.Configure(shootDirection, team, soldierId);

            // Lógica de disparo
        }

       
    }
}