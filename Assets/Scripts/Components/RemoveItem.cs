namespace Scripts.Components
{
    using Scripts.Model;
    using Scripts.Model.Definitions;
    using UnityEngine;

    public class RemoveItem : MonoBehaviour
    {
        private GameSession _session = default;

        private void Start()
        {
            _session = GameSession.Instance;
        }

        public void Remove()
        {
            var items = _session.Inventory.GetAll();
            if (items.Length == 0)
            {
                Debug.Log("Инвентарь пуст");
                return;
            }

            var rand = Random.Range(0, items.Length);
            var maxValue = DefsFacade.I.Items.Get(items[rand].Id);

            _session.Inventory.Remove(items[rand].Id, maxValue.MaxStack);
        }
    }
}