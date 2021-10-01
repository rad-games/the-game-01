using System.Collections;
using System.Collections.Generic;
using TheGame.Engine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TheGame.UI
{
    public class TitleScreenObject : UIScreen
    {
        public const string SysName = nameof(TitleScreenObject);
        public override string SystemName => SysName;

        /// <summary>
        ///  this method is called from UI using UnityEvent
        /// </summary>
        public void OnPlayButtonClick()
        {
            UIManager.Instance.Close(TitleScreenObject.SysName);
            UIManager.Instance.Open(GameScreenObject.SysName);
            SceneManager.LoadScene("DebugScene");
        }

        /// <summary>
        ///  this method is called from UI using UnityEvent
        /// </summary>
        public void OnExitButtonClick()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
#else
            UnityEngine.Application.Quit();
#endif
        }
    }
}