namespace Scripts.Components
{
    using Scripts.Model.Definitions;
    using UnityEngine;

    public class AddRandomItems : BaseInventoryModify
    {
        [SerializeField] private int _value = 0;

        public void Add()
        {
            var gunItems = DefsFacade.I.Items.GetItemWhithTag(ItemTag.Gun);
            var headItems = DefsFacade.I.Items.GetItemWhithTag(ItemTag.Head);
            var torsoItems = DefsFacade.I.Items.GetItemWhithTag(ItemTag.Torso);

            var randomGunItem = Random.Range(0, gunItems.Count);
            var randomHeadItem = Random.Range(0, headItems.Count);
            var randomTorsoItem = Random.Range(0, torsoItems.Count);

            _session.Inventory.Add(gunItems[randomGunItem].Id, _value);
            _session.Inventory.Add(headItems[randomHeadItem].Id, _value);
            _session.Inventory.Add(torsoItems[randomTorsoItem].Id, _value);
        }
    }
}