using UnityEngine;

namespace GameModels.PlayerEssence
{
    public class PlayerGizmos : MonoBehaviour
    {
        private Vector3 _startPos;
        private Vector3 _endPos;
        
        public void UpdateData(Vector3 startPos, Vector3 endPos)
        {
            _startPos = startPos;
            _endPos = endPos;
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(_startPos, _endPos);
        }
    }
}