using System;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float bulletSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "target")
        {
            GameManager.Instance.AddScore();
            Destroy(other.gameObject);
        }
    }
}
