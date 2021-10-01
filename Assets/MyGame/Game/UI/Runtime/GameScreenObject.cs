using System.Collections;
using System.Collections.Generic;
using TheGame.Engine.UI;
using UnityEngine;

namespace TheGame.UI
{
    public class GameScreenObject : UIScreen
    {
        public const string SysName = nameof(GameScreenObject);

        public override string SystemName => SysName;
    }
}