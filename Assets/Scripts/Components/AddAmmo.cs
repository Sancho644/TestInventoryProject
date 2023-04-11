namespace Scripts.Components
{
    using Scripts.Model.Definitions;
    using UnityEngine;

    public class AddAmmo : BaseInventoryModify
    {
        [InventoryId] [SerializeField] private string[] _items = default;

        public void Add()
        {
            for (int i = 0; i < _items.Length; i++)
            {
                var itemId = DefsFacade.I.Items.Get(_items[i]);
                var value = itemId.MaxStack;
                _session.Inventory.AddStack(_items[i], value);
            }
        }
    }
}