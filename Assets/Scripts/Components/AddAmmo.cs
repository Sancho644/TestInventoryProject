namespace Scripts.Components
{
    using Scripts.Model;
    using Scripts.Model.Definitions;
    using UnityEngine;

    public class AddAmmo : MonoBehaviour
    {
        [InventoryId] [SerializeField] private string _itemOne = default;
        [InventoryId] [SerializeField] private string _itemTwo = default;

        private GameSession _session = default;

        private void Start()
        {
            _session = GameSession.Instance;
        }

        public void Add()
        {
            var itemOne = DefsFacade.I.Items.Get(_itemOne);
            var itemTwo = DefsFacade.I.Items.Get(_itemTwo);

            var valueOne = itemOne.MaxStack;
            var valueTwo = itemTwo.MaxStack;

            _session.Inventory.Add(_itemOne, valueOne);
            _session.Inventory.Add(_itemTwo, valueTwo);
        }
    }
}