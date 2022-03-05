using Data.Input;
using MetaGame.Architecture.Wrappers;
using MetaGame.Objects;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameModels.PlayerEssence
{
    public class Player : AliveObject
    {
        private float _jumpForce = 0.5f;
        private float _rayDistance = 1.1f;
        private float _gravity = 4f;
        private float _jumpTime = 1;

        private readonly MainInput _input;
        private readonly PlayerGizmos _gizmos;
        private readonly PlayerMovement _movement;
        private readonly AnimationCurve _jumpCurve;

        public Player() : base(null, null, "zero")
        {
            
        }
        
        public Player(Transform transform, ModelCollider collider, string name, PlayerGizmos gizmos, AnimationCurve jump) : base(transform, collider, name)
        {
            _gizmos = gizmos;
            _input = new MainInput();
            _input.Enable();
            _input.Player.Jump.performed += Jump;
            _movement = new PlayerMovement(Vector3.up, _rayDistance);
            _jumpCurve = jump;
        }

        private void Jump(InputAction.CallbackContext ctx)
        {
            if (_movement.IsOnGround(_transform.position))
            {
                _jumpTime = 0;
            }
        }


        public override void Tick(float deltaTime)
        {
            
        }

        public override void FixedTick(float deltaTime)
        {
            var position = _transform.position;
            if (_movement.IsOnGround(position))
            {
                position = _movement.CalculatePosition(_transform.position);
            }
            else
            {
                position.y -= _gravity*deltaTime;
            }

            if (_jumpTime < 1)
            {
                position.y += _jumpCurve.Evaluate(_jumpTime)*_jumpForce;
                _jumpTime += deltaTime;
            }

            _transform.position = position;
            _transform.rotation = _movement.CalculateAngle(_transform.position);
            _gizmos.UpdateData(_transform.position+Vector3.up, _transform.position+Vector3.up+Vector3.down*_rayDistance);
        }

        public override void GetDamage(float value)
        {
            _health -= value;
        }
    }
}