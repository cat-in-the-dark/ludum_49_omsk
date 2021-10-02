using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Disk", menuName = "PC Parts/Disk Data", order = 51)]
public class DiskPart : ScriptableObject
{
    public string Name;
    public double Price;
    public double DiskSize;
    public double Energy;
}
