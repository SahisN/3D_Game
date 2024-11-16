using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


namespace MultiTargetCameraMovement.Example
{
    public class ExampleTargetBehaviour : MonoBehaviour
    {
        [SerializeField] private float radius;
        private Vector2 _waypoint;
        private float speed = 0.4f;
        
        private IEnumerator Start()
        {
            for(int i=0; i< 30; i++) {
                var x = Random.Range(-radius, radius);
                var y = Random.Range(-radius, radius);
                var randomPos = new Vector2(x, y);
                _waypoint = randomPos;
                
                yield return new WaitForSeconds(Random.Range(3, 7));
            }
        }

        private void Update()
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(_waypoint.x, 1, _waypoint.y), Time.deltaTime * speed);
        }
    }
}

