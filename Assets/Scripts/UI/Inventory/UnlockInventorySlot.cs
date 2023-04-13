namespace Scripts.UI.Inventory
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class UnlockInventorySlot : MonoBehaviour
    {
        [SerializeField] private int _currentCoins = 5;
        [SerializeField] private int _unlockPrice = 10;
        [SerializeField] private Button _button = default;
        [SerializeField] private List<InventorySlot> _lockedSlots = default;
        [SerializeField] private CreateInventorySlots _lockSlots = default;

        private void Awake()
        {
            _lockedSlots = _lockSlots.LockedSlots;
        }

        public void Unlock()
        {
            if (_unlockPrice <= _currentCoins)
            {
                foreach (var slot in _lockedSlots)
                {
                    slot.ActivateSlot();
                }

                _currentCoins -= _unlockPrice;
                _button.interactable = false;
            }
            else
            {
                Debug.Log($"Недостаточно монет для разблокирования слотов инвентаря. Монеты: {_currentCoins} Цена: {_unlockPrice}");
            }
        }
    }
}