namespace Scripts.Model.Definitions.Items
{
    using UnityEngine;

    [CreateAssetMenu(menuName = "Defs/Items/HelmetDef", fileName = "HelmetDef")]
    public class HelmetDef : ScriptableObject
    {
        [SerializeField] private float _weight = 1f;
        [SerializeField] private int _defense = 10;
    }
}