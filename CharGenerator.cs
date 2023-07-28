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


    #region GenerateButtons

    public void GenerateAVampire(int sect)
    {
        GenerateVampire(sect);
    }
    public void GenerateAMage(int sect)
    {
        GenerateMage(sect);
    }
    public void GenerateAChangeling(int sect)
    {
        GenerateChangeling(sect);
    }
    public void GenerateAWerewolf(int sect)
    {
        GenerateWerewolf(sect);
    }
    public void GenerateAGeist(int sect)
    {
        GenerateGeist(sect);
    }
    public void GenerateADemon(int sect)
    {
        GenerateDemon(sect);
    }
    public void GenerateAPromethean(int sect)
    {
        GeneratePromethean(sect);
    }
    public void GenerateAMummy(int sect)
    {
        GenerateMummy(sect);
    }
    public void GenerateABeast(int sect)
    {
        GenerateBeast(sect);
    }
    public void GenerateADeviant(int sect)
    {
        GenerateDeviant(sect);
    }
    public void GenerateAHunter(int sect)
    {
        GenerateHunter(sect);
    }
    public void GenerateAMortal(int sect)
    {
        GenerateMortal(sect);
    }
    #endregion
    #region GenerateIndividuals
    public void GenerateVampire(int sect, bool toCharSheet = true)
    {
        bool isItWoD = TabManager.Instance.wodConversion;
        VampireTemplate newVamp = Instantiate(vampire, charListParent.transform).GetComponent<VampireTemplate>();
        newVamp.AddVampireTraits(sect, isItWoD);
        newVamp.CreateCharacter();
        if (toCharSheet == true)
        {
            selectedTemplate = newVamp;
            UIManager.Instance.vampireSheet.UpdateThisSheet(newVamp);
        }
        listOfCharacters.Add(newVamp);
    }
    public void GenerateMage(int sect, bool toCharSheet = true)
    {
        bool isItWoD = TabManager.Instance.wodConversion;
        MageTemplate newMage = Instantiate(mage, charListParent.transform).GetComponent<MageTemplate>();
        newMage.AddMageTraits(sect, isItWoD);
        newMage.CreateCharacter();
        if (toCharSheet == true)
        {
            selectedTemplate = newMage;
            UIManager.Instance.mageSheet.UpdateThisSheet(newMage);
        }
        listOfCharacters.Add(newMage);
    }
    public void GenerateWerewolf(int sect, bool toCharSheet = true)
    {
        WerewolfTemplate newWere = Instantiate(werewolf, charListParent.transform).GetComponent<WerewolfTemplate>();
        newWere.AddWerewolfTraits(sect);
        newWere.CreateCharacter();
        if (toCharSheet == true)
        {
            selectedTemplate = newWere;
            UIManager.Instance.werSheet.UpdateThisSheet(newWere);
        }
        listOfCharacters.Add(newWere);
    }
    public void GenerateChangeling(int sect, bool toCharSheet = true)
    {
        ChangelingTemplate newChang = Instantiate(changeling, charListParent.transform).GetComponent<ChangelingTemplate>();
        newChang.AddChangelingTraits(sect);
        newChang.CreateCharacter();
        if (toCharSheet == true)
        {
            selectedTemplate = newChang;
            UIManager.Instance.changeSheet.UpdateThisSheet(newChang);
        }
        listOfCharacters.Add(newChang);
    }
    public void GenerateGeist(int sect, bool toCharSheet = true)
    {
        GeistTemplate newGeist = Instantiate(geist, charListParent.transform).GetComponent<GeistTemplate>();
        newGeist.AddGeistTraits(sect);
        newGeist.CreateCharacter();
        if (toCharSheet == true)
        {
            selectedTemplate = newGeist;
            UIManager.Instance.geistSheet.UpdateThisSheet(newGeist);
        }
        listOfCharacters.Add(newGeist);
    }
    public void GenerateDemon(int sect, bool toCharSheet = true)
    {
        DemonTemplate newDemon = Instantiate(demon, charListParent.transform).GetComponent<DemonTemplate>();
        newDemon.AddDemonTraits(sect);
        newDemon.CreateCharacter();
        if (toCharSheet == true)
        {
            selectedTemplate = newDemon;
            UIManager.Instance.demonSheet.UpdateThisSheet(newDemon);
        }
        listOfCharacters.Add(newDemon);
    }
    public void GeneratePromethean(int sect, bool toCharSheet = true)
    {
        PrometheanTemplate newProm = Instantiate(promethean, charListParent.transform).GetComponent<PrometheanTemplate>();
        newProm.AddPrometheanTraits(sect);
        newProm.CreateCharacter();
        if (toCharSheet == true)
        {
            selectedTemplate = newProm;
            UIManager.Instance.promethSheet.UpdateThisSheet(newProm);
        }
        listOfCharacters.Add(newProm);
    }
    public void GenerateMummy(int sect, bool toCharSheet = true)
    {
        MummyTemplate newMummy = Instantiate(mummy, charListParent.transform).GetComponent<MummyTemplate>();
        newMummy.AddMummyTraits(sect);
        newMummy.CreateCharacter();
        if (toCharSheet == true)
        {
            selectedTemplate = newMummy;
            UIManager.Instance.mummySheet.UpdateThisSheet(newMummy);
        }
        listOfCharacters.Add(newMummy);
    }
    public void GenerateBeast(int sect, bool toCharSheet = true)
    {
        BeastTemplate newBeast = Instantiate(beast, charListParent.transform).GetComponent<BeastTemplate>();
        newBeast.AddBeastTraits(sect);
        newBeast.CreateCharacter();
        if (toCharSheet == true)
        {
            selectedTemplate = newBeast;
            UIManager.Instance.beastSheet.UpdateThisSheet(newBeast);
        }
        listOfCharacters.Add(newBeast);
    }
    public void GenerateDeviant(int sect, bool toCharSheet = true)
    {
        DeviantTemplate newDeviant = Instantiate(deviant, charListParent.transform).GetComponent<DeviantTemplate>();
        newDeviant.AddDeviantTraits(sect);
        newDeviant.CreateCharacter();
        if (toCharSheet == true)
        {
            selectedTemplate = newDeviant;
            UIManager.Instance.deviantSheet.UpdateThisSheet(newDeviant);
        }
        listOfCharacters.Add(newDeviant);
    }
    public void GenerateHunter(int sect, bool toCharSheet = true)
    {
        HunterTemplate newHunter = Instantiate(hunter, charListParent.transform).GetComponent<HunterTemplate>();
        newHunter.AddHunterTraits(sect);
        newHunter.CreateCharacter();
        if (toCharSheet == true)
        {
            selectedTemplate = newHunter;
            UIManager.Instance.hunterSheet.UpdateThisSheet(newHunter);
        }
        listOfCharacters.Add(newHunter);
    }
    public void GenerateMortal(int sect, bool toCharSheet = true)
    {
        CharTemplate newMortal = Instantiate(mortal, charListParent.transform).GetComponent<CharTemplate>();
        newMortal.isMortal = true;
        newMortal.CreateCharacter();
        newMortal.AddMortalStuff(sect);
        if (toCharSheet == true)
        {
            selectedTemplate = newMortal;
            UIManager.Instance.mortalSheet.UpdateThisSheet(newMortal);
        }
        listOfCharacters.Add(newMortal);
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
