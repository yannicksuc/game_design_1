using System;
using System.Collections;
using System.IO;
using Player;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Debug = System.Diagnostics.Debug;
using Random = UnityEngine.Random;

namespace Gameplay
{
    [RequireComponent(typeof(PositiveIdea))]
    public class PositiveIdeasController : MonoBehaviour
    {
        [Header("Player stats")]
        [SerializeField] private PlayerConstitution constitution;
        [SerializeField] private float stressRatioInfluence;
        [SerializeField] private float onClickBreathRatioMargin;

        [Header("Positive ideas")]
        [SerializeField] private PositiveIdea positiveIdeaPreset;
        [SerializeField] private RectTransform positiveIdeasFrame;
        [SerializeField] private int size = 50;
        
        
        public class PositiveIdeaEvent : UnityEvent<PositiveIdea> {};
        private readonly PositiveIdeaEvent _onClick = new PositiveIdeaEvent();
        private PositiveIdea _lastIdea = null;

        private float toto = 0;
        void Awake()
        {
            _onClick.AddListener(OnPointerClick);
            constitution.breath.StepChange.AddListener(delegate{ StartCoroutine( nameof(ToggleIdea) ); });
        }

        private IEnumerator ToggleIdea()
        {
            var start = constitution.breath.Ratio;
            yield return new WaitUntil(() => Mathf.Abs(constitution.breath.Ratio - start) < onClickBreathRatioMargin);

            if (_lastIdea != null)
            {
                _lastIdea.Destroy();
                _lastIdea = null;
            }

            SummonPositiveIdea();
        }

        private void SummonPositiveIdea()
        {
            Vector3 spawnPosition = GetBottomLeftCorner(positiveIdeasFrame) - new Vector3(Random.Range(0 - size, positiveIdeasFrame.rect.x * 2 + size), Random.Range(0 - size, positiveIdeasFrame.rect.y * 2 + size), 0);

            print("Spawn image at position: " + spawnPosition);

            _lastIdea = Instantiate(positiveIdeaPreset, spawnPosition, Quaternion.identity, positiveIdeasFrame);
            var ideaData = PositiveIdeasManager.Instance.GetRandomIdea();
            ideaData.size = size;
            _lastIdea.Init(_onClick, PositiveIdeasManager.Instance.GetRandomIdea());
        }

        private void OnPointerClick(PositiveIdea idea)
        {
            if (constitution.stress.Ratio <= onClickBreathRatioMargin ||
                (PlayerCharacteristic.Limit - constitution.stress.Ratio) <= onClickBreathRatioMargin)
            {
                idea.Assimilate();
                _lastIdea = null;
                constitution.stress.Ratio -= stressRatioInfluence;
            }
        }

        Vector3 GetBottomLeftCorner(RectTransform rt)
        {
            Vector3[] v = new Vector3[4];
            rt.GetWorldCorners(v);
            return v[0];
        }
    }
}
