using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Gameplay.BadEvents
{
    public class BadEventColorFilter : ABadEvent
    {
        // Start is called before the first frame update
        void Awake()
        {
            Debug.Log("Bad Event activated : " + gameObject.GetInstanceID());
            Volume volume = Camera.main.GetComponent<Volume>();

            LiftGammaGain tmp;
            if (volume.profile.TryGet<LiftGammaGain>(out tmp))
            {
                tmp.active = true;
                tmp.gamma.value = new Vector4(0, 1, 0, 0); // Color RGBA
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
            LiftGammaGain tmp;
            if (volume.profile.TryGet<LiftGammaGain>(out tmp))
            {
                tmp.active = true;
                tmp.gamma.value = new Vector4(0, 0, 0, 0);
            }
        }
    }
}
