using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateEffects/Buffs/Velocidad")]
public class Velocidad : PowerUp
{
    movimiento a;
    private float initVel;
    [Min(1)]public float velocityMultiplier;
    public override void apply(GameObject target)
    {
        a = target.GetComponent<movimiento>();
        initVel = a.vel;
        a.vel *= velocityMultiplier;
    }
    public override void deapply(GameObject target)
    {
        a.vel = initVel;
    }
}
