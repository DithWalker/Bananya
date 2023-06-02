using UnityEngine;

namespace Weapon
{
    public abstract class WeaponBase : MonoBehaviour
    {
        [SerializeField] protected Bullet bullet;
        
        
        private StartBulletPoint _startBulletPoint;
        private ParticleSystem _particle;
        

        protected virtual void Awake()
        {
            _startBulletPoint = GetComponentInChildren<StartBulletPoint>();
            _particle = GetComponentInChildren<ParticleSystem>();
        }

        public virtual void Shoot(Quaternion direction)
        {
            _particle.Play();
            var bull =  Instantiate(bullet.gameObject, _startBulletPoint.transform.position, Quaternion.identity, transform).GetComponent<Bullet>();
            bull.Init(direction);
        }
    }
}