using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movimiento : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D este;
    //public generador gen;
    public bool inmortal;
    public PhysicsMaterial2D crashedMaterial;
    public enum Estado
    {
        fantasma = 1,
        salto = 2,
        turbo = 3, 
        normal = 0,
        invencible = 4
    }
    
    public float vel;
    public Sprite[] car;
    private SpriteRenderer yo;
    public Estado estado;
    void Start()
    {
        este = GetComponent<Rigidbody2D>();
        este.gravityScale=0;
        yo = GetComponent<SpriteRenderer>();
        //yo.sprite = car[0];
        estado = Estado.normal;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 actualVel = este.velocity;
        if (Input.GetKey("a"))
        {
            este.velocity = new Vector2(-vel, actualVel.y);
        }
        else if (Input.GetKey("d"))
        {
            este.velocity = new Vector2(vel, actualVel.y);
        }
        else
        {
            este.velocity = new Vector2(0, actualVel.y);
        }
        actualVel = este.velocity;
        if (Input.GetKey("s"))
        {
            este.velocity = new Vector2(actualVel.x, -vel);
        }
        else if(Input.GetKey("w"))
        {
            este.velocity = new Vector2(actualVel.x, vel);
        }
        else
        {
            este.velocity = new Vector2(actualVel.x, 0);
        }
    }
    void OnCollisionEnter2D(Collision2D collider)
    {

        if (collider.gameObject.tag == "carro")
        {
            if(estado == Estado.invencible)
            {
                
            }
            else if(estado != Estado.fantasma && estado != Estado.salto)
            {
                este.freezeRotation = false;
                este.angularVelocity = (((int)Random.Range(0,2))*2-1) * Random.Range(80, 250);

                este.sharedMaterial = crashedMaterial;
                este.drag = 2;
                este.angularDrag = 1.5f;
                this.enabled = false;
                GameManager.Instance.ChangeState(GameManager.GameState.crashed);
                Destroy(gameObject, 2.1f);

            }
        }

    }
    private void OnDestroy()
    {
        SceneManager.LoadScene("End");
    }

}
