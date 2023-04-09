namespace Scripts.Model.Definitions.Items
{
    using UnityEngine;

    [CreateAssetMenu(menuName = "Defs/Items/GunDef", fileName = "GunDef")]
    public class GunDef : ScriptableObject
    {
        [SerializeField] private float _weight = 1f;
        [SerializeField] private int _damage = 10;
    }
}