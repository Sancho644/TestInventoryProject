namespace Scripts.UI.Inventory
{
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class InventorySlot : MonoBehaviour, IDropHandler
    {
        private GameObject _dropped = default;
        private DraggableItem _draggableItem = default;

        public void OnDrop(PointerEventData eventData)
        {
            if (transform.childCount == 0)
            {
                _dropped = eventData.pointerDrag;
                _draggableItem = _dropped.GetComponent<DraggableItem>();
                _draggableItem.ParentAfterDrag = transform;
            }
        }
    }
}