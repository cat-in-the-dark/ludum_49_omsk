using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New GPU", menuName="PC Parts/GPU Data", order=51)]
public class GpuPart: ScriptableObject {
    public string Name;
    public double Price;
    public double CudaPower;
    public double CudaRam;
    public double Energy;
}
