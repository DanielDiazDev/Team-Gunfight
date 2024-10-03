using Soldier.Common;
using System;
using UnityEngine;

namespace Soldier.Weapon
{
    public abstract class WeaponController : MonoBehaviour
    {
        [SerializeField] protected Weapon[] _weapons;
        [SerializeField] protected Transform _firePoint;
        protected int _selectedWeaponIndex = 0;
        protected ISoldier _soldier;
        protected Teams _team;
        public void Configure(ISoldier soldier, int selectedWeaponIndex, Teams team)
        {
            _soldier = soldier;
            _selectedWeaponIndex = selectedWeaponIndex;
            _team = team;
        }
        private void Start()
        {
            SelectWeapon(_selectedWeaponIndex);
        }

        private void Update()
        {
            ChangeWeapon();
            
        }
        public abstract void ChangeWeapon();
        public abstract void Shoot();
        protected void SelectWeapon(int index)
        {
         //   if (index == selectedWeaponIndex) return;

            _selectedWeaponIndex = index;
            for (int i = 0; i < _weapons.Length; i++)
            {
                _weapons[i].gameObject.SetActive(i == _selectedWeaponIndex);
            }
            Debug.Log("Weapon selected: " + _weapons[_selectedWeaponIndex].weaponData.weaponName);
        }
    }
}