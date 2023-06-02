using System;
using UnityEngine;

namespace Weapon
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] protected float speed = 7f;
        [SerializeField] private float timeLife = 7f;

        private float _currentTime;

        private Vector3 _vector3;
        private bool _isActive;

        public void Init(Quaternion dir)
        {
            transform.rotation = dir;
            _isActive = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.GetComponent<Player>()) return;
            
            _isActive = false;
            gameObject.SetActive(false);
        }

        private void Update()
        {
            if(!_isActive) return;
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));
            
            _currentTime += Time.deltaTime;
            if (_currentTime >= timeLife)
            {
                _isActive = false;
                gameObject.SetActive(false);
            }
        }
    }
}