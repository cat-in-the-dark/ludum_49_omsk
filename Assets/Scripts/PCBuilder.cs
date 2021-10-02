using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCBuilder : MonoBehaviour
{
    public GameObject PCManager;

    public GameObject PCPartViewPrefab;

    private PCManager pcManager;

    private PC buildingPC;

    // Start is called before the first frame update
    void Start()
    {
        pcManager = PCManager.GetComponent<PCManager>();
    }

    void Update() {

    }

    public void SetMotherboard(MotherBoardPart motherboard) {
        buildingPC.motherBoard = motherboard;
    }

    void BuildPC() {
        pcManager.AddComputer(buildingPC);
    }
}
