using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStat : MonoBehaviour
{
    [SerializeField] private string statName;
    [SerializeField] private int statValue;
    [SerializeField] private int maxValue;

    public void InitialiseStat(string sName, int value = 0)
    {
        name = sName;
        statName = sName;
        statValue = value;
    }
    public void SetStatValue(int value)
    {
        statValue = value;
    }
    public void SetMaxValue(int value)
    {
        maxValue = value;
    }
    public int GetMaxValue()
    {
        return maxValue;
    }
    public void AddToStatValue(int value)
    {
        statValue += value;
    }
    public int GetStatValue()
    {
        return statValue;
    }
    public string GetStatName()
    {
        return statName;
    }

}
