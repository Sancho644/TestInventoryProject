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

        private void Start()
        {
            _session = GameSession.Instance;
            _session.InventoryModel.OnChanged += Rebuild;

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

            for (int i = 0; i < _inventory.Length; i++)
            {
                _createdItems[i].SetData(_inventory[i]);
                _createdItems[i].gameObject.SetActive(true);
            }

            for (int i = _inventory.Length; i < _createdItems.Count; i++)
            {
                _createdItems[i].gameObject.SetActive(false);
            }
        }

        private void OnDestroy()
        {
            _session.InventoryModel.OnChanged -= Rebuild;
        }
    }
}