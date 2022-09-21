using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : ScriptableObject
{
    public int duration;
    public int usages;
    public abstract void apply(GameObject target);
    public abstract void deapply(GameObject target);

}
