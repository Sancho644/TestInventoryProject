namespace Scripts.Model.Definitions.Items
{
    using UnityEngine;

    [CreateAssetMenu(menuName = "Defs/Items/AmmunitionOneDef", fileName = "AmmunitionOneDef")]
    public class AmmunitionOneDef : ScriptableObject
    {
        [SerializeField] private float _weight = 0.01f;
    }
}