using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Power Supply", menuName="PC Parts/Power Supply Data", order=51)]
public class PowerSupplyPart: ScriptableObject {
    public string Name;
    public double Price;
    public double Energy;
}
