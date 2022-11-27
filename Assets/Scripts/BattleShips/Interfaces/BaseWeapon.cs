using System;
using System.Collections;
using UnityEngine;

namespace BattleShips.Interfaces
{
    public class BaseWeapon : ICloneable
    {
        public readonly string PathToIcon;
        private readonly int _weaponCooldown;
        public readonly float WeaponDamage;
        public bool IsReady { get; set; }


        public BaseWeapon(string pathToIcon, int weaponCooldown, float weaponDamage)
        {
            PathToIcon = pathToIcon;
            _weaponCooldown = weaponCooldown;
            WeaponDamage = weaponDamage;
            IsReady = true;
        }

        public IEnumerator SetCooldown(float weaponCooldownReduce)
        {
            IsReady = false;
            yield return new WaitForSeconds((weaponCooldownReduce / 100) * _weaponCooldown);
            IsReady = true;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
