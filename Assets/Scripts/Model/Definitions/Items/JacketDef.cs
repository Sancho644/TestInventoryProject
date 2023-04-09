namespace Scripts.Model.Definitions.Items
{
    using UnityEngine;

    [CreateAssetMenu(menuName = "Defs/Items/JacketDef", fileName = "JacketDef")]
    public class JacketDef : ScriptableObject
    {
        [SerializeField] private float _weight = 1f;
        [SerializeField] private int _defense = 3;
    }
}