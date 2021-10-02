using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MotherBoard", menuName="PC Parts/MotherBoard Data", order=51)]
public class MotherBoardPart: ScriptableObject {
    public string Name;
    public double Price;
    public int CpuSlots;
    public int RamSlots;
    public int GpuSlots;
    public int DiskSlots;
}
