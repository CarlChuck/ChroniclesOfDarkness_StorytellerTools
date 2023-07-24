using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIStat : MonoBehaviour
{
    [SerializeField] private int statValue;
    [SerializeField] private int maxStatValue;
    [SerializeField] private Image image1;
    [SerializeField] private Image image2;
    [SerializeField] private Image image3;
    [SerializeField] private Image image4;
    [SerializeField] private Image image5;
    [SerializeField] private Image image6;
    [SerializeField] private Image image7;
    [SerializeField] private Image image8;
    [SerializeField] private Image image9;
    [SerializeField] private Image image10;
    [SerializeField] private Image image11;
    [SerializeField] private Image image12;
    [SerializeField] private Image image13;
    [SerializeField] private Image image14;
    [SerializeField] private Image image15;

    [SerializeField] private TextMeshProUGUI statText;


    public void SetStat(int value, int maxNum, string statName, Color inputColor)
    {
        name = statName;
        if (statText != null)
        {
            statText.text = statName;
        }
        SetMaxStatValue(maxNum);
        BlankDots(inputColor);
        UpdateStat(value);
    }
    public void SetStat(int value, Color inputColor)
    {
        BlankDots(inputColor);
        UpdateStat(value);
    }

    public void UpdateStat(int num)
    {
        statValue = num;
        SetValueToDots();
    }

    #region Dots
    private void SetValueToDots()
    {
        BlankDots(UIManager.Instance.GetColour());
        switch (statValue)
        {
            case 1:
                image1.color = Color.black;
                break;
            case 2:
                image1.color = Color.black;
                image2.color = Color.black;
                break;
            case 3:
                image1.color = Color.black;
                image2.color = Color.black;
                image3.color = Color.black;
                break;
            case 4:
                image1.color = Color.black;
                image2.color = Color.black;
                image3.color = Color.black;
                image4.color = Color.black;
                break;
            case 5:
                image1.color = Color.black;
                image2.color = Color.black;
                image3.color = Color.black;
                image4.color = Color.black;
                image5.color = Color.black;
                break;
            case 6:
                image1.color = Color.black;
                image2.color = Color.black;
                image3.color = Color.black;
                image4.color = Color.black;
                image5.color = Color.black;
                image6.color = Color.black;
                break;
            case 7:
                image1.color = Color.black;
                image2.color = Color.black;
                image3.color = Color.black;
                image4.color = Color.black;
                image5.color = Color.black;
                image6.color = Color.black;
                image7.color = Color.black;
                break;
            case 8:
                image1.color = Color.black;
                image2.color = Color.black;
                image3.color = Color.black;
                image4.color = Color.black;
                image5.color = Color.black;
                image6.color = Color.black;
                image7.color = Color.black;
                image8.color = Color.black;
                break;
            case 9:
                image1.color = Color.black;
                image2.color = Color.black;
                image3.color = Color.black;
                image4.color = Color.black;
                image5.color = Color.black;
                image6.color = Color.black;
                image7.color = Color.black;
                image8.color = Color.black;
                image9.color = Color.black;
                break;
            case 10:
                image1.color = Color.black;
                image2.color = Color.black;
                image3.color = Color.black;
                image4.color = Color.black;
                image5.color = Color.black;
                image6.color = Color.black;
                image7.color = Color.black;
                image8.color = Color.black;
                image9.color = Color.black; 
                image10.color = Color.black;
                break;
            case 11:
                image1.color = Color.black;
                image2.color = Color.black;
                image3.color = Color.black;
                image4.color = Color.black;
                image5.color = Color.black;
                image6.color = Color.black;
                image7.color = Color.black;
                image8.color = Color.black;
                image9.color = Color.black;
                image10.color = Color.black;
                image11.color = Color.black;
                break;
            case 12:
                image1.color = Color.black;
                image2.color = Color.black;
                image3.color = Color.black;
                image4.color = Color.black;
                image5.color = Color.black;
                image6.color = Color.black;
                image7.color = Color.black;
                image8.color = Color.black;
                image9.color = Color.black;
                image10.color = Color.black;
                image11.color = Color.black;
                image12.color = Color.black;
                break;
            case 13:
                image1.color = Color.black;
                image2.color = Color.black;
                image3.color = Color.black;
                image4.color = Color.black;
                image5.color = Color.black;
                image6.color = Color.black;
                image7.color = Color.black;
                image8.color = Color.black;
                image9.color = Color.black;
                image10.color = Color.black;
                image11.color = Color.black;
                image12.color = Color.black;
                image13.color = Color.black;
                break;
            case 14:
                image1.color = Color.black;
                image2.color = Color.black;
                image3.color = Color.black;
                image4.color = Color.black;
                image5.color = Color.black;
                image6.color = Color.black;
                image7.color = Color.black;
                image8.color = Color.black;
                image9.color = Color.black;
                image10.color = Color.black;
                image11.color = Color.black;
                image12.color = Color.black;
                image13.color = Color.black;
                image14.color = Color.black;
                break;
            case 15:
                image1.color = Color.black;
                image2.color = Color.black;
                image3.color = Color.black;
                image4.color = Color.black;
                image5.color = Color.black;
                image6.color = Color.black;
                image7.color = Color.black;
                image8.color = Color.black;
                image9.color = Color.black;
                image10.color = Color.black;
                image11.color = Color.black;
                image12.color = Color.black;
                image13.color = Color.black;
                image14.color = Color.black;
                image15.color = Color.black;
                break;
            default:
                break;
        }
    }
    public void BlankDots(Color inputColor)
    {
        image1.color = inputColor;
        image2.color = inputColor;
        image3.color = inputColor;
        image4.color = inputColor;
        image5.color = inputColor;
        if (image6 != null)
        {
            image6.color = inputColor;
        }
        if (image7 != null)
        {
            image7.color = inputColor;
        }
        if (image8 != null)
        {
            image8.color = inputColor;
        }
        if (image9 != null)
        {
            image9.color = inputColor;
        }
        if (image10 != null)
        {
            image10.color = inputColor;
        }
        if (image11 != null)
        {
            image11.color = inputColor;
        }
        if (image12 != null)
        {
            image12.color = inputColor;
        }
        if (image13 != null)
        {
            image13.color = inputColor;
        }
        if (image14 != null)
        {
            image14.color = inputColor;
        }
        if (image15 != null)
        {
            image15.color = inputColor;
        }
    }
    public void SetMaxStatValue(int value)
    {
        maxStatValue = value;
        image1.gameObject.SetActive(true);
        image2.gameObject.SetActive(true);
        image3.gameObject.SetActive(true);
        image4.gameObject.SetActive(true);
        image5.gameObject.SetActive(true);

        if (maxStatValue == 6)
        {
            image6.gameObject.SetActive(true);
            image7.gameObject.SetActive(false);
            image8.gameObject.SetActive(false);
            image9.gameObject.SetActive(false);
            image10.gameObject.SetActive(false);
        }
        else if (maxStatValue == 7)
        {
            image6.gameObject.SetActive(true);
            image7.gameObject.SetActive(true);
            image8.gameObject.SetActive(false);
            image9.gameObject.SetActive(false);
            image10.gameObject.SetActive(false);
        }
        else if (maxStatValue == 8)
        {
            image6.gameObject.SetActive(true);
            image7.gameObject.SetActive(true);
            image8.gameObject.SetActive(true);
            image9.gameObject.SetActive(false);
            image10.gameObject.SetActive(false);
        }
        else if (maxStatValue == 9)
        {
            image6.gameObject.SetActive(true);
            image7.gameObject.SetActive(true);
            image8.gameObject.SetActive(true);
            image9.gameObject.SetActive(true);
            image10.gameObject.SetActive(false);
        }
        else if (maxStatValue == 10)
        {
            image6.gameObject.SetActive(true);
            image7.gameObject.SetActive(true);
            image8.gameObject.SetActive(true);
            image9.gameObject.SetActive(true);
            image10.gameObject.SetActive(true);
        }
        else
        {
            if (image6 != null)
            {
                image6.gameObject.SetActive(false);
            }
            if (image7 != null)
            {
                image7.gameObject.SetActive(false);
            }
            if (image8 != null)
            {
                image8.gameObject.SetActive(false);
            }
            if (image9 != null)
            {
                image9.gameObject.SetActive(false);
            }
            if (image10 != null)
            {
                image10.gameObject.SetActive(false);
            }
        }
    }
    #endregion
}
