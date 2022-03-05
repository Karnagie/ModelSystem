using UnityEngine;

namespace GameModels.PlayerEssence
{
    public class PlayerMovement
    {
        private Vector3 _offset;
        private float _rayDistance;
        
        public PlayerMovement(Vector3 offset, float rayDistance)
        {
            _offset = offset;
            _rayDistance = rayDistance;
        }

        public bool IsOnGround(Vector3 currentPosition)
        {
            if (Physics.Raycast(currentPosition + _offset, Vector3.down, _rayDistance, LayerMask.GetMask("Obstacle")))
            {
                return true;
            }
            return false;
        }

        public Vector3 CalculatePosition(Vector3 currentPosition)
        {
            Vector3 newPosition = new Vector3();
            if (Physics.Raycast(currentPosition+_offset, Vector3.down, out var hit, _rayDistance,  LayerMask.GetMask("Obstacle")))
            {
                newPosition = currentPosition;
                newPosition.y = hit.point.y;
            }
            return newPosition;
        }
        
        public Quaternion CalculateAngle(Vector3 currentPosition)
        {
            if (Physics.Raycast(currentPosition+_offset, Vector3.down, out var hit, _rayDistance,  LayerMask.GetMask("Obstacle")))
            {
                var angle = Vector3.Angle(Vector3.up, hit.normal);
                return Quaternion.Euler(-angle,0,0);
            }
            return Quaternion.Euler(0,0,0);
        }
    }
}