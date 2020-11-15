using System;
using System.Dynamic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Player
{
    [Serializable]
    public class PlayerCharacteristic
    {
        public const uint Limit = 1;
        [ShowOnly] [SerializeField] private float ratio;

        public float Ratio
        {
            get => ratio;
            set => SetRatio(value);
        }

        public float cooldown;

        protected virtual void SetRatio(float value)
        {
            if (value > Limit)
                ratio = Limit;
            else if (value < 0)
                ratio = 0;
            else
                ratio = value;
        }
    }

    [Serializable]
    public class PlayerStressCharacteristic : PlayerCharacteristic
    {
        public int steps;

        public enum Evolution
        {
            Increasing,
            Decreasing
        }

        public class StressStepEvent : UnityEvent<Evolution>
        {
        }

        public StressStepEvent StepReached = new StressStepEvent();

        protected override void SetRatio(float value)
        {
            var newStep = GetStepFromRatio(value);
            var currentStep = GetStepFromRatio(Ratio);

            for (int step = newStep; step < currentStep; step++)
                StepReached.Invoke(Evolution.Decreasing);
            for (int step = currentStep; step < newStep; step++)
                StepReached.Invoke(Evolution.Increasing);

            base.SetRatio(value);
        }

        private int GetStepFromRatio(float ratio)
        {
            return (int) Math.Truncate(steps * ratio / Limit);
        }
    }
    
    public enum BreathStep
    {
        Inhale = 1,
        Exhale = -1
    }

    [Serializable]
    public class PlayerBreathCharacteristic : PlayerCharacteristic
    {
        private BreathStep _step;

        public BreathStep Step
        {
            get => _step;
            set
            {
                if (value != _step)
                    StepChange.Invoke();
                Ratio = value == BreathStep.Inhale ? 0 : Limit;
                _step = value;
            }
        }

        [HideInInspector] public UnityEvent StepChange = new UnityEvent();
    }
}