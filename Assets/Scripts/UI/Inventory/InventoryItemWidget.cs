namespace Scripts.UI.Inventory
{
    using Scripts.Model.Data;
    using Scripts.Model.Definitions;
    using UnityEngine;
    using UnityEngine.UI;

    public class InventoryItemWidget : MonoBehaviour
    {
        [SerializeField] private Image _icon = default;
        [SerializeField] private Text _value = default;

        public void SetData(InventoryItemData item)
        {
            var def = DefsFacade.I.Items.Get(item.Id);
            _icon.sprite = def.Icon;
            _value.text = item.Value.ToString();

            if (item.Value > 1)
            {
                _value.gameObject.SetActive(true);
            }
            else
            {
                _value.gameObject.SetActive(false);
            }
        }        
    }
}