namespace Scripts.Model.Definitions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Defs/InventoryItems", fileName = "InventoryItems")]
    public class InventoryItemsDef : ScriptableObject
    {
        [SerializeField] private ItemDef[] _items = default;

        public ItemDef Get(string id)
        {
            ItemDef items = default;

            foreach (var itemDef in _items)
            {
                if (itemDef.Id == id)
                {
                    items = itemDef;
                }
            }

            return items;
        }

        public List<ItemDef> GetItemWithTag(ItemTag tag)
        {
            List<ItemDef> items = new List<ItemDef>();

            foreach (var item in _items)
            {
                if (item.HasTag(tag))
                {
                    items.Add(item);
                }
            }

            return items;
        }

#if UNITY_EDITOR
        public ItemDef[] ItemsForEditor => _items;
#endif
    }

    [Serializable]
    public struct ItemDef
    {
        [SerializeField] private string _id;
        [SerializeField] private Sprite _icon;
        [SerializeField] private int _maxStack;
        [SerializeField] private ItemTag[] _tags;

        public string Id => _id;
        public int MaxStack => _maxStack;
        public Sprite Icon => _icon;
        public bool IsVoid => string.IsNullOrEmpty(_id);

        public bool HasTag(ItemTag tag)
        {
            return _tags.Contains(tag);
        }
    }
}