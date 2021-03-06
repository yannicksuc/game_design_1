﻿using UnityEngine;

namespace Gameplay.BadEvents
{
    public class BadEventExample : ABadEvent
    {
        // Start is called before the first frame update
        protected override void Awake() {
            base.Awake();
            Debug.Log("Bad Event activated : " + gameObject.GetInstanceID());
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void OnDestroy()
        {
            Debug.Log("Bad Event deactivated: " + gameObject.GetInstanceID());
        }
    }
}
