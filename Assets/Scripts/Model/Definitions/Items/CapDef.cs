namespace Scripts.Model.Definitions.Items
{
    using UnityEngine;

    [CreateAssetMenu(menuName = "Defs/Items/CapDef", fileName = "CapDef")]
    public class CapDef : ScriptableObject
    {
        [SerializeField] private float _weight = 0.1f;
        [SerializeField] private int _defense = 3;
    }
}