using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BattleShips.Classes;
using BattleShips.Interfaces;
using BattleShips.Modules;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace BattleShips
{
    public class TestBattle : MonoBehaviour
    {
        [FormerlySerializedAs("PanelAttack1")] [SerializeField] private GameObject panelAttack1;
        [FormerlySerializedAs("PanelAttack2")] [SerializeField] private GameObject panelAttack2;
        [FormerlySerializedAs("PanelModules1")] [SerializeField] private GameObject panelModules1;
        [FormerlySerializedAs("PanelModules2")] [SerializeField] private GameObject panelModules2;
        [FormerlySerializedAs("Ship1")] [SerializeField] private GameObject ship1;
        [FormerlySerializedAs("Ship2")] [SerializeField] private GameObject ship2;
    
        [FormerlySerializedAs("_statusesShip1")] [SerializeField] private TMP_Text[] statusesShip1;
        [FormerlySerializedAs("_statusesShip2")] [SerializeField] private TMP_Text[] statusesShip2;
    
        private IModule _moduleA;
        private IModule _moduleB;
        private IModule _moduleC;
        private IModule _moduleD;
    
        private readonly List<GameObject> _images = new ();
    
        private BaseWeapon _baseWeaponA;
        private BaseWeapon _baseWeaponB;
        private BaseWeapon _baseWeaponC;

        private BaseShip _battleShip1;
        private BaseShip _battleShip2;

        private bool _isAlive;
        void Start()
        {
            CreateModules();
            CreateWeapons();
            _battleShip1 = ship1.AddComponent<BaseShip>();
            _battleShip1.Initialize(100, 80, 1, 2, 2, "Ship1");
            _battleShip2 = ship2.AddComponent<BaseShip>();
            _battleShip2.Initialize(60, 80, 1, 2, 3, "Ship2");
            _isAlive = true;
            StartCoroutine(UpdateUI());
        }

        private void CreateModules()
        {
            _moduleA = new ModuleA();
            _moduleB = new ModuleB();
            _moduleC = new ModuleC();
            _moduleD = new ModuleD();
        }

        private void CreateWeapons()
        {
            _baseWeaponA = new BaseWeapon("weaponA", 3, 5);
            _baseWeaponB = new BaseWeapon("weaponB", 2, 4);
            _baseWeaponC = new BaseWeapon("weaponC", 5, 20);
        }

        public void SetWeaponAToShip1()
        {
            var isAdded = _battleShip1.SetWeapon((BaseWeapon)_baseWeaponA.Clone());
            SetWeapon(_baseWeaponA.PathToIcon, isAdded, panelAttack1, true);
        }

        public void ResetWeaponAShip1()
        {
            var isDeleted = _battleShip1.DeleteWeapon(_baseWeaponA);
            SetWeapon(_baseWeaponA.PathToIcon, isDeleted, panelAttack1, false);
        }

        public void SetWeaponBToShip1()
        {
            var isAdded = _battleShip1.SetWeapon((BaseWeapon)_baseWeaponB.Clone());
            SetWeapon(_baseWeaponB.PathToIcon, isAdded, panelAttack1, true);
        }

        public void ResetWeaponBShip1()
        {
            var isDeleted = _battleShip1.DeleteWeapon(_baseWeaponB);
            SetWeapon(_baseWeaponB.PathToIcon, isDeleted, panelAttack1, false);
        }

        public void SetWeaponCToShip1()
        {
            var isAdded = _battleShip1.SetWeapon((BaseWeapon)_baseWeaponC.Clone());
            SetWeapon(_baseWeaponC.PathToIcon, isAdded, panelAttack1, true);
        }

        public void ResetWeaponCShip1()
        {
            var isDeleted = _battleShip1.DeleteWeapon(_baseWeaponC);
            SetWeapon(_baseWeaponC.PathToIcon, isDeleted, panelAttack1, false);
        }
    
        public void SetWeaponAToShip2()
        {
            var isAdded = _battleShip2.SetWeapon((BaseWeapon)_baseWeaponA.Clone());
            SetWeapon(_baseWeaponA.PathToIcon, isAdded, panelAttack2, true);
        }

        public void ResetWeaponAShip2()
        {
            var isDeleted = _battleShip2.DeleteWeapon(_baseWeaponA);
            SetWeapon(_baseWeaponA.PathToIcon, isDeleted, panelAttack2, false);
        }

        public void SetWeaponBToShip2()
        {
            var isAdded = _battleShip2.SetWeapon((BaseWeapon)_baseWeaponB.Clone());
            SetWeapon(_baseWeaponB.PathToIcon, isAdded, panelAttack2, true);
        }

        public void ResetWeaponBShip2()
        {
            var isDeleted = _battleShip2.DeleteWeapon(_baseWeaponB);
            SetWeapon(_baseWeaponB.PathToIcon, isDeleted, panelAttack2, false);
        }

        public void SetWeaponCToShip2()
        {
            var isAdded = _battleShip2.SetWeapon((BaseWeapon)_baseWeaponC.Clone());
            SetWeapon(_baseWeaponC.PathToIcon, isAdded, panelAttack2, true);
        }

        public void ResetWeaponCShip2()
        {
            var isDeleted = _battleShip2.DeleteWeapon(_baseWeaponC);
            SetWeapon(_baseWeaponC.PathToIcon, isDeleted, panelAttack2, false);
        }
    
    
        public void SetModuleAToShip1()
        {
            var isAdded = _battleShip1.SetModule(_moduleA);
            SetWeapon(_moduleA.PathToIcon, isAdded, panelModules1, true);
        }

        public void ResetModuleAShip1()
        {
            var isDeleted = _battleShip1.DeleteModule(_moduleA);
            SetWeapon(_moduleA.PathToIcon, isDeleted, panelModules1, false);
        }
    
        public void SetModuleBToShip1()
        {
            var isAdded = _battleShip1.SetModule(_moduleB);
            SetWeapon(_moduleB.PathToIcon, isAdded, panelModules1, true);
        }

        public void ResetModuleBShip1()
        {
            var isDeleted = _battleShip1.DeleteModule(_moduleB);
            SetWeapon(_moduleB.PathToIcon, isDeleted, panelModules1, false);
        }
    
        public void SetModuleCToShip1()
        {
            var isAdded = _battleShip1.SetModule(_moduleC);
            SetWeapon(_moduleC.PathToIcon, isAdded, panelModules1, true);
        }

        public void ResetModuleCShip1()
        {
            var isDeleted = _battleShip1.DeleteModule(_moduleC);
            SetWeapon(_moduleC.PathToIcon, isDeleted, panelModules1, false);
        }
    
        public void SetModuleDToShip1()
        {
            var isAdded = _battleShip1.SetModule(_moduleD);
            SetWeapon(_moduleD.PathToIcon, isAdded, panelModules1, true);
        }

        public void ResetModuleDShip1()
        {
            var isDeleted = _battleShip1.DeleteModule(_moduleD);
            SetWeapon(_moduleD.PathToIcon, isDeleted, panelModules1, false);
        }
    
    
        public void SetModuleAToShip2()
        {
            var isAdded = _battleShip2.SetModule(_moduleA);
            SetWeapon(_moduleA.PathToIcon, isAdded, panelModules2, true);
        }

        public void ResetModuleAShip2()
        {
            var isDeleted = _battleShip2.DeleteModule(_moduleA);
            SetWeapon(_moduleA.PathToIcon, isDeleted, panelModules2, false);
        }
    
        public void SetModuleBToShip2()
        {
            var isAdded = _battleShip2.SetModule(_moduleB);
            SetWeapon(_moduleB.PathToIcon, isAdded, panelModules2, true);
        }

        public void ResetModuleBShip2()
        {
            var isDeleted = _battleShip2.DeleteModule(_moduleB);
            SetWeapon(_moduleB.PathToIcon, isDeleted, panelModules2, false);
        }
    
        public void SetModuleCToShip2()
        {
            var isAdded = _battleShip2.SetModule(_moduleC);
            SetWeapon(_moduleC.PathToIcon, isAdded, panelModules2, true);
        }

        public void ResetModuleCShip2()
        {
            var isDeleted = _battleShip2.DeleteModule(_moduleC);
            SetWeapon(_moduleC.PathToIcon, isDeleted, panelModules2, false);
        }
    
        public void SetModuleDToShip2()
        {
            var isAdded = _battleShip2.SetModule(_moduleD);
            SetWeapon(_moduleD.PathToIcon, isAdded, panelModules2, true);
        }

        public void ResetModuleDShip2()
        {
            var isDeleted = _battleShip2.DeleteModule(_moduleD);
            SetWeapon(_moduleD.PathToIcon, isDeleted, panelModules2, false);
        }
    
        private void SetWeapon(string path, bool isEquipped, GameObject panel, bool isActive)
        {
            if (!isEquipped) return;
            if (isActive)
            {
                var image = CreateImage(path);
                image.transform.SetParent(panel.transform);
                _images.Add(image);
            }
            else
            {
                var image = _images.First(x => x.name.Equals(path) && x.transform.parent.Equals(panel.transform));
                _images.Remove(image);
                Destroy(image);
            }
        }

        private GameObject CreateImage(string path)
        {
            GameObject imageObject = new GameObject();
            Image newImage = imageObject.AddComponent<Image>();
            imageObject.name = path;
            newImage.sprite = Resources.Load<Sprite>(path);
            return imageObject;
        }

        public void StartBattle()
        {
            _isAlive = true;
            StartCoroutine(RecoverShield(_battleShip1));
            StartCoroutine(Attack(_battleShip1, _battleShip2));
            StartCoroutine(RecoverShield(_battleShip2));
            StartCoroutine(Attack(_battleShip2, _battleShip1));
        }

        IEnumerator Attack(BaseShip shipAttacking, BaseShip shipAttacked)
        {
            while (_isAlive)
            {
                shipAttacking.MakeDamage(shipAttacked);
                _isAlive = _battleShip1.IsAlive && _battleShip2.IsAlive;
                if (!_battleShip1.IsAlive) ship1.GetComponent<MeshRenderer>().material.color = Color.red;
                if (!_battleShip2.IsAlive) ship2.GetComponent<MeshRenderer>().material.color = Color.red;
                yield return null;
            }
        }

        IEnumerator RecoverShield(BaseShip ship)
        {
            while (_isAlive)
            {
                if (ship.Shield + ship.ShieldRecharge * (ship.ShieldRechargeIncrease / 100) < ship.ShieldMax)
                {
                    ship.Shield += ship.ShieldRecharge * (ship.ShieldRechargeIncrease / 100);
                }
                else if(ship.Shield + ship.ShieldRecharge * (ship.ShieldRechargeIncrease / 100) > ship.ShieldMax)
                {
                    ship.Shield = ship.ShieldMax;
                }
                yield return new WaitForSeconds(1);
            }
        }

        IEnumerator UpdateUI()
        {
            while (_isAlive)
            {
                statusesShip1[0].text = $"HP {_battleShip1.Health}";
                statusesShip1[1].text = $"Shield {_battleShip1.Shield:0.00}";
                statusesShip1[2].text = $"Damage {_battleShip1.WeaponDamage:0.00}";
                statusesShip1[3].text = $"ShieldRec {(_battleShip1.ShieldRecharge * (_battleShip1.ShieldRechargeIncrease / 100)):0.00}";

                statusesShip2[0].text = $"HP {_battleShip2.Health}";
                statusesShip2[1].text = $"Shield {_battleShip2.Shield:0.00}";
                statusesShip2[2].text = $"Damage {_battleShip2.WeaponDamage:0.00}";
                statusesShip2[3].text = $"ShieldRec {(_battleShip2.ShieldRecharge * (_battleShip2.ShieldRechargeIncrease / 100)):0.00}";

                yield return null;
            }
        }
        

    }
}
