namespace Scripts.Model.Definitions.Items
{
    using UnityEngine;

    [CreateAssetMenu(menuName = "Defs/Items/BodyArmorDef", fileName = "BodyArmorDef")]
    public class BodyArmorDef : ScriptableObject
    {
        [SerializeField] private float _weight = 10f;
        [SerializeField] private int _defense = 10;
    }
}