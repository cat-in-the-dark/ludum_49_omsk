using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PCBuilder : MonoBehaviour
{
    public GameObject PCManager;
    public GameObject shopManager;

    public GameObject componentsCanvas;
    public Button closeButton;

    [Header("Component Prefabs")]
    public GameObject cpuViewPrefab;
    public GameObject ramViewPrefab;
    public GameObject gpuViewPrefab;
    public GameObject diskViewPrefab;

    [Header("Purchase Data")]
    public TextMeshProUGUI powerTextLabel;
    public TextMeshProUGUI priceTextLabel;
    public Button purchaseButton;

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

        purchaseButton.onClick.AddListener(Purchase);
        closeButton.onClick.AddListener(CloseBuilder);
        buildingPC = new PC(shop.motherBoardParts[0], shop.powerSupplyParts[0]);
    }

    private void OnEnable() {
        buildingPC = new PC(shop.motherBoardParts[0], shop.powerSupplyParts[0]);   
    }

    private void OnDisable() {
        buildingPC = null;

        foreach (Transform picker in canvasTransform) {
            GameObject.Destroy(picker.gameObject);
        }
    }

    void Update() {
        if (prevMotherboard != buildingPC.GetMotherBoard()) {
            var motherboard = buildingPC.GetMotherBoard();

            foreach (Transform picker in canvasTransform) {
                GameObject.Destroy(picker.gameObject);
            }

            for (int i = 0; i < motherboard.CpuSlots; i++) {
                var picker = cpuViewPrefab.GetComponent<CpuPicker>();

                picker.PCBuilder = gameObject;
                picker.shopManager = shopManager;
                picker.cpuIndex = i;

                var instantiatedPicker = Instantiate(picker);
                instantiatedPicker.transform.SetParent(canvasTransform, false);
            }

            for (int i = 0; i < motherboard.RamSlots; i++) {
                var picker = ramViewPrefab.GetComponent<RamPicker>();

                picker.PCBuilder = gameObject;
                picker.shopManager = shopManager;
                picker.ramIndex = i;

                var instantiatedPicker = Instantiate(picker);
                instantiatedPicker.transform.SetParent(canvasTransform, false);
            }

            for (int i = 0; i < motherboard.GpuSlots; i++) {
                var picker = gpuViewPrefab.GetComponent<GpuPicker>();

                picker.PCBuilder = gameObject;
                picker.shopManager = shopManager;
                picker.gpuIndex = i;

                var instantiatedPicker = Instantiate(picker);
                instantiatedPicker.transform.SetParent(canvasTransform, false);
            }

            for (int i = 0; i < motherboard.DiskSlots; i++) {
                var picker = diskViewPrefab.GetComponent<DiskPicker>();

                picker.PCBuilder = gameObject;
                picker.shopManager = shopManager;
                picker.diskIndex = i;

                var instantiatedPicker = Instantiate(picker);
                instantiatedPicker.transform.SetParent(canvasTransform, false);
            }

            prevMotherboard = motherboard;
        }

        purchaseButton.interactable = (buildingPC.CanMine()) && (buildingPC.GetPrice() <= pcManager.Balance);
    }

    private void SetPowerData() {
        double pcPower = buildingPC.GetPower() * -1;
        double psuPower = buildingPC.powerSupply.Energy;

        powerTextLabel.text = string.Format("{0} W/{1} W", ((int) pcPower).ToString(), ((int) psuPower).ToString());
    }

    private void SetPriceData() {
        double price = buildingPC.GetPrice();

        priceTextLabel.text = string.Format("${0}", ((int) price).ToString());
    }

    private void Purchase() {
        pcManager.AddComputer(buildingPC);
        gameObject.SetActive(false);
    }

    private void CloseBuilder() {
        gameObject.SetActive(false);
    }

    public void SetMotherboard(MotherBoardPart motherboard) {
        buildingPC.SetMotherboard(motherboard);

        SetPowerData();
        SetPriceData();
    }

    public void SetPowerSupply(PowerSupplyPart powerSupply) {
        buildingPC.powerSupply = powerSupply;

        SetPowerData();
        SetPriceData();
    }

    public void SetCpu(CpuPart cpu, int index) {
        buildingPC.ReplaceCpu(cpu, index);

        SetPowerData();
        SetPriceData();
    }

    public void SetRam(RamPart ram, int index) {
        buildingPC.ReplaceRam(ram, index);

        SetPowerData();
        SetPriceData();
    }

    public void SetGpu(GpuPart gpu, int index) {
        buildingPC.ReplaceGpu(gpu, index);

        SetPowerData();
        SetPriceData();
    }

    public void SetDisk(DiskPart disk, int index) {
        buildingPC.ReplaceDisk(disk, index);

        SetPowerData();
        SetPriceData();
    }

    void BuildPC() {
        pcManager.AddComputer(buildingPC);
    }
}
