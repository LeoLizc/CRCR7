using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : ScriptableObject
{
    [Min(0)] public float duration;
    [Min(1)] public int usages;
    public abstract void apply(GameObject target);
    public abstract void deapply(GameObject target);

}
