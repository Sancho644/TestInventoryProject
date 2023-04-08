namespace Scripts.Components
{
    using Scripts.Model;
    using Scripts.Model.Definitions;
    using UnityEngine;

    public class InventoryAddComponent : MonoBehaviour
    {
        [InventoryId] [SerializeField] private string _id = default;
        [SerializeField] private int _count = 0;

        private GameSession _session = default;

        private void Start()
        {
            _session = GameSession.Instance;
        }

        public void Add()
        {
            _session.Inventory.Add(_id, _count);
        }
    }
}