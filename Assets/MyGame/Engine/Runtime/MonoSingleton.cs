using UnityEngine;

namespace TheGame.Engine
{
    public class MonoSingleton<TType> : MonoBehaviour
        where TType : MonoSingleton<TType>
    {
        [SerializeField]
        bool _dontDestroyOnLoad = true;

        public static TType Instance { get; private set; }

        protected virtual void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError($"[Singleton] Duplicate Singleton spawned. old:'{Instance.name}', new: '{name}'");
                Destroy(this);
                return;
            }
            Instance = (TType)this;

            if (_dontDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }
        }

        protected virtual void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }
    }
}