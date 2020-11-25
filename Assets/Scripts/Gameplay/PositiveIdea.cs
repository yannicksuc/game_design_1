using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

namespace Gameplay
{
    public class PositiveIdea : MonoBehaviour, IPointerClickHandler
    {
        private PositiveIdeasController.PositiveIdeaEvent _onClick = null;

        private bool _active = false;

        public void Init(PositiveIdeasController.PositiveIdeaEvent onClick, PositiveIdeaData data)
        {
            _onClick = onClick;
            _active = true;
        }
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void Destroy()
        {
            _active = false;
            Destroy(gameObject);
        }
        
        public void Assimilate()
        {
            _active = false;
            Destroy(gameObject);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_active)
                _onClick.Invoke(this);
        }
    }
}
