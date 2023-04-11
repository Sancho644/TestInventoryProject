namespace Scripts.Model.Data
{
    using System;

    public class InventoryModel
    {
        private readonly InventoryData _inventory = default;

        public event Action OnChanged = default;
        public event Action OnRemoveItem = default;
        public event Action OnAddItem = default;

        public InventoryModel(InventoryData inventory)
        {
            _inventory = inventory;
            _inventory.OnChanged += OnInventoryChanged;
            _inventory.OnRemove += OnRemove;
            _inventory.OnAdd += OnAdd;
        }

        private void OnAdd()
        {
            OnAddItem?.Invoke();
        }

        private void OnRemove()
        {
            OnRemoveItem?.Invoke();
        }

        private void OnInventoryChanged(string id, int value)
        {
            OnChanged?.Invoke();
        }
    }
}