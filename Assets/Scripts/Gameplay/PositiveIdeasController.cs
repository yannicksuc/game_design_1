using Player;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Debug = System.Diagnostics.Debug;

namespace Gameplay
{
    public class PositiveIdeasController : MonoBehaviour
    {
        [Header("Player stats")]
        [SerializeField] private PlayerConstitution constitution;
        [SerializeField] private float stressRatioInfluence;
        [SerializeField] private float onClickBreathRatioMargin;

        [Header("Positive ideas")]
        [SerializeField] private PositiveIdea positiveIdeaPreset;
        
        
        public class PositiveIdeaEvent : UnityEvent<PositiveIdea> {};
        private readonly PositiveIdeaEvent _onClick = new PositiveIdeaEvent();
    
        void Awake()
        {
            _onClick.AddListener(OnPointerClick);
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void SummonPositiveIdea()
        {
            Debug.Assert(Camera.main != null, "Camera.main != null");
            var screenPosition = Camera.main.ScreenToWorldPoint(
                new Vector3(Random.Range(0,Screen.width), 
                    Random.Range(0,Screen.height), 
                    Camera.main.farClipPlane / 2));
            var idea = Instantiate(positiveIdeaPreset, screenPosition, Quaternion.identity);
            idea.Init(_onClick, PositiveIdeasManager.Instance.GetRandomIdea());
        }

        private void OnPointerClick(PositiveIdea idea)
        {
            if (constitution.stress.Ratio <= onClickBreathRatioMargin ||
                (PlayerCharacteristic.Limit - constitution.stress.Ratio) <= onClickBreathRatioMargin)
            {
                idea.Destroy();
                constitution.stress.Ratio -= stressRatioInfluence;
            }
        }
    }
}
