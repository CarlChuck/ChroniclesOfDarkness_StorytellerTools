using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class CityGenerator : MonoBehaviour
{
    [SerializeField] private TMP_InputField cityName;
    [SerializeField] private TMP_InputField cityPopulation;
    [SerializeField] private TemplateType tType;
    [SerializeField] private GameObject loadingScreen;
    private string filename = "";

    public void Start()
    {
        filename = Application.dataPath + "/test.csv";
        tType = TemplateType.Vampire;
    }


    public void SetSpecies(TextMeshProUGUI species)
    {
        string sText = species.text;
        tType = sText switch
        {
            "Vampire" => TemplateType.Vampire,
            "Mage" => TemplateType.Mage,
            "Changeling" => TemplateType.Changeling,
            "Werewolf" => TemplateType.Werewolf,
            "Geist" => TemplateType.Geist,
            "Demon" => TemplateType.Demon,
            "Promethean" => TemplateType.Promethean,
            "Mummy" => TemplateType.Mummy,
            "Beast" => TemplateType.Beast,
            "Deviant" => TemplateType.Deviant,
            "Hunter" => TemplateType.Hunter,
            "Mortal" => TemplateType.Mortal,
            "All" => TemplateType.None,
            _ => TemplateType.None
        };
    }
    public void GenerateCity()
    {
        loadingScreen.SetActive(true);
        switch (tType)
        {
            case TemplateType.Vampire:
                GenerateVampireCity();
                break;
            case TemplateType.Mage:
                GenerateMageCity();
                break;
            case TemplateType.Werewolf:
                GenerateWerewolfCity();
                break;
            case TemplateType.Changeling:
                GenerateChangelingCity();
                break;
            case TemplateType.Geist:
                GenerateGeistCity();
                break;
            case TemplateType.Demon:
                GenerateDemonCity();
                break;
            case TemplateType.Promethean:
                GeneratePrometheanCity();
                break;
            case TemplateType.Mummy:
                GenerateMummyCity();
                break;
            case TemplateType.Beast:
                GenerateBeastCity();
                break;
            case TemplateType.Deviant:
                GenerateDeviantCity();
                break;
            case TemplateType.Hunter:
                GenerateHunterCity();
                break;
            case TemplateType.Mortal:
                GenerateMortalCity();
                break;
            case TemplateType.None:
                GenerateVampireCity();
                GenerateMageCity();
                GenerateWerewolfCity();
                GenerateChangelingCity();
                GenerateGeistCity();
                GenerateDemonCity();
                GeneratePrometheanCity();
                GenerateMummyCity();
                GenerateBeastCity();
                GenerateDeviantCity();
                GenerateHunterCity();
                GenerateMortalCity();
                break;
        }
        StartCoroutine(ExportFile.Instance.EndLoadingScreen(loadingScreen));
    }
    #region GeneratingCharacters
    private void GenerateVampireCity()
    {
        filename = Application.persistentDataPath + "/" + cityName.text + "_" + "Vampire.csv";
        int.TryParse(cityPopulation.text, out int inputPopulation);

        CharGenerator.Instance.ClearAllCharacters();
        int numberOfChars;

        //Slight Difference on Vampire population depending on Nation
        Nation nation = Nationality.Instance.GetNation();
        if (nation == Nation.NorthAmerica || nation == Nation.EuropeEngland || nation == Nation.EuropeScotland || nation == Nation.EuropeWales || nation == Nation.EuropeFrance
            || nation == Nation.EuropePortugal || nation == Nation.EuropeSpain || nation == Nation.EuropeIreland || nation == Nation.EuropeScandanavia || nation == Nation.AsiaWest)
        {
            numberOfChars = inputPopulation / Random.Range(40000, 60000);
        }
        else
        {
            numberOfChars = inputPopulation / Random.Range(60000, 100000);
        }

        //Generate the number of Vampires
        for (int i = 0; i < numberOfChars; i++)
        {
            int rand;
            if (TabManager.Instance.wodConversion == true)
            {
                rand = Random.Range(1, 12);
            }
            else
            {
                rand = Random.Range(1, 3);
                if (rand == 1)
                {
                    rand = Random.Range(1, 6);
                }
                else
                {
                    rand = Random.Range(10, 12);
                }
            }
            CharGenerator.Instance.GenerateVampire(rand, false);
        }
        VampireToCSV();
    }
    private void GenerateMageCity()
    {
        filename = Application.persistentDataPath + "/" + cityName.text + "_" + "Mage.csv";
        int.TryParse(cityPopulation.text, out int inputPopulation);

        CharGenerator.Instance.ClearAllCharacters();
        int numberOfChars;

        numberOfChars = inputPopulation / Random.Range(100000, 160000);

        //Generate the characters
        for (int i = 0; i < numberOfChars; i++)
        {
            int rand;
            if (TabManager.Instance.wodConversion == true)
            {
                rand = Random.Range(1, 9);
            }
            else
            {
                rand = Random.Range(1, 15);
            }
            CharGenerator.Instance.GenerateMage(rand, false);
        }
        MageToCSV();
    }
    private void GenerateWerewolfCity()
    {
        filename = Application.persistentDataPath + "/" + cityName.text + "_" + "Werewolf.csv";
        int.TryParse(cityPopulation.text, out int inputPopulation);

        CharGenerator.Instance.ClearAllCharacters();
        int numberOfChars;

        numberOfChars = inputPopulation / Random.Range(100000, 160000);

        //Generate the characters
        for (int i = 0; i < numberOfChars; i++)
        {
            int rand = Random.Range(1, 10);
            CharGenerator.Instance.GenerateWerewolf(rand, false);
        }
        WerewolfToCSV();
    }
    private void GenerateChangelingCity()
    {
        filename = Application.persistentDataPath + "/" + cityName.text + "_" + "Changeling.csv";
        int.TryParse(cityPopulation.text, out int inputPopulation);

        CharGenerator.Instance.ClearAllCharacters();
        int numberOfChars;

        numberOfChars = inputPopulation / Random.Range(100000, 160000);

        //Generate the characters
        for (int i = 0; i < numberOfChars; i++)
        {
            int rand = Random.Range(1, 10);
            CharGenerator.Instance.GenerateChangeling(rand, false);
        }
        ChangelingToCSV();
    }
    private void GenerateGeistCity()
    {
        filename = Application.persistentDataPath + "/" + cityName.text + "_" + "Geist.csv";
        int.TryParse(cityPopulation.text, out int inputPopulation);

        CharGenerator.Instance.ClearAllCharacters();
        int numberOfChars;

        numberOfChars = inputPopulation / Random.Range(150000, 200000);

        //Generate the characters
        for (int i = 0; i < numberOfChars; i++)
        {
            int rand = Random.Range(1, 10);
            CharGenerator.Instance.GenerateGeist(rand, false);
        }
        GeistToCSV();
    }
    private void GenerateDemonCity()
    {
        filename = Application.persistentDataPath + "/" + cityName.text + "_" + "Demon.csv";
        int.TryParse(cityPopulation.text, out int inputPopulation);

        CharGenerator.Instance.ClearAllCharacters();
        int numberOfChars;

        numberOfChars = inputPopulation / Random.Range(200000, 400000);

        //Generate the characters
        for (int i = 0; i < numberOfChars; i++)
        {
            int rand = Random.Range(1, 10);
            CharGenerator.Instance.GenerateDemon(rand, false);
        }
        DemonToCSV();
    }
    private void GeneratePrometheanCity()
    {
        filename = Application.persistentDataPath + "/" + cityName.text + "_" + "Promethean.csv";
        int.TryParse(cityPopulation.text, out int inputPopulation);

        CharGenerator.Instance.ClearAllCharacters();
        int numberOfChars;

        numberOfChars = inputPopulation / Random.Range(500000, 1000000);

        //Generate the characters
        for (int i = 0; i < numberOfChars; i++)
        {
            int rand = Random.Range(1, 10);
            CharGenerator.Instance.GeneratePromethean(rand, false);
        }
        PrometheanToCSV();
    }
    private void GenerateMummyCity()
    {
        filename = Application.persistentDataPath + "/" + cityName.text + "_" + "Mummy.csv";
        int.TryParse(cityPopulation.text, out int inputPopulation);

        CharGenerator.Instance.ClearAllCharacters();
        int numberOfChars;

        numberOfChars = inputPopulation / Random.Range(800000, 1000000);

        //Generate the characters
        for (int i = 0; i < numberOfChars; i++)
        {
            int rand = Random.Range(1, 10);
            CharGenerator.Instance.GenerateMummy(rand, false);
        }
        MummyToCSV();
    }
    private void GenerateBeastCity()
    {
        filename = Application.persistentDataPath + "/" + cityName.text + "_" + "Beast.csv";
        int.TryParse(cityPopulation.text, out int inputPopulation);

        CharGenerator.Instance.ClearAllCharacters();
        int numberOfChars;

        numberOfChars = inputPopulation / Random.Range(500000, 1000000);

        //Generate the characters
        for (int i = 0; i < numberOfChars; i++)
        {
            int rand = Random.Range(1, 10);
            CharGenerator.Instance.GenerateBeast(rand, false);
        }
        BeastToCSV();
    }
    private void GenerateDeviantCity()
    {
        filename = Application.persistentDataPath + "/" + cityName.text + "_" + "Deviant.csv";
        int.TryParse(cityPopulation.text, out int inputPopulation);

        CharGenerator.Instance.ClearAllCharacters();
        int numberOfChars;

        numberOfChars = inputPopulation / Random.Range(500000, 1000000);

        //Generate the characters
        for (int i = 0; i < numberOfChars; i++)
        {
            int rand = Random.Range(1, 10);
            CharGenerator.Instance.GenerateDeviant(rand, false);
        }
        DeviantToCSV();
    }
    private void GenerateHunterCity()
    {
        filename = Application.persistentDataPath + "/" + cityName.text + "_" + "Hunter.csv";
        int.TryParse(cityPopulation.text, out int inputPopulation);

        CharGenerator.Instance.ClearAllCharacters();
        int numberOfChars;

        numberOfChars = inputPopulation / Random.Range(100000, 200000);

        //Generate the characters
        for (int i = 0; i < numberOfChars; i++)
        {
            int rand = Random.Range(1, 10);
            CharGenerator.Instance.GenerateHunter(rand, false);
        }
        HunterToCSV();
    }
    private void GenerateMortalCity()
    {
        filename = Application.persistentDataPath + "/" + cityName.text + "_" + "Mortal.csv";
        int.TryParse(cityPopulation.text, out int inputPopulation);

        CharGenerator.Instance.ClearAllCharacters();
        int numberOfChars;

        numberOfChars = inputPopulation / Random.Range(50000, 100000);

        //Generate the characters
        for (int i = 0; i < numberOfChars; i++)
        {
            int rand = Random.Range(1, 10);
            CharGenerator.Instance.GenerateMortal(rand, false);
        }
        MortalToCSV();
    }
    #endregion
    #region ExportToCSV
    private void VampireToCSV()
    {
        if (CharGenerator.Instance.listOfCharacters.Count > 0)
        {
            List<VampireTemplate> vampList = new();
            foreach (CharTemplate ctemp in CharGenerator.Instance.listOfCharacters)
            {
                VampireTemplate vtemp = (VampireTemplate)ctemp;
                vampList.Add(vtemp);
            }

            TextWriter tw = new StreamWriter(filename, false);
            tw.WriteLine("Name, Gender, Embrace, Age, Clan, Bloodline, Covenant, Mask, Dirge, Concept, City, Strength, Dexterity, Stamina, Presence, Manipulation, Composure, " +
                "Intelligence, Wits, Resolve, Potency, Willpower, Humanity, Size, Initiative, Speed, Defence, Health, Athletics, Brawl, Drive, Firearm, Larceny, Stealth, " +
                "Survival, Weaponry, Animal Ken, Empathy, Expression, Intimidation, Persuasion, Socialise, Streetwise, Subterfuge, Academics, Computer, Crafts, Investigation, " +
                "Medicine, Occult, Politics, Science, Vigor, Celerity, Resilience, Animalism, Obfuscate, Auspex, Dominate, Majesty, Nightmare, Protean, " +
                "Coils Of The Dragon, Cruac Sorcery, Theban Sorcery, Ahranite Sorcery, Thanatology");
            tw.Close();
            tw = new StreamWriter(filename, true);
            foreach (VampireTemplate vTemp in vampList)
            {
                string vName = vTemp.GetName();
                string gender = vTemp.GetGender();
                string embrace = vTemp.GetEmbraceYear().ToString();
                string age = vTemp.age.ToString();
                string clan = vTemp.GetClan().ToString();
                string bloodline = vTemp.GetBloodline().ToString();
                string covenant = vTemp.GetCovenant().ToString();
                string mask = vTemp.GetMask().ToString();
                string dirge = vTemp.GetDirge().ToString();
                string concept = vTemp.GetConcept();
                string city = cityName.text;
                string strength = vTemp.strength.GetStatValue().ToString();
                string dexterity = vTemp.dexterity.GetStatValue().ToString();
                string stamina = vTemp.stamina.GetStatValue().ToString();
                string presence = vTemp.presence.GetStatValue().ToString();
                string manipulation = vTemp.manipulation.GetStatValue().ToString();
                string composure = vTemp.composure.GetStatValue().ToString();
                string intelligence = vTemp.intelligence.GetStatValue().ToString();
                string wits = vTemp.wits.GetStatValue().ToString();
                string resolve = vTemp.resolve.GetStatValue().ToString();
                string potency = vTemp.GetPotency().ToString();
                string willpower = vTemp.willpower.ToString();
                string humanity = vTemp.integrity.ToString();
                string size = vTemp.size.ToString();
                string initiative = vTemp.initiative.ToString();
                string speed = vTemp.speed.ToString();
                string defence = vTemp.defence.ToString();
                string health = vTemp.health.ToString();
                string athletics = vTemp.athletics.GetStatValue().ToString();
                string brawl = vTemp.brawl.GetStatValue().ToString();
                string drive = vTemp.drive.GetStatValue().ToString();
                string firearm = vTemp.firearms.GetStatValue().ToString();
                string larceny = vTemp.larceny.GetStatValue().ToString();
                string stealth = vTemp.stealth.GetStatValue().ToString();
                string survival = vTemp.survival.GetStatValue().ToString();
                string weaponry = vTemp.weaponry.GetStatValue().ToString();
                string animalKen = vTemp.animalKen.GetStatValue().ToString();
                string empathy = vTemp.empathy.GetStatValue().ToString();
                string expression = vTemp.expression.GetStatValue().ToString();
                string intimidation = vTemp.intimidation.GetStatValue().ToString();
                string persuasion = vTemp.persuasion.GetStatValue().ToString();
                string socialise = vTemp.socialise.GetStatValue().ToString();
                string streetwise = vTemp.streetwise.GetStatValue().ToString();
                string subterfuge = vTemp.subterfuge.GetStatValue().ToString();
                string academics = vTemp.academics.GetStatValue().ToString();
                string computer = vTemp.computer.GetStatValue().ToString();
                string crafts = vTemp.crafts.GetStatValue().ToString();
                string investigation = vTemp.investigation.GetStatValue().ToString();
                string medicine = vTemp.medicine.GetStatValue().ToString();
                string occult = vTemp.occult.GetStatValue().ToString();
                string politics = vTemp.politics.GetStatValue().ToString();
                string science = vTemp.science.GetStatValue().ToString();
                string vigor = vTemp.vigor.GetStatValue().ToString();
                string celerity = vTemp.celerity.GetStatValue().ToString();
                string resilience = vTemp.resilience.GetStatValue().ToString();
                string animalism = vTemp.animalism.GetStatValue().ToString();
                string obfuscate = vTemp.obfuscate.GetStatValue().ToString();
                string auspex = vTemp.auspex.GetStatValue().ToString();
                string dominate = vTemp.dominate.GetStatValue().ToString();
                string majesty = vTemp.majesty.GetStatValue().ToString();
                string nightmare = vTemp.nightmare.GetStatValue().ToString();
                string protean = vTemp.protean.GetStatValue().ToString();
                string coilsOfTheDragon = vTemp.coilsOfTheDragon.GetStatValue().ToString();
                string cruacSorcery = vTemp.cruacSorcery.GetStatValue().ToString();
                string thebanSorcery = vTemp.thebanSorcery.GetStatValue().ToString();
                string ahraniteSorcery = vTemp.ahraniteSorcery.GetStatValue().ToString();
                string thanatology = vTemp.thanatology.GetStatValue().ToString();

                tw.WriteLine(vName + "," + gender + "," + embrace + "," + age + "," + clan + "," + bloodline + "," + covenant + "," + mask + "," + dirge + "," + concept + "," + city + ","
                    + strength + "," + dexterity + "," + stamina + "," + presence + "," + manipulation + "," + composure + "," + intelligence + "," + wits + "," + resolve + ","
                    + potency + "," + willpower + "," + humanity + "," + size + "," + initiative + "," + speed + "," + defence + "," + health + ","
                    + athletics + "," + brawl + "," + drive + "," + firearm + "," + larceny + "," + stealth + "," + survival + "," + weaponry + "," + animalKen + "," + empathy + ","
                    + expression + "," + intimidation + "," + persuasion + "," + socialise + "," + streetwise + "," + subterfuge + "," + academics + "," + computer + ","
                    + crafts + "," + investigation + "," + medicine + "," + occult + "," + politics + "," + science + ","
                    + vigor + "," + celerity + "," + resilience + "," + animalism + "," + obfuscate + "," + auspex + "," + dominate + "," + majesty + "," + nightmare + ","
                    + protean + "," + coilsOfTheDragon + "," + cruacSorcery + "," + thebanSorcery + "," + ahraniteSorcery + "," + thanatology);
            }
            tw.Close();
        }
    }
    private void MageToCSV()
    {
        if (CharGenerator.Instance.listOfCharacters.Count > 0)
        {
            List<MageTemplate> charList = new();
            foreach (CharTemplate ctemp in CharGenerator.Instance.listOfCharacters)
            {
                MageTemplate chartemp = (MageTemplate)ctemp;
                charList.Add(chartemp);
            }

            TextWriter tw = new StreamWriter(filename, false);
            tw.WriteLine("Name, Gender, Age, Path, Legacy, Order, Virtue, Vice, Concept, City, Strength, Dexterity, Stamina, Presence, Manipulation, Composure, " +
                "Intelligence, Wits, Resolve, Potency, Willpower, Humanity, Size, Initiative, Speed, Defence, Health, Athletics, Brawl, Drive, Firearm, Larceny, Stealth, " +
                "Survival, Weaponry, Animal Ken, Empathy, Expression, Intimidation, Persuasion, Socialise, Streetwise, Subterfuge, Academics, Computer, Crafts, Investigation, " +
                "Medicine, Occult, Politics, Science, Prime, Forces, Fate, Time, Mind, Space, Spirit, Life, Death, Matter");
            tw.Close();
            tw = new StreamWriter(filename, true);
            foreach (MageTemplate cTemp in charList)
            {
                string cName = cTemp.GetName();
                string gender = cTemp.GetGender();
                string age = cTemp.age.ToString();
                string path = cTemp.GetMagePath().ToString();
                string legacy = cTemp.GetMageLegacy().ToString();
                string order = cTemp.GetMageOrder().ToString();
                string virtue = cTemp.GetVirtue().ToString();
                string vice = cTemp.GetVice().ToString();
                string concept = cTemp.GetConcept();
                string city = cityName.text;
                string strength = cTemp.strength.GetStatValue().ToString();
                string dexterity = cTemp.dexterity.GetStatValue().ToString();
                string stamina = cTemp.stamina.GetStatValue().ToString();
                string presence = cTemp.presence.GetStatValue().ToString();
                string manipulation = cTemp.manipulation.GetStatValue().ToString();
                string composure = cTemp.composure.GetStatValue().ToString();
                string intelligence = cTemp.intelligence.GetStatValue().ToString();
                string wits = cTemp.wits.GetStatValue().ToString();
                string resolve = cTemp.resolve.GetStatValue().ToString();
                string potency = cTemp.GetPotency().ToString();
                string willpower = cTemp.willpower.ToString();
                string humanity = cTemp.integrity.ToString();
                string size = cTemp.size.ToString();
                string initiative = cTemp.initiative.ToString();
                string speed = cTemp.speed.ToString();
                string defence = cTemp.defence.ToString();
                string health = cTemp.health.ToString();
                string athletics = cTemp.athletics.GetStatValue().ToString();
                string brawl = cTemp.brawl.GetStatValue().ToString();
                string drive = cTemp.drive.GetStatValue().ToString();
                string firearm = cTemp.firearms.GetStatValue().ToString();
                string larceny = cTemp.larceny.GetStatValue().ToString();
                string stealth = cTemp.stealth.GetStatValue().ToString();
                string survival = cTemp.survival.GetStatValue().ToString();
                string weaponry = cTemp.weaponry.GetStatValue().ToString();
                string animalKen = cTemp.animalKen.GetStatValue().ToString();
                string empathy = cTemp.empathy.GetStatValue().ToString();
                string expression = cTemp.expression.GetStatValue().ToString();
                string intimidation = cTemp.intimidation.GetStatValue().ToString();
                string persuasion = cTemp.persuasion.GetStatValue().ToString();
                string socialise = cTemp.socialise.GetStatValue().ToString();
                string streetwise = cTemp.streetwise.GetStatValue().ToString();
                string subterfuge = cTemp.subterfuge.GetStatValue().ToString();
                string academics = cTemp.academics.GetStatValue().ToString();
                string computer = cTemp.computer.GetStatValue().ToString();
                string crafts = cTemp.crafts.GetStatValue().ToString();
                string investigation = cTemp.investigation.GetStatValue().ToString();
                string medicine = cTemp.medicine.GetStatValue().ToString();
                string occult = cTemp.occult.GetStatValue().ToString();
                string politics = cTemp.politics.GetStatValue().ToString();
                string science = cTemp.science.GetStatValue().ToString();
                string prime = cTemp.prime.GetStatValue().ToString();
                string forces = cTemp.prime.GetStatValue().ToString();
                string fate = cTemp.fate.GetStatValue().ToString();
                string time = cTemp.time.GetStatValue().ToString();
                string mind = cTemp.mind.GetStatValue().ToString();
                string space = cTemp.space.GetStatValue().ToString();
                string spirit = cTemp.spirit.GetStatValue().ToString();
                string life = cTemp.life.GetStatValue().ToString();
                string death = cTemp.death.GetStatValue().ToString();
                string matter = cTemp.matter.GetStatValue().ToString();

                tw.WriteLine(cName + "," + gender + "," + age + "," + path + "," + legacy + "," + order + "," + virtue + "," + vice + "," + concept + "," + city + ","
                    + strength + "," + dexterity + "," + stamina + "," + presence + "," + manipulation + "," + composure + "," + intelligence + "," + wits + "," + resolve + ","
                    + potency + "," + willpower + "," + humanity + "," + size + "," + initiative + "," + speed + "," + defence + "," + health + ","
                    + athletics + "," + brawl + "," + drive + "," + firearm + "," + larceny + "," + stealth + "," + survival + "," + weaponry + "," + animalKen + "," + empathy + ","
                    + expression + "," + intimidation + "," + persuasion + "," + socialise + "," + streetwise + "," + subterfuge + "," + academics + "," + computer + ","
                    + crafts + "," + investigation + "," + medicine + "," + occult + "," + politics + "," + science + ","
                    + prime + "," + forces + "," + fate + "," + time + "," + mind + "," + space + "," + spirit + "," + life + "," + death + "," + matter);
            }
            tw.Close();
        }
    }
    private void WerewolfToCSV()
    {
        if (CharGenerator.Instance.listOfCharacters.Count > 0)
        {
            List<WerewolfTemplate> charList = new();
            foreach (CharTemplate ctemp in CharGenerator.Instance.listOfCharacters)
            {
                WerewolfTemplate chartemp = (WerewolfTemplate)ctemp;
                charList.Add(chartemp);
            }

            TextWriter tw = new StreamWriter(filename, false);
            tw.WriteLine("Name, Gender, Age, Auspice, Legacy, Order, Blood, Bone, City, Strength, Dexterity, Stamina, Presence, Manipulation, Composure, " +
                "Intelligence, Wits, Resolve, Potency, Willpower, Humanity, Size, Initiative, Speed, Defence, Health, Athletics, Brawl, Drive, Firearm, Larceny, Stealth, " +
                "Survival, Weaponry, Animal Ken, Empathy, Expression, Intimidation, Persuasion, Socialise, Streetwise, Subterfuge, Academics, Computer, Crafts, Investigation, " +
                "Medicine, Occult, Politics, Science");
            tw.Close();
            tw = new StreamWriter(filename, true);
            foreach (WerewolfTemplate cTemp in charList)
            {
                string cName = cTemp.GetName();
                string gender = cTemp.GetGender();
                string age = cTemp.age.ToString();
                string auspice = cTemp.GetAuspice().ToString();
                string tribe = cTemp.GetTribe().ToString();
                string lodge = cTemp.GetLodge().ToString();
                string virtue = cTemp.GetBlood().ToString();
                string vice = cTemp.GetBone().ToString();
                string city = cityName.text;
                string strength = cTemp.strength.GetStatValue().ToString();
                string dexterity = cTemp.dexterity.GetStatValue().ToString();
                string stamina = cTemp.stamina.GetStatValue().ToString();
                string presence = cTemp.presence.GetStatValue().ToString();
                string manipulation = cTemp.manipulation.GetStatValue().ToString();
                string composure = cTemp.composure.GetStatValue().ToString();
                string intelligence = cTemp.intelligence.GetStatValue().ToString();
                string wits = cTemp.wits.GetStatValue().ToString();
                string resolve = cTemp.resolve.GetStatValue().ToString();
                string potency = cTemp.GetPotency().ToString();
                string willpower = cTemp.willpower.ToString();
                string humanity = cTemp.integrity.ToString();
                string size = cTemp.size.ToString();
                string initiative = cTemp.initiative.ToString();
                string speed = cTemp.speed.ToString();
                string defence = cTemp.defence.ToString();
                string health = cTemp.health.ToString();
                string athletics = cTemp.athletics.GetStatValue().ToString();
                string brawl = cTemp.brawl.GetStatValue().ToString();
                string drive = cTemp.drive.GetStatValue().ToString();
                string firearm = cTemp.firearms.GetStatValue().ToString();
                string larceny = cTemp.larceny.GetStatValue().ToString();
                string stealth = cTemp.stealth.GetStatValue().ToString();
                string survival = cTemp.survival.GetStatValue().ToString();
                string weaponry = cTemp.weaponry.GetStatValue().ToString();
                string animalKen = cTemp.animalKen.GetStatValue().ToString();
                string empathy = cTemp.empathy.GetStatValue().ToString();
                string expression = cTemp.expression.GetStatValue().ToString();
                string intimidation = cTemp.intimidation.GetStatValue().ToString();
                string persuasion = cTemp.persuasion.GetStatValue().ToString();
                string socialise = cTemp.socialise.GetStatValue().ToString();
                string streetwise = cTemp.streetwise.GetStatValue().ToString();
                string subterfuge = cTemp.subterfuge.GetStatValue().ToString();
                string academics = cTemp.academics.GetStatValue().ToString();
                string computer = cTemp.computer.GetStatValue().ToString();
                string crafts = cTemp.crafts.GetStatValue().ToString();
                string investigation = cTemp.investigation.GetStatValue().ToString();
                string medicine = cTemp.medicine.GetStatValue().ToString();
                string occult = cTemp.occult.GetStatValue().ToString();
                string politics = cTemp.politics.GetStatValue().ToString();
                string science = cTemp.science.GetStatValue().ToString();

                tw.WriteLine(cName + "," + gender + "," + age + "," + auspice + "," + tribe + "," + lodge + "," + virtue + "," + vice + "," + city + ","
                    + strength + "," + dexterity + "," + stamina + "," + presence + "," + manipulation + "," + composure + "," + intelligence + "," + wits + "," + resolve + ","
                    + potency + "," + willpower + "," + humanity + "," + size + "," + initiative + "," + speed + "," + defence + "," + health + ","
                    + athletics + "," + brawl + "," + drive + "," + firearm + "," + larceny + "," + stealth + "," + survival + "," + weaponry + "," + animalKen + "," + empathy + ","
                    + expression + "," + intimidation + "," + persuasion + "," + socialise + "," + streetwise + "," + subterfuge + "," + academics + "," + computer + ","
                    + crafts + "," + investigation + "," + medicine + "," + occult + "," + politics + "," + science);
            }
            tw.Close();
        }
    }
    private void ChangelingToCSV()
    {
        if (CharGenerator.Instance.listOfCharacters.Count > 0)
        {
            List<ChangelingTemplate> charList = new();
            foreach (CharTemplate ctemp in CharGenerator.Instance.listOfCharacters)
            {
                ChangelingTemplate chartemp = (ChangelingTemplate)ctemp;
                charList.Add(chartemp);
            }

            TextWriter tw = new StreamWriter(filename, false);
            tw.WriteLine("Name, Gender, Age, Kith, Seeming, Court, Needle, Thread, Concept, City, Strength, Dexterity, Stamina, Presence, Manipulation, Composure, " +
                "Intelligence, Wits, Resolve, Potency, Willpower, Humanity, Size, Initiative, Speed, Defence, Health, Athletics, Brawl, Drive, Firearm, Larceny, Stealth, " +
                "Survival, Weaponry, Animal Ken, Empathy, Expression, Intimidation, Persuasion, Socialise, Streetwise, Subterfuge, Academics, Computer, Crafts, Investigation, " +
                "Medicine, Occult, Politics, Science, Prime, Forces, Fate, Time, Mind, Space, Spirit, Life, Death, Matter");
            tw.Close();
            tw = new StreamWriter(filename, true);
            foreach (ChangelingTemplate cTemp in charList)
            {
                string cName = cTemp.GetName();
                string gender = cTemp.GetGender();
                string age = cTemp.age.ToString();
                string kith = cTemp.GetKith().ToString();
                string seeming = cTemp.GetSeeming().ToString();
                string court = cTemp.GetCourt().ToString();
                string virtue = cTemp.GetNeedle().ToString();
                string vice = cTemp.GetThread().ToString();
                string concept = cTemp.GetConcept();
                string city = cityName.text;
                string strength = cTemp.strength.GetStatValue().ToString();
                string dexterity = cTemp.dexterity.GetStatValue().ToString();
                string stamina = cTemp.stamina.GetStatValue().ToString();
                string presence = cTemp.presence.GetStatValue().ToString();
                string manipulation = cTemp.manipulation.GetStatValue().ToString();
                string composure = cTemp.composure.GetStatValue().ToString();
                string intelligence = cTemp.intelligence.GetStatValue().ToString();
                string wits = cTemp.wits.GetStatValue().ToString();
                string resolve = cTemp.resolve.GetStatValue().ToString();
                string potency = cTemp.GetPotency().ToString();
                string willpower = cTemp.willpower.ToString();
                string humanity = cTemp.integrity.ToString();
                string size = cTemp.size.ToString();
                string initiative = cTemp.initiative.ToString();
                string speed = cTemp.speed.ToString();
                string defence = cTemp.defence.ToString();
                string health = cTemp.health.ToString();
                string athletics = cTemp.athletics.GetStatValue().ToString();
                string brawl = cTemp.brawl.GetStatValue().ToString();
                string drive = cTemp.drive.GetStatValue().ToString();
                string firearm = cTemp.firearms.GetStatValue().ToString();
                string larceny = cTemp.larceny.GetStatValue().ToString();
                string stealth = cTemp.stealth.GetStatValue().ToString();
                string survival = cTemp.survival.GetStatValue().ToString();
                string weaponry = cTemp.weaponry.GetStatValue().ToString();
                string animalKen = cTemp.animalKen.GetStatValue().ToString();
                string empathy = cTemp.empathy.GetStatValue().ToString();
                string expression = cTemp.expression.GetStatValue().ToString();
                string intimidation = cTemp.intimidation.GetStatValue().ToString();
                string persuasion = cTemp.persuasion.GetStatValue().ToString();
                string socialise = cTemp.socialise.GetStatValue().ToString();
                string streetwise = cTemp.streetwise.GetStatValue().ToString();
                string subterfuge = cTemp.subterfuge.GetStatValue().ToString();
                string academics = cTemp.academics.GetStatValue().ToString();
                string computer = cTemp.computer.GetStatValue().ToString();
                string crafts = cTemp.crafts.GetStatValue().ToString();
                string investigation = cTemp.investigation.GetStatValue().ToString();
                string medicine = cTemp.medicine.GetStatValue().ToString();
                string occult = cTemp.occult.GetStatValue().ToString();
                string politics = cTemp.politics.GetStatValue().ToString();
                string science = cTemp.science.GetStatValue().ToString();

                tw.WriteLine(cName + "," + gender + "," + age + "," + kith + "," + seeming + "," + court + "," + virtue + "," + vice + "," + concept + "," + city + ","
                    + strength + "," + dexterity + "," + stamina + "," + presence + "," + manipulation + "," + composure + "," + intelligence + "," + wits + "," + resolve + ","
                    + potency + "," + willpower + "," + humanity + "," + size + "," + initiative + "," + speed + "," + defence + "," + health + ","
                    + athletics + "," + brawl + "," + drive + "," + firearm + "," + larceny + "," + stealth + "," + survival + "," + weaponry + "," + animalKen + "," + empathy + ","
                    + expression + "," + intimidation + "," + persuasion + "," + socialise + "," + streetwise + "," + subterfuge + "," + academics + "," + computer + ","
                    + crafts + "," + investigation + "," + medicine + "," + occult + "," + politics + "," + science);
            }
            tw.Close();
        }
    }
    private void GeistToCSV()
    {
        if (CharGenerator.Instance.listOfCharacters.Count > 0)
        {
            List<GeistTemplate> charList = new();
            foreach (CharTemplate ctemp in CharGenerator.Instance.listOfCharacters)
            {
                GeistTemplate chartemp = (GeistTemplate)ctemp;
                charList.Add(chartemp);
            }

            TextWriter tw = new StreamWriter(filename, false);
            tw.WriteLine("Name, Gender, Age, Geist, Burden, Krewe Archetype, Root, Bloom, Concept, City, Strength, Dexterity, Stamina, Presence, Manipulation, Composure, " +
                "Intelligence, Wits, Resolve, Potency, Willpower, Humanity, Size, Initiative, Speed, Defence, Health, Athletics, Brawl, Drive, Firearm, Larceny, Stealth, " +
                "Survival, Weaponry, Animal Ken, Empathy, Expression, Intimidation, Persuasion, Socialise, Streetwise, Subterfuge, Academics, Computer, Crafts, Investigation, " +
                "Medicine, Occult, Politics, Science, Prime, Forces, Fate, Time, Mind, Space, Spirit, Life, Death, Matter");
            tw.Close();
            tw = new StreamWriter(filename, true);
            foreach (GeistTemplate cTemp in charList)
            {
                string cName = cTemp.GetName();
                string gender = cTemp.GetGender();
                string age = cTemp.age.ToString();
                string geist = cTemp.GetGeist().ToString();
                string burden = cTemp.GetBurden().ToString();
                string kreweArchetype = cTemp.GetKreweArchetype().ToString();
                string root = cTemp.GetRoot().ToString();
                string bloom = cTemp.GetBloom().ToString();
                string concept = cTemp.GetConcept();
                string city = cityName.text;
                string strength = cTemp.strength.GetStatValue().ToString();
                string dexterity = cTemp.dexterity.GetStatValue().ToString();
                string stamina = cTemp.stamina.GetStatValue().ToString();
                string presence = cTemp.presence.GetStatValue().ToString();
                string manipulation = cTemp.manipulation.GetStatValue().ToString();
                string composure = cTemp.composure.GetStatValue().ToString();
                string intelligence = cTemp.intelligence.GetStatValue().ToString();
                string wits = cTemp.wits.GetStatValue().ToString();
                string resolve = cTemp.resolve.GetStatValue().ToString();
                string potency = cTemp.GetPotency().ToString();
                string willpower = cTemp.willpower.ToString();
                string humanity = cTemp.integrity.ToString();
                string size = cTemp.size.ToString();
                string initiative = cTemp.initiative.ToString();
                string speed = cTemp.speed.ToString();
                string defence = cTemp.defence.ToString();
                string health = cTemp.health.ToString();
                string athletics = cTemp.athletics.GetStatValue().ToString();
                string brawl = cTemp.brawl.GetStatValue().ToString();
                string drive = cTemp.drive.GetStatValue().ToString();
                string firearm = cTemp.firearms.GetStatValue().ToString();
                string larceny = cTemp.larceny.GetStatValue().ToString();
                string stealth = cTemp.stealth.GetStatValue().ToString();
                string survival = cTemp.survival.GetStatValue().ToString();
                string weaponry = cTemp.weaponry.GetStatValue().ToString();
                string animalKen = cTemp.animalKen.GetStatValue().ToString();
                string empathy = cTemp.empathy.GetStatValue().ToString();
                string expression = cTemp.expression.GetStatValue().ToString();
                string intimidation = cTemp.intimidation.GetStatValue().ToString();
                string persuasion = cTemp.persuasion.GetStatValue().ToString();
                string socialise = cTemp.socialise.GetStatValue().ToString();
                string streetwise = cTemp.streetwise.GetStatValue().ToString();
                string subterfuge = cTemp.subterfuge.GetStatValue().ToString();
                string academics = cTemp.academics.GetStatValue().ToString();
                string computer = cTemp.computer.GetStatValue().ToString();
                string crafts = cTemp.crafts.GetStatValue().ToString();
                string investigation = cTemp.investigation.GetStatValue().ToString();
                string medicine = cTemp.medicine.GetStatValue().ToString();
                string occult = cTemp.occult.GetStatValue().ToString();
                string politics = cTemp.politics.GetStatValue().ToString();
                string science = cTemp.science.GetStatValue().ToString();

                tw.WriteLine(cName + "," + gender + "," + age + "," + geist + "," + burden + "," + kreweArchetype + "," + root + "," + bloom + "," + concept + "," + city + ","
                    + strength + "," + dexterity + "," + stamina + "," + presence + "," + manipulation + "," + composure + "," + intelligence + "," + wits + "," + resolve + ","
                    + potency + "," + willpower + "," + humanity + "," + size + "," + initiative + "," + speed + "," + defence + "," + health + ","
                    + athletics + "," + brawl + "," + drive + "," + firearm + "," + larceny + "," + stealth + "," + survival + "," + weaponry + "," + animalKen + "," + empathy + ","
                    + expression + "," + intimidation + "," + persuasion + "," + socialise + "," + streetwise + "," + subterfuge + "," + academics + "," + computer + ","
                    + crafts + "," + investigation + "," + medicine + "," + occult + "," + politics + "," + science);
            }
            tw.Close();
        }
    }
    private void DemonToCSV()
    {
        if (CharGenerator.Instance.listOfCharacters.Count > 0)
        {
            List<DemonTemplate> charList = new();
            foreach (CharTemplate ctemp in CharGenerator.Instance.listOfCharacters)
            {
                DemonTemplate chartemp = (DemonTemplate)ctemp;
                charList.Add(chartemp);
            }

            TextWriter tw = new StreamWriter(filename, false);
            tw.WriteLine("Name, Gender, Age, Incarnation, Agenda, Virtue, Vice, Concept, City, Strength, Dexterity, Stamina, Presence, Manipulation, Composure, " +
                "Intelligence, Wits, Resolve, Potency, Willpower, Humanity, Size, Initiative, Speed, Defence, Health, Athletics, Brawl, Drive, Firearm, Larceny, Stealth, " +
                "Survival, Weaponry, Animal Ken, Empathy, Expression, Intimidation, Persuasion, Socialise, Streetwise, Subterfuge, Academics, Computer, Crafts, Investigation, " +
                "Medicine, Occult, Politics, Science, Prime, Forces, Fate, Time, Mind, Space, Spirit, Life, Death, Matter");
            tw.Close();
            tw = new StreamWriter(filename, true);
            foreach (DemonTemplate cTemp in charList)
            {
                string cName = cTemp.GetName();
                string gender = cTemp.GetGender();
                string age = cTemp.age.ToString();
                string incarnation = cTemp.GetIncarnation().ToString();
                string agenda = cTemp.GetAgenda().ToString();
                string virtue = cTemp.GetVirtue().ToString();
                string vice = cTemp.GetVice().ToString();
                string concept = cTemp.GetConcept();
                string city = cityName.text;
                string strength = cTemp.strength.GetStatValue().ToString();
                string dexterity = cTemp.dexterity.GetStatValue().ToString();
                string stamina = cTemp.stamina.GetStatValue().ToString();
                string presence = cTemp.presence.GetStatValue().ToString();
                string manipulation = cTemp.manipulation.GetStatValue().ToString();
                string composure = cTemp.composure.GetStatValue().ToString();
                string intelligence = cTemp.intelligence.GetStatValue().ToString();
                string wits = cTemp.wits.GetStatValue().ToString();
                string resolve = cTemp.resolve.GetStatValue().ToString();
                string potency = cTemp.GetPotency().ToString();
                string willpower = cTemp.willpower.ToString();
                string humanity = cTemp.integrity.ToString();
                string size = cTemp.size.ToString();
                string initiative = cTemp.initiative.ToString();
                string speed = cTemp.speed.ToString();
                string defence = cTemp.defence.ToString();
                string health = cTemp.health.ToString();
                string athletics = cTemp.athletics.GetStatValue().ToString();
                string brawl = cTemp.brawl.GetStatValue().ToString();
                string drive = cTemp.drive.GetStatValue().ToString();
                string firearm = cTemp.firearms.GetStatValue().ToString();
                string larceny = cTemp.larceny.GetStatValue().ToString();
                string stealth = cTemp.stealth.GetStatValue().ToString();
                string survival = cTemp.survival.GetStatValue().ToString();
                string weaponry = cTemp.weaponry.GetStatValue().ToString();
                string animalKen = cTemp.animalKen.GetStatValue().ToString();
                string empathy = cTemp.empathy.GetStatValue().ToString();
                string expression = cTemp.expression.GetStatValue().ToString();
                string intimidation = cTemp.intimidation.GetStatValue().ToString();
                string persuasion = cTemp.persuasion.GetStatValue().ToString();
                string socialise = cTemp.socialise.GetStatValue().ToString();
                string streetwise = cTemp.streetwise.GetStatValue().ToString();
                string subterfuge = cTemp.subterfuge.GetStatValue().ToString();
                string academics = cTemp.academics.GetStatValue().ToString();
                string computer = cTemp.computer.GetStatValue().ToString();
                string crafts = cTemp.crafts.GetStatValue().ToString();
                string investigation = cTemp.investigation.GetStatValue().ToString();
                string medicine = cTemp.medicine.GetStatValue().ToString();
                string occult = cTemp.occult.GetStatValue().ToString();
                string politics = cTemp.politics.GetStatValue().ToString();
                string science = cTemp.science.GetStatValue().ToString();

                tw.WriteLine(cName + "," + gender + "," + age + "," + incarnation + "," + agenda + "," + virtue + "," + vice + "," + concept + "," + city + ","
                    + strength + "," + dexterity + "," + stamina + "," + presence + "," + manipulation + "," + composure + "," + intelligence + "," + wits + "," + resolve + ","
                    + potency + "," + willpower + "," + humanity + "," + size + "," + initiative + "," + speed + "," + defence + "," + health + ","
                    + athletics + "," + brawl + "," + drive + "," + firearm + "," + larceny + "," + stealth + "," + survival + "," + weaponry + "," + animalKen + "," + empathy + ","
                    + expression + "," + intimidation + "," + persuasion + "," + socialise + "," + streetwise + "," + subterfuge + "," + academics + "," + computer + ","
                    + crafts + "," + investigation + "," + medicine + "," + occult + "," + politics + "," + science);
            }
            tw.Close();
        }
    }
    private void PrometheanToCSV()
    {
        if (CharGenerator.Instance.listOfCharacters.Count > 0)
        {
            List<PrometheanTemplate> charList = new();
            foreach (CharTemplate ctemp in CharGenerator.Instance.listOfCharacters)
            {
                PrometheanTemplate chartemp = (PrometheanTemplate)ctemp;
                charList.Add(chartemp);
            }

            TextWriter tw = new StreamWriter(filename, false);
            tw.WriteLine("Name, Gender, Age, Lineage, Refinement, Elpis, Torment, Concept, City, Strength, Dexterity, Stamina, Presence, Manipulation, Composure, " +
                "Intelligence, Wits, Resolve, Potency, Willpower, Humanity, Size, Initiative, Speed, Defence, Health, Athletics, Brawl, Drive, Firearm, Larceny, Stealth, " +
                "Survival, Weaponry, Animal Ken, Empathy, Expression, Intimidation, Persuasion, Socialise, Streetwise, Subterfuge, Academics, Computer, Crafts, Investigation, " +
                "Medicine, Occult, Politics, Science, Prime, Forces, Fate, Time, Mind, Space, Spirit, Life, Death, Matter");
            tw.Close();
            tw = new StreamWriter(filename, true);
            foreach (PrometheanTemplate cTemp in charList)
            {
                string cName = cTemp.GetName();
                string gender = cTemp.GetGender();
                string age = cTemp.age.ToString();
                string lineage = cTemp.GetLineage().ToString();
                string refinement = cTemp.GetRefinement().ToString();
                string elpis = cTemp.GetElpis().ToString();
                string torment = cTemp.GetTorment().ToString();
                string concept = cTemp.GetConcept();
                string city = cityName.text;
                string strength = cTemp.strength.GetStatValue().ToString();
                string dexterity = cTemp.dexterity.GetStatValue().ToString();
                string stamina = cTemp.stamina.GetStatValue().ToString();
                string presence = cTemp.presence.GetStatValue().ToString();
                string manipulation = cTemp.manipulation.GetStatValue().ToString();
                string composure = cTemp.composure.GetStatValue().ToString();
                string intelligence = cTemp.intelligence.GetStatValue().ToString();
                string wits = cTemp.wits.GetStatValue().ToString();
                string resolve = cTemp.resolve.GetStatValue().ToString();
                string potency = cTemp.GetPotency().ToString();
                string willpower = cTemp.willpower.ToString();
                string humanity = cTemp.integrity.ToString();
                string size = cTemp.size.ToString();
                string initiative = cTemp.initiative.ToString();
                string speed = cTemp.speed.ToString();
                string defence = cTemp.defence.ToString();
                string health = cTemp.health.ToString();
                string athletics = cTemp.athletics.GetStatValue().ToString();
                string brawl = cTemp.brawl.GetStatValue().ToString();
                string drive = cTemp.drive.GetStatValue().ToString();
                string firearm = cTemp.firearms.GetStatValue().ToString();
                string larceny = cTemp.larceny.GetStatValue().ToString();
                string stealth = cTemp.stealth.GetStatValue().ToString();
                string survival = cTemp.survival.GetStatValue().ToString();
                string weaponry = cTemp.weaponry.GetStatValue().ToString();
                string animalKen = cTemp.animalKen.GetStatValue().ToString();
                string empathy = cTemp.empathy.GetStatValue().ToString();
                string expression = cTemp.expression.GetStatValue().ToString();
                string intimidation = cTemp.intimidation.GetStatValue().ToString();
                string persuasion = cTemp.persuasion.GetStatValue().ToString();
                string socialise = cTemp.socialise.GetStatValue().ToString();
                string streetwise = cTemp.streetwise.GetStatValue().ToString();
                string subterfuge = cTemp.subterfuge.GetStatValue().ToString();
                string academics = cTemp.academics.GetStatValue().ToString();
                string computer = cTemp.computer.GetStatValue().ToString();
                string crafts = cTemp.crafts.GetStatValue().ToString();
                string investigation = cTemp.investigation.GetStatValue().ToString();
                string medicine = cTemp.medicine.GetStatValue().ToString();
                string occult = cTemp.occult.GetStatValue().ToString();
                string politics = cTemp.politics.GetStatValue().ToString();
                string science = cTemp.science.GetStatValue().ToString();

                tw.WriteLine(cName + "," + gender + "," + age + "," + lineage + "," + refinement + "," + elpis + "," + torment + "," + concept + "," + city + ","
                    + strength + "," + dexterity + "," + stamina + "," + presence + "," + manipulation + "," + composure + "," + intelligence + "," + wits + "," + resolve + ","
                    + potency + "," + willpower + "," + humanity + "," + size + "," + initiative + "," + speed + "," + defence + "," + health + ","
                    + athletics + "," + brawl + "," + drive + "," + firearm + "," + larceny + "," + stealth + "," + survival + "," + weaponry + "," + animalKen + "," + empathy + ","
                    + expression + "," + intimidation + "," + persuasion + "," + socialise + "," + streetwise + "," + subterfuge + "," + academics + "," + computer + ","
                    + crafts + "," + investigation + "," + medicine + "," + occult + "," + politics + "," + science);
            }
            tw.Close();
        }
    }
    private void MummyToCSV()
    {
        if (CharGenerator.Instance.listOfCharacters.Count > 0)
        {
            List<MummyTemplate> charList = new();
            foreach (CharTemplate ctemp in CharGenerator.Instance.listOfCharacters)
            {
                MummyTemplate chartemp = (MummyTemplate)ctemp;
                charList.Add(chartemp);
            }

            TextWriter tw = new StreamWriter(filename, false);
            tw.WriteLine("Name, Gender, Age, Guild, Balance, Decree, Burden, Concept, City, Strength, Dexterity, Stamina, Presence, Manipulation, Composure, " +
                "Intelligence, Wits, Resolve, Potency, Willpower, Humanity, Size, Initiative, Speed, Defence, Health, Athletics, Brawl, Drive, Firearm, Larceny, Stealth, " +
                "Survival, Weaponry, Animal Ken, Empathy, Expression, Intimidation, Persuasion, Socialise, Streetwise, Subterfuge, Academics, Computer, Crafts, Investigation, " +
                "Medicine, Occult, Politics, Science, Prime, Forces, Fate, Time, Mind, Space, Spirit, Life, Death, Matter");
            tw.Close();
            tw = new StreamWriter(filename, true);
            foreach (MummyTemplate cTemp in charList)
            {
                string cName = cTemp.GetName();
                string gender = cTemp.GetGender();
                string age = cTemp.age.ToString();
                string guild = cTemp.GetGuild().ToString();
                string balance = cTemp.GetBalance().ToString();
                string decree = cTemp.GetDecree().ToString();
                string burden = cTemp.GetBurden().ToString();
                string concept = cTemp.GetConcept();
                string city = cityName.text;
                string strength = cTemp.strength.GetStatValue().ToString();
                string dexterity = cTemp.dexterity.GetStatValue().ToString();
                string stamina = cTemp.stamina.GetStatValue().ToString();
                string presence = cTemp.presence.GetStatValue().ToString();
                string manipulation = cTemp.manipulation.GetStatValue().ToString();
                string composure = cTemp.composure.GetStatValue().ToString();
                string intelligence = cTemp.intelligence.GetStatValue().ToString();
                string wits = cTemp.wits.GetStatValue().ToString();
                string resolve = cTemp.resolve.GetStatValue().ToString();
                string potency = cTemp.GetPotency().ToString();
                string willpower = cTemp.willpower.ToString();
                string humanity = cTemp.integrity.ToString();
                string size = cTemp.size.ToString();
                string initiative = cTemp.initiative.ToString();
                string speed = cTemp.speed.ToString();
                string defence = cTemp.defence.ToString();
                string health = cTemp.health.ToString();
                string athletics = cTemp.athletics.GetStatValue().ToString();
                string brawl = cTemp.brawl.GetStatValue().ToString();
                string drive = cTemp.drive.GetStatValue().ToString();
                string firearm = cTemp.firearms.GetStatValue().ToString();
                string larceny = cTemp.larceny.GetStatValue().ToString();
                string stealth = cTemp.stealth.GetStatValue().ToString();
                string survival = cTemp.survival.GetStatValue().ToString();
                string weaponry = cTemp.weaponry.GetStatValue().ToString();
                string animalKen = cTemp.animalKen.GetStatValue().ToString();
                string empathy = cTemp.empathy.GetStatValue().ToString();
                string expression = cTemp.expression.GetStatValue().ToString();
                string intimidation = cTemp.intimidation.GetStatValue().ToString();
                string persuasion = cTemp.persuasion.GetStatValue().ToString();
                string socialise = cTemp.socialise.GetStatValue().ToString();
                string streetwise = cTemp.streetwise.GetStatValue().ToString();
                string subterfuge = cTemp.subterfuge.GetStatValue().ToString();
                string academics = cTemp.academics.GetStatValue().ToString();
                string computer = cTemp.computer.GetStatValue().ToString();
                string crafts = cTemp.crafts.GetStatValue().ToString();
                string investigation = cTemp.investigation.GetStatValue().ToString();
                string medicine = cTemp.medicine.GetStatValue().ToString();
                string occult = cTemp.occult.GetStatValue().ToString();
                string politics = cTemp.politics.GetStatValue().ToString();
                string science = cTemp.science.GetStatValue().ToString();

                tw.WriteLine(cName + "," + gender + "," + age + "," + guild + "," + balance + "," + decree + "," + burden + "," + concept + "," + city + ","
                    + strength + "," + dexterity + "," + stamina + "," + presence + "," + manipulation + "," + composure + "," + intelligence + "," + wits + "," + resolve + ","
                    + potency + "," + willpower + "," + humanity + "," + size + "," + initiative + "," + speed + "," + defence + "," + health + ","
                    + athletics + "," + brawl + "," + drive + "," + firearm + "," + larceny + "," + stealth + "," + survival + "," + weaponry + "," + animalKen + "," + empathy + ","
                    + expression + "," + intimidation + "," + persuasion + "," + socialise + "," + streetwise + "," + subterfuge + "," + academics + "," + computer + ","
                    + crafts + "," + investigation + "," + medicine + "," + occult + "," + politics + "," + science);
            }
            tw.Close();
        }
    }
    private void BeastToCSV()
    {
        if (CharGenerator.Instance.listOfCharacters.Count > 0)
        {
            List<BeastTemplate> charList = new();
            foreach (CharTemplate ctemp in CharGenerator.Instance.listOfCharacters)
            {
                BeastTemplate chartemp = (BeastTemplate)ctemp;
                charList.Add(chartemp);
            }

            TextWriter tw = new StreamWriter(filename, false);
            tw.WriteLine("Name, Gender, Age, Family, Hunger, Lgend, Life, Concept, City, Strength, Dexterity, Stamina, Presence, Manipulation, Composure, " +
                "Intelligence, Wits, Resolve, Potency, Willpower, Humanity, Size, Initiative, Speed, Defence, Health, Athletics, Brawl, Drive, Firearm, Larceny, Stealth, " +
                "Survival, Weaponry, Animal Ken, Empathy, Expression, Intimidation, Persuasion, Socialise, Streetwise, Subterfuge, Academics, Computer, Crafts, Investigation, " +
                "Medicine, Occult, Politics, Science, Prime, Forces, Fate, Time, Mind, Space, Spirit, Life, Death, Matter");
            tw.Close();
            tw = new StreamWriter(filename, true);
            foreach (BeastTemplate cTemp in charList)
            {
                string cName = cTemp.GetName();
                string gender = cTemp.GetGender();
                string age = cTemp.age.ToString();
                string family = cTemp.GetFamily().ToString();
                string hunger = cTemp.GetHunger().ToString();
                string legend = cTemp.GetLegend().ToString();
                string life = cTemp.GetLife().ToString();
                string concept = cTemp.GetConcept();
                string city = cityName.text;
                string strength = cTemp.strength.GetStatValue().ToString();
                string dexterity = cTemp.dexterity.GetStatValue().ToString();
                string stamina = cTemp.stamina.GetStatValue().ToString();
                string presence = cTemp.presence.GetStatValue().ToString();
                string manipulation = cTemp.manipulation.GetStatValue().ToString();
                string composure = cTemp.composure.GetStatValue().ToString();
                string intelligence = cTemp.intelligence.GetStatValue().ToString();
                string wits = cTemp.wits.GetStatValue().ToString();
                string resolve = cTemp.resolve.GetStatValue().ToString();
                string potency = cTemp.GetPotency().ToString();
                string willpower = cTemp.willpower.ToString();
                string humanity = cTemp.integrity.ToString();
                string size = cTemp.size.ToString();
                string initiative = cTemp.initiative.ToString();
                string speed = cTemp.speed.ToString();
                string defence = cTemp.defence.ToString();
                string health = cTemp.health.ToString();
                string athletics = cTemp.athletics.GetStatValue().ToString();
                string brawl = cTemp.brawl.GetStatValue().ToString();
                string drive = cTemp.drive.GetStatValue().ToString();
                string firearm = cTemp.firearms.GetStatValue().ToString();
                string larceny = cTemp.larceny.GetStatValue().ToString();
                string stealth = cTemp.stealth.GetStatValue().ToString();
                string survival = cTemp.survival.GetStatValue().ToString();
                string weaponry = cTemp.weaponry.GetStatValue().ToString();
                string animalKen = cTemp.animalKen.GetStatValue().ToString();
                string empathy = cTemp.empathy.GetStatValue().ToString();
                string expression = cTemp.expression.GetStatValue().ToString();
                string intimidation = cTemp.intimidation.GetStatValue().ToString();
                string persuasion = cTemp.persuasion.GetStatValue().ToString();
                string socialise = cTemp.socialise.GetStatValue().ToString();
                string streetwise = cTemp.streetwise.GetStatValue().ToString();
                string subterfuge = cTemp.subterfuge.GetStatValue().ToString();
                string academics = cTemp.academics.GetStatValue().ToString();
                string computer = cTemp.computer.GetStatValue().ToString();
                string crafts = cTemp.crafts.GetStatValue().ToString();
                string investigation = cTemp.investigation.GetStatValue().ToString();
                string medicine = cTemp.medicine.GetStatValue().ToString();
                string occult = cTemp.occult.GetStatValue().ToString();
                string politics = cTemp.politics.GetStatValue().ToString();
                string science = cTemp.science.GetStatValue().ToString();

                tw.WriteLine(cName + "," + gender + "," + age + "," + family + "," + hunger + "," + legend + "," + life + "," + concept + "," + city + ","
                    + strength + "," + dexterity + "," + stamina + "," + presence + "," + manipulation + "," + composure + "," + intelligence + "," + wits + "," + resolve + ","
                    + potency + "," + willpower + "," + humanity + "," + size + "," + initiative + "," + speed + "," + defence + "," + health + ","
                    + athletics + "," + brawl + "," + drive + "," + firearm + "," + larceny + "," + stealth + "," + survival + "," + weaponry + "," + animalKen + "," + empathy + ","
                    + expression + "," + intimidation + "," + persuasion + "," + socialise + "," + streetwise + "," + subterfuge + "," + academics + "," + computer + ","
                    + crafts + "," + investigation + "," + medicine + "," + occult + "," + politics + "," + science);
            }
            tw.Close();
        }
    }
    private void DeviantToCSV()
    {
        if (CharGenerator.Instance.listOfCharacters.Count > 0)
        {
            List<DeviantTemplate> charList = new();
            foreach (CharTemplate ctemp in CharGenerator.Instance.listOfCharacters)
            {
                DeviantTemplate chartemp = (DeviantTemplate)ctemp;
                charList.Add(chartemp);
            }

            TextWriter tw = new StreamWriter(filename, false);
            tw.WriteLine("Name, Gender, Age, Form, Origin, Clade, Concept, City, Strength, Dexterity, Stamina, Presence, Manipulation, Composure, " +
                "Intelligence, Wits, Resolve, Potency, Willpower, Humanity, Size, Initiative, Speed, Defence, Health, Athletics, Brawl, Drive, Firearm, Larceny, Stealth, " +
                "Survival, Weaponry, Animal Ken, Empathy, Expression, Intimidation, Persuasion, Socialise, Streetwise, Subterfuge, Academics, Computer, Crafts, Investigation, " +
                "Medicine, Occult, Politics, Science, Prime, Forces, Fate, Time, Mind, Space, Spirit, Life, Death, Matter");
            tw.Close();
            tw = new StreamWriter(filename, true);
            foreach (DeviantTemplate cTemp in charList)
            {
                string cName = cTemp.GetName();
                string gender = cTemp.GetGender();
                string age = cTemp.age.ToString();
                string form = cTemp.GetForm().ToString();
                string origin = cTemp.GetOrigin().ToString();
                string clade = cTemp.GetClade().ToString();
                string concept = cTemp.GetConcept();
                string city = cityName.text;
                string strength = cTemp.strength.GetStatValue().ToString();
                string dexterity = cTemp.dexterity.GetStatValue().ToString();
                string stamina = cTemp.stamina.GetStatValue().ToString();
                string presence = cTemp.presence.GetStatValue().ToString();
                string manipulation = cTemp.manipulation.GetStatValue().ToString();
                string composure = cTemp.composure.GetStatValue().ToString();
                string intelligence = cTemp.intelligence.GetStatValue().ToString();
                string wits = cTemp.wits.GetStatValue().ToString();
                string resolve = cTemp.resolve.GetStatValue().ToString();
                string potency = cTemp.GetPotency().ToString();
                string willpower = cTemp.willpower.ToString();
                string humanity = cTemp.integrity.ToString();
                string size = cTemp.size.ToString();
                string initiative = cTemp.initiative.ToString();
                string speed = cTemp.speed.ToString();
                string defence = cTemp.defence.ToString();
                string health = cTemp.health.ToString();
                string athletics = cTemp.athletics.GetStatValue().ToString();
                string brawl = cTemp.brawl.GetStatValue().ToString();
                string drive = cTemp.drive.GetStatValue().ToString();
                string firearm = cTemp.firearms.GetStatValue().ToString();
                string larceny = cTemp.larceny.GetStatValue().ToString();
                string stealth = cTemp.stealth.GetStatValue().ToString();
                string survival = cTemp.survival.GetStatValue().ToString();
                string weaponry = cTemp.weaponry.GetStatValue().ToString();
                string animalKen = cTemp.animalKen.GetStatValue().ToString();
                string empathy = cTemp.empathy.GetStatValue().ToString();
                string expression = cTemp.expression.GetStatValue().ToString();
                string intimidation = cTemp.intimidation.GetStatValue().ToString();
                string persuasion = cTemp.persuasion.GetStatValue().ToString();
                string socialise = cTemp.socialise.GetStatValue().ToString();
                string streetwise = cTemp.streetwise.GetStatValue().ToString();
                string subterfuge = cTemp.subterfuge.GetStatValue().ToString();
                string academics = cTemp.academics.GetStatValue().ToString();
                string computer = cTemp.computer.GetStatValue().ToString();
                string crafts = cTemp.crafts.GetStatValue().ToString();
                string investigation = cTemp.investigation.GetStatValue().ToString();
                string medicine = cTemp.medicine.GetStatValue().ToString();
                string occult = cTemp.occult.GetStatValue().ToString();
                string politics = cTemp.politics.GetStatValue().ToString();
                string science = cTemp.science.GetStatValue().ToString();

                tw.WriteLine(cName + "," + gender + "," + age + "," + form + "," + origin + "," + clade + "," + concept + "," + city + ","
                    + strength + "," + dexterity + "," + stamina + "," + presence + "," + manipulation + "," + composure + "," + intelligence + "," + wits + "," + resolve + ","
                    + potency + "," + willpower + "," + humanity + "," + size + "," + initiative + "," + speed + "," + defence + "," + health + ","
                    + athletics + "," + brawl + "," + drive + "," + firearm + "," + larceny + "," + stealth + "," + survival + "," + weaponry + "," + animalKen + "," + empathy + ","
                    + expression + "," + intimidation + "," + persuasion + "," + socialise + "," + streetwise + "," + subterfuge + "," + academics + "," + computer + ","
                    + crafts + "," + investigation + "," + medicine + "," + occult + "," + politics + "," + science);
            }
            tw.Close();
        }
    }
    private void HunterToCSV()
    {
        if (CharGenerator.Instance.listOfCharacters.Count > 0)
        {
            List<HunterTemplate> charList = new();
            foreach (CharTemplate ctemp in CharGenerator.Instance.listOfCharacters)
            {
                HunterTemplate chartemp = (HunterTemplate)ctemp;
                charList.Add(chartemp);
            }

            TextWriter tw = new StreamWriter(filename, false);
            tw.WriteLine("Name, Gender, Age, Compact, Conspiracy, Virtue, Vice, Concept, City, Strength, Dexterity, Stamina, Presence, Manipulation, Composure, " +
                "Intelligence, Wits, Resolve, Potency, Willpower, Humanity, Size, Initiative, Speed, Defence, Health, Athletics, Brawl, Drive, Firearm, Larceny, Stealth, " +
                "Survival, Weaponry, Animal Ken, Empathy, Expression, Intimidation, Persuasion, Socialise, Streetwise, Subterfuge, Academics, Computer, Crafts, Investigation, " +
                "Medicine, Occult, Politics, Science, Prime, Forces, Fate, Time, Mind, Space, Spirit, Life, Death, Matter");
            tw.Close();
            tw = new StreamWriter(filename, true);
            foreach (HunterTemplate cTemp in charList)
            {
                string cName = cTemp.GetName();
                string gender = cTemp.GetGender();
                string age = cTemp.age.ToString();
                string compact = cTemp.GetCompact().ToString();
                string conspiracy = cTemp.GetConspiracy().ToString();
                string virtue = cTemp.GetVirtue().ToString();
                string vice = cTemp.GetVice().ToString();
                string concept = cTemp.GetConcept();
                string city = cityName.text;
                string strength = cTemp.strength.GetStatValue().ToString();
                string dexterity = cTemp.dexterity.GetStatValue().ToString();
                string stamina = cTemp.stamina.GetStatValue().ToString();
                string presence = cTemp.presence.GetStatValue().ToString();
                string manipulation = cTemp.manipulation.GetStatValue().ToString();
                string composure = cTemp.composure.GetStatValue().ToString();
                string intelligence = cTemp.intelligence.GetStatValue().ToString();
                string wits = cTemp.wits.GetStatValue().ToString();
                string resolve = cTemp.resolve.GetStatValue().ToString();
                string potency = cTemp.GetPotency().ToString();
                string willpower = cTemp.willpower.ToString();
                string humanity = cTemp.integrity.ToString();
                string size = cTemp.size.ToString();
                string initiative = cTemp.initiative.ToString();
                string speed = cTemp.speed.ToString();
                string defence = cTemp.defence.ToString();
                string health = cTemp.health.ToString();
                string athletics = cTemp.athletics.GetStatValue().ToString();
                string brawl = cTemp.brawl.GetStatValue().ToString();
                string drive = cTemp.drive.GetStatValue().ToString();
                string firearm = cTemp.firearms.GetStatValue().ToString();
                string larceny = cTemp.larceny.GetStatValue().ToString();
                string stealth = cTemp.stealth.GetStatValue().ToString();
                string survival = cTemp.survival.GetStatValue().ToString();
                string weaponry = cTemp.weaponry.GetStatValue().ToString();
                string animalKen = cTemp.animalKen.GetStatValue().ToString();
                string empathy = cTemp.empathy.GetStatValue().ToString();
                string expression = cTemp.expression.GetStatValue().ToString();
                string intimidation = cTemp.intimidation.GetStatValue().ToString();
                string persuasion = cTemp.persuasion.GetStatValue().ToString();
                string socialise = cTemp.socialise.GetStatValue().ToString();
                string streetwise = cTemp.streetwise.GetStatValue().ToString();
                string subterfuge = cTemp.subterfuge.GetStatValue().ToString();
                string academics = cTemp.academics.GetStatValue().ToString();
                string computer = cTemp.computer.GetStatValue().ToString();
                string crafts = cTemp.crafts.GetStatValue().ToString();
                string investigation = cTemp.investigation.GetStatValue().ToString();
                string medicine = cTemp.medicine.GetStatValue().ToString();
                string occult = cTemp.occult.GetStatValue().ToString();
                string politics = cTemp.politics.GetStatValue().ToString();
                string science = cTemp.science.GetStatValue().ToString();

                tw.WriteLine(cName + "," + gender + "," + age + "," + compact + "," + conspiracy + "," + virtue + "," + vice + "," + concept + "," + city + ","
                    + strength + "," + dexterity + "," + stamina + "," + presence + "," + manipulation + "," + composure + "," + intelligence + "," + wits + "," + resolve + ","
                    + potency + "," + willpower + "," + humanity + "," + size + "," + initiative + "," + speed + "," + defence + "," + health + ","
                    + athletics + "," + brawl + "," + drive + "," + firearm + "," + larceny + "," + stealth + "," + survival + "," + weaponry + "," + animalKen + "," + empathy + ","
                    + expression + "," + intimidation + "," + persuasion + "," + socialise + "," + streetwise + "," + subterfuge + "," + academics + "," + computer + ","
                    + crafts + "," + investigation + "," + medicine + "," + occult + "," + politics + "," + science);
            }
            tw.Close();
        }
    }
    private void MortalToCSV()
    {
        if (CharGenerator.Instance.listOfCharacters.Count > 0)
        {
            List<CharTemplate> charList = new();
            foreach (CharTemplate ctemp in CharGenerator.Instance.listOfCharacters)
            {
                CharTemplate chartemp = (CharTemplate)ctemp;
                charList.Add(chartemp);
            }

            TextWriter tw = new StreamWriter(filename, false);
            tw.WriteLine("Name, Gender, Age, Faction, Group, Virtue, Vice, Concept, City, Strength, Dexterity, Stamina, Presence, Manipulation, Composure, " +
                "Intelligence, Wits, Resolve, Potency, Willpower, Humanity, Size, Initiative, Speed, Defence, Health, Athletics, Brawl, Drive, Firearm, Larceny, Stealth, " +
                "Survival, Weaponry, Animal Ken, Empathy, Expression, Intimidation, Persuasion, Socialise, Streetwise, Subterfuge, Academics, Computer, Crafts, Investigation, " +
                "Medicine, Occult, Politics, Science, Prime, Forces, Fate, Time, Mind, Space, Spirit, Life, Death, Matter");
            tw.Close();
            tw = new StreamWriter(filename, true);
            foreach (CharTemplate cTemp in charList)
            {
                string cName = cTemp.GetName();
                string gender = cTemp.GetGender();
                string age = cTemp.age.ToString();
                string faction = cTemp.GetFaction().ToString();
                string group = cTemp.GetGroup().ToString();
                string virtue = cTemp.GetVirtue().ToString();
                string vice = cTemp.GetVice().ToString();
                string concept = cTemp.GetConcept();
                string city = cityName.text;
                string strength = cTemp.strength.GetStatValue().ToString();
                string dexterity = cTemp.dexterity.GetStatValue().ToString();
                string stamina = cTemp.stamina.GetStatValue().ToString();
                string presence = cTemp.presence.GetStatValue().ToString();
                string manipulation = cTemp.manipulation.GetStatValue().ToString();
                string composure = cTemp.composure.GetStatValue().ToString();
                string intelligence = cTemp.intelligence.GetStatValue().ToString();
                string wits = cTemp.wits.GetStatValue().ToString();
                string resolve = cTemp.resolve.GetStatValue().ToString();
                string potency = cTemp.GetPotency().ToString();
                string willpower = cTemp.willpower.ToString();
                string humanity = cTemp.integrity.ToString();
                string size = cTemp.size.ToString();
                string initiative = cTemp.initiative.ToString();
                string speed = cTemp.speed.ToString();
                string defence = cTemp.defence.ToString();
                string health = cTemp.health.ToString();
                string athletics = cTemp.athletics.GetStatValue().ToString();
                string brawl = cTemp.brawl.GetStatValue().ToString();
                string drive = cTemp.drive.GetStatValue().ToString();
                string firearm = cTemp.firearms.GetStatValue().ToString();
                string larceny = cTemp.larceny.GetStatValue().ToString();
                string stealth = cTemp.stealth.GetStatValue().ToString();
                string survival = cTemp.survival.GetStatValue().ToString();
                string weaponry = cTemp.weaponry.GetStatValue().ToString();
                string animalKen = cTemp.animalKen.GetStatValue().ToString();
                string empathy = cTemp.empathy.GetStatValue().ToString();
                string expression = cTemp.expression.GetStatValue().ToString();
                string intimidation = cTemp.intimidation.GetStatValue().ToString();
                string persuasion = cTemp.persuasion.GetStatValue().ToString();
                string socialise = cTemp.socialise.GetStatValue().ToString();
                string streetwise = cTemp.streetwise.GetStatValue().ToString();
                string subterfuge = cTemp.subterfuge.GetStatValue().ToString();
                string academics = cTemp.academics.GetStatValue().ToString();
                string computer = cTemp.computer.GetStatValue().ToString();
                string crafts = cTemp.crafts.GetStatValue().ToString();
                string investigation = cTemp.investigation.GetStatValue().ToString();
                string medicine = cTemp.medicine.GetStatValue().ToString();
                string occult = cTemp.occult.GetStatValue().ToString();
                string politics = cTemp.politics.GetStatValue().ToString();
                string science = cTemp.science.GetStatValue().ToString();

                tw.WriteLine(cName + "," + gender + "," + age + "," + faction + "," + group + "," + virtue + "," + vice + "," + concept + "," + city + ","
                    + strength + "," + dexterity + "," + stamina + "," + presence + "," + manipulation + "," + composure + "," + intelligence + "," + wits + "," + resolve + ","
                    + potency + "," + willpower + "," + humanity + "," + size + "," + initiative + "," + speed + "," + defence + "," + health + ","
                    + athletics + "," + brawl + "," + drive + "," + firearm + "," + larceny + "," + stealth + "," + survival + "," + weaponry + "," + animalKen + "," + empathy + ","
                    + expression + "," + intimidation + "," + persuasion + "," + socialise + "," + streetwise + "," + subterfuge + "," + academics + "," + computer + ","
                    + crafts + "," + investigation + "," + medicine + "," + occult + "," + politics + "," + science);
            }
            tw.Close();
        }
    }
    #endregion

}