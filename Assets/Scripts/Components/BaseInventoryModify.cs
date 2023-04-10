namespace Scripts.Components
{
    using Scripts.Model;
    using UnityEngine;

    public class BaseInventoryModify : MonoBehaviour
    {
        protected GameSession _session = default;

        private void Start()
        {
            _session = GameSession.Instance;
        }
    }
}