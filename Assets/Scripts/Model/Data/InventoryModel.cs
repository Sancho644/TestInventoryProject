namespace Scripts.Model.Data
{
    using System;

    public class InventoryModel
    {
        private readonly InventoryData _inventory = default;

        public event Action OnChanged = default;

        public InventoryModel(InventoryData inventory)
        {
            _inventory = inventory;
            _inventory.OnChanged += OnInventoryChanged;
        }

        private void OnInventoryChanged(string id, int value)
        {
            OnChanged?.Invoke();
        }
    }
}