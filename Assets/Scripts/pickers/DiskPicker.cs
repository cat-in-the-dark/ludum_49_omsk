using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiskPicker : MonoBehaviour
{
    public GameObject PCBuilder;
    public GameObject shopManager;
    public int diskIndex;

    [Header("Text Labels")]
    public TextMeshProUGUI nameTextLabel;
    public TextMeshProUGUI priceTextLabel;
    public TextMeshProUGUI specsTextLabel;

    [Header("Navigation Buttons")]
    public Button nextDisk;
    public Button prevDisk;

    private PCBuilder pcBuilder;
    private Shop shop;

    private DiskPart currentDisk;
    private int currentdDiskIndex = 0;

    void Start()
    {
        pcBuilder = PCBuilder.GetComponent<PCBuilder>();
        shop = shopManager.GetComponent<Shop>();

        nextDisk.onClick.AddListener(ClickOnNext);
        prevDisk.onClick.AddListener(ClickOnPrev);

        currentDisk = shop.diskParts[currentdDiskIndex];
        pcBuilder.SetDisk(currentDisk, diskIndex);
    }

    void Update()
    {
        nameTextLabel.text = currentDisk.Name;
        priceTextLabel.text = string.Format("${0}", currentDisk.Price);
        specsTextLabel.text = string.Format("Disk Power: {0}, Energy: {1}", currentDisk.DiskSize, currentDisk.Price);
    }

    void ClickOnNext()
    {
        if (currentdDiskIndex < shop.diskParts.Count - 1) {
            currentdDiskIndex++;
            currentDisk = shop.diskParts[currentdDiskIndex];
            pcBuilder.SetDisk(currentDisk, diskIndex);
        }
    }

    void ClickOnPrev()
    {
        if (currentdDiskIndex > 0) {
            currentdDiskIndex--;
            currentDisk = shop.diskParts[currentdDiskIndex];
            pcBuilder.SetDisk(currentDisk, diskIndex);
        }
    }
}
