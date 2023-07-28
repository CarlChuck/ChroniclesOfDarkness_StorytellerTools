using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICharSheet : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI charName;
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private TextMeshProUGUI chronicles;
    [SerializeField] private TextMeshProUGUI virtue;
    [SerializeField] private TextMeshProUGUI vice;
    [SerializeField] private TextMeshProUGUI concept;
    [SerializeField] private TextMeshProUGUI text1;
    [SerializeField] private TextMeshProUGUI text2;
    [SerializeField] private TextMeshProUGUI text3;

    [SerializeField] private UIStat strength;
    [SerializeField] private UIStat dexterity;
    [SerializeField] private UIStat stamina;
    [SerializeField] private UIStat presence;
    [SerializeField] private UIStat manipulation;
    [SerializeField] private UIStat composure;
    [SerializeField] private UIStat intelligence;
    [SerializeField] private UIStat wits;
    [SerializeField] private UIStat resolve;

    [SerializeField] private UIStat academics;
    [SerializeField] private UIStat computer;
    [SerializeField] private UIStat crafts;
    [SerializeField] private UIStat investigation;
    [SerializeField] private UIStat medicine;
    [SerializeField] private UIStat occult;
    [SerializeField] private UIStat politics;
    [SerializeField] private UIStat science;

    [SerializeField] private UIStat athletics;
    [SerializeField] private UIStat brawl;
    [SerializeField] private UIStat drive;
    [SerializeField] private UIStat firearms;
    [SerializeField] private UIStat larceny;
    [SerializeField] private UIStat stealth;
    [SerializeField] private UIStat survival;
    [SerializeField] private UIStat weaponry;

    [SerializeField] private UIStat animalKen;
    [SerializeField] private UIStat empathy;
    [SerializeField] private UIStat expression;
    [SerializeField] private UIStat intimidation;
    [SerializeField] private UIStat persuasion;
    [SerializeField] private UIStat socialise;
    [SerializeField] private UIStat streetwise;
    [SerializeField] private UIStat subterfuge;

    [SerializeField] private UIStat health;
    [SerializeField] private UIStat willpower;
    [SerializeField] private UIStat potency;
    [SerializeField] private UIStat integrity;

    [SerializeField] private TextMeshProUGUI size;
    [SerializeField] private TextMeshProUGUI speed;
    [SerializeField] private TextMeshProUGUI defence;
    [SerializeField] private TextMeshProUGUI armour;
    [SerializeField] private TextMeshProUGUI initiative;

    public GameObject uiStatPrefab;
    public GameObject meritLayoutGroup;
    public GameObject powersLayoutGroup;
    public List<UIStat> merits;
    public List<UIStat> powers;



    public void UpdateThisSheet(CharTemplate cTemplate)
    {
        SetAllStatsMaxValue(cTemplate.maxAttributeSkill);
        SetAllAttributes(cTemplate);
        SetAllSkills(cTemplate);
        SetDerivedStats(cTemplate);
        SetTextFields(cTemplate);
        if (cTemplate is VampireTemplate)
        {
            VampireTemplate vtemp = cTemplate as VampireTemplate;
            AddVampireTextFields(vtemp);
            AddVampireDisciplines(vtemp);
        }
        else if (cTemplate is MageTemplate)
        {
            MageTemplate mtemp = cTemplate as MageTemplate;
            AddMageTextFields(mtemp);
            AddMageArcana(mtemp);
        }
        else if (cTemplate is ChangelingTemplate)
        {
            ChangelingTemplate ctemp = cTemplate as ChangelingTemplate;
            AddChangelingTextFields(ctemp);
        }
        else if (cTemplate is WerewolfTemplate)
        {
            WerewolfTemplate wtemp = cTemplate as WerewolfTemplate;
            AddWerewolfTextFields(wtemp);
        }
        else if (cTemplate is GeistTemplate)
        {
            GeistTemplate gtemp = cTemplate as GeistTemplate;
            AddGeistTextFields(gtemp);
        }
        else if (cTemplate is DemonTemplate)
        {
            DemonTemplate dtemp = cTemplate as DemonTemplate;
            AddDemonTextFields(dtemp);
        }
        else if (cTemplate is PrometheanTemplate)
        {
            PrometheanTemplate ptemp = cTemplate as PrometheanTemplate;
            AddPrometheanTextFields(ptemp);
        }
        else if (cTemplate is MummyTemplate)
        {
            MummyTemplate mtemp = cTemplate as MummyTemplate;
            AddMummyTextFields(mtemp);
        }
        else if (cTemplate is BeastTemplate)
        {
            BeastTemplate btemp = cTemplate as BeastTemplate;
            AddBeastTextFields(btemp);
        }
        else if (cTemplate is DeviantTemplate)
        {
            DeviantTemplate dtemp = cTemplate as DeviantTemplate;
            AddDeviantTextFields(dtemp);
        }
        else if (cTemplate is HunterTemplate)
        {
            HunterTemplate htemp = cTemplate as HunterTemplate;
            AddHunterTextFields(htemp);
        }
        else
        {            
            AddMortalTextFields(cTemplate);
        }
    }

    public void SetAllStatsMaxValue(int num)
    {
        strength.SetMaxStatValue(num);
        dexterity.SetMaxStatValue(num);
        stamina.SetMaxStatValue(num);
        presence.SetMaxStatValue(num);
        manipulation.SetMaxStatValue(num);
        composure.SetMaxStatValue(num);
        intelligence.SetMaxStatValue(num);
        wits.SetMaxStatValue(num);
        resolve.SetMaxStatValue(num);

        academics.SetMaxStatValue(num);
        computer.SetMaxStatValue(num);
        crafts.SetMaxStatValue(num);
        investigation.SetMaxStatValue(num);
        medicine.SetMaxStatValue(num);
        occult.SetMaxStatValue(num);
        politics.SetMaxStatValue(num);
        science.SetMaxStatValue(num);

        athletics.SetMaxStatValue(num);
        brawl.SetMaxStatValue(num);
        drive.SetMaxStatValue(num);
        firearms.SetMaxStatValue(num);
        larceny.SetMaxStatValue(num);
        stealth.SetMaxStatValue(num);
        survival.SetMaxStatValue(num);
        weaponry.SetMaxStatValue(num);

        animalKen.SetMaxStatValue(num);
        empathy.SetMaxStatValue(num);
        expression.SetMaxStatValue(num);
        intimidation.SetMaxStatValue(num);
        persuasion.SetMaxStatValue(num);
        socialise.SetMaxStatValue(num);
        streetwise.SetMaxStatValue(num);
        subterfuge.SetMaxStatValue(num);
    }

    public void SetAllAttributes(CharTemplate cTemplate)
    {
        Color colour = UIManager.Instance.GetColour();
        strength.SetStat(cTemplate.strength.GetStatValue(), colour);
        dexterity.SetStat(cTemplate.dexterity.GetStatValue(), colour);
        stamina.SetStat(cTemplate.stamina.GetStatValue(), colour);
        presence.SetStat(cTemplate.presence.GetStatValue(), colour);
        manipulation.SetStat(cTemplate.manipulation.GetStatValue(), colour);
        composure.SetStat(cTemplate.composure.GetStatValue(), colour);
        intelligence.SetStat(cTemplate.intelligence.GetStatValue(), colour);
        wits.SetStat(cTemplate.wits.GetStatValue(), colour);
        resolve.SetStat(cTemplate.resolve.GetStatValue(), colour);
    }
    public void SetAllSkills(CharTemplate cTemplate)
    {
        Color colour = UIManager.Instance.GetColour();
        academics.SetStat(cTemplate.academics.GetStatValue(), colour);
        computer.SetStat(cTemplate.computer.GetStatValue(), colour);
        crafts.SetStat(cTemplate.crafts.GetStatValue(), colour);
        investigation.SetStat(cTemplate.investigation.GetStatValue(), colour);
        medicine.SetStat(cTemplate.medicine.GetStatValue(), colour);
        occult.SetStat(cTemplate.occult.GetStatValue(), colour);
        politics.SetStat(cTemplate.politics.GetStatValue(), colour);
        science.SetStat(cTemplate.science.GetStatValue(), colour);

        athletics.SetStat(cTemplate.athletics.GetStatValue(), colour);
        brawl.SetStat(cTemplate.brawl.GetStatValue(), colour);
        drive.SetStat(cTemplate.drive.GetStatValue(), colour);
        firearms.SetStat(cTemplate.firearms.GetStatValue(), colour);
        larceny.SetStat(cTemplate.larceny.GetStatValue(), colour);
        stealth.SetStat(cTemplate.stealth.GetStatValue(), colour);
        survival.SetStat(cTemplate.survival.GetStatValue(), colour);
        weaponry.SetStat(cTemplate.weaponry.GetStatValue(), colour);

        animalKen.SetStat(cTemplate.animalKen.GetStatValue(), colour);
        empathy.SetStat(cTemplate.empathy.GetStatValue(), colour);
        expression.SetStat(cTemplate.expression.GetStatValue(), colour);
        intimidation.SetStat(cTemplate.intimidation.GetStatValue(), colour);
        persuasion.SetStat(cTemplate.persuasion.GetStatValue(), colour);
        socialise.SetStat(cTemplate.socialise.GetStatValue(), colour);
        streetwise.SetStat(cTemplate.streetwise.GetStatValue(), colour);
        subterfuge.SetStat(cTemplate.subterfuge.GetStatValue(), colour);
    }
    public void SetDerivedStats(CharTemplate cTemplate)
    {
        Color colour = UIManager.Instance.GetColour();
        health.SetStat(cTemplate.health, colour);
        willpower.SetStat(cTemplate.willpower, colour);
        potency.SetStat(cTemplate.potency, colour);
        integrity.SetStat(cTemplate.integrity, colour);
        size.text = cTemplate.size.ToString();
        speed.text = cTemplate.speed.ToString();
        defence.text = cTemplate.defence.ToString();
        armour.text = cTemplate.armour.ToString();
        initiative.text = cTemplate.initiative.ToString();
    }
    public void SetTextFields(CharTemplate cTemplate)
    {
        charName.text = cTemplate.GetName();
        playerName.text = "";
        chronicles.text = "";
    }
    public void AddVampireTextFields(VampireTemplate vTemplate)
    {
        virtue.text = vTemplate.GetMask();
        vice.text = vTemplate.GetDirge();
        concept.text = vTemplate.GetConcept();
        text1.text = vTemplate.GetClan().ToString();
        text2.text = vTemplate.GetBloodline().ToString();
        text3.text = vTemplate.GetCovenant().ToString();
    }
    public void AddVampireDisciplines(VampireTemplate vTemplate)
    {
        ClearPowersAndMerits();
        List<CharStat> charList = vTemplate.GetCurrentDisciplinesList();
        Color colour = UIManager.Instance.GetColour();
        foreach (CharStat stat in charList)
        {
            UIStat newDisc = Instantiate(uiStatPrefab, powersLayoutGroup.transform).GetComponent<UIStat>();
            newDisc.SetStat(stat.GetStatValue(), 5, stat.GetStatName(), colour);
            powers.Add(newDisc);
        }
    }
    public void AddMageTextFields(MageTemplate mTemplate)
    {
        
        virtue.text = mTemplate.GetVirtue();
        vice.text = mTemplate.GetVice();
        concept.text = mTemplate.GetConcept();
        text1.text = mTemplate.GetMageOrder().ToString();
        text2.text = mTemplate.GetMagePath().ToString();
        text3.text = mTemplate.GetMageLegacy().ToString();
        
    }
    public void AddMageArcana(MageTemplate mTemplate)
    {
        ClearPowersAndMerits();
        List<CharStat> charList = mTemplate.GetArcanaList();
        Color colour = UIManager.Instance.GetColour();
        foreach (CharStat stat in charList)
        {
            UIStat newArcana = Instantiate(uiStatPrefab, powersLayoutGroup.transform).GetComponent<UIStat>();
            newArcana.SetStat(stat.GetStatValue(), 5, stat.GetStatName(), colour);
            powers.Add(newArcana);
        }
    }
    public void AddChangelingTextFields(ChangelingTemplate cTemplate)
    {
        
        virtue.text = cTemplate.GetNeedle();
        vice.text = cTemplate.GetThread();
        concept.text = cTemplate.GetConcept();
        text1.text = cTemplate.GetSeeming().ToString();
        text2.text = cTemplate.GetKith().ToString();
        text3.text = cTemplate.GetCourt().ToString();
        
    }
    public void AddWerewolfTextFields(WerewolfTemplate cTemplate)
    {
        
        virtue.text = cTemplate.GetBlood();
        vice.text = cTemplate.GetBone();
        concept.text = cTemplate.GetConcept();
        text1.text = cTemplate.GetAuspice().ToString();
        text2.text = cTemplate.GetTribe().ToString();
        text3.text = cTemplate.GetLodge().ToString();
        
    }
    public void AddGeistTextFields(GeistTemplate cTemplate)
    {
        playerName.text = cTemplate.GetBurden().ToString();
        virtue.text = cTemplate.GetRoot();
        vice.text = cTemplate.GetBloom();
        concept.text = cTemplate.GetConcept();
        text1.text = cTemplate.GetGeist();
        text2.text = cTemplate.GetKrewe();
        text3.text = cTemplate.GetKreweArchetype().ToString();
    }
    public void AddDemonTextFields(DemonTemplate cTemplate)
    {
        virtue.text = cTemplate.GetVirtue();
        vice.text = cTemplate.GetVice();
        concept.text = cTemplate.GetConcept();
        text1.text = cTemplate.GetIncarnation().ToString();
        text2.text = cTemplate.GetAgenda().ToString();
        text3.text = cTemplate.GetCatalyst();
    }
    public void AddPrometheanTextFields(PrometheanTemplate cTemplate)
    {
        virtue.text = cTemplate.GetElpis();
        vice.text = cTemplate.GetTorment();
        concept.text = cTemplate.GetConcept();
        text1.text = cTemplate.GetLineage().ToString();
        text2.text = cTemplate.GetRefinement().ToString();
        text3.text = cTemplate.GetRole();
    }
    public void AddMummyTextFields(MummyTemplate cTemplate)
    {
        virtue.text = cTemplate.GetDecree().ToString();
        vice.text = cTemplate.GetBurden();
        concept.text = cTemplate.GetConcept();
        text1.text = cTemplate.GetGuild().ToString();
        text2.text = cTemplate.GetJudge().ToString();
        text3.text = cTemplate.GetBalance();
    }
    public void AddBeastTextFields(BeastTemplate cTemplate)
    {
        virtue.text = cTemplate.GetLegend();
        vice.text = cTemplate.GetLife();
        concept.text = cTemplate.GetConcept();
        text1.text = cTemplate.GetFamily().ToString();
        text2.text = cTemplate.GetHunger().ToString();
        text3.text = cTemplate.GetHorror();
    }
    public void AddDeviantTextFields(DeviantTemplate cTemplate)
    {
        virtue.text = cTemplate.GetOrigin().ToString();
        vice.text = cTemplate.GetClade().ToString();
        concept.text = cTemplate.GetConcept();
        text1.text = cTemplate.GetForm();
        text2.text = "";
        text3.text = "";
    }
    public void AddHunterTextFields(HunterTemplate cTemplate)
    {
        virtue.text = cTemplate.GetVirtue();
        vice.text = cTemplate.GetVice();
        concept.text = cTemplate.GetConcept();
        text1.text = cTemplate.GetCell();
        text2.text = cTemplate.GetCompact().ToString();
        text3.text = cTemplate.GetConspiracy().ToString();
    }
    public void AddMortalTextFields(CharTemplate cTemplate)
    {        
        virtue.text = cTemplate.GetVirtue();
        vice.text = cTemplate.GetVice();
        concept.text = cTemplate.GetConcept();
        text1.text = cTemplate.GetAge().ToString();
        text2.text = cTemplate.GetFaction();
        text3.text = cTemplate.GetGroup();        
    }
    private void ClearPowersAndMerits()
    {
        foreach (UIStat stat in powers)
        {
            Destroy(stat.gameObject);
        }

        foreach (UIStat stat in merits)
        {
            Destroy(stat.gameObject);
        }
        powers = new();
        merits = new();
    }
}
