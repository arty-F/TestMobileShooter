using UnityEngine;

namespace Assets.Scripts.Infrastructure.ScriptableObjects
{
    [CreateAssetMenu(fileName = "CoinConfig", menuName = "ScriptableObjects/CoinConfig")]
    public class CoinConfig : ScriptableObject
    {
        public GameObject Prefab;

        [Tooltip("Импульс, при создании монеты.")]
        public Vector3 InitialForce = new Vector3(0f, 250f, 0f);

        [Tooltip("Вращение, при создании монеты.")]
        public Vector3 InitialTorque = new Vector3(0f, 5f, 0f);
    }
}
