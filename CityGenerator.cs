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
    [SerializeField] private int cityPopAsint;
    [SerializeField] private GameObject layoutGroup;
    [SerializeField] private GameObject prefab;

    string filename = "";
    public void Start()
    {

        filename = Application.dataPath + "/test.csv";
    }

    /*
    public void GenerateCity(int sect)
    {
        filename = Application.dataPath + "/" + cityName.text + ".csv";
        UIManager.Instance.citySheet.SetActive(true);
        int.TryParse(cityPopulation.text, out int result);
        cityPopAsint = result;
        if (sect == 1)
        {
            CamarillaCity();
        }
        else if (sect == 2)
        {
            SabbatCity();
        }
        else if (sect == 3)
        {
            AnarchCity();
        }
        else
        {
            IndependentCity();
        }
        foreach (VampireTemplate character in CharGenerator.Instance.listOfCharacters)
        {
            string vampGender = character.GetGender();
            string vampRank = "";
            int vampAge = character.GetAge();

            GameObject vamp = Instantiate(prefab, layoutGroup.transform);
            ACityVampire vTemp = vamp.GetComponent<ACityVampire>();
            vTemp.CreateCityVampire(character.GetName(), vampGender, vampRank, (int)character.embrace, vampAge, character.clan.clanName.ToString(), character.GetSire(), 
                character.physicalStats[0].statValue, character.physicalStats[1].statValue, character.physicalStats[2].statValue, character.socialStats[0].statValue, 
                character.socialStats[1].statValue, character.socialStats[2].statValue, character.mentalStats[0].statValue, character.mentalStats[1].statValue, 
                character.mentalStats[2].statValue, character.GetGeneration(), character.willpower, character.humanityPath,0,0,0 );
        }
        UIManager.Instance.SetVampireCity();
    }
    */
    /*
    public void ExportToCSV()
    {
        if (CharGenerator.Instance.listOfCharacters.Count > 0)
        {
            List<VampireTemplate> vampList = new List<VampireTemplate>();
            foreach (CharTemplate ctemp in CharGenerator.Instance.listOfCharacters)
            {
                VampireTemplate vtemp = (VampireTemplate)ctemp;
                vampList.Add(vtemp);
            }

            TextWriter tw = new StreamWriter(filename, false);
            tw.WriteLine("Name, Gender, Embrace, Age, Clan, Sire, City, Strength, Dexterity, Stamina, Charisma, Manipulation, Appearance, Perception, Intelligence, Wits, Generation, Willpower, Humanity, Potence, Celerity, Fortitude, Animalism, Auspex, Dominate, Presence, Obfuscate, Protean, Dementation, Obtenebration, Quietus, Chimerstry, Serpentis, Vicissitude, Thaumaturgy, Necromancy, Ogham, Spiritus, Daimonion, Bardo, Flight, Visceratika, Melpominee, Mytherceria, Temporis, Obeah, Paths");
            tw.Close();
            tw = new StreamWriter(filename, true);
            foreach (VampireTemplate vTemp in vampList)
            {
                string vName = vTemp.GetName();
                string Gender = vTemp.gender;
                string Embrace = vTemp.embrace.ToString();
                string Age = vTemp.age.ToString();
                string Clan = vTemp.clan.clanName.ToString();
                string Sire = vTemp.GetSire();
                string City = cityName.text;
                string Strength = vTemp.GetStatValue("Strength", vTemp.physicalStats);
                string Dexterity = vTemp.GetStatValue("Dexterity", vTemp.physicalStats);
                string Stamina = vTemp.GetStatValue("Stamina", vTemp.physicalStats);
                string Charisma = vTemp.GetStatValue("Charisma", vTemp.socialStats);
                string Manipulation = vTemp.GetStatValue("Manipulation", vTemp.socialStats);
                string Appearance = vTemp.GetStatValue("Appearance", vTemp.socialStats);
                string Perception = vTemp.GetStatValue("Perception", vTemp.mentalStats);
                string Intelligence = vTemp.GetStatValue("Intelligence", vTemp.mentalStats);
                string Wits = vTemp.GetStatValue("Wits", vTemp.mentalStats);
                string Generation = vTemp.GetGeneration();
                string Willpower = vTemp.willpower.ToString();
                string Humanity = vTemp.humanityPath.ToString();
                string Potence = vTemp.GetStatValue("Potence", vTemp.disciplines);
                string Celerity = vTemp.GetStatValue("Celerity", vTemp.disciplines);
                string Fortitude = vTemp.GetStatValue("Fortitude", vTemp.disciplines);
                string Animalism = vTemp.GetStatValue("Animalism", vTemp.disciplines);
                string Auspex = vTemp.GetStatValue("Auspex", vTemp.disciplines);
                string Dominate = vTemp.GetStatValue("Dominate", vTemp.disciplines);
                string Presence = vTemp.GetStatValue("Presence", vTemp.disciplines);
                string Obfuscate = vTemp.GetStatValue("Obfuscate", vTemp.disciplines);
                string Protean = vTemp.GetStatValue("Protean", vTemp.disciplines);
                string Dementation = vTemp.GetStatValue("Dementation", vTemp.disciplines);
                string Obtenebration = vTemp.GetStatValue("Obtenebration", vTemp.disciplines);
                string Quietus = vTemp.GetStatValue("Quietus", vTemp.disciplines);
                string Chimerstry = vTemp.GetStatValue("Chimerstry", vTemp.disciplines);
                string Serpentis = vTemp.GetStatValue("Serpentis", vTemp.disciplines);
                string Vicissitude = vTemp.GetStatValue("Vicissitude", vTemp.disciplines);
                string Thaumaturgy = vTemp.GetStatValue("Thaumaturgy", vTemp.disciplines);
                string Necromancy = vTemp.GetStatValue("Necromancy", vTemp.disciplines);
                string Ogham = vTemp.GetStatValue("Ogham", vTemp.disciplines);
                string Spiritus = vTemp.GetStatValue("Spiritus", vTemp.disciplines);
                string Daimonion = vTemp.GetStatValue("Daimonion", vTemp.disciplines);
                string Bardo = vTemp.GetStatValue("Bardo", vTemp.disciplines);
                string Flight = vTemp.GetStatValue("Flight", vTemp.disciplines);
                string Visceratika = vTemp.GetStatValue("Visceratika", vTemp.disciplines);
                string Melpominee = vTemp.GetStatValue("Melpominee", vTemp.disciplines);
                string Mytherceria = vTemp.GetStatValue("Mytherceria", vTemp.disciplines);
                string Temporis = vTemp.GetStatValue("Temporis", vTemp.disciplines);
                string Obeah = vTemp.GetStatValue("Obeah", vTemp.disciplines);


                tw.WriteLine(vName + "," + Gender + "," + Embrace + "," + Age + "," + Clan + "," + Sire + "," + City + "," + Strength + "," + Dexterity + "," + Stamina + "," + Charisma + "," + Manipulation + "," + Appearance + "," + Perception + "," + Intelligence + "," + Wits + "," + Generation + "," + Willpower + "," + Humanity + "," + Potence + "," + Celerity + "," + Fortitude + "," + Animalism + "," + Auspex + "," + Dominate + "," + Presence + "," + Obfuscate + "," + Protean + "," + Dementation + "," + Obtenebration + "," + Quietus + "," + Chimerstry + "," + Serpentis + "," + Vicissitude + "," + Thaumaturgy + "," + Necromancy + "," + Ogham + "," + Spiritus + "," + Daimonion + "," + Bardo + "," + Flight + "," + Visceratika + "," + Melpominee + "," + Mytherceria + "," + Temporis + "," + Obeah);

            }
            tw.Close();
        }
    }*/

    public void CamarillaCity()
    {
        CharGenerator.Instance.ClearAllCharacters();
        int numberOfVamps;
        Nation nation = Nationality.Instance.GetNation();
        if (nation == Nation.NorthAmerica || nation == Nation.EuropeEngland || nation == Nation.EuropeScotland || nation == Nation.EuropeWales || nation == Nation.EuropeFrance
            || nation == Nation.EuropePortugal || nation == Nation.EuropeSpain || nation == Nation.EuropeIreland || nation == Nation.EuropeScandanavia || nation == Nation.AsiaWest)
        {
            numberOfVamps = cityPopAsint / Random.Range(40000, 60000);
        }
        else
        {
            numberOfVamps = cityPopAsint / Random.Range(60000, 100000);
        }


        for (int i= 0; i < numberOfVamps; i++)
        {
            int rand = Random.Range(1, 21);
            if (rand == 1)
            {
                CharGenerator.Instance.GenerateRandomVampire(4);
            }
            else
            {
                CharGenerator.Instance.GenerateRandomVampire(1);
            }
        }
    }
    public void SabbatCity()
    {
        CharGenerator.Instance.ClearAllCharacters();
        int numberOfVamps;
        Nation nation = Nationality.Instance.GetNation();
        if (nation == Nation.NorthAmerica)
        {
            numberOfVamps = cityPopAsint / Random.Range(10000, 40000); ;
        }
        else
        {
            numberOfVamps = cityPopAsint / Random.Range(40000, 80000);
        }

        for (int i = 0; i < numberOfVamps; i++)
        {
            int rand = Random.Range(1, 21);
            if (rand == 1)
            {
                CharGenerator.Instance.GenerateRandomVampire(4);
            }
            else
            {
                CharGenerator.Instance.GenerateRandomVampire(2);
            }
        }
    }
    public void AnarchCity()
    {
        CharGenerator.Instance.ClearAllCharacters();
        int numberOfVamps;
        Nation nation = Nationality.Instance.GetNation();
        if (nation == Nation.NorthAmerica)
        {
            numberOfVamps = cityPopAsint / Random.Range(30000, 60000);
        }
        else
        {
            numberOfVamps = cityPopAsint / Random.Range(60000, 80000);
        }

        for (int i = 0; i < numberOfVamps; i++)
        {
            int rand = Random.Range(1, 21);
            if (rand == 1)
            {
                CharGenerator.Instance.GenerateRandomVampire(4);
            }
            else
            {
                CharGenerator.Instance.GenerateRandomVampire(3);
            }
        }
    }
    public void IndependentCity()
    {
        CharGenerator.Instance.ClearAllCharacters();
        int numberOfVamps = cityPopAsint / Random.Range(60000, 80000);
        for (int i = 0; i < numberOfVamps; i++)
        {
            CharGenerator.Instance.GenerateRandomVampire(4);
        }
    }
}
