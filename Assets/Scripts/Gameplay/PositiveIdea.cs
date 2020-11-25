using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
            var r = GetComponent<RectTransform>().rect;
            GetComponent<RectTransform>().rect.Set(r.size.x, r.size.y, data.size, data.size);
            GetComponent<Image>().sprite = data.sprite;
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
