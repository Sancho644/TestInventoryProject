﻿namespace Scripts.UI.Inventory
{
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class InventorySlot : MonoBehaviour, IDropHandler
    {
        [SerializeField] private GameObject _lockImage = default;

        private GameObject _dropped = default;
        private bool _isActive = true;

        public bool IsActive => _isActive;

        private void Start()
        {
            if (_isActive)
            {
                Destroy(_lockImage);
            }
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (transform.childCount == 0 || !transform.GetChild(0).gameObject.activeSelf && _isActive)
            {
                _dropped = eventData.pointerDrag;
                if (_dropped.TryGetComponent(out DraggableItem draggableItem))
                {
                    draggableItem.ParentAfterDrag = transform;
                }
            }
        }

        public void ActivateSlot()
        {
            _isActive = true;
            Destroy(_lockImage);
        }

        public void LockSlot()
        {
            _isActive = false;
            _lockImage.gameObject.SetActive(true);
        }
    }
}