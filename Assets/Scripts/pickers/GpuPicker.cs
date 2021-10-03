using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GpuPicker : MonoBehaviour
{
    public GameObject PCBuilder;
    public GameObject shopManager;
    public int gpuIndex;

    [Header("Text Labels")]
    public TextMeshProUGUI nameTextLabel;
    public TextMeshProUGUI priceTextLabel;
    public TextMeshProUGUI specsTextLabel;

    [Header("Navigation Buttons")]
    public Button nextGPU;
    public Button prevGPU;

    private PCBuilder pcBuilder;
    private Shop shop;

    private GpuPart currentGpu;
    private int currentGpuIndex = 0;

    void Start()
    {
        pcBuilder = PCBuilder.GetComponent<PCBuilder>();
        shop = shopManager.GetComponent<Shop>();

        nextGPU.onClick.AddListener(ClickOnNext);
        prevGPU.onClick.AddListener(ClickOnPrev);

        currentGpu = shop.gpuParts[currentGpuIndex];
        pcBuilder.SetGpu(currentGpu, gpuIndex);
    }

    void Update()
    {
        nameTextLabel.text = currentGpu.Name;
        priceTextLabel.text = string.Format("${0}", currentGpu.Price);
        specsTextLabel.text = string.Format("GPU Power: {0}, Energy: {1}", currentGpu.CudaPower, currentGpu.Price);
    }

    void ClickOnNext()
    {
        if (currentGpuIndex < shop.gpuParts.Count - 1) {
            currentGpuIndex++;
            currentGpu = shop.gpuParts[currentGpuIndex];
            pcBuilder.SetGpu(currentGpu, gpuIndex);
        }
    }

    void ClickOnPrev()
    {
        if (currentGpuIndex > 0) {
            currentGpuIndex--;
            currentGpu = shop.gpuParts[currentGpuIndex];
            pcBuilder.SetGpu(currentGpu, gpuIndex);
        }
    }
}
