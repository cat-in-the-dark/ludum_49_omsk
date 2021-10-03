using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CurrencyScores
{
    public double BTC;
    public double LTC;
    public double BRST;
    public double DOGE;
}

public class PCManager : MonoBehaviour
{
    double JAM_MUL = 50;
    public NewsFeed newsFeed;
    public CurrancyEvent currancyEvent;
    private List<PC> computers = new List<PC>();
    [SerializeField]
    private double incomePerSec = 0;
    public double IncomePerSec => incomePerSec;

    [SerializeField]
    private double balance = 0.0;
    public double Balance => balance;

    public List<Currency> currencies;

    public List<CurrancyEvent> events = new List<CurrancyEvent>();

    public void MinusBalance(double value)
    {
        balance -= value;
    }

    public void AddComputer(PC computer)
    {
        computers.Add(computer);
    }

    public CurrencyScores GetCurrencyScores()
    {
        var scores = new CurrencyScores();
        foreach (Currency cur in currencies)
        {
            if (cur.currencyName == "BTC")
            {
                scores.BTC = cur.USDRate;
            }
            if (cur.currencyName == "DOGE")
            {
                scores.DOGE = cur.USDRate;
            }
            if (cur.currencyName == "LTC")
            {
                scores.LTC = cur.USDRate;
            }
            if (cur.currencyName == "BRST")
            {
                scores.BRST = cur.USDRate;
            }
        }

        for (int i = 0; i < currancyEvent.names.Count; i++)
        {
            var name = currancyEvent.names[i];
            double mul = currancyEvent.multipliers[i];
            if (name == "BTC")
            {
                scores.BTC *= mul;
            }
            if (name == "DOGE")
            {
                scores.DOGE *= mul;
            }
            if (name == "LTC")
            {
                scores.LTC *= mul;
            }
            if (name == "BRST")
            {
                scores.BRST *= mul;
            }
        }

        return scores;
    }

    void UpdateBalance()
    {
        double icomeSum = 0;
        var scores = GetCurrencyScores();
        foreach (Currency cur in currencies)
        {
            double mul = 1;
            if (cur.currencyName == "BRST") mul = scores.BRST;
            if (cur.currencyName == "BTC") mul = scores.BTC;
            if (cur.currencyName == "DOGE") mul = scores.DOGE;
            if (cur.currencyName == "LTC") mul = scores.LTC;
            icomeSum += mul * computers.Aggregate(0.0, (acc, pc) => acc + pc.GetDollarsPerSecFor(cur));
        }
        incomePerSec = icomeSum * JAM_MUL;
        balance += incomePerSec * Time.deltaTime;
    }

    void SetEvent(int idx)
    {
        currancyEvent = events[idx];
        newsFeed.SetText(currancyEvent.Text);
    }

    void SpawnEvent()
    {
        var idx = Random.Range(0, events.Count);
        SetEvent(idx);
        float nextSpawnIn = Random.Range(10.0f, 30.0f);
        Invoke("SpawnEvent", nextSpawnIn);
    }

    void Update()
    {
        UpdateBalance();
    }

    void Start()
    {
        SetEvent(0);
        Invoke("SpawnEvent", 30.0f);
    }
}
