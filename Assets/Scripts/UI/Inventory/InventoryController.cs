namespace Scripts.UI.Inventory
{
    using Scripts.Model;
    using Scripts.Model.Data;
    using System.Collections.Generic;
    using UnityEngine;

    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private Transform[] _container = default;
        [SerializeField] private InventoryItemWidget _prefab = default;

        private GameSession _session = default;
        private InventoryItemData[] _inventory = default;
        private List<InventoryItemWidget> _createdItems = new List<InventoryItemWidget>();

        public Transform[] Container => _container;

        private void Start()
        {
            _session = GameSession.Instance;
            _session.InventoryModel.OnChanged += Rebuild;
            _session.InventoryModel.OnRemoveItem += DeleteItem;
            _session.InventoryModel.OnAddItem += AddItem;
            DraggableItem.OnEndDragChanged += Rebuild;

            Rebuild();
        }

        private void Rebuild()
        {
            _inventory = _session.Inventory.GetAll();

            for (int i = _createdItems.Count; i < _inventory.Length; i++)
            {
                var item = Instantiate(_prefab, _container[i]);
                _createdItems.Add(item);
            }

            UpdateItem();
        }

        private void AddItem()
        {
            _inventory = _session.Inventory.GetAll();

            for (int i = 0; i < _inventory.Length; i++)
            {
                if (_container[i].childCount == 0)
                {
                    var item = Instantiate(_prefab, _container[i]);
                    _createdItems.Add(item);

                    break;
                }
            }

            UpdateItem();
        }

        private void DeleteItem()
        {
            _inventory = _session.Inventory.GetAll();

            for (int i = _inventory.Length; i < _createdItems.Count; i++)
            {
                Destroy(_createdItems[i].gameObject);
                _createdItems.Remove(_createdItems[i]);
            }

            UpdateItem();
        }

        private void UpdateItem()
        {
            for (int i = 0; i < _inventory.Length; i++)
            {
                _createdItems[i].SetData(_inventory[i]);
                _createdItems[i].gameObject.SetActive(true);
            }
        }

        private void OnDestroy()
        {
            _session.InventoryModel.OnChanged -= Rebuild;
            _session.InventoryModel.OnRemoveItem -= DeleteItem;
            _session.InventoryModel.OnAddItem -= AddItem;
            DraggableItem.OnEndDragChanged -= Rebuild;
        }
    }
}