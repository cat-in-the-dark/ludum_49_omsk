using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PCPart", menuName="PCPart Data", order=51)]
public class PCPart: ScriptableObject {
    public string Name;
    public PCPartType Type;
    public double Price;
    public double CudaPower;
    public double CudaRam;
    public double CpuPower;
    public double CpuRam;
    public double DiskSize;
    public double DiskSpeed;
    public double Energy;
}
