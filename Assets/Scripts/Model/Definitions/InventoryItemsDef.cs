﻿namespace Scripts.Model.Definitions
{
    using System;
    using System.Linq;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Defs/InventoryItems", fileName = "InventoryItems")]
    public class InventoryItemsDef : ScriptableObject
    {
        [SerializeField] private ItemDef[] _items = default;

        public ItemDef Get(string id)
        {
            foreach (var itemDef in _items)
            {
                if (itemDef.Id == id)
                {
                    return itemDef;
                }
            }

            return default;
        }

#if UNITY_EDITOR
        public ItemDef[] ItemsForEdotor => _items;
#endif
    }

    [Serializable]
    public struct ItemDef
    {
        [SerializeField] private string _id;
        [SerializeField] private Sprite _icon;
        [SerializeField] private ItemTag[] _tags;

        public string Id => _id;

        public bool IsVoid => string.IsNullOrEmpty(_id);

        public Sprite Icon => _icon;

        public bool HasTag(ItemTag tag)
        {
            return _tags.Contains(tag);
        }
    }
}