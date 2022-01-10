using System;
using System.Collections.Generic;
using Interfaces.CharacterBehaviour;
using Interfaces.Observer;
using UnityEngine;

namespace Stats
{
    public abstract class BasicStats: MonoBehaviour, IObservable, IHealth, IStamina
    {
        //Health
        public float Health;

        //Stamina
        public float Stamina;
        
        //Stats
        public Stat MaxHealth = new Stat();
        public Stat MaxStamina = new Stat();
        
        public Stat HealthGenRate = new Stat();
        public Stat StaminaGenRate = new Stat();
        
        //Observer
        private List<IObserver> _observers =new List<IObserver>();

        private void Awake()
        {
            Health = MaxHealth.GetValue();
            Stamina = MaxStamina.GetValue();
        }

        private void Update()
        {
            if (Health != MaxHealth.GetValue())
            {
                HealthGen((HealthGenRate.GetValue() * Time.deltaTime));
            }

            if (Stamina != MaxStamina.GetValue())
            {
                StaminaGen((StaminaGenRate.GetValue() * Time.deltaTime));
            }
            
        }

        public void HealthGen(float value)
        {
            Health = Mathf.Clamp(Health + value, 0, MaxHealth.GetValue());
            Notify();
        }

        public void DoDamage(float value)
        {
            Health = Mathf.Clamp(Health - value, 0, MaxHealth.GetValue());
            Notify();
        }

        public void StaminaGen(float value)
        {
            Stamina = Mathf.Clamp(Stamina + value, 0, MaxStamina.GetValue());
            Notify();
        }

        public void StaminaCost(float value)
        {
            Stamina = Mathf.Clamp(Stamina - value, 0, MaxStamina.GetValue());
            Notify();
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
            observer.UpdateData(this);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var VARIABLE in _observers)
            {
                VARIABLE.UpdateData(this);
            }
        }
    }
}