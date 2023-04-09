namespace Scripts.Model.Definitions.Items
{
    using UnityEngine;

    [CreateAssetMenu(menuName = "Defs/Items/AmmunitionTwoDef", fileName = "AmmunitionTwoDef")]
    public class AmmunitionTwoDef : ScriptableObject
    {
        [SerializeField] private float _weight = 0.01f;
    }
}