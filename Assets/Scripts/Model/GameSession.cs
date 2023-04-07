namespace Scripts.Model
{
    using Scripts.Model.Data;
    using UnityEngine;

    public class GameSession : MonoBehaviour
    {
        [SerializeField] private InventoryData _inventory = default;
        public InventoryData Inventory => _inventory;

        public static GameSession Instance { get; private set; }

        private void Awake()
        {
            if (IsSessionExists())
            {
                DestroyImmediate(gameObject);
            }
            else
            {
                DontDestroyOnLoad(this);
                Instance = this;
            }
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
            if (Instance == null)
            {
                Instance = null;
            }
        }
    }
}