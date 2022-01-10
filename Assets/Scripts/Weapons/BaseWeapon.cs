using System;
using Interfaces;
using Interfaces.CharacterBehaviour;
using Interfaces.WeaponBehaviour;
using JetBrains.Annotations;
using UnityEngine;

namespace Weapons
{
    public abstract class BaseWeapon : MonoBehaviour ,IHit, IWeapon
    {
        private bool _canHit = false;

        private String _team;

        [SerializeField]
        protected int _basicDamage;

        [SerializeField] protected float _range;

        protected string _combatModeString;

        public string TeamTag
        {
            get
            {
                return _team;
            }
            set
            {
                _team = value;
            }
        }

        public int Damage
        {
            get
            {
                return _basicDamage;
            }
        }

        public float Range
        {
            get
            {
                return _range;
            }
        }

        public string CombatModeString
        {
            get
            {
                return _combatModeString;
            }
        }

        public abstract void SetWeaponTypeTrue(Animator animator);

        public abstract void SetWeaponTypeFalse(Animator animator);

        public abstract int Combo1Tran();
        public abstract int Combo2Tran();
        public abstract int Combo3Tran();
        public abstract int Combo4Tran();
        public abstract int BasicAttackTran();

        public void Hit(IHitBox target, int value)
        {
            target.TakeDamage(value);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_canHit)
            {
                if (String.Compare(_team,"Enemy") == 0)
                {
                    if (!other.CompareTag("Enemy"))
                    {
                        if (other.GetComponent<IHitBox>() != null && _canHit)
                        {
                            Hit(other.GetComponent<IHitBox>(), _basicDamage);
                        }
                    }
                }
                else
                {
                    if (other.CompareTag("Enemy"))
                    {
                        if (other.GetComponent<IHitBox>() != null && _canHit)
                        {
                            Hit(other.GetComponent<IHitBox>(), _basicDamage);
                        }
                    }
                }
            }
        }

        public bool CanHit
        {
            get => _canHit;
            set => _canHit = value;
        }
    }
}