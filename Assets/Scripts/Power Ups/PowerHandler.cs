using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PowerHandler : MonoBehaviour
{
    private bool active;
    private bool charged;
    private PowerUp powerUp;
    private int usages;
    // Start is called before the first frame update
    void Start()
    {
        active = false;
        charged = false;
    }

    private void Update()
    {
        // check for the keys
        if (Input.GetKey(KeyCode.Space))
        {
            activate();
        }
    }

    // Activate Power
    void activate()
    {
        if (charged && usages >= 0 && !active) {
            powerUp.apply(gameObject);
            active = true;
            usages--;
            StartCoroutine("deactivate", powerUp);
            if (usages <= 0)
            {
                charged = false;
                powerUp = null;
            }
        }
    }

    IEnumerator deactivate(PowerUp power)
    {
        Debug.Log("hola1");
        Debug.Log(power);
        yield return new WaitForSeconds(power.duration);
        Debug.Log("hola");
        Debug.Log(power);
        power.deapply(gameObject);
        active = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Power") && !charged)
        {
            powerUp = collision.gameObject.GetComponent<Power>().powerUp;
            usages = powerUp.usages;
            charged = true;
            Destroy(collision.gameObject);
            //activate();
        }
    }
}
