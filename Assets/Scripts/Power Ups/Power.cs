using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Power : MonoBehaviour
{
    public PowerUp powerUp;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if(collision.tag.ToLower() == "player")
        {
            powerUp.apply(collision.gameObject);
            Destroy(gameObject);
        }*/
    }
}
