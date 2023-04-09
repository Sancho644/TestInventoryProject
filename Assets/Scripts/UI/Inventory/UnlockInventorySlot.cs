namespace Scripts.UI.Inventory
{
    using UnityEngine;
    using UnityEngine.UI;

    public class UnlockInventorySlot : MonoBehaviour
    {
        [SerializeField] private int _currentCoins = 5;
        [SerializeField] private int _unlockPrice = 10;
        [SerializeField] private Button _button = default;
        [SerializeField] private InventorySlot[] _slots = default;

        private void Awake()
        {
            foreach (var slot in _slots)
            {
                slot.LockSlot();
            }
        }

        public void Unlock()
        {
            if (_unlockPrice <= _currentCoins)
            {
                foreach (var slot in _slots)
                {
                    slot.ActivateSlot();
                }

                _currentCoins -= _unlockPrice;
                _button.interactable = false;
            }
            else
            {
                Debug.Log($"Недостаточно монет для разблокирования слотов инвенторя. Монеты: {_currentCoins} Цена: {_unlockPrice}");
            }
        }
    }
}