using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    /*public GameObject gm;
    public float velocity;*/
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("generatePlatform", 2, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generatePlatform(GameObject gm, float velocity)
    {
        GameObject platform = Instantiate(gm, transform.position, gm.transform.rotation);
        platform.GetComponent<Rigidbody2D>().velocity = Vector2.left * velocity;
    }
}
