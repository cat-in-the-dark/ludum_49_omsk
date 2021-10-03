using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencyView : MonoBehaviour
{
    public TextMeshProUGUI btc;
    public TextMeshProUGUI ltc;
    public TextMeshProUGUI doge;
    public TextMeshProUGUI brst;

    public PCManager pcManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var scores = pcManager.GetCurrencyScores();
        btc.text = "$" + (scores.BTC * 100).ToString();
        ltc.text = "$" + (scores.LTC * 100).ToString();
        brst.text = "$" + (scores.BRST * 100).ToString();
        doge.text = "$" + (scores.DOGE * 100).ToString();
    }
}
