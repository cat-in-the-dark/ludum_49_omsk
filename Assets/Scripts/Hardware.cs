using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum PCPartType {
    GPU = 0,
    CPU = 1,
    RAM = 2,
    DISK = 3,
    PSU = 4
}

[System.Serializable]   
public struct MotherBoard {
    string Name;
    int CpuSlots;
    int RamSlots;
    int GpuSlots;
    int DiskSlots;
}

[System.Serializable]
struct Hardware {
    List<MotherBoard> motherBoards;
    List<PCPart> pcParts;
}