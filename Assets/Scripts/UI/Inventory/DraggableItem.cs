namespace Scripts.UI.Inventory
{
    using System;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;

    public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private Image _icon = default;

        [HideInInspector]
        public Transform ParentAfterDrag = default;

        public static event Action OnEndDragChanged = default;

        public void OnBeginDrag(PointerEventData eventData)
        {
            ParentAfterDrag = transform.parent;
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            _icon.raycastTarget = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.SetParent(ParentAfterDrag);
            _icon.raycastTarget = true;
            OnEndDragChanged?.Invoke();
        }
    }
}