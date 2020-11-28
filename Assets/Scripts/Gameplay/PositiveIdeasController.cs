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
    public class PositiveIdeasController : MonoBehaviour, IPointerClickHandler
    {
        [Header("Player stats")]
        [SerializeField] private PlayerConstitution constitution;
        [SerializeField] private float stressRatioInfluence;
        [SerializeField] private float onClickBreathRatioMargin;

        [Header("Positive ideas")]
        [SerializeField] private PositiveIdea positiveIdeaPreset;
        [SerializeField] private int size = 50;
        
        
        private RectTransform _positiveIdeasFrame;
        public class PositiveIdeaEvent : UnityEvent<PositiveIdea> {};
        private readonly PositiveIdeaEvent _onClick = new PositiveIdeaEvent();
        private PositiveIdea _lastIdea = null;

        void Awake()
        {
            _positiveIdeasFrame = GetComponent<RectTransform>();
            _onClick.AddListener(OnPointerClick);
            constitution.breath.StepChange.AddListener(delegate{ StartCoroutine( nameof(ToggleIdea) ); });
        }

        private IEnumerator ToggleIdea()
        {
            var start = constitution.breath.Ratio;
            yield return new WaitUntil(() => Mathf.Abs(constitution.breath.Ratio - start) < onClickBreathRatioMargin);

            DestroyLastIdea();
            if (!IsPlayerMoving())
                SummonPositiveIdea();
        }

        private void SummonPositiveIdea()
        {
            Vector3 spawnPosition = GetBottomLeftCorner(_positiveIdeasFrame) - new Vector3(Random.Range(0 - size, _positiveIdeasFrame.rect.x * 2 + size), Random.Range(0 - size, _positiveIdeasFrame.rect.y * 2 + size), 0);

            _lastIdea = Instantiate(positiveIdeaPreset, spawnPosition, Quaternion.identity, _positiveIdeasFrame);
            var ideaData = PositiveIdeasManager.Instance.GetRandomIdea();
            ideaData.size = size;
            _lastIdea.Init(_onClick, PositiveIdeasManager.Instance.GetRandomIdea());
        }

        private void Update()
        {
            if (IsPlayerMoving()) {
                DestroyLastIdea();
            }
        }

        private void OnPointerClick(PositiveIdea idea)
        {
            if (constitution.breath.Ratio <= onClickBreathRatioMargin ||
                PlayerCharacteristic.Limit - constitution.breath.Ratio <= onClickBreathRatioMargin)
            {
                idea.Assimilate();
                _lastIdea = null;
                constitution.stress.Ratio -= stressRatioInfluence;
            }
            else
                DestroyLastIdea();
        }

        private bool IsPlayerMoving()
        {
            return Input.GetAxis("Horizontal") != 0 || constitution.velocity.magnitude != 0;
        }

        private Vector3 GetBottomLeftCorner(RectTransform rt)
        {
            Vector3[] v = new Vector3[4];
            rt.GetWorldCorners(v);
            return v[0];
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            DestroyLastIdea();
        }

        private void DestroyLastIdea()
        {
            if (_lastIdea != null)
            {
                _lastIdea.Destroy();
                _lastIdea = null;
            }
        }
    }
}
