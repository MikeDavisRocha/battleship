using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBehavior : EnemysBehavior
{
    public LayerMask collisionMask;
    private Rigidbody rb;

    [SerializeField]
    float speed;    
    float forceXAxis, forceZAxis;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(forceXAxis, 0f, forceZAxis));
    }

    void Update()
    {
        MoveBounce();
    }

    void MoveBounce()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed * GameManager.Instance.gameTime);
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Time.deltaTime * speed * GameManager.Instance.gameTime + .1f, collisionMask))
        {
            Vector3 refletDirection = Vector3.Reflect(ray.direction, hit.normal);
            float rotation = 90 - Mathf.Atan2(refletDirection.z, refletDirection.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, rotation, 0);
        }
    }
}
