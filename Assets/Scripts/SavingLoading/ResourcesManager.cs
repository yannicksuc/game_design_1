using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace SavingLoading
{
    public class ResourcesManager : MonoBehaviour
    {
        private string SavePath => $"{Application.persistentDataPath}/save.txt";

        private void Awake()
        {
            Load();
        }

        [ContextMenu("Save")]
        private void Save()
        {
            var state = LoadFile();

            CaptureState(state);
            Debug.Log(state);
            SaveFile(state);
        }
        
        [ContextMenu("Load")]

        private void Load()
        {
            var state = LoadFile();
            RestoreState(state);
        }

        private void SaveFile(object state)
        {
            using (var s = File.Open(SavePath, FileMode.Create))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(s, state);
            }
        }

        private void CaptureState(Dictionary<string, object> state)
        {
            foreach (var savable in FindObjectsOfType<SavableEntity>())
            {
                state[savable.Id] = savable.CaptureState();
            }
        }
        
        private void RestoreState(Dictionary<string, object> state)
        {
            foreach (var savable in FindObjectsOfType<SavableEntity>())
            {
                if (state.TryGetValue(savable.Id, out object value))
                    savable.RestoreState(value);
            }
        }

        private Dictionary<string, object> LoadFile()
        {
            if (!File.Exists(SavePath))
            {
                return new Dictionary<string, object>();
            }
            
            using (var s = File.Open(SavePath, FileMode.Create))
            {
                var formatter = new BinaryFormatter();
                if (s.Length <= 0)
                    return new Dictionary<string, object>();
                return (Dictionary<string, object>) formatter.Deserialize(s);
            }
        }
    }
}