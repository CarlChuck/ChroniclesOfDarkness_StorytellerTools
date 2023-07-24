using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharGenerator : MonoBehaviour
{
    #region Singleton
    public static CharGenerator Instance { get; private set; }
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
    public GameObject charListParent;

    public GameObject mortal;
    public GameObject vampire;
    public GameObject mage;
    public GameObject werewolf;
    public GameObject changeling;
    public GameObject geist;
    public GameObject promethean;
    public GameObject beast;
    public GameObject deviant;
    public GameObject demon;
    public GameObject mummy;
    public GameObject hunter;

    public List<CharTemplate> listOfCharacters;
    public CharTemplate selectedTemplate;

    [SerializeField] private TextMeshProUGUI nation;

    #region GenerateIndividuals
    public void GenerateRandomVampire(int sect)
    {
        bool isItWoD = TabManager.Instance.wodConversion;
        VampireTemplate newVamp = Instantiate(vampire, charListParent.transform).GetComponent<VampireTemplate>();
        newVamp.AddVampireTraits(sect, isItWoD);
        newVamp.CreateCharacter();
        selectedTemplate = newVamp;
        UIManager.Instance.vampireSheet.UpdateThisSheet(newVamp);
    }
    public void GenerateRandomMage(int sect)
    {
        bool isItWoD = TabManager.Instance.wodConversion;
        MageTemplate newMage = Instantiate(mage, charListParent.transform).GetComponent<MageTemplate>();
        newMage.AddMageTraits(sect, isItWoD);
        newMage.CreateCharacter();
        selectedTemplate = newMage;
        UIManager.Instance.mageSheet.UpdateThisSheet(newMage);
    }
    public void GenerateRandomWerewolf(int sect)
    {
        WerewolfTemplate newWere = Instantiate(werewolf, charListParent.transform).GetComponent<WerewolfTemplate>();
        newWere.AddWerewolfTraits(sect);
        newWere.CreateCharacter();
        selectedTemplate = newWere;
        UIManager.Instance.werSheet.UpdateThisSheet(newWere);
    }
    public void GenerateChangeling(int sect)
    {
        ChangelingTemplate newChang = Instantiate(changeling, charListParent.transform).GetComponent<ChangelingTemplate>();
        newChang.AddChangelingTraits(sect);
        newChang.CreateCharacter();
        selectedTemplate = newChang;
        UIManager.Instance.changeSheet.UpdateThisSheet(newChang);
    }
    public void GenerateGeist(int sect)
    {
        GeistTemplate newGeist = Instantiate(geist, charListParent.transform).GetComponent<GeistTemplate>();
        newGeist.AddGeistTraits(sect);
        newGeist.CreateCharacter();
        selectedTemplate = newGeist;
        UIManager.Instance.geistSheet.UpdateThisSheet(newGeist);
    }
    public void GenerateDemon(int sect)
    {
        DemonTemplate newDemon = Instantiate(demon, charListParent.transform).GetComponent<DemonTemplate>();
        newDemon.AddDemonTraits(sect);
        newDemon.CreateCharacter();
        selectedTemplate = newDemon;
        UIManager.Instance.demonSheet.UpdateThisSheet(newDemon);
    }
    public void GeneratePromethean(int sect)
    {
        PrometheanTemplate newProm = Instantiate(promethean, charListParent.transform).GetComponent<PrometheanTemplate>();
        newProm.AddPrometheanTraits(sect);
        newProm.CreateCharacter();
        selectedTemplate = newProm;
        UIManager.Instance.vampireSheet.UpdateThisSheet(newProm);
    }
    public void GenerateMummy(int sect)
    {
        MummyTemplate newMummy = Instantiate(mummy, charListParent.transform).GetComponent<MummyTemplate>();
        newMummy.AddMummyTraits(sect);
        newMummy.CreateCharacter();
        selectedTemplate = newMummy;
        UIManager.Instance.mummySheet.UpdateThisSheet(newMummy);
    }
    public void GenerateBeast(int sect)
    {
        BeastTemplate newBeast = Instantiate(beast, charListParent.transform).GetComponent<BeastTemplate>();
        newBeast.AddBeastTraits(sect);
        newBeast.CreateCharacter();
        selectedTemplate = newBeast;
        UIManager.Instance.beastSheet.UpdateThisSheet(newBeast);
    }
    public void GenerateDeviant(int sect)
    {
        DeviantTemplate newDeviant = Instantiate(deviant, charListParent.transform).GetComponent<DeviantTemplate>();
        newDeviant.AddDeviantTraits(sect);
        newDeviant.CreateCharacter();
        selectedTemplate = newDeviant;
        UIManager.Instance.deviantSheet.UpdateThisSheet(newDeviant);
    }
    public void GenerateHunter(int sect)
    {
        HunterTemplate newHunter = Instantiate(hunter, charListParent.transform).GetComponent<HunterTemplate>();
        newHunter.AddHunterTraits(sect);
        newHunter.CreateCharacter();
        selectedTemplate = newHunter;
        UIManager.Instance.hunterSheet.UpdateThisSheet(newHunter);
    }
    public void GenerateMortal(int sect)
    {
        CharTemplate newMortal = Instantiate(mortal, charListParent.transform).GetComponent<CharTemplate>();
        newMortal.isMortal = true;
        newMortal.CreateCharacter();
        newMortal.AddMortalStuff(sect);
        selectedTemplate = newMortal;
        UIManager.Instance.mortalSheet.UpdateThisSheet(newMortal);
    }
    #endregion

    #region SetPriorityStates
    private void RandomiseTheAttributes(CharTemplate theChar)
    {
        int rand = Random.Range(1,7);
        switch (rand)
        {
            case 1:
                theChar.physicalAttributes = State.Primary;
                theChar.socialAttributes = State.Secondary;
                theChar.mentalAttributes = State.Tertiary;
                break;
            case 2:
                theChar.physicalAttributes = State.Primary;
                theChar.socialAttributes = State.Tertiary;
                theChar.mentalAttributes = State.Secondary;
                break;
            case 3:
                theChar.physicalAttributes = State.Secondary;
                theChar.socialAttributes = State.Primary;
                theChar.mentalAttributes = State.Tertiary;
                break;
            case 4:
                theChar.physicalAttributes = State.Tertiary;
                theChar.socialAttributes = State.Primary;
                theChar.mentalAttributes = State.Secondary;
                break;
            case 5:
                theChar.physicalAttributes = State.Secondary;
                theChar.socialAttributes = State.Tertiary;
                theChar.mentalAttributes = State.Primary;
                break;
            case 6:
                theChar.physicalAttributes = State.Tertiary;
                theChar.socialAttributes = State.Secondary;
                theChar.mentalAttributes = State.Primary;
                break;
        }
    }
    private void RandomiseTheAbilities(CharTemplate theChar)
    {
        int rand = Random.Range(1, 7);
        switch (rand)
        {
            case 1:
                theChar.physicalSkills = State.Primary;
                theChar.socialSkills = State.Secondary;
                theChar.mentalSkills = State.Tertiary;
                break;
            case 2:
                theChar.physicalSkills = State.Primary;
                theChar.socialSkills = State.Tertiary;
                theChar.mentalSkills = State.Secondary;
                break;
            case 3:
                theChar.physicalSkills = State.Secondary;
                theChar.socialSkills = State.Primary;
                theChar.mentalSkills = State.Tertiary;
                break;
            case 4:
                theChar.physicalSkills = State.Tertiary;
                theChar.socialSkills = State.Primary;
                theChar.mentalSkills = State.Secondary;
                break;
            case 5:
                theChar.physicalSkills = State.Secondary;
                theChar.socialSkills = State.Tertiary;
                theChar.mentalSkills = State.Primary;
                break;
            case 6:
                theChar.physicalSkills = State.Tertiary;
                theChar.socialSkills = State.Secondary;
                theChar.mentalSkills = State.Primary;
                break;
        }
    }
    private void RandomisePhysicalFocusedStats(CharTemplate theChar)
    {
        int rand = Random.Range(1,4); 
        switch (rand)
        {
            case 1:
                theChar.physicalAttributes = State.Primary;
                theChar.socialAttributes = State.Secondary;
                theChar.mentalAttributes = State.Tertiary;
                break;
            case 2:
                theChar.physicalAttributes = State.Primary;
                theChar.socialAttributes = State.Tertiary;
                theChar.mentalAttributes = State.Secondary;
                break;
            case 3:
                RandomiseTheAttributes(theChar);
                break;
        }
        rand = Random.Range(1, 4); 
        switch (rand)
        {
            case 1:
                theChar.physicalSkills = State.Secondary;
                theChar.socialSkills = State.Primary;
                theChar.mentalSkills = State.Tertiary;
                break;
            case 2:
                theChar.physicalSkills = State.Tertiary;
                theChar.socialSkills = State.Primary;
                theChar.mentalSkills = State.Secondary;
                break;
            case 3:
                RandomiseTheAbilities(theChar);
                break;
        }
    }
    private void RandomiseSocialFocusedStats(CharTemplate theChar)
    {
        int rand = Random.Range(1, 4);
        switch (rand)
        {
            case 1:
                theChar.physicalAttributes = State.Secondary;
                theChar.socialAttributes = State.Primary;
                theChar.mentalAttributes = State.Tertiary;
                break;
            case 2:
                theChar.physicalAttributes = State.Tertiary;
                theChar.socialAttributes = State.Primary;
                theChar.mentalAttributes = State.Secondary;
                break;
            case 3:
                RandomiseTheAttributes(theChar);
                break;
        }
        rand = Random.Range(1, 4);
        switch (rand)
        {
            case 1:
                theChar.physicalSkills = State.Primary;
                theChar.socialSkills = State.Secondary;
                theChar.mentalSkills = State.Tertiary;
                break;
            case 2:
                theChar.physicalSkills = State.Primary;
                theChar.socialSkills = State.Tertiary;
                theChar.mentalSkills = State.Secondary;
                break;
            case 3:
                RandomiseTheAbilities(theChar);
                break;
        }
    }
    private void RandomiseMentalFocusedStats(CharTemplate theChar)
    {
        int rand = Random.Range(1, 4);
        switch (rand)
        {
            case 1:
                theChar.physicalAttributes = State.Secondary;
                theChar.socialAttributes = State.Tertiary;
                theChar.mentalAttributes = State.Primary;
                break;
            case 2:
                theChar.physicalAttributes = State.Tertiary;
                theChar.socialAttributes = State.Secondary;
                theChar.mentalAttributes = State.Primary;
                break;
            case 3:
                RandomiseTheAttributes(theChar);
                break;
        }
        rand = Random.Range(1, 4);
        switch (rand)
        {
            case 1:
                theChar.physicalSkills = State.Secondary;
                theChar.socialSkills = State.Tertiary;
                theChar.mentalSkills = State.Primary;
                break;
            case 2:
                theChar.physicalSkills = State.Tertiary;
                theChar.socialSkills = State.Secondary;
                theChar.mentalSkills = State.Primary;
                break;
            case 3:
                RandomiseTheAbilities(theChar);
                break;
        }
    }

    private void SetPrioritiesByVampireClan()
    {
       
    }
    private void SetPrioritiesByMageAffiliation()
    {
        
    }
    #endregion

    public void ClearAllCharacters()
    {
        foreach (CharTemplate ctemp in listOfCharacters)
        {
            Destroy(ctemp.gameObject);
        }
        listOfCharacters.Clear();
    }
}
