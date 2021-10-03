using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CpuPicker : MonoBehaviour
{
    public GameObject PCBuilder;
    public GameObject shopManager;

    [Header("Text Labels")]
    public TextMeshProUGUI nameTextLabel;
    public TextMeshProUGUI priceTextLabel;
    public TextMeshProUGUI specsTextLabel;

    [Header("Navigation Buttons")]
    public Button nextCPU;
    public Button prevCPU;

    private PCBuilder pcBuilder;
    private Shop shop;

    private CpuPart currentCpu;
    private int currentCpuIndex = 0;

    void Start()
    {
        pcBuilder = PCBuilder.GetComponent<PCBuilder>();
        shop = shopManager.GetComponent<Shop>();

        nextCPU.onClick.AddListener(ClickOnNext);
        prevCPU.onClick.AddListener(ClickOnPrev);

        currentCpu = shop.cpuParts[currentCpuIndex];
    }

    void Update()
    {
        nameTextLabel.text = currentCpu.Name;
        priceTextLabel.text = string.Format("${0}", currentCpu.Price);
        specsTextLabel.text = string.Format("CPU Power: {0}, Energy: {1}", currentCpu.CpuPower, currentCpu.Price);
    }

    void ClickOnNext()
    {
        if (currentCpuIndex < shop.cpuParts.Count - 1) {
            currentCpuIndex++;
            currentCpu = shop.cpuParts[currentCpuIndex];
            // pcBuilder.SetMotherboard(currentMotherboard);
        }
    }

    void ClickOnPrev()
    {
        if (currentCpuIndex > 0) {
            currentCpuIndex--;
            currentCpu = shop.cpuParts[currentCpuIndex];
            // pcBuilder.SetMotherboard(currentMotherboard);
        }
    }
}
