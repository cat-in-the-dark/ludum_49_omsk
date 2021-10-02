using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CPU", menuName="PC Parts/CPU Data", order=51)]
public class CpuPart: ScriptableObject {
    public string Name;
    public double Price;
    public double CpuPower;
    public double Energy;
}
