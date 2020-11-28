using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Gameplay.BadEvents
{
    public class BadEventFlipScreen : ABadEvent
    {
        // Start is called before the first frame update
        protected override void Awake() {
            base.Awake();
            Debug.Log("Bad Event activated : " + gameObject.GetInstanceID());
            camera.gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void OnDestroy()
        {
            Debug.Log("Bad Event deactivated: " + gameObject.GetInstanceID());
            camera.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
