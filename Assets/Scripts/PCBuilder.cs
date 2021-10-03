using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PCBuilder : MonoBehaviour
{
    public GameObject PCManager;
    public GameObject shopManager;

    public GameObject componentsCanvas;

    [Header("Component Prefabs")]
    public GameObject cpuViewPrefab;
    public GameObject ramViewPrefab;
    public GameObject gpuViewPrefab;
    public GameObject diskViewPrefab;

    private PCManager pcManager;
    private Shop shop;
    private Transform canvasTransform;

    private PC buildingPC;
    private MotherBoardPart prevMotherboard = null;

    void Start()
    {
        pcManager = PCManager.GetComponent<PCManager>();
        shop = shopManager.GetComponent<Shop>();
        canvasTransform = componentsCanvas.GetComponent<Transform>();

        buildingPC = new PC(shop.motherBoardParts[0], shop.powerSupplyParts[0]);
    }

    void Update() {
        if (prevMotherboard != buildingPC.motherBoard) {
            var motherboard = buildingPC.motherBoard;

            foreach (Transform picker in canvasTransform) {
                GameObject.Destroy(picker.gameObject);
            }

            for (int i = 0; i < motherboard.CpuSlots; i++) {
                var picker = cpuViewPrefab.GetComponent<CpuPicker>();

                picker.PCBuilder = gameObject;
                picker.shopManager = shopManager;

                var instantiatedPicker = Instantiate(picker);
                instantiatedPicker.transform.SetParent(canvasTransform, false);
            }

            for (int i = 0; i < motherboard.RamSlots; i++) {
                var picker = ramViewPrefab.GetComponent<RamPicker>();

                picker.PCBuilder = gameObject;
                picker.shopManager = shopManager;

                var instantiatedPicker = Instantiate(picker);
                instantiatedPicker.transform.SetParent(canvasTransform, false);
            }

            for (int i = 0; i < motherboard.GpuSlots; i++) {
                var picker = gpuViewPrefab.GetComponent<GpuPicker>();

                picker.PCBuilder = gameObject;
                picker.shopManager = shopManager;

                var instantiatedPicker = Instantiate(picker);
                instantiatedPicker.transform.SetParent(canvasTransform, false);
            }

            for (int i = 0; i < motherboard.DiskSlots; i++) {
                var picker = diskViewPrefab.GetComponent<DiskPicker>();

                picker.PCBuilder = gameObject;
                picker.shopManager = shopManager;

                var instantiatedPicker = Instantiate(picker);
                instantiatedPicker.transform.SetParent(canvasTransform, false);
            }

            prevMotherboard = motherboard;
        }
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
