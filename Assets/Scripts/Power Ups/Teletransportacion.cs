using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateEffects/Buffs/Teletransportacion")]
public class Teletransportacion : PowerUp
{
    public float distancia;
    movimiento a;
    public LayerMask mask;
    public override void apply(GameObject target)
    {
        Vector3 pos = target.transform.position;
        float radio = target.transform.localScale.x/2;
        int x=0,y=0;
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
        else if (x == 0) x = 1;

        Vector2 direction = new Vector2(x, y).normalized;
        float distance = Physics2D.Raycast(new Vector2(pos.x, pos.y), direction, 20, mask).distance;
        direction = direction * Mathf.Min(distance - radio, distancia);
        target.transform.position = new Vector3(pos.x + direction.x, pos.y+direction.y, pos.z);

    }
    public override void deapply(GameObject target)
    {
        
    }
}