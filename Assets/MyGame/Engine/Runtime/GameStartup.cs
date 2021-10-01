using System.Collections;
using System.Collections.Generic;
using TheGame.Engine.UI;
using TheGame.UI;
using UnityEngine;

namespace TheGame
{
    /// <summary>
    /// this is the entry point for the game
    /// </summary>
    public class GameStartup : MonoBehaviour
    {
        void Start()
        {
            UIManager.Instance.Open(TitleScreenObject.SysName);
        }
    }
}