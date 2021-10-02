using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    List<RamPart> ramParts;
    
    [SerializeField]
    List<CpuPart> cpuParts;
    
    [SerializeField]
    List<GpuPart> gpuParts;

    [SerializeField]
    List<DiskPart> diskParts;

    [SerializeField]
    List<PowerSupplyPart> powerSupplyParts;

    [SerializeField]
    List<MotherBoardPart> motherBoardParts;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
