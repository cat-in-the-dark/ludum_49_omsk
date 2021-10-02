using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCBuilder : MonoBehaviour
{
    public GameObject PCManager;

    private PCManager pcManager;

    private PC buildingPC;

    // Start is called before the first frame update
    void Start()
    {
        pcManager = PCManager.GetComponent<PCManager>();
    }

    void BuildPC() {
        pcManager.AddComputer(buildingPC);
    }
}
