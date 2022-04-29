using Management;
using UnityEngine;

namespace Objects
{
    public class Enemy : MonoBehaviour
    {
        public GameObject bloodSplatter;
        public float speed = 10.0f;

        private Transform _currentMarker;
        private Vector3 _direction;
        private int _mIndex;

        public void TakeDamage()
        {
            var position = transform.position;
            var bloodPos = new Vector3(position.x, 0.12f, position.z);
            var randomRot = Random.Range(1.0f, 360.0f);
            
            Instantiate(bloodSplatter, bloodPos, Quaternion.Euler(0f, randomRot, 0f));
            Destroy(gameObject);
        }

        private void ChangeMarker()
        {
            _mIndex ++;

            _currentMarker = WaveSpawner.GetMarkerList()[_mIndex];
            _direction = _currentMarker.position - transform.position;
            _direction.Normalize();

            transform.rotation = Quaternion.LookRotation(_direction);
        }

        private void Start()
        {
            ChangeMarker();
        }

        private void Update()
        {
            if (WaveSpawner.IsReset) Destroy(gameObject);
        
            transform.Translate(_direction * (speed * Time.deltaTime), Space.World);

            if (Vector3.Distance(transform.position, _currentMarker.position) < 0.3f)
            {
                if (_mIndex < WaveSpawner.GetMarkerList().Length - 1)
                    ChangeMarker();

                else
                {
                    var levelObject = GameObject.FindWithTag("Player");
                    var controller = levelObject.GetComponent<LevelController>();
                    controller.DealDamage(15f);
                    
                    Destroy(gameObject);
                }
            }
        }
    }
}
