namespace Scripts.Model
{
    using Scripts.Model.Data;
    using Scripts.Model.Data.Properties;
    using UnityEngine;

    public class GameSession : MonoBehaviour
    {
        [SerializeField] private InventoryData _inventory = default;

        private SaveSystem _systemData = default;
        private SaveData _inventoryData = new SaveData();

        public InventoryData Inventory => _inventory;
        public InventoryModel InventoryModel { get; private set; }

        public static GameSession Instance { get; private set; }

        private void Awake()
        {
            _systemData = new SaveSystem();

            if (IsSessionExists())
            {
                DestroyImmediate(gameObject);
            }
            else
            {
                LoadSystem();
                InitModels();
                DontDestroyOnLoad(this);
                Instance = this;
            }
        }

        private void LoadSystem()
        {
            _inventoryData = _systemData.Load();
        }

        public void SaveInventory()
        {
            _inventoryData.SaveItems = _inventory.Items;
            _systemData.Save(_inventoryData);
        }

        private void InitModels()
        {
            _inventory.EnableSave(_inventoryData.SaveItems);
            InventoryModel = new InventoryModel(Inventory);
        }

        private bool IsSessionExists()
        {
            var session = FindObjectsOfType<GameSession>();
            foreach (var gameSession in session)
            {
                if (gameSession != this)
                {
                    return true;
                }
            }

            return false;
        }

        private void OnDestroy()
        {
            SaveInventory();

            if (Instance == null)
            {
                Instance = null;
            }
        }
    }
}