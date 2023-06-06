using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooting : MonoBehaviour
{
    [SerializeField] private float bulletOffset = 0.5f;
    void Start()
    {
        ButtonSequence.isShooting = true;
        InvokeRepeating("Fire", 0f, .5f);
    }

    // Update is called once per frame
    private void Fire()
    {
        if (ButtonSequence.isShooting == true)
        {
            GameObject bullet = ObjectPool.Instance.RequestBullet();
            bullet.transform.position = transform.position + Vector3.right * bulletOffset;
        }
    }
}
