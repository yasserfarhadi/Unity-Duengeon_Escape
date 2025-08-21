using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Moss_Giant : Enemy, IDamagable
{
     public int Health { get; set; }


    public override void Init()
    {
        base.Init();
    }
    public void Daamge(int damageAmount)
    {
        throw new System.NotImplementedException();
    }
}
