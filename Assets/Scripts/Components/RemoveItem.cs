namespace Scripts.Components
{
    using UnityEngine;

    public class RemoveItem : BaseInventoryModify
    {
        public void Remove()
        {
            var items = _session.Inventory.GetAll();
            if (items.Length == 0)
            {
                Debug.Log("Инвентарь пуст");
                return;
            }

            var rand = Random.Range(0, items.Length);

            _session.Inventory.Remove(items[rand].Id, items[rand].Value);
        }
    }
}