using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Gameplay.BadEvents
{
    public class BadEventReverseScreen : ABadEvent
    {
        // Start is called before the first frame update
        void Awake()
        {
            Debug.Log("Bad Event activated : " + gameObject.GetInstanceID());
            Volume volume = Camera.main.GetComponent<Volume>();

            LensDistortion tmp;
            if (volume.profile.TryGet<LensDistortion>(out tmp))
            {
                tmp.active = true;
            }
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void OnDestroy()
        {
            Debug.Log("Bad Event deactivated: " + gameObject.GetInstanceID());
            Volume volume = Camera.main.GetComponent<Volume>();

            LensDistortion tmp;
            if (volume.profile.TryGet<LensDistortion>(out tmp))
            {
                tmp.active = false;
            }
        }
    }
}
