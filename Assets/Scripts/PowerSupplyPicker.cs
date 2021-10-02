using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerSupplyPicker : MonoBehaviour
{
    public GameObject PCBuilder;
    public GameObject shopManager;

    [Header("Text Labels")]
    public TextMeshProUGUI nameTextLabel;
    public TextMeshProUGUI priceTextLabel;
    public TextMeshProUGUI specsTextLabel;

    [Header("Navigation Buttons")]
    public Button nextPowerSupply;
    public Button prevPowerSupply;

    private PCBuilder pcBuilder;
    private Shop shop;

    private PowerSupplyPart currentPowerSupply;
    private int currentPsIndex = 0;

    void Start()
    {
        pcBuilder = PCBuilder.GetComponent<PCBuilder>();
        shop = shopManager.GetComponent<Shop>();

        nextPowerSupply.onClick.AddListener(ClickOnNext);
        prevPowerSupply.onClick.AddListener(ClickOnPrev);

        currentPowerSupply = shop.powerSupplyParts[currentPsIndex];
        pcBuilder.SetPowerSupply(currentPowerSupply);
    }

    void Update()
    {
        nameTextLabel.text = currentPowerSupply.Name;
        priceTextLabel.text = string.Format("${0}", currentPowerSupply.Price);
        specsTextLabel.text = string.Format("{0} WT", currentPowerSupply.Energy);
    }

    void ClickOnNext()
    {
        if (currentPsIndex < shop.powerSupplyParts.Count - 1) {
            currentPsIndex++;
            currentPowerSupply = shop.powerSupplyParts[currentPsIndex];
            pcBuilder.SetPowerSupply(currentPowerSupply);
        }
    }

    void ClickOnPrev()
    {
        if (currentPsIndex > 0) {
            currentPsIndex--;
            currentPowerSupply = shop.powerSupplyParts[currentPsIndex];
            pcBuilder.SetPowerSupply(currentPowerSupply);
        }
    }
}
