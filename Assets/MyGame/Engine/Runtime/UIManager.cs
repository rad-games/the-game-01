using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheGame.Engine.UI
{
    public class UIManager : MonoSingleton<UIManager>
    {
        [SerializeField]
        Canvas _screenCanvas;

        Dictionary<string, UIScreen> _screens = new Dictionary<string, UIScreen>();

        void OnEnable()
        {
            int childCount = _screenCanvas.transform.childCount;
            for (int i = 0; i < childCount; ++i)
            {
                var child = _screenCanvas.transform.GetChild(i).GetComponent<UIScreen>();
                _screens.Add(child.SystemName, child);
                child.gameObject.SetActive(false);
            }
        }

        public void Open(string screenName)
        {
            _screens[screenName].gameObject.SetActive(true);
        }

        public void Close(string screenName)
        {
            _screens[screenName].gameObject.SetActive(false);
        }
    }
}