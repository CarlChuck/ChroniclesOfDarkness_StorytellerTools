using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    #region Singleton
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion

    public static UIManager Instance { get; private set; }
    public TemplateType template;
    public Color vampColour;
    public Color mageColour;
    public Color wereColour;
    public Color changColour;
    public Color geistColour;
    public Color demonColour;
    public Color prometheanColour;
    public Color mummyColour;
    public Color beastColour;
    public Color deviantColour;
    public Color hunterColour;
    public Color mortalColour;

    public Color selectedColour;

    public UICharSheet vampireSheet;
    public UICharSheet mageSheet;
    public UICharSheet changeSheet;
    public UICharSheet werSheet;
    public UICharSheet geistSheet;
    public UICharSheet demonSheet;
    public UICharSheet promethSheet;
    public UICharSheet mummySheet;
    public UICharSheet beastSheet;
    public UICharSheet deviantSheet;
    public UICharSheet hunterSheet;
    public UICharSheet mortalSheet;


    [SerializeField] private GameObject statPrefab;

    [SerializeField] public GameObject citySheet;

    public void Start()
    {
        Screen.SetResolution(1440, 810, false);
    }
    public Color GetColour()
    {
        return selectedColour;
    }
    private void SetColour()
    {
        switch (template)
        {
            case TemplateType.Vampire:
                selectedColour = vampColour;
                break;
            case TemplateType.Mage:
                selectedColour = vampColour;
                break;
            case TemplateType.Changeling:
                selectedColour = vampColour;
                break;
            case TemplateType.Werewolf:
                selectedColour = vampColour;
                break;
            case TemplateType.Demon:
                selectedColour = vampColour;
                break;
            case TemplateType.Mummy:
                selectedColour = vampColour;
                break;
            case TemplateType.Geist:
                selectedColour = vampColour;
                break;
            case TemplateType.Promethean:
                selectedColour = vampColour;
                break;
            case TemplateType.Beast:
                selectedColour = vampColour;
                break;
            case TemplateType.Deviant:
                selectedColour = vampColour;
                break;
            case TemplateType.Hunter:
                selectedColour = vampColour;
                break;
            case TemplateType.Mortal:
                selectedColour = vampColour;
                break;
        }
    }
    public void UpdateGeneralUI(TemplateType tType)
    {
        template = tType;
        SetColour();
    }
}
public enum TemplateType {None, Vampire, Mage, Changeling, Werewolf, Demon, Mummy, Geist, Promethean, Beast, Deviant, Hunter, Mortal }