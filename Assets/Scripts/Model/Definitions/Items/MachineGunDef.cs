namespace Scripts.Model.Definitions.Items
{
    using UnityEngine;

    [CreateAssetMenu(menuName = "Defs/Items/MachineGunDef", fileName = "MachineGunDef")]
    public class MachineGunDef : ScriptableObject
    {
        [SerializeField] private float _weight = 5f;
        [SerializeField] private int _damage = 20;
    }
}