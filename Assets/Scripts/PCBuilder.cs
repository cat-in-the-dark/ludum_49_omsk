using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCBuilder : MonoBehaviour
{
    public GameObject PCManager;

    public GameObject PCPartViewPrefab;

    private PCManager pcManager;

    private PC buildingPC;

    void Start()
    {
        pcManager = PCManager.GetComponent<PCManager>();

        buildingPC = new PC();
    }

    void Update() {

    }

    public void SetMotherboard(MotherBoardPart motherboard) {
        buildingPC.motherBoard = motherboard;
    }

    public void SetPowerSupply(PowerSupplyPart powerSupply) {
        buildingPC.powerSupply = powerSupply;
    }

    void BuildPC() {
        pcManager.AddComputer(buildingPC);
    }
}
