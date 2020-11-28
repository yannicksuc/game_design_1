using System;
using System.Collections.Generic;
using Cinemachine;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.BadEvents
{
    public class BadEventsManager : MonoBehaviour
    {
        [SerializeField] private PlayerConstitution playerConstitution;
        [SerializeField] private List<ABadEvent> eventPrefabs;
        private List<ABadEvent> usedPrefab = new List<ABadEvent>();

        private readonly List<ABadEvent> _instantiatedEvents = new List<ABadEvent>();
    
        private Random _rnd = new Random();

        void Awake()
        {
            playerConstitution.Reset();
        }

        // Update is called once per frame
        void Start()
        {
            playerConstitution.stress.StepReached.AddListener(evolution =>
            {
                if (evolution == PlayerStressCharacteristic.Evolution.Increasing)
                    Activate();
                else
                    Deactivate();
            });
        }

        void Activate()
        {
            if (eventPrefabs.Count <= 0)
                return;
            var idx = Random.Range(0, eventPrefabs.Count);
            var selectedEvent = eventPrefabs[idx];
            if (selectedEvent.maxNbClone > 0) {
                selectedEvent.maxNbClone -= 1;
            }
            if (selectedEvent.maxNbClone == 0) {
                eventPrefabs.RemoveAt(idx);
                usedPrefab.Add(selectedEvent);
            }

            var newEvent = Instantiate(selectedEvent);
            _instantiatedEvents.Add(newEvent);
        }

        void Deactivate()
        {
            if (_instantiatedEvents.Count <= 0)
                return;
            var idx = Random.Range (0, _instantiatedEvents.Count);
            
            cloneIncrement(eventPrefabs, idx);
            var canReuseIdx = cloneIncrement(usedPrefab, idx);
            if (canReuseIdx >= 0)
            {
                eventPrefabs.Add(usedPrefab[canReuseIdx]);
                usedPrefab.RemoveAt(canReuseIdx);
            }
            
            Destroy(_instantiatedEvents[idx]);
            _instantiatedEvents.RemoveAt(idx);
        }

        int cloneIncrement(List<ABadEvent> list, int idx)
        {
            for (var i = 0; i < list.Count; ++i)
            {
                if (_instantiatedEvents[idx].name.IndexOf(list[i].name, StringComparison.Ordinal) >= 0 &&
                    list[i].maxNbClone >= 0)
                {
                    list[i].maxNbClone += 1;
                    return i;
                }
            }
            return -1;
        }
    }
}
