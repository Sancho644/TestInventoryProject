namespace Scripts.Model.Data
{
    using System.Collections.Generic;
    using UnityEngine;
    using System;
    using Scripts.Model.Definitions;
    using System.Linq;

    [Serializable]
    public class InventoryData
    {
        [SerializeField] private List<InventoryItemData> _items = new List<InventoryItemData>();

        private bool _isFullStack = false;
        private InventoryItemData _item = default;

        public List<InventoryItemData> Items => _items;

        public delegate void OnInventoryChanged(string id, int value);

        public OnInventoryChanged OnChanged = default;

        public void Add(string id, int value)
        {
            if (value <= 0) return;

            var itemDef = DefsFacade.I.Items.Get(id);
            if (itemDef.IsVoid) return;

            _item = GetItem(id);
            _isFullStack = false;

            AddItemToStack(id, value, itemDef);

            var emptySlots = GameSession.Instance.Slots;
            for (int i = 0; i < emptySlots.Length; i++)
            {
                if (emptySlots[i].transform.childCount == 0 || !emptySlots[i].transform.GetChild(0).gameObject.activeSelf)
                {
                    CheckItem(id, itemDef);

                    _item.Value += value;

                    OnChanged?.Invoke(id, Count(id));

                    break;
                }
            }
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

            OnChanged?.Invoke(id, Count(id));
        }

        public void RandomRemove(int value, int randomValue)
        {
            var id = _items[randomValue].Id;

            var itemDef = DefsFacade.I.Items.Get(id);
            if (itemDef.IsVoid) return;

            var item = GetItem(id);
            if (item == null) return;

            _items[randomValue].Value -= value;

            if (_items[randomValue].Value <= 0)
            {
                _items.Remove(_items[randomValue]);
            }

            OnChanged?.Invoke(id, Count(id));
        }

        public void EnableSave(List<InventoryItemData> saveList)
        {
            _items = saveList;
        }

        private void AddItemToStack(string id, int value, ItemDef itemDef)
        {
            if (_item != null)
            {
                if (_item.Value >= itemDef.MaxStack)
                {
                    StackIsFull(id);
                }

                if (!_isFullStack)
                {
                    _item.Value += value;
                    _item.Value = Mathf.Clamp(_item.Value, 0, itemDef.MaxStack);

                    OnChanged?.Invoke(id, Count(id));
                }
            }
        }

        private void CheckItem(string id, ItemDef itemDef)
        {
            if (_item == null)
            {
                CreateNewItem(id);
            }

            if (_item.Value >= itemDef.MaxStack)
            {
                StackIsFull(id);
            }

            if (_isFullStack)
            {
                CreateNewItem(id);
            }
        }

        private InventoryItemData StackIsFull(string id)
        {
            var itemDef = DefsFacade.I.Items.Get(id);

            foreach (var emptyStack in _items)
            {
                if (emptyStack.Value < itemDef.MaxStack && emptyStack.Id == itemDef.Id)
                {
                    _isFullStack = false;

                    return _item = emptyStack;
                }
                else
                {
                    _isFullStack = true;
                }
            }

            return null;
        }

        private void CreateNewItem(string id)
        {
            _item = new InventoryItemData(id);
            _items.Add(_item);
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

        public InventoryItemData[] GetAll(params ItemTag[] tags)
        {
            var retValue = new List<InventoryItemData>();
            foreach (var item in _items)
            {
                var itemDef = DefsFacade.I.Items.Get(item.Id);
                var isAllRequirementsMet = tags.All(x => itemDef.HasTag(x));
                if (isAllRequirementsMet)
                {
                    retValue.Add(item);
                }
            }

            return retValue.ToArray();
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