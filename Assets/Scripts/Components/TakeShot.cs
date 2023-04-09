namespace Scripts.Components
{
    using Scripts.Model;
    using Scripts.Model.Definitions;
    using System.Collections.Generic;
    using UnityEngine;

    public class TakeShot : MonoBehaviour
    {
        [InventoryId] [SerializeField] private string _itemOne = default;
        [InventoryId] [SerializeField] private string _itemTwo = default;
        [SerializeField] private int _count = 0;

        private GameSession _session = default;

        private void Start()
        {
            _session = GameSession.Instance;
        }

        public void Shot()
        {
            var items = _session.Inventory.GetAll();

            List<int> numbers = new List<int>();

            if (items.Length == 0)
            {
                return;
            }

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Id == _itemOne || items[i].Id == _itemTwo)
                {
                    numbers.Add(i);
                }
            }

            var item = Random.Range(0, numbers.Count);

            _session.Inventory.RandomRemove(_count, numbers[item]);
        }
    }
}