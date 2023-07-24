using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ACityVampire : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI vName;
    [SerializeField] private TextMeshProUGUI sex;
    [SerializeField] private TextMeshProUGUI rank;
    [SerializeField] private TextMeshProUGUI embrace;
    [SerializeField] private TextMeshProUGUI age;
    [SerializeField] private TextMeshProUGUI clan;
    [SerializeField] private TextMeshProUGUI sire;
    [SerializeField] private TextMeshProUGUI str;
    [SerializeField] private TextMeshProUGUI dex;
    [SerializeField] private TextMeshProUGUI sta;
    [SerializeField] private TextMeshProUGUI cha;
    [SerializeField] private TextMeshProUGUI man;
    [SerializeField] private TextMeshProUGUI app;
    [SerializeField] private TextMeshProUGUI per;
    [SerializeField] private TextMeshProUGUI intel;
    [SerializeField] private TextMeshProUGUI wit;
    [SerializeField] private TextMeshProUGUI generation;
    [SerializeField] private TextMeshProUGUI willpower;
    [SerializeField] private TextMeshProUGUI humanity;
    [SerializeField] private TextMeshProUGUI potence;
    [SerializeField] private TextMeshProUGUI celerity;
    [SerializeField] private TextMeshProUGUI fortitude;





    //Potence, Celerity, Fortitude, Animalism, Auspex, Dominate, Presence, Obfuscate, Protean, Dementation, Obtenebration, Quietus, Chimerstry, Serpentis, Vicissitude, Thaumaturgy, Necromancy, Ogham, Spiritus, Daimonion, Bardo, Flight, Visceratika, Melpominee, Mytherceria, Temporis, Obeah, Paths
    public void CreateCityVampire(string vampName, string gender, string vRank, int embraceDate, int vAge, string clanName, string sireName, 
        int strength, int dexterity, int stamina, int charisma, int manip, int appearance, int perception, int intelligence, int wits,
        string gen, int willpow, int human, int pot, int cel, int fort)
    {
        vName.text = vampName;
        sex.text = gender;
        rank.text = vRank;
        embrace.text = embraceDate.ToString();
        age.text = vAge.ToString();
        clan.text = clanName;
        sire.text = sireName;
        str.text = strength.ToString();
        dex.text = dexterity.ToString();
        sta.text = stamina.ToString();
        cha.text = charisma.ToString();
        man.text = manip.ToString();
        app.text = appearance.ToString();
        per.text = perception.ToString();
        intel.text = intelligence.ToString();
        wit.text = wits.ToString();
        generation.text = gen;
        willpower.text = willpow.ToString();
        humanity.text = human.ToString();
        potence.text = pot.ToString();
        celerity.text = cel.ToString();
        fortitude.text = fort.ToString();
    }
}
