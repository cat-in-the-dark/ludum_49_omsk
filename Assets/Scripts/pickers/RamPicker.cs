using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RamPicker : MonoBehaviour
{
    public GameObject PCBuilder;
    public GameObject shopManager;
    public int ramIndex;

    [Header("Text Labels")]
    public TextMeshProUGUI nameTextLabel;
    public TextMeshProUGUI priceTextLabel;
    public TextMeshProUGUI specsTextLabel;

    [Header("Navigation Buttons")]
    public Button nextRAM;
    public Button prevRAM;

    private PCBuilder pcBuilder;
    private Shop shop;

    private RamPart currentRam;
    private int currentRamIndex = 0;

    void Start()
    {
        pcBuilder = PCBuilder.GetComponent<PCBuilder>();
        shop = shopManager.GetComponent<Shop>();

        nextRAM.onClick.AddListener(ClickOnNext);
        prevRAM.onClick.AddListener(ClickOnPrev);

        currentRam = shop.ramParts[currentRamIndex];
        pcBuilder.SetRam(currentRam, ramIndex);
    }

    void Update()
    {
        nameTextLabel.text = currentRam.Name;
        priceTextLabel.text = string.Format("${0}", currentRam.Price);
        specsTextLabel.text = string.Format("RAM Power: {0}, Energy: {1}", currentRam.CpuRam, currentRam.Price);
    }

    void ClickOnNext()
    {
        if (currentRamIndex < shop.ramParts.Count - 1) {
            currentRamIndex++;
            currentRam = shop.ramParts[currentRamIndex];
            pcBuilder.SetRam(currentRam, ramIndex);
        }
    }

    void ClickOnPrev()
    {
        if (currentRamIndex > 0) {
            currentRamIndex--;
            currentRam = shop.ramParts[currentRamIndex];
            pcBuilder.SetRam(currentRam, ramIndex);
        }
    }
}
