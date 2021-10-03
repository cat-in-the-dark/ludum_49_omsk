using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PCViewManager : MonoBehaviour
{
    public GameObject PCManager;

    public TextMeshProUGUI balanceTextLabel;
    public TextMeshProUGUI incomeTextLabel;

    private PCManager pcManager;

    void Start()
    {
        pcManager = PCManager.GetComponent<PCManager>();
    }

    void Update()
    {
        balanceTextLabel.text = string.Format("${0:F2}", pcManager.Balance);
        incomeTextLabel.text = string.Format("${0:F2}", pcManager.IncomePerSec);
    }
}
