using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangelingTemplate : CharTemplate
{
    private string needle;
    private string thread;
    private Seeming seeming;
    private string kith;
    private Court court;

    public override void CreateCharacter()
    {
        SetRandomPriority();
        base.CreateCharacter();
        SetNeedle();
        SetThread();
        SetName();
        SetWyrd();
        GenerateChangelingContracts();
        AddExperience();
        UpdateCharacter();
        GenerateConcept();
        UIManager.Instance.UpdateGeneralUI(TemplateType.Changeling);
    }

    public void AddChangelingTraits(int orderNum = 0)
    {
        SetCourt(orderNum);
        SetSeeming();
        SetKith();
    }

    #region Merits and Experience
    public override void AddExperience()
    {
        base.AddExperience();
    }
    public override void AddMerit()
    {
        base.AddMerit();
    }
    #endregion
    #region Update
    public override void UpdateCharacter()
    {
        base.UpdateCharacter();
    }
    #endregion
    #region Setters
    public override void SetName(string inputName = "")
    {
        base.SetName(inputName);
    }
    public override void SetAge()
    {
        int rand = Random.Range(1, 101);
        if (rand < 50)
        {
            age = Random.Range(16, 30);
        }
        else if (rand < 80)
        {
            age = Random.Range(20, 40);
        }
        else
        {
            age = Random.Range(30, 50);
        }
    }
    public override void GenerateConcept()
    {
        base.GenerateConcept();
    }
    private void SetWyrd()
    {
        int pot = 1;
        int wyrdAge = age - 15;
        if (wyrdAge > 5)
        {
            pot += AddChanceOfWyrdIncrease();
        }
        if (wyrdAge > 10)
        {
            pot += AddChanceOfWyrdIncrease();
        }
        if (wyrdAge > 15)
        {
            pot += AddChanceOfWyrdIncrease();
        }
        if (wyrdAge > 20)
        {
            pot += AddChanceOfWyrdIncrease();
        }
        if (wyrdAge > 25)
        {
            pot += AddChanceOfWyrdIncrease();
        }
        if (wyrdAge > 30)
        {
            pot += AddChanceOfWyrdIncrease();
        }
        if (wyrdAge > 35)
        {
            pot += AddChanceOfWyrdIncrease();
        }
        if (wyrdAge > 40)
        {
            pot += AddChanceOfWyrdIncrease();
        }
        SetPotency(pot);
    }
    private int AddChanceOfWyrdIncrease()
    {
        int rand = Random.Range(1, 3);
        if (rand == 1)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }
    private void SetNeedle()
    {
        int rand = Random.Range(1, 15);
        needle = rand switch
        {
            1 => "Bon Vivant",
            2 => "Chess Master",
            3 => "Commander",
            4 => "Composer",
            5 => "Counsellor",
            6 => "Daredevil",
            7 => "Dynamo",
            8 => "Protector",
            9 => "Provider",
            10 => "Scholar",
            11 => "Storyteller",
            12 => "Teacher",
            13 => "Traditionalist",
            14 => "Visionary",
            _ => "Bon Vivant"
        };
    }
    private void SetThread()
    {
        int rand = Random.Range(1, 11);
        thread = rand switch
        {
            1 => "Acceptance",
            2 => "Anger",
            3 => "Family",
            4 => "Friendship",
            5 => "Hate",
            6 => "Honour",
            7 => "Joy",
            8 => "Love",
            9 => "Memory",
            10 => "Revenge",
            _ => "Revenge"
        };
    }
    private void SetSeeming()
    {
        int rand = Random.Range(1, 7);
        seeming = rand switch
        {
            1 => Seeming.Beast,
            2 => Seeming.Darkling,
            3 => Seeming.Elemental,
            4 => Seeming.Fairest,
            5 => Seeming.Ogre,
            6 => Seeming.Wizened,
            _ => Seeming.Wizened
        };
    }
    private void SetKith()
    {
        kith = seeming switch
        {
            Seeming.Beast => SetKithBeast(),
            Seeming.Darkling => SetKithDarkling(),
            Seeming.Elemental => SetKithElemental(),
            Seeming.Fairest => SetKithFairest(),
            Seeming.Ogre => SetKithOgre(),
            Seeming.Wizened => SetKithWizened(),
            _ => ""
        };
    }
    private string SetKithBeast()
    {
        int rand = Random.Range(1, 25);
        string toSend = rand switch
        {
            1 => "Gristlegrinder",
            2 => "Helldiver",
            3 => "Hunterheart",
            4 => "Playmate",
            5 => "Climacteric",
            6 => "Concubus",
            7 => "Uttervoice",
            8 => "Polychromatic",
            9 => "Cloakskin",
            10 => "Lullsecent",
            11 => "Riddleseeker",
            12 => "Librorum",
            13 => "Reborn",
            14 => "Stoneflesh",
            15 => "Airtouched",
            16 => "Farwalker",
            17 => "Flickerflash",
            18 => "Swarmflight",
            19 => "Swimmerskin",
            20 => "Beastcaller",
            21 => "Cyclopean",
            22 => "Sandharrowed",
            23 => "Valkyrie",
            24 => "Gravewright",
            _ => "Gravewright"
        };

        return toSend;
    }
    private string SetKithDarkling()
    {
        int rand = Random.Range(1, 24);
        string toSend = rand switch
        {
            1 => "Chatelaine",
            2 => "Helldiver",
            3 => "Leechfinger",
            4 => "Mirrorskin",
            5 => "Concubus",
            6 => "Ghostheart",
            7 => "Moonborn",
            8 => "Delver",
            9 => "Bricoleur",
            10 => "Cloakskin",
            11 => "Doppelganger",
            12 => "Lethipomp",
            13 => "Lullsecent",
            14 => "Riddleseeker",
            15 => "Sideromancer",
            16 => "Spiegelbild ",
            17 => "Chalomot",
            18 => "Swarmflight",
            19 => "Razorhand",
            20 => "Apoptsome",
            21 => "Becquerel",
            22 => "Whisperwisp",
            23 => "Cleverquick",
            _ => "Cleverquick"
        };
        return toSend;
    }
    private string SetKithElemental()
    {
        int rand = Random.Range(1, 28);
        string toSend = rand switch
        {
            1 => "Bright One",
            2 => "Mirrorskin",
            3 => "Notary",
            4 => "Snowskin",
            5 => "Flowering",
            6 => "Uttervoice",
            7 => "Delver",
            8 => "Glimmerwisp",
            9 => "Veneficus",
            10 => "Lethipomp",
            11 => "Asclepian",
            12 => "Bridgeguard",
            13 => "Librorum",
            14 => "Liminal",
            15 => "Stoneflesh",
            16 => "Airtouched",
            17 => "Chevalier",
            18 => "Flickerflash",
            19 => "Levinquick",
            20 => "Bearskin",
            21 => "Beastcaller",
            22 => "Plaguesmith",
            23 => "Sandharrowed",
            24 => "Venombite",
            25 => "Enkrateia",
            26 => "Shadowsoul",
            27 => "Telluric",
            _ => "Telluric"
        };
        return toSend;
    }
    private string SetKithFairest()
    {
        int rand = Random.Range(1, 25);
        string toSend = rand switch
        {
            1 => "BrightOne",
            2 => "Chatelaine",
            3 => "Nightsinger",
            4 => "Playmate",
            5 => "Absinthal",
            6 => "Draconic",
            7 => "Flowering",
            8 => "Manikin",
            9 => "Oculus",
            10 => "Polychromatic",
            11 => "Witchtooth",
            12 => "Spiegelbild",
            13 => "Bridgeguard",
            14 => "Wisewitch",
            15 => "Levinquick",
            16 => "Swimmerskin",
            17 => "Plaguesmith",
            18 => "Razorhand",
            19 => "Valkyrie",
            20 => "Blightbent",
            21 => "Enkrateia",
            22 => "Shadowsoul",
            23 => "Telluric",
            24 => "Whisperwisp",
            _ => "Whisperwisp"
        };
        return toSend;
    }
    private string SetKithOgre()
    {
        int rand = Random.Range(1, 17);
        string toSend = rand switch
        {
            1 => "Artist",
            2 => "Gristlegrinder",
            3 => "Hunterheart",
            4 => "Snowskin",
            5 => "Draconic",
            6 => "Ghostheart",
            7 => "Gremlin",
            8 => "Doppelganger",
            9 => "Sideromancer",
            10 => "Liminal",
            11 => "Wisewitch",
            12 => "Farwalker",
            13 => "Cyclopean",
            14 => "Apoptsome",
            15 => "Becquerel",
            16 => "Cleverquick",
            _ => "Cleverquick"
        };
        return toSend;
    }
    private string SetKithWizened()
    {
        int rand = Random.Range(1, 23);
        string toSend = rand switch
        {
            1 => "Artist",
            2 => "Leechfinger",
            3 => "Nightsinger",
            4 => "Notary",
            5 => "Absinthal",
            6 => "Climacteric",
            7 => "Moonborn",
            8 => "Glimmerwisp",
            9 => "Gremlin",
            10 => "Manikin",
            11 => "Oculus",
            12 => "Veneficus",
            13 => "Witchtooth",
            14 => "Bricoleur",
            15 => "Asclepian",
            16 => "Reborn",
            17 => "Chalomot",
            18 => "Chevalier",
            19 => "Bearskin",
            20 => "Venombite",
            21 => "Blightbent",
            22 => "Gravewright",
            _ => "Gravewright"
        };
        return toSend;
    }
    private void SetCourt(int sect = 0)
    {
        if (sect == 0)
        {
            int rand = Random.Range(1, 5);
        }

        if (sect == 1)
        {
            court = Court.Spring;
        }
        else if (sect == 2)
        {
            court = Court.Summer;
        }
        else if (sect == 3)
        {
            court = Court.Autumn;
        }
        else
        {
            court = Court.Winter;
        }
    }
    #endregion
    #region Getters
    public string GetNeedle()
    {
        return needle;
    }
    public string GetThread()
    {
        return thread;
    }
    public Seeming GetSeeming()
    {
        return seeming;
    }
    public string GetKith()
    {
        return kith;
    }
    public Court GetCourt()
    {
        return court;
    }
    #endregion
    #region Contracts
    private void GenerateChangelingContracts()
    {
        //TODO
    }
    #endregion
}
public enum Seeming { Beast, Darkling, Elemental, Fairest, Ogre, Wizened }

public enum Court { Spring, Summer, Autumn, Winter }