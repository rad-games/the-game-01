using System;
using System.Collections;
using System.Collections.Generic;
using TheGame.Engine;
using UnityEngine;

namespace TheGame.Character
{
    [RequireComponent(typeof(CharacterController))]
    public class WaterBoyObject : MonoBehaviour
    {
        [SerializeField]
        WaterBoyState[] _states = new WaterBoyState[EnumTraits<WaterBoyStateType>.Count];

        public CharacterController Controller;

        void OnEnable()
        {
            Controller = GetComponent<CharacterController>();
        }

        internal void SetGrounded(bool isGrounded)
        {
            // update animator if using character
            //_animator.SetBool(_animIDGrounded, Grounded);
        }
    }
}