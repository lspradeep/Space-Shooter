using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float speed = 10f;
    [SerializeField] float lifetime = 5f;
    [SerializeField] float fireingRate = 0.2f;
    [HideInInspector] public bool isFiring;
    private Coroutine shootCoroutine;
    [SerializeField] bool isAI = false;

    // Start is called before the first frame update
    void Start()
    {
        if (isAI)
        {
            isFiring = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isFiring && shootCoroutine == null)
        {
            shootCoroutine = StartCoroutine(Shoot());
        }
        else if (!isFiring && shootCoroutine != null)
        {
            StopCoroutine(shootCoroutine);
            shootCoroutine = null;
        }
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rigidbody2D = bullet.GetComponent<Rigidbody2D>();
            if (rigidbody2D != null)
            {
                rigidbody2D.velocity = transform.up * speed;
            }
            Destroy(bullet, lifetime);
            yield return new WaitForSeconds(fireingRate);
        }
    }
}
