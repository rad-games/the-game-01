using UnityEngine;

namespace TheGame.Character
{
    public enum WaterBoyStateType
    {
        StadningWater,
        FloorWater,
        StandingIce,
        IceBall,
        Steam,
    }

    public abstract class WaterBoyState : MonoBehaviour
    {
        [SerializeField]
        WaterBoyStateType _type;

        public abstract void Tick();
        public void Setup(WaterBoyStateType type) => _type = type;
    }
}