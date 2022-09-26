using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateEffects/Buffs/Intangibilidad")]
public class Intangibilidad : PowerUp
{
    public override void apply(GameObject target)
    {
        target.layer = 3;
        target.GetComponent<movimiento>().estado = movimiento.Estado.fantasma;
    }
    public override void deapply(GameObject target)
    {
        target.layer = 0;
        target.GetComponent<movimiento>().estado = movimiento.Estado.normal;
    }
}
