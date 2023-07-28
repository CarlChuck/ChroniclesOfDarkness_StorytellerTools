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
    private string filename = "";

    public void Start()
    {
        filename = Application.dataPath + "/test.csv";
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
    }
    #region GeneratingCharacters
    private void GenerateVampireCity()
    {
        filename = Application.dataPath + "/" + cityName.text + "_" + tType + ".csv";
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
        for (int i= 0; i < numberOfChars; i++)
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
        filename = Application.dataPath + "/" + cityName.text + "_" + tType + ".csv";
        int.TryParse(cityPopulation.text, out int inputPopulation);

        CharGenerator.Instance.ClearAllCharacters();
        int numberOfChars;

        numberOfChars = inputPopulation / Random.Range(80000, 120000);

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
        filename = Application.dataPath + "/" + cityName.text + "_" + tType + ".csv";
        int.TryParse(cityPopulation.text, out int inputPopulation);

        CharGenerator.Instance.ClearAllCharacters();
        int numberOfChars;

        numberOfChars = inputPopulation / Random.Range(80000, 120000);

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
        filename = Application.dataPath + "/" + cityName.text + "_" + tType + ".csv";
        int.TryParse(cityPopulation.text, out int inputPopulation);

        CharGenerator.Instance.ClearAllCharacters();
        int numberOfChars;

        numberOfChars = inputPopulation / Random.Range(80000, 120000);

        //Generate the characters
        for (int i = 0; i < numberOfChars; i++)
        {
            int rand = Random.Range(1, 10);
            CharGenerator.Instance.GenerateWerewolf(rand, false);
        }
        WerewolfToCSV();
    }
    private void GenerateGeistCity()
    {
        filename = Application.dataPath + "/" + cityName.text + "_" + tType + ".csv";
        int.TryParse(cityPopulation.text, out int inputPopulation);

        CharGenerator.Instance.ClearAllCharacters();
        int numberOfChars;

        numberOfChars = inputPopulation / Random.Range(100000, 140000);

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
        filename = Application.dataPath + "/" + cityName.text + "_" + tType + ".csv";
        int.TryParse(cityPopulation.text, out int inputPopulation);

        CharGenerator.Instance.ClearAllCharacters();
        int numberOfChars;

        numberOfChars = inputPopulation / Random.Range(100000, 140000);

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
        filename = Application.dataPath + "/" + cityName.text + "_" + tType + ".csv";
        int.TryParse(cityPopulation.text, out int inputPopulation);

        CharGenerator.Instance.ClearAllCharacters();
        int numberOfChars;

        numberOfChars = inputPopulation / Random.Range(200000, 300000);

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
        filename = Application.dataPath + "/" + cityName.text + "_" + tType + ".csv";
        int.TryParse(cityPopulation.text, out int inputPopulation);

        CharGenerator.Instance.ClearAllCharacters();
        int numberOfChars;

        numberOfChars = inputPopulation / Random.Range(200000, 300000);

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
        filename = Application.dataPath + "/" + cityName.text + "_" + tType + ".csv";
        int.TryParse(cityPopulation.text, out int inputPopulation);

        CharGenerator.Instance.ClearAllCharacters();
        int numberOfChars;

        numberOfChars = inputPopulation / Random.Range(200000, 300000);

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
        filename = Application.dataPath + "/" + cityName.text + "_" + tType + ".csv";
        int.TryParse(cityPopulation.text, out int inputPopulation);

        CharGenerator.Instance.ClearAllCharacters();
        int numberOfChars;

        numberOfChars = inputPopulation / Random.Range(200000, 300000);

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
        filename = Application.dataPath + "/" + cityName.text + "_" + tType + ".csv";
        int.TryParse(cityPopulation.text, out int inputPopulation);

        CharGenerator.Instance.ClearAllCharacters();
        int numberOfChars;

        numberOfChars = inputPopulation / Random.Range(100000, 140000);

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
        filename = Application.dataPath + "/" + cityName.text + "_" + tType + ".csv";
        int.TryParse(cityPopulation.text, out int inputPopulation);

        CharGenerator.Instance.ClearAllCharacters();
        int numberOfChars;

        numberOfChars = inputPopulation / Random.Range(80000, 120000);

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
            tw.WriteLine("Name, Gender, Embrace, Age, Clan, Bloodline, Covenant, Mask, Dirge, City, Strength, Dexterity, Stamina, Presence, Manipulation, Composure, " +
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

                tw.WriteLine(vName + "," + gender + "," + embrace + "," + age + "," + clan + "," + bloodline + "," + covenant + "," + mask + "," + dirge + "," + city + ","
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

    }
    private void WerewolfToCSV()
    {

    }
    private void ChangelingToCSV()
    {

    }
    private void GeistToCSV()
    {

    }
    private void DemonToCSV()
    {

    }
    private void PrometheanToCSV()
    {

    }
    private void MummyToCSV()
    {

    }
    private void BeastToCSV()
    {

    }
    private void DeviantToCSV()
    {

    }
    private void HunterToCSV()
    {

    }
    private void MortalToCSV()
    {

    }
    #endregion
}
