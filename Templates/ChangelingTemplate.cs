using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangelingTemplate : CharTemplate
{
    private string needle;
    private string thread;
    private Seeming seeming;
    private Kith kith;
    private Court court;

    public override void CreateCharacter()
    {
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
        //TODO
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
    public Kith GetKith()
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
public enum Kith { }
public enum Court { Spring, Summer, Autumn, Winter }