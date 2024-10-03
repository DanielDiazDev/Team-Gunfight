using UnityEngine;

namespace Soldier.Weapon
{
    public class PlayerWeaponController : WeaponController
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Shoot();
            }
        }
        public override void ChangeWeapon()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) SelectWeapon(0);
            if (Input.GetKeyDown(KeyCode.Alpha2)) SelectWeapon(1);
            if (Input.GetKeyDown(KeyCode.Alpha3)) SelectWeapon(2);
            if (Input.GetKeyDown(KeyCode.Alpha4)) SelectWeapon(3);
            if (Input.GetKeyDown(KeyCode.Alpha5)) SelectWeapon(4);
            if (Input.GetKeyDown(KeyCode.Alpha6)) SelectWeapon(5);
        }

        public override void Shoot()
        {
            _weapons[_selectedWeaponIndex].Shoot(_firePoint, _team, _soldier.Id);
        }
    }
}