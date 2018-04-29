using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public class Cannon : MonoBehaviour
    {
        [Header("Projectile comes out GameObject's RED Axis")]
        public GameObject projectile;
        public float shootForce;
        public int clipCapacity;
        public float shootCooldown, reloadSeconds;
        public bool infiniteAmmo;  
        int clipCount;
        float lastShotTime;
        private void Start()
        {
            clipCount = clipCapacity;
            lastShotTime = -10f;  
        }
        public void shoot()
        {
            if (canShoot())
            {
                Rigidbody sProjRB = Instantiate(projectile, transform.position, Quaternion.Euler(transform.forward)).GetComponent<Rigidbody>();
                sProjRB.AddForce(shootForce * transform.forward);  
                lastShotTime = Time.time;
                clipCount--;
            }
        }

        public void reload()
        {
            //todo support finite clips
            Invoke("fullReload", reloadSeconds); 
        }

        public bool canShoot()
        {
            return (clipCount > 0 && Time.time > lastShotTime + shootCooldown);
        }

        void fullReload()
        {
            clipCount = clipCapacity;  
        }


    }
}

