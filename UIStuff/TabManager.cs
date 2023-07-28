using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabManager : MonoBehaviour
{
    #region Singleton
    public static TabManager Instance { get; private set; }
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

    [SerializeField] private GameObject vampSheetTab;
    [SerializeField] private GameObject mageSheetTab;
    [SerializeField] private GameObject wereSheetTab;
    [SerializeField] private GameObject changSheetTab;
    [SerializeField] private GameObject geistSheetTab;
    [SerializeField] private GameObject demonSheetTab;
    [SerializeField] private GameObject mummySheetTab;
    [SerializeField] private GameObject prometheanSheetTab;
    [SerializeField] private GameObject beastSheetTab;
    [SerializeField] private GameObject deviantSheetTab;
    [SerializeField] private GameObject hunterSheetTab;
    [SerializeField] private GameObject mortalSheetTab;
    [SerializeField] private GameObject vampButtonTab;
    [SerializeField] private GameObject mageButtonTab;
    [SerializeField] private GameObject wereButtonTab;
    [SerializeField] private GameObject changButtonTab;
    [SerializeField] private GameObject geistButtonTab;
    [SerializeField] private GameObject demonButtonTab;
    [SerializeField] private GameObject mummyButtonTab;
    [SerializeField] private GameObject prometheanButtonTab;
    [SerializeField] private GameObject beastButtonTab;
    [SerializeField] private GameObject deviantButtonTab;
    [SerializeField] private GameObject hunterButtonTab;
    [SerializeField] private GameObject mortalButtonTab;
    [SerializeField] private GameObject cityButtonTab;
    [SerializeField] private GameObject vampWodTab;
    [SerializeField] private GameObject mageWodTab;
    [SerializeField] private GameObject vampCofdTab;
    [SerializeField] private GameObject mageCofdTab;

    public bool wodConversion = false;

    private void Start()
    {
        SetAllTabsInactive();
        SetAllButtonsInactive();
    }

    public void VampireSheetSetActive()
    {
        UIManager.Instance.template = TemplateType.Vampire;
        SetAllTabsInactive();
        vampSheetTab.SetActive(true);
    }
    public void MageSheetSetActive()
    {
        UIManager.Instance.template = TemplateType.Mage;
        SetAllTabsInactive();
        mageSheetTab.SetActive(true);
    }
    public void WerewolfSheetSetActive()
    {
        UIManager.Instance.template = TemplateType.Werewolf;
        SetAllTabsInactive();
        wereSheetTab.SetActive(true);
    }
    public void ChangelingSheetSetActive()
    {
        UIManager.Instance.template = TemplateType.Changeling;
        SetAllTabsInactive();
        changSheetTab.SetActive(true);
    }
    public void GeistSheetSetActive()
    {
        UIManager.Instance.template = TemplateType.Geist;
        SetAllTabsInactive();
        geistSheetTab.SetActive(true);
    }
    public void PromeatheanSheetSetActive()
    {
        UIManager.Instance.template = TemplateType.Geist;
        SetAllTabsInactive();
        prometheanSheetTab.SetActive(true);
    }
    public void BeastSheetSetActive()
    {
        UIManager.Instance.template = TemplateType.Geist;
        SetAllTabsInactive();
        beastSheetTab.SetActive(true);
    }
    public void DeviantSheetSetActive()
    {
        UIManager.Instance.template = TemplateType.Geist;
        SetAllTabsInactive();
        deviantSheetTab.SetActive(true);
    }
    public void DemonSheetSetActive()
    {
        UIManager.Instance.template = TemplateType.Demon;
        SetAllTabsInactive();
        demonSheetTab.SetActive(true);
    }
    public void MummySheetSetActive()
    {
        UIManager.Instance.template = TemplateType.Mummy;
        SetAllTabsInactive();
        mummySheetTab.SetActive(true);
    }
    public void HunterSheetSetActive()
    {
        UIManager.Instance.template = TemplateType.Hunter;
        SetAllTabsInactive();
        hunterSheetTab.SetActive(true);
    }
    public void MortalSheetSetActive()
    {
        UIManager.Instance.template = TemplateType.Mortal;
        SetAllTabsInactive();
        mortalSheetTab.SetActive(true);
    }

    public void VampireButtonActive()
    {
        SetAllButtonsInactive();
        SetAllTabsInactive();
        vampButtonTab.SetActive(true);
    }
    public void MageButtonActive()
    {
        SetAllButtonsInactive();
        SetAllTabsInactive();
        mageButtonTab.SetActive(true);
    }
    public void WerewolfButtonActive()
    {
        SetAllButtonsInactive();
        SetAllTabsInactive();
        wereButtonTab.SetActive(true);
    }
    public void ChangelingButtonActive()
    {
        SetAllButtonsInactive();
        SetAllTabsInactive();
        changButtonTab.SetActive(true);
    }
    public void GeistButtonActive()
    {
        SetAllButtonsInactive();
        SetAllTabsInactive();
        geistButtonTab.SetActive(true);
    }
    public void DemonButtonActive()
    {
        SetAllButtonsInactive();
        SetAllTabsInactive();
        demonButtonTab.SetActive(true);
    }
    public void MummyButtonActive()
    {
        SetAllButtonsInactive();
        SetAllTabsInactive();
        mummyButtonTab.SetActive(true);
    }
    public void PrometheanButtonActive()
    {
        SetAllButtonsInactive();
        SetAllTabsInactive();
        prometheanButtonTab.SetActive(true);
    }
    public void BeastButtonActive()
    {
        SetAllButtonsInactive();
        SetAllTabsInactive();
        beastButtonTab.SetActive(true);
    }
    public void DeviantButtonActive()
    {
        SetAllButtonsInactive();
        SetAllTabsInactive();
        deviantButtonTab.SetActive(true);
    }
    public void HunterButtonActive()
    {
        SetAllButtonsInactive();
        SetAllTabsInactive();
        hunterButtonTab.SetActive(true);
    }
    public void MortalButtonActive()
    {
        SetAllButtonsInactive();
        SetAllTabsInactive();
        mortalButtonTab.SetActive(true);
    }
    public void CityButtonActive()
    {
        SetAllButtonsInactive();
        SetAllTabsInactive();
        cityButtonTab.SetActive(true);
    }

    private void SetAllTabsInactive()
    {
        vampSheetTab.SetActive(false);
        mageSheetTab.SetActive(false);
        wereSheetTab.SetActive(false);
        changSheetTab.SetActive(false);
        geistSheetTab.SetActive(false);
        demonSheetTab.SetActive(false);
        mummySheetTab.SetActive(false);
        prometheanSheetTab.SetActive(false);
        beastSheetTab.SetActive(false);
        deviantSheetTab.SetActive(false);
        mortalSheetTab.SetActive(false);
        hunterSheetTab.SetActive(false);
    }
    private void SetAllButtonsInactive()
    {
        vampButtonTab.SetActive(false);
        mageButtonTab.SetActive(false);
        wereButtonTab.SetActive(false);
        changButtonTab.SetActive(false);
        geistButtonTab.SetActive(false);
        prometheanButtonTab.SetActive(false);
        beastButtonTab.SetActive(false);
        deviantButtonTab.SetActive(false);
        demonButtonTab.SetActive(false);
        mummyButtonTab.SetActive(false);
        mortalButtonTab.SetActive(false);
        hunterButtonTab.SetActive(false);
        cityButtonTab.SetActive(false);
    }

    public void OWoDConversionChange()
    {
        wodConversion = !wodConversion;
        if (wodConversion == true)
        {
            vampWodTab.SetActive(true);
            mageWodTab.SetActive(true);
            vampCofdTab.SetActive(false);
            mageCofdTab.SetActive(false);
        }
        else
        {
            vampWodTab.SetActive(false);
            mageWodTab.SetActive(false);
            vampCofdTab.SetActive(true);
            mageCofdTab.SetActive(true);
        }
    }
}
