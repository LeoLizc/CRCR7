using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateEffects/Buffs/Invencible")]
public class Invencible : PowerUp
{
    public override void apply(GameObject target)
    {
        target.GetComponent<movimiento>().estado = movimiento.Estado.invencible;
    }

    public override void deapply(GameObject target)
    {
        target.GetComponent<movimiento>().estado = movimiento.Estado.normal;
    }
}
