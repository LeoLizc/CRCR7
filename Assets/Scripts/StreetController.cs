using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class StreetController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = GetComponent<Rigidbody2D>().velocity.normalized;
        if (vel.magnitude==0)
            vel = Vector2.left;
        GetComponent<Rigidbody2D>().velocity = vel * GameManager.Instance.velocity;
    }
}
