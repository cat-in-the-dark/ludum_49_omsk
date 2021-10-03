using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MotherboardPicker : MonoBehaviour
{
    public GameObject PCBuilder;
    public GameObject shopManager;

    [Header("Text Labels")]
    public TextMeshProUGUI nameTextLabel;
    public TextMeshProUGUI priceTextLabel;
    public TextMeshProUGUI specsTextLabel;

    [Header("Navigation Buttons")]
    public Button nextMotherboard;
    public Button prevMotherboard;

    private PCBuilder pcBuilder;
    private Shop shop;

    private MotherBoardPart currentMotherboard;
    private int currentMbIndex = 0;

    void Start()
    {
        pcBuilder = PCBuilder.GetComponent<PCBuilder>();
        shop = shopManager.GetComponent<Shop>();

        nextMotherboard.onClick.AddListener(ClickOnNext);
        prevMotherboard.onClick.AddListener(ClickOnPrev);

        currentMotherboard = shop.motherBoardParts[currentMbIndex];
    }

    private void OnDisable() {
        currentMbIndex = 0;
        currentMotherboard = shop.motherBoardParts[currentMbIndex];
    }

    void Update()
    {
        nameTextLabel.text = currentMotherboard.Name;
        priceTextLabel.text = string.Format("${0}", currentMotherboard.Price);
        specsTextLabel.text = BuildMbSpecs(currentMotherboard);
    }

    void ClickOnNext()
    {
        if (currentMbIndex < shop.motherBoardParts.Count - 1) {
            currentMbIndex++;
            currentMotherboard = shop.motherBoardParts[currentMbIndex];
            pcBuilder.SetMotherboard(currentMotherboard);
        }
    }

    void ClickOnPrev()
    {
        if (currentMbIndex > 0) {
            currentMbIndex--;
            currentMotherboard = shop.motherBoardParts[currentMbIndex];
            pcBuilder.SetMotherboard(currentMotherboard);
        }
    }

    private string BuildMbSpecs(MotherBoardPart motherboard) {
        return string.Format(
            "{0} CPU, {1} RAM, {2} GPU, {3} HDD",
            currentMotherboard.CpuSlots,
            currentMotherboard.RamSlots,
            currentMotherboard.GpuSlots,
            currentMotherboard.DiskSlots
        );
    }
}
