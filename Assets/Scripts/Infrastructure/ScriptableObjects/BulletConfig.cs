using UnityEngine;

namespace Assets.Scripts.Infrastructure.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BulletConfig", menuName = "ScriptableObjects/BulletConfig")]
    public class BulletConfig : ScriptableObject
    {
        [Tooltip("Префаб пули.")]
        public GameObject Prefab;

        [Tooltip("Урон, наносимый пулей.")]
        public float Damage = 1f;

        [Tooltip("Время существования пули.")]
        public float LifeTime = 3f;

        [Tooltip("Начальный вектор силы.")]
        public Vector3 StartingForce = new Vector3(0f, 0f, 3000f);
    }
}
