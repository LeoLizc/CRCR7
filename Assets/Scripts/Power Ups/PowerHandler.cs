using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
public class PowerHandler : MonoBehaviour
{
    private bool active;
    private bool charged;
    private PowerUp powerUp;
    private int usages;
    private float progress, duration;
    [SerializeField] Slider bar;

    public Image ima;
    public Sprite[] pod;


    void Start()
    {
        active = false;
        charged = false;
        progress = 0;
        ima.enabled = false;
    }

    private void Update()
    {
        // check for the keys
        if (Input.GetKey(KeyCode.Space))
        {
            activate();
        }

        if (active)
        {
            progress += Time.deltaTime / duration;
            if (bar)
            {
                bar.value = progress;
            }
        }
    }

    // Activate Power
    void activate()
    {
        if (charged && usages >= 0 && !active) {
            powerUp.apply(gameObject);
            active = true;
            usages--;
            progress = 0;
            StartCoroutine("deactivate", powerUp);
            if (usages <= 0)
            {
                charged = false;
                powerUp = null;
                ima.enabled = false;
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
        Debug.Log("pder fuera");
        power.deapply(gameObject);
        active = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Power") && !charged)
        {
            Debug.Log("Poder obtenido");
            powerUp = collision.gameObject.GetComponent<Power>().powerUp;
            usages = powerUp.usages;
            duration = powerUp.duration;
            charged = true;
            Destroy(collision.gameObject);
            string d = powerUp.ToString();
            if (d == "intangible (Intangibilidad)" && charged)
            {
                ima.enabled = true;
                ima.sprite = pod[0];

            }
            if (d == "Velocidad (Velocidad)" && charged)
            {
                ima.enabled = true;
                ima.sprite = pod[2];

            }
            if (d == "Teletransportacion (Teletransportacion)" && charged)
            {
                ima.enabled = true;
                ima.sprite = pod[1];

            }
            //activate();
        }
    }

    private void OnDrawGizmos()
    {
        if(powerUp is Teletransportacion)
        {
            Gizmos.color = Color.red;
            int x = 0, y = 0;
            if (Input.GetKey("d"))
            {
                x = 1;
            }
            else if (Input.GetKey("a"))
            {
                x = -1;
            }

            if (Input.GetKey("w"))
            {
                y = 1;
            }
            else if (Input.GetKey("s"))
            {
                y = -1;
            }
            else if (x==0) x = 1;

            Teletransportacion tp = powerUp as Teletransportacion;
            Vector3 direction = new Vector2(x, y).normalized;
            Gizmos.DrawLine(transform.position, transform.position+direction*tp.distancia);
        }
    }
}
