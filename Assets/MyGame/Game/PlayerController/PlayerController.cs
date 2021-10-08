using System.Collections;
using System.Collections.Generic;
using TheGame.Character;
using UnityEngine;

namespace TheGame.PlayerController
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement")]
        public float MoveSpeed = 2f;
        public float SprintSpeed = 5f;
        public float SpeedChangeRate = 10f;

        [Header("Rotation")]
        public float RotationSpeed = 10f;

        [Header("Jump")]
        public float JumpHeight = 1f;
        public bool IsGrounded = false;
        public LayerMask GroundLayerMask;

        float _speed;
        float _rotationSpeed;

        WaterBoyObject _waterBoy;

        void Posess(WaterBoyObject waterBoy)
        {
            _waterBoy = waterBoy;
        }

        void GroundedCheck()
        {
            var radius = _waterBoy.Controller.radius;
            // set sphere position, with offset
            Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - radius * 2, transform.position.z);
            IsGrounded = Physics.CheckSphere(spherePosition, radius, GroundLayerMask, QueryTriggerInteraction.Ignore);

            _waterBoy.SetGrounded(IsGrounded);
        }
    }
}