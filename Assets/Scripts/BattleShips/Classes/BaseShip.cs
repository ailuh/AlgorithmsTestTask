using System.Collections.Generic;
using BattleShips.Interfaces;
using UnityEngine;

namespace BattleShips.Classes
{
    public class BaseShip : MonoBehaviour, IHealthValue, IShieldRecovery, IWeaponCooldown, IShieldValue, IWeaponDamage
    {
        public float Health { get; private set; }
        public float HealthMax { get; set; }
        public float ShieldMax { get; set; }
        public float WeaponDamage { get; private set; }
        public float ShieldRecharge { get; private set; }
        public float ShieldRechargeIncrease { get; set; }
        public int WeaponCooldown { get; }
        public float WeaponCooldownReduce { get; set; }
        public float Shield { get; set; }
        public bool IsAlive { get; private set; }

        private string _name;

        private List<BaseWeapon> _weaponSlots;
        private int _weaponSlotsNum;
        private List<IModule> _moduleSlots;
        private int _moduleSlotsNum;

        public BaseShip(int weaponCooldown)
        {
            WeaponCooldown = weaponCooldown;
        }


        public void Initialize(float startHealth, float startShield, float shieldRecharge, int slotNum, int weaponNum, string shipName)
        {
            ShieldRechargeIncrease = 100f;
            WeaponCooldownReduce = 100f;
            HealthMax = Health = startHealth;
            ShieldMax = Shield = startShield;   
            ShieldRecharge = shieldRecharge;
            _weaponSlotsNum = weaponNum;
            _moduleSlotsNum = slotNum;
            _name = shipName;
            IsAlive = true;
            _weaponSlots = new();
            _moduleSlots = new();
        }

        public bool SetModule(IModule newModule)
        {
            if (_moduleSlots.Count < _moduleSlotsNum)
            {
                _moduleSlots.Add(newModule);
                newModule.TurnOnModule(this);
                return true;
            }

            return false;
        }

        public bool DeleteModule(IModule module)
        {
            if (!_moduleSlots.Contains(module)) return false;
            module.TurnOffModule(this);
            _moduleSlots.Remove(module);
            return true;
        }

        public bool SetWeapon(BaseWeapon newBaseWeapon)
        {
                if (_weaponSlots.Count < _weaponSlotsNum)
            {
                _weaponSlots.Add(newBaseWeapon);
                WeaponDamage += newBaseWeapon.WeaponDamage;
                return true;
            }
            return false;
        }

        public bool DeleteWeapon(BaseWeapon baseWeapon)
        {
            var weapon = _weaponSlots.Find(x => x.PathToIcon == baseWeapon.PathToIcon); 
            if (!_weaponSlots.Contains(weapon)) return false;
            _weaponSlots.Remove(weapon);
            WeaponDamage -= weapon.WeaponDamage;
            return true;
        }

        private float GetDamage(float damage)
        {
            float finishDamage = 0;
            if (Shield - damage > 0)
            {
                Shield -= damage;
                finishDamage = damage;
            }
            else if (Shield - damage < 0)
            {
                var healthDamage = damage - Shield;
                Shield = 0;
                if (healthDamage > Health)
                {
                    Health = 0;
                    IsAlive = false;
                }
                else
                {
                    Health -= healthDamage;
                    finishDamage = healthDamage;
                }
            }

            return finishDamage;
        }
    
        public void MakeDamage(BaseShip enemyShip)
        {
            foreach (var weapon in _weaponSlots)
            {
                if (!weapon.IsReady) continue;
                var damage = enemyShip.GetDamage(weapon.WeaponDamage);
                StartCoroutine(weapon.SetCooldown(WeaponCooldownReduce));
                Debug.Log($"{_name} inflicts {enemyShip._name} {damage} damage");
            }
        }
    
    }
}
