using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateEffects/Buffs/Intangibilidad")]
public class Intangibilidad : PowerUp
{
    public override void apply(GameObject target)
    {
        target.layer = 3;
        //target.StartCoroutine();
    }

    private IEnumerable start(GameObject target)
    {
        yield return new WaitForSeconds(2);
        target.layer = LayerMask.NameToLayer("Default");
    }
}
