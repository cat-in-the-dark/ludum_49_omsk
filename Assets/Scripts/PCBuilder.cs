using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCBuilder : MonoBehaviour
{
    public GameObject PCManager;
    public GameObject shopManager;

    public GameObject PCPartViewPrefab;

    private PCManager pcManager;
    private Shop shop;

    private PC buildingPC;

    void Start()
    {
        pcManager = PCManager.GetComponent<PCManager>();
        shop = shopManager.GetComponent<Shop>();

        buildingPC = new PC(shop.motherBoardParts[0], shop.powerSupplyParts[0]);
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
