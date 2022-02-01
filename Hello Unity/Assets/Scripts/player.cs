using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 20.0f;

    MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        if (rb != null)
        {
            rb = GetComponent<Rigidbody>();
        }
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 randDir = Random.onUnitSphere * speed;
        rb.AddForce(new Vector3(randDir.x,0,randDir.z));
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision enter: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("obstacle"))
        {
            MeshRenderer other = collision.gameObject.GetComponent<MeshRenderer>();
            meshRenderer.material.color = other.material.color;
        }

        if (collision.gameObject.CompareTag("goal"))
        {
            MeshRenderer other = collision.gameObject.GetComponent<MeshRenderer>();
            meshRenderer.material.color = other.material.color;
            Vector3 randDir = Random.onUnitSphere * speed * 100;
            rb.AddForce(new Vector3(randDir.x, randDir.y, randDir.z));
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Collision stay: " + collision.gameObject.name);
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collision exit: " + collision.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger stay: " + other.gameObject.name);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("trigger stay: " + other.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("trigger stay: " + other.gameObject.name);
    }

}
