using UnityEngine;

namespace TheGame.Engine.UI
{
    public abstract class UIScreen : MonoBehaviour
    {
        public abstract string SystemName { get; }

        protected virtual void OnEnable()
        {
            gameObject.name = SystemName;
        }
    }
}