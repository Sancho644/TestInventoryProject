namespace Scripts.UI.Inventory
{
    using System.Collections.Generic;
    using UnityEngine;

    public class CreateInventorySlots : MonoBehaviour
    {
        [SerializeField] private int _inventorySize = 30;
        [SerializeField] private int _lockSlots = 15;
        [SerializeField] private InventorySlot _slotPrefab = default;
        [SerializeField] private InventorySlot[] _slots = default;

        private List<InventorySlot> _lockedSlots = default;

        public InventorySlot[] Slots => _slots;
        public List<InventorySlot> LockedSlots => _lockedSlots;

        private void Awake()
        {
            _slots = new InventorySlot[_inventorySize];
            _lockedSlots = new List<InventorySlot>();

            for (int i = 0; i < _inventorySize; i++)
            {
                _slots[i] = Instantiate(_slotPrefab, gameObject.transform);
                _slotPrefab.gameObject.SetActive(true);
            }

            for (int i = _lockSlots; i < _inventorySize; i++)
            {
                _slots[i].LockSlot();
                _lockedSlots.Add(_slots[i]);
            }
        }
    }
}