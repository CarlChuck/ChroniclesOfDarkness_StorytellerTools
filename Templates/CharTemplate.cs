using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharTemplate : MonoBehaviour
{
    public string charName;
    public int age;
    public bool genderM;
    public string charConcept;
    public GameObject statPrefab;
    public string virtue;
    public string vice;
    public bool isMortal = false;

    #region Priorities
    public State physicalAttributes;
    public State socialAttributes;
    public State mentalAttributes;

    public State physicalSkills;
    public State socialSkills;
    public State mentalSkills;
    #endregion
    public int maxAttributeSkill;
    #region Attributes
    public CharStat strength;
    public CharStat dexterity;
    public CharStat stamina;

    public CharStat presence;
    public CharStat manipulation;
    public CharStat composure;

    public CharStat intelligence;
    public CharStat wits;
    public CharStat resolve;
    #endregion
    #region Mental Skills
    public CharStat academics;
    public CharStat computer;
    public CharStat crafts;
    public CharStat investigation;
    public CharStat medicine;
    public CharStat occult;
    public CharStat politics;
    public CharStat science;
    #endregion
    #region Physical Skills
    public CharStat athletics;
    public CharStat brawl;
    public CharStat drive;
    public CharStat firearms;
    public CharStat larceny;
    public CharStat stealth;
    public CharStat survival;
    public CharStat weaponry;
    #endregion
    #region Social Skills
    public CharStat animalKen;
    public CharStat empathy;
    public CharStat expression;
    public CharStat intimidation;
    public CharStat persuasion;
    public CharStat socialise;
    public CharStat streetwise;
    public CharStat subterfuge;
    #endregion
    #region Lists
    public List<CharStat> listOfAttributes;
    public List<CharStat> listOfSkills;
    #endregion
    #region Other Traits
    public int size;
    public int speed;
    public int defence;
    public int armour;
    public int initiative;
    public int health;
    public int willpower;
    public int integrity;
    public int potency;
    #endregion


    public virtual void CreateCharacter()
    {
        if (isMortal == true)
        {
            SetRandomPriority();
        }
        maxAttributeSkill = 5;
        InstantiateAllStats();
        SetAge();
        SetGender();
        AddStartingAttributes();
        AddStartingSkills();
        SetSize();
        SetSpeed();
        SetDefence();
        SetArmour();
        SetInitiative();
        SetHealth();
        SetWillpower();
        SetIntegrity();
    }
    public void AddMortalStuff(int sect)
    {
        SetName();
        SetVirtue();
        SetVice();
        AddExperience();
        GenerateConcept();
        UpdateCharacter();
        UIManager.Instance.UpdateGeneralUI(TemplateType.Mortal);
    }
    #region Setters
    public virtual void SetName(string inputName = "")
    {
        if (inputName == "")
        {
           charName = Nationality.Instance.GetNameForChar(genderM);
        }
        else
        {
            charName = inputName;
        }
    }
    public virtual void SetAge()
    {
        int rand = Random.Range(1, 101);
        if (rand > 30)
        {
            age = Random.Range(20, 40);
        }
        else if(rand <= 30 && rand > 10)
        {
            age = Random.Range(18, 50);
        }
        else if (rand <= 10)
        {
            age = Random.Range(16, 60);
        }
    }
    public void SetGender()
    {
        int rand = Random.Range(1, 101);
        if (rand < 50)
        {
            genderM = true;
        }
        else
        {
            genderM = false;
        }
    }
    private void SetSize(int sizeToSet = 5)
    {
        size = sizeToSet;
    }
    public virtual void SetSpeed()
    {
        speed = size + strength.GetStatValue() + dexterity.GetStatValue();
    }
    public virtual void SetDefence()
    {
        if (wits.GetStatValue() > dexterity.GetStatValue())
        {
            defence = dexterity.GetStatValue() + athletics.GetStatValue();
        }
        else
        {
            defence = wits.GetStatValue() + athletics.GetStatValue();
        }

    }
    private void SetArmour(int armourToSet = 0)
    {
        armour = armourToSet;
    }
    private void SetInitiative()
    {
        initiative = dexterity.GetStatValue() + composure.GetStatValue();
    }
    public virtual void SetHealth()
    {
        health = stamina.GetStatValue() + size;
    }
    private void SetWillpower()
    {
        willpower = resolve.GetStatValue() + composure.GetStatValue();
        if (willpower > 10)
        {
            willpower = 10;
        }
    }
    private void SetIntegrity(int integToSet = 7)
    {
        integrity = integToSet;
    }
    public void SetPotency(int potToSet = 1)
    {
        potency = potToSet;
        if (potToSet > 5)
        {
            maxAttributeSkill = potToSet;
        }
        else
        {
            maxAttributeSkill = 5;
        }
    }
    public virtual void SetVirtue()
    {
        int rand = Random.Range(1, 11);
        virtue = rand switch
        {
            1 => "Hopeful",
            2 => "Loving",
            3 => "Honest",
            4 => "Trustworthy",
            5 => "Loyal",
            6 => "Ambitious",
            7 => "Just",
            8 => "Generous",
            9 => "Patient",
            10 => "Courageous",
            _ => "Hopeful"
        };
    }
    public virtual void SetVice()
    {
        int rand = Random.Range(1, 11);
        vice = rand switch
        {
            1 => "Pessimistic",
            2 => "Hateful",
            3 => "Deceitful",
            4 => "Ambitious",
            5 => "Cruel",
            6 => "Addictive",
            7 => "Hasty",
            8 => "Corrupt",
            9 => "Greedy",
            10 => "Dogmatic",
            _ => "Pessimistic"
        };
    }
    public virtual void GenerateConcept()
    {
        int rand = Random.Range(1, 4);

        if (rand == 4)
        {
            rand = Random.Range(1, 26);
            charConcept = rand switch
            {
                1 => "Activist",
                2 => "Artist",
                3 => "Athlete",
                4 => "Caretaker",
                5 => "Criminal",
                6 => "Drifter",
                7 => "Entertainer",
                8 => "Executive",
                9 => "Guardian",
                10 => "Intellectual",
                11 => "Investigator",
                12 => "Kid",
                13 => "Labourer",
                14 => "Mystic",
                15 => "Night-Owl",
                16 => "Outsider",
                17 => "Politician",
                18 => "Professional",
                19 => "Rebel",
                20 => "Reporter",
                21 => "Scenester",
                22 => "Socialite",
                23 => "Soldier",
                24 => "Technician",
                25 => "Warrior",
                _ => "Worker",
            };
        }
        else
        {
            CharStat highestSkill = GetHighestSkill();
            switch (highestSkill.GetStatName())
            {
                case "academics":
                    if (rand == 1)
                    {
                        charConcept = "Librarian";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Anthropologist";
                    }
                    else
                    {
                        charConcept = "Teacher";
                    }
                    break;
                case "computer":
                    if (rand == 1)
                    {
                        charConcept = "Hacker";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Programmer";
                    }
                    else
                    {
                        charConcept = "Data Analyst";
                    }
                    break;
                case "crafts":
                    if (rand == 1)
                    {
                        charConcept = "Tailor";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Smith";
                    }
                    else
                    {
                        charConcept = "Mechanic";
                    }
                    break;
                case "investigation":
                    if (rand == 1)
                    {
                        charConcept = "Detective";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Private Investigator";
                    }
                    else
                    {
                        charConcept = "Lab Tech";
                    }
                    break;
                case "medicine":
                    if (rand == 1)
                    {
                        charConcept = "Doctor";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Psychiatrist";
                    }
                    else
                    {
                        charConcept = "Surgeon";
                    }
                    break;
                case "occult":
                    charConcept = "Professor";
                    break;
                case "politics":
                    if (rand == 1)
                    {
                        charConcept = "Administrator";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Bureaucrat";
                    }
                    else
                    {
                        charConcept = "Politician";
                    }
                    break;
                case "science":
                    if (rand == 1)
                    {
                        charConcept = "Geneticist";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Chemist";
                    }
                    else
                    {
                        charConcept = "Physicist";
                    }
                    break;
                case "athletics":
                    if (rand == 1)
                    {
                        charConcept = "Swimmer";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Footballer";
                    }
                    else
                    {
                        charConcept = "Athlete";
                    }
                    break;
                case "brawl":
                    if (rand == 1)
                    {
                        charConcept = "Boxer";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "MMA Fighter";
                    }
                    else
                    {
                        charConcept = "Cop";
                    }
                    break;
                case "drive":
                    if (rand == 1)
                    {
                        charConcept = "Taxi Driver";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Racing Driver";
                    }
                    else
                    {
                        charConcept = "Truck Driver";
                    }
                    break;
                case "firearms":
                    if (rand == 1)
                    {
                        charConcept = "Soldier";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Cop";
                    }
                    else
                    {
                        charConcept = "Hunter";
                    }
                    break;
                case "larceny":
                    if (rand == 1)
                    {
                        charConcept = "Burglar";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Locksmith";
                    }
                    else
                    {
                        charConcept = "Security Expert";
                    }
                    break;
                case "stealth":
                    if (rand == 1)
                    {
                        charConcept = "Burglar";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Hunter";
                    }
                    else
                    {
                        charConcept = "Spy";
                    }
                    break;
                case "survival":
                    if (rand == 1)
                    {
                        charConcept = "Survivalist";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Camper";
                    }
                    else
                    {
                        charConcept = "Hunter";
                    }
                    break;
                case "weaponry":
                    if (rand == 1)
                    {
                        charConcept = "Martial Aritst";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Thug";
                    }
                    else
                    {
                        charConcept = "Soldier";
                    }
                    break;
                case "animalKen":
                    if (rand == 1)
                    {
                        charConcept = "Dog Breeder";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Farmer";
                    }
                    else
                    {
                        charConcept = "Herder";
                    }
                    break;
                case "empathy":
                    if (rand == 1)
                    {
                        charConcept = "Nurse";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Therapist";
                    }
                    else
                    {
                        charConcept = "Teacher";
                    }
                    break;
                case "expression":
                    if (rand == 1)
                    {
                        charConcept = "Artist";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Dancer";
                    }
                    else
                    {
                        charConcept = "Musician";
                    }
                    break;
                case "intimidation":
                    if (rand == 1)
                    {
                        charConcept = "Gang Member";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Debt Collector";
                    }
                    else
                    {
                        charConcept = "Security Guard";
                    }
                    break;
                case "persuasion":
                    if (rand == 1)
                    {
                        charConcept = "Diplomat";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Executive";
                    }
                    else
                    {
                        charConcept = "Dilettante";
                    }
                    break;
                case "socialise":
                    if (rand == 1)
                    {
                        charConcept = "Socialite";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Bartender";
                    }
                    else
                    {
                        charConcept = "Dilettante";
                    }
                    break;
                case "streetwise":
                    if (rand == 1)
                    {
                        charConcept = "Gang Member";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Drug Dealer";
                    }
                    else
                    {
                        charConcept = "Cop";
                    }
                    break;
                case "subterfuge":
                    if (rand == 1)
                    {
                        charConcept = "Spy";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Politician";
                    }
                    else
                    {
                        charConcept = "Con Artist";
                    }
                    break;
            }
        }
    }
    #endregion
    #region Priorities
    public void SetPhysicalPriority()
    {
        int rand = Random.Range(1, 100);
        if (rand > 60)
        {
            physicalAttributes = State.Primary;
            physicalSkills = State.Primary;
            socialAttributes = State.Secondary;
            socialSkills = State.Secondary;
            mentalAttributes = State.Tertiary;
            mentalSkills = State.Tertiary;
        }
        else if (rand > 20)
        {
            physicalAttributes = State.Primary;
            physicalSkills = State.Primary;
            socialAttributes = State.Tertiary;
            socialSkills = State.Tertiary;
            mentalAttributes = State.Secondary;
            mentalSkills = State.Secondary;
        }
        else
        {
            SetRandomPriority();
        }
    }
    public void SetMentalPriority()
    {
        int rand = Random.Range(1, 100);
        if (rand > 60)
        {
            physicalAttributes = State.Tertiary;
            physicalSkills = State.Tertiary;
            socialAttributes = State.Secondary;
            socialSkills = State.Secondary;
            mentalAttributes = State.Primary;
            mentalSkills = State.Primary;
        }
        else if (rand > 20)
        {
            physicalAttributes = State.Secondary;
            physicalSkills = State.Secondary;
            socialAttributes = State.Tertiary;
            socialSkills = State.Tertiary;
            mentalAttributes = State.Primary;
            mentalSkills = State.Primary;
        }
        else
        {
            SetRandomPriority();
        }
    }
    public void SetSocialPriority()
    {
        int rand = Random.Range(1, 100);
        if (rand > 60)
        {
            physicalAttributes = State.Secondary;
            physicalSkills = State.Secondary;
            socialAttributes = State.Primary;
            socialSkills = State.Primary;
            mentalAttributes = State.Tertiary;
            mentalSkills = State.Tertiary;
        }
        else if (rand > 20)
        {
            physicalAttributes = State.Tertiary;
            physicalSkills = State.Tertiary;
            socialAttributes = State.Primary;
            socialSkills = State.Primary;
            mentalAttributes = State.Secondary;
            mentalSkills = State.Secondary;
        }
        else
        {
            SetRandomPriority();
        }
    }
    public void SetRandomPriority()
    {
        int rand = Random.Range(1, 4);
        if (rand == 1)
        {
            SetSocialPriority();
        }
        else if (rand == 2)
        {
            SetMentalPriority();
        }
        else
        {
            SetPhysicalPriority();
        }
    }
    public void SetMentalOrSocialPriority()
    {
        int rand = Random.Range(1, 3);
        if (rand == 1)
        {
            SetSocialPriority();
        }
        else
        {
            SetMentalPriority();
        }
    }
    public void SetMentalOrPhysicalPriority()
    {
        int rand = Random.Range(1, 3);
        if (rand == 1)
        {
            SetPhysicalPriority();
        }
        else
        {
            SetMentalPriority();
        }
    }
    public void SetSocialOrPhysicalPriority()
    {
        int rand = Random.Range(1, 3);
        if (rand == 1)
        {
            SetSocialPriority();
        }
        else
        {
            SetPhysicalPriority();
        }
    }
    #endregion
    #region Merits and Experience Virtuals
    public virtual void AddExperience()
    {

        int experienceAge = age - 15;
        int attributesOrSphereToAdd = (Mathf.Clamp((int)(Mathf.Sqrt(experienceAge) * 1.5), 0, 15));
        int skillsToAdd = (int)(Mathf.Sqrt(experienceAge) * 3);
        int meritsToAdd = (int)(Mathf.Sqrt(experienceAge) * 1);

        if (attributesOrSphereToAdd > 0)
        {
            for (int i = 0; i < attributesOrSphereToAdd; i++)
            {
                AddSingleAttribute();
            }
        }
        if (skillsToAdd > 0)
        {
            for (int i = 0; i < skillsToAdd; i++)
            {
                AddSingleSkill();
            }
        }
        if (meritsToAdd > 0)
        {
            for (int i = 0; i < meritsToAdd; i++)
            {
                AddMerit();
            }
        }
        int humVariable = (int)(Mathf.Sqrt(experienceAge) / 2);
        integrity = Mathf.Clamp(integrity - Random.Range(-1, humVariable), 1, 8);
        willpower = Mathf.Clamp(willpower + Random.Range(0, humVariable * 2), 1, 10);
    }

    public virtual void AddMerit()
    {

    }
    #endregion
    #region Adding Attributes
    public void AddStartingAttributes() 
    {
        switch (physicalAttributes)
        {
            case State.Primary:
                AddPhysicalAttributes(5);
                break;
            case State.Secondary:
                AddPhysicalAttributes(4);
                break;
            case State.Tertiary:
                AddPhysicalAttributes(3);
                break;
        }
        switch (socialAttributes)
        {
            case State.Primary:
                AddSocialAttributes(5);
                break;
            case State.Secondary:
                AddSocialAttributes(4);
                break;
            case State.Tertiary:
                AddSocialAttributes(3);
                break;
        }
        switch (mentalAttributes)
        {
            case State.Primary:
                AddMentalAttributes(5);
                break;
            case State.Secondary:
                AddMentalAttributes(4);
                break;
            case State.Tertiary:
                AddMentalAttributes(3);
                break;
        }
    }
    public void AddRandomAttributes(int numOfAttributes)
    {
        for (int i = 0; i < numOfAttributes; i++)
        {
            if (strength.GetStatValue() >= maxAttributeSkill && dexterity.GetStatValue() >= maxAttributeSkill && stamina.GetStatValue() >= maxAttributeSkill && 
                presence.GetStatValue() >= maxAttributeSkill && manipulation.GetStatValue() >= maxAttributeSkill && composure.GetStatValue() >= maxAttributeSkill && 
                intelligence.GetStatValue() >= maxAttributeSkill && wits.GetStatValue() >= maxAttributeSkill && resolve.GetStatValue() >= maxAttributeSkill)
            {
                //if all are full, nothing needs to happen
            }
            else
            {
                int rand = Random.Range(1, 4);
                if (rand == 1)
                {
                    AddPhysicalAttribute();
                }
                else if (rand == 2)
                {
                    AddSocialAttribute();
                }
                else
                {
                    AddMentalAttribute();
                }
            }
        }
    }
    public void AddPhysicalAttributes(int numOfAttributes)
    {
        for (int i = 0; i < numOfAttributes; i++)
        {
            AddPhysicalAttribute();
        }
    }
    public void AddSocialAttributes(int numOfAttributes)
    {
        for (int i = 0; i < numOfAttributes; i++)
        {
            AddSocialAttribute();
        }
    }
    public void AddMentalAttributes(int numOfAttributes)
    {
        for (int i = 0; i < numOfAttributes; i++)
        {
            AddMentalAttribute();
        }
    }
    public void AddPhysicalAttribute()
    {
        int rand = Random.Range(1, 4);
        if (rand == 1)
        {
            if (strength.GetStatValue() >= maxAttributeSkill)
            {
                AddRandomAttributes(1);
            }
            else
            {
                strength.AddToStatValue(1);
            }
        }
        else if (rand == 2)
        {
            if (dexterity.GetStatValue() >= maxAttributeSkill)
            {
                AddRandomAttributes(1);
            }
            else
            {
                dexterity.AddToStatValue(1);
            }
        }
        else
        {
            if (stamina.GetStatValue() >= maxAttributeSkill)
            {
                AddRandomAttributes(1);
            }
            else
            {
                stamina.AddToStatValue(1);
            }
        }
    }
    public void AddSocialAttribute()
    {
        int rand = Random.Range(1, 4);
        if (rand == 1)
        {
            if (presence.GetStatValue() >= maxAttributeSkill)
            {
                AddRandomAttributes(1);
            }
            else
            {
                presence.AddToStatValue(1);
            }
        }
        else if (rand == 2)
        {
            if (manipulation.GetStatValue() >= maxAttributeSkill)
            {
                AddRandomAttributes(1);
            }
            else
            {
                manipulation.AddToStatValue(1);
            }
        }
        else
        {
            if (composure.GetStatValue() >= maxAttributeSkill)
            {
                AddRandomAttributes(1);
            }
            else
            {
                composure.AddToStatValue(1);
            }
        }
    }
    public void AddMentalAttribute()
    {
        int rand = Random.Range(1, 4);
        if (rand == 1)
        {
            if (intelligence.GetStatValue() >= maxAttributeSkill)
            {
                AddRandomAttributes(1);
            }
            else
            {
                intelligence.AddToStatValue(1);
            }
        }
        else if (rand == 2)
        {
            if (wits.GetStatValue() >= maxAttributeSkill)
            {
                AddRandomAttributes(1);
            }
            else
            {
                wits.AddToStatValue(1);
            }
        }
        else
        {
            if (resolve.GetStatValue() >= maxAttributeSkill)
            {
                AddRandomAttributes(1);
            }
            else
            {
                resolve.AddToStatValue(1);
            }
        }
    }
    public void AddSingleAttribute()
    {
        int rand = Random.Range(1, 100);
        if (rand > 50)
        {
            if (physicalAttributes == State.Primary)
            {
                AddPhysicalAttribute();
            }
            else if(socialAttributes == State.Primary)
            {
                AddSocialAttribute();
            }
            else
            {
                AddMentalAttribute();
            }
        }
        else if (rand > 15)
        {
            if (physicalAttributes == State.Secondary)
            {
                AddPhysicalAttribute();
            }
            else if (socialAttributes == State.Secondary)
            {
                AddSocialAttribute();
            }
            else
            {
                AddMentalAttribute();
            }
        }
        else
        {
            if (physicalAttributes == State.Tertiary)
            {
                AddPhysicalAttribute();
            }
            else if (socialAttributes == State.Tertiary)
            {
                AddSocialAttribute();
            }
            else
            {
                AddMentalAttribute();
            }
        }
    }
    #endregion
    #region Adding Skills
    public void AddStartingSkills()
    {
        switch (physicalSkills)
        {
            case State.Primary:
                AddPhysicalSkills(11);
                break;
            case State.Secondary:
                AddPhysicalSkills(7);
                break;
            case State.Tertiary:
                AddPhysicalSkills(4);
                break;
        }
        switch (socialSkills)
        {
            case State.Primary:
                AddSocialSkills(11);
                break;
            case State.Secondary:
                AddSocialSkills(7);
                break;
            case State.Tertiary:
                AddSocialSkills(4);
                break;
        }
        switch (mentalSkills)
        {
            case State.Primary:
                AddMentalSkills(11);
                break;
            case State.Secondary:
                AddMentalSkills(7);
                break;
            case State.Tertiary:
                AddMentalSkills(4);
                break;
        }
    }
    public void AddRandomSkill()
    { 
        int rand = Random.Range(1, 4);
        if (rand == 1)
        {
            AddPhysicalSkill();
        }
        else if (rand == 2)
        {
            AddSocialSkill();
        }
        else
        {
            AddMentalSkill();
        }
    }
    public void AddPhysicalSkills(int numOfSkills)
    {
        for (int i = 0; i < numOfSkills; i++)
        {
            AddPhysicalSkill();
        }
    }
    public void AddSocialSkills(int numOfSkills)
    {
        for (int i = 0; i < numOfSkills; i++)
        {
            AddSocialSkill();
        }
    }
    public void AddMentalSkills(int numOfSkills)
    {
        for (int i = 0; i < numOfSkills; i++)
        {
            AddMentalSkill();
        }
    }
    public void AddPhysicalSkill()
    {
        int rand = Random.Range(1, 9);
        if (rand == 1)
        {
            if (athletics.GetStatValue() >= maxAttributeSkill)
            {
                AddRandomSkill();
            }
            else
            {
                athletics.AddToStatValue(1);
            }
        }
        else if (rand == 2)
        {
            if (brawl.GetStatValue() >= maxAttributeSkill)
            {
                AddRandomSkill();
            }
            else
            {
                brawl.AddToStatValue(1);
            }
        }
        else if (rand == 3)
        {
            if (drive.GetStatValue() >= maxAttributeSkill)
            {
                AddRandomSkill();
            }
            else
            {
                drive.AddToStatValue(1);
            }
        }
        else if (rand == 4)
        {
            if (firearms.GetStatValue() >= maxAttributeSkill)
            {
                AddRandomSkill();
            }
            else
            {
                firearms.AddToStatValue(1);
            }
        }
        else if (rand == 5)
        {
            if (larceny.GetStatValue() >= maxAttributeSkill)
            {
                AddRandomSkill();
            }
            else
            {
                larceny.AddToStatValue(1);
            }
        }
        else if (rand == 6)
        {
            if (stealth.GetStatValue() >= maxAttributeSkill)
            {
                AddRandomSkill();
            }
            else
            {
                stealth.AddToStatValue(1);
            }
        }
        else if (rand == 7)
        {
            if (survival.GetStatValue() >= maxAttributeSkill)
            {
                AddRandomSkill();
            }
            else
            {
                survival.AddToStatValue(1);
            }
        }
        else
        {
            if (weaponry.GetStatValue() >= maxAttributeSkill)
            {
                AddRandomSkill();
            }
            else
            {
                weaponry.AddToStatValue(1);
            }
        }
    }
    public void AddSocialSkill()
    {
        int rand = Random.Range(1, 9);
        if (rand == 1)
        {
            if (animalKen.GetStatValue() >= maxAttributeSkill)
            {
                AddRandomSkill();
            }
            else
            {
                animalKen.AddToStatValue(1);
            }
        }
        else if (rand == 2)
        {
            if (empathy.GetStatValue() >= maxAttributeSkill)
            {
                AddRandomSkill();
            }
            else
            {
                empathy.AddToStatValue(1);
            }
        }
        else if (rand == 3)
        {
            if (expression.GetStatValue() >= maxAttributeSkill)
            {
                AddRandomSkill();
            }
            else
            {
                expression.AddToStatValue(1);
            }
        }
        else if (rand == 4)
        {
            if (intimidation.GetStatValue() >= maxAttributeSkill)
            {
                AddRandomSkill();
            }
            else
            {
                intimidation.AddToStatValue(1);
            }
        }
        else if (rand == 5)
        {
            if (persuasion.GetStatValue() >= maxAttributeSkill)
            {
                AddRandomSkill();
            }
            else
            {
                persuasion.AddToStatValue(1);
            }
        }
        else if (rand == 6)
        {
            if (socialise.GetStatValue() >= maxAttributeSkill)
            {
                AddRandomSkill();
            }
            else
            {
                socialise.AddToStatValue(1);
            }
        }
        else if (rand == 7)
        {
            if (streetwise.GetStatValue() >= maxAttributeSkill)
            {
                AddRandomSkill();
            }
            else
            {
                streetwise.AddToStatValue(1);
            }
        }
        else
        {
            if (subterfuge.GetStatValue() >= maxAttributeSkill)
            {
                AddRandomSkill();
            }
            else
            {
                subterfuge.AddToStatValue(1);
            }
        }
    }
    public void AddMentalSkill()
    {
        int rand = Random.Range(1, 9);
        if (rand == 1)
        {
            if (academics.GetStatValue() >= maxAttributeSkill)
            {
                AddRandomSkill();
            }
            else
            {
                academics.AddToStatValue(1);
            }
        }
        else if (rand == 2)
        {
            if (computer.GetStatValue() >= maxAttributeSkill)
            {
                AddRandomSkill();
            }
            else
            {
                computer.AddToStatValue(1);
            }
        }
        else if (rand == 3)
        {
            if (crafts.GetStatValue() >= maxAttributeSkill)
            {
                AddRandomSkill();
            }
            else
            {
                crafts.AddToStatValue(1);
            }
        }
        else if (rand == 4)
        {
            if (investigation.GetStatValue() >= maxAttributeSkill)
            {
                AddRandomSkill();
            }
            else
            {
                investigation.AddToStatValue(1);
            }
        }
        else if (rand == 5)
        {
            if (medicine.GetStatValue() >= maxAttributeSkill)
            {
                AddRandomSkill();
            }
            else
            {
                medicine.AddToStatValue(1);
            }
        }
        else if (rand == 6)
        {
            if (occult.GetStatValue() >= maxAttributeSkill)
            {
                AddRandomSkill();
            }
            else
            {
                occult.AddToStatValue(1);
            }
        }
        else if (rand == 7)
        {
            if (politics.GetStatValue() >= maxAttributeSkill)
            {
                AddRandomSkill();
            }
            else
            {
                politics.AddToStatValue(1);
            }
        }
        else
        {
            if (science.GetStatValue() >= maxAttributeSkill)
            {
                AddRandomSkill();
            }
            else
            {
                science.AddToStatValue(1);
            }
        }
    }
    public void AddSingleSkill()
    {
        int rand = Random.Range(1, 100);
        if (rand > 50)
        {
            if (physicalSkills == State.Primary)
            {
                AddPhysicalSkill();
            }
            else if (socialSkills == State.Primary)
            {
                AddSocialSkill();
            }
            else
            {
                AddMentalSkill();
            }
        }
        else if (rand > 15)
        {
            if (physicalSkills == State.Secondary)
            {
                AddPhysicalSkill();
            }
            else if (socialSkills == State.Secondary)
            {
                AddSocialSkill();
            }
            else
            {
                AddMentalSkill();
            }
        }
        else
        {
            if (physicalSkills == State.Tertiary)
            {
                AddPhysicalSkill();
            }
            else if (socialSkills == State.Tertiary)
            {
                AddSocialSkill();
            }
            else
            {
                AddMentalSkill();
            }
        }
    }
    #endregion
    #region Update
    public virtual void UpdateCharacter()
    {
        SetSize();
        SetSpeed();
        SetDefence();
        SetArmour();
        SetInitiative();
        SetHealth();
    }
    #endregion
    #region Getters
    public int GetAge()
    {
        return age;
    }
    public string GetGender()
    {
        if (genderM == true)
        {
            return "M";
        }
        else
        {
            return "F";
        }

    }
    public string GetName()
    {
        return charName;
    }
    public string GetPlayer()
    {
        return "";
    }
    public string GetChronicle()
    {
        return "";
    }
    public string GetGroup()
    {
        return ""; //TODO
    }
    public string GetFaction()
    {
        return ""; //TODO
    }
    public string GetConcept()
    {
        return charConcept;
    }
    public string GetVirtue()
    {
        return virtue;
    }
    public string GetVice()
    {
        return vice;
    }
    public CharStat GetHighestSkill()
    {
        CharStat statToReturn = academics;
        foreach (CharStat stat in listOfSkills)
        {
            if (stat.GetStatValue() > statToReturn.GetStatValue())
            {
                statToReturn = stat;
            }
        }

        return statToReturn;
    }
    #endregion
    #region StatInitialisations
    public void InstantiateAllStats()
    {
        strength = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        dexterity = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        stamina = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        presence = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        manipulation = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        composure = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        intelligence = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        wits = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        resolve = Instantiate(statPrefab, transform).GetComponent<CharStat>();

        academics = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        computer = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        crafts = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        investigation = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        medicine = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        occult = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        politics = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        science = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        athletics = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        brawl = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        drive = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        firearms = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        larceny = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        stealth = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        survival = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        weaponry = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        animalKen = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        empathy = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        expression = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        intimidation = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        persuasion = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        socialise = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        streetwise = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        subterfuge = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        InitialiseAllCharStats();
        PopulateAttributeList();
        PopulateSkillList();
    }
    public void InitialiseAllCharStats()
    {
        strength.InitialiseStat("strength", 1);
        dexterity.InitialiseStat("dexterity", 1);
        stamina.InitialiseStat("stamina", 1);
        presence.InitialiseStat("presence", 1);
        manipulation.InitialiseStat("manipulation", 1);
        composure.InitialiseStat("composure", 1);
        intelligence.InitialiseStat("intelligence", 1);
        wits.InitialiseStat("wits", 1);
        resolve.InitialiseStat("resolve", 1);

        academics.InitialiseStat("academics");
        computer.InitialiseStat("computer");
        crafts.InitialiseStat("crafts");
        investigation.InitialiseStat("investigation");
        medicine.InitialiseStat("medicine");
        occult.InitialiseStat("occult");
        politics.InitialiseStat("politics");
        science.InitialiseStat("science");
        athletics.InitialiseStat("athletics");
        brawl.InitialiseStat("brawl");
        drive.InitialiseStat("drive");
        firearms.InitialiseStat("firearms"); 
        larceny.InitialiseStat("larceny"); 
        stealth.InitialiseStat("stealth"); 
        survival.InitialiseStat("survival"); 
        weaponry.InitialiseStat("weaponry");
        animalKen.InitialiseStat("animalKen");
        empathy.InitialiseStat("empathy");
        expression.InitialiseStat("expression");
        intimidation.InitialiseStat("intimidation");
        persuasion.InitialiseStat("persuasion");
        socialise.InitialiseStat("socialise");
        streetwise.InitialiseStat("streetwise");
        subterfuge.InitialiseStat("subterfuge");
    }


    #endregion
    #region ListInteractions
    public void PopulateAttributeList()
    {
        listOfAttributes = new List<CharStat>
        {
            strength,
            dexterity,
            stamina,
            presence,
            manipulation,
            composure,
            intelligence,
            wits,
            resolve
        };
    }
    public void PopulateSkillList()
    {
        listOfSkills = new List<CharStat>
        {
            academics,
            computer,
            crafts,
            investigation,
            medicine,
            occult,
            politics,
            science,
            athletics,
            brawl,
            drive,
            firearms,
            larceny,
            stealth,
            survival,
            weaponry,
            animalKen,
            empathy,
            expression,
            intimidation,
            persuasion,
            socialise,
            streetwise,
            subterfuge
        };
    }

    public CharStat GetAttributeByName(string nameToCheck)
    {
        CharStat statToSend = null;
        foreach (CharStat stat in listOfAttributes)
        {
            if (stat.GetStatName() == nameToCheck)
            {
                statToSend = stat;
            }
        }
        return statToSend;
    }
    public CharStat GetSkillByName(string nameToCheck)
    {
        CharStat statToSend = null;
        foreach (CharStat stat in listOfSkills)
        {
            if (stat.GetStatName() == nameToCheck)
            {
                statToSend = stat;
            }
        }
        return statToSend;
    }
    #endregion
}
public enum State {Primary, Secondary, Tertiary }