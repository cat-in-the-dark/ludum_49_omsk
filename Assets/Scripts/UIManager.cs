using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject PCBuilderView;

    public Button inventoryButton;

    void Start()
    {
        inventoryButton.onClick.AddListener(OpenBuilder);
    }

    void OpenBuilder()
    {
        PCBuilderView.SetActive(true);
    }
}
