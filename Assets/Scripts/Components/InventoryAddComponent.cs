namespace Scripts.Components
{
    using Scripts.Model;
    using Scripts.Model.Definitions;
    using UnityEngine;

    public class InventoryAddComponent : MonoBehaviour
    {
        [InventoryId] [SerializeField] private string _id;
        [SerializeField] private int _count;

        public void Add()
        {
            var session = GameSession.Instance;
            session.Inventory.Add(_id, _count);
        }
    }
}