namespace Scripts.Model.Data
{
    using System.Collections.Generic;
    using UnityEngine;
    using System;
    using Scripts.Model.Definitions;

    [Serializable]
    public class InventoryData
    {
        [SerializeField] private List<InventoryItemData> _items = new List<InventoryItemData>();

        public void Add(string id, int value)
        {
            if (value <= 0) return;

            var itemDef = DefsFacade.I.Items.Get(id);
            if (itemDef.IsVoid) return;

            var item = GetItem(id);
            if (item == null)
            {
                item = new InventoryItemData(id);
                _items.Add(item);
            }

            item.Value += value;
        }

        public void Remove(string id, int value)
        {
            var itemDef = DefsFacade.I.Items.Get(id);
            if (itemDef.IsVoid) return;

            var item = GetItem(id);
            if (item == null) return;

            item.Value -= value;

            if (item.Value <= 0)
            {
                _items.Remove(item);
            }
        }

        private InventoryItemData GetItem(string id)
        {
            foreach (var itemData in _items)
            {
                if (itemData.Id == id)
                {
                    return itemData;
                }
            }

            return null;
        }

        public int Count(string id)
        {
            int count = 0;
            foreach (var item in _items)
            {
                if (item.Id == id)
                {
                    count += item.Value;
                }
            }

            return count;
        }
    }

    [Serializable]
    public class InventoryItemData
    {
        [InventoryId] public string Id = default;
        public int Value = 0;

        public InventoryItemData(string id)
        {
            Id = id;
        }
    }
}