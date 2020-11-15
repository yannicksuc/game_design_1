using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Gameplay.BadEvents
{
    public class BadEventsManager : MonoBehaviour
    {
        [SerializeField] private PlayerConstitution playerConstitution;
        [SerializeField] private List<ABadEvent> eventPrefabs;

        private readonly List<ABadEvent> _instantiatedEvents = new List<ABadEvent>();
    
        private Random _rnd = new Random();
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
            var selectedEvent = eventPrefabs[Random.Range (0, eventPrefabs.Count)];
            var newEvent = Instantiate(selectedEvent);
            _instantiatedEvents.Add(newEvent);
        }

        void Deactivate()
        {
            if (_instantiatedEvents.Count <= 0)
                return;
            var idx = Random.Range (0, _instantiatedEvents.Count);
            GameObject.Destroy(_instantiatedEvents[idx]);
            _instantiatedEvents.RemoveAt(idx);
        }
    }
}
