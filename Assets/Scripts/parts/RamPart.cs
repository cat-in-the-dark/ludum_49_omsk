using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New RAM", menuName="PC Parts/RAM Data", order=51)]
public class RamPart: ScriptableObject {
    public string Name;
    public double Price;
    public double CpuRam;
    public double Energy;
}
