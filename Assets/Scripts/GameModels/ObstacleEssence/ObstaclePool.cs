using System.Collections;
using MetaGame.Objects;
using UnityEngine;

namespace GameModels.ObstacleEssence
{
    public class ObstaclePool : TransformableObject
    {
        private Queue _obstacles;
        private float _speed = 4;
        private float _time = 0;

        public ObstaclePool(Transform transform, string name, Transform[] obstacles) : base(transform, name)
        {
            _obstacles = new Queue(obstacles);
        }
        
        public override void Tick(float deltaTime)
        {
            if (_time <= Time.time)
            {
                _time = Time.time + 4;
                var el = _obstacles.Dequeue() as Transform;
                ResetObstacle(el);
                _obstacles.Enqueue(el);
            }
        }

        public override void FixedTick(float deltaTime)
        {
            foreach (Transform obstacle in _obstacles)
            {
                obstacle.Translate(Vector3.back*deltaTime*_speed);
            }
        }

        private void ResetObstacle(Transform obstacle)
        {
            obstacle.gameObject.SetActive(true);
            obstacle.position = _transform.position;
        }
    }
}