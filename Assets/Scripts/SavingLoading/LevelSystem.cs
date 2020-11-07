using System;
using UnityEngine;

namespace SavingLoading
{
    public class LevelSystem : MonoBehaviour, ISavable
    {
        [SerializeField] private int level = 1;
        [SerializeField] private int xp = 100;

        public object CaptureState()
        {
            return new SaveData
            {
                level = level,
                xp = xp
            };
        }

        public void RestoreData(object state)
        {
            var saveData = (SaveData)state;
            level = saveData.level;
            xp = saveData.xp;
        }

        [Serializable]
        private struct SaveData
        {
            public int level;
            public int xp;
        }
    }
}