using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WerewolfTemplate : CharTemplate
{
    private Auspice auspice;
    private Tribe tribe;
    private string lodge;
    private string blood;
    private string bone;

    public override void CreateCharacter()
    {
        SetPriorityByAuspice();
        base.CreateCharacter();

        SetBlood();
        SetBone();
        SetName();
        SetPrimalUrge();
        AddExperience();
        UpdateCharacter();
        GenerateConcept();

        UIManager.Instance.UpdateGeneralUI(TemplateType.Werewolf);
    }

    public void AddWerewolfTraits(int tribeNum = 0)
    {
        SetTribe(tribeNum);
        SetAuspice();
        SetLodge();
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
        base.SetAge();
    }
    public override void GenerateConcept()
    {
        base.GenerateConcept();
    }
    private void SetAuspice()
    {
        int rand = Random.Range(1, 6);
        auspice = rand switch
        {
            1 => Auspice.Cahalith,
            2 => Auspice.Elodoth,
            3 => Auspice.Irraka,
            4 => Auspice.Ithaeur,
            5 => Auspice.Rahu,
            _ => Auspice.Rahu
        };
    }
    private void SetTribe(int tribeNum)
    {
        tribe = tribeNum switch
        {
            1 => Tribe.BloodTalon,
            2 => Tribe.BoneShadows,
            3 => Tribe.HuntersInDarkness,
            4 => Tribe.IronMasters,
            5 => Tribe.StormLords,
            6 => Tribe.FireTouched,
            7 => Tribe.IvoryClaws,
            8 => Tribe.PredatorKings,
            9 => Tribe.GhostWolves,
            10 => Tribe.BaleHounds,
            _ => Tribe.BloodTalon,
        };
    }
    private void SetLodge()
    {
        lodge = "";
    }
    private void SetPrimalUrge()
    {
        int pot = 1;
        int primAge = age - 15;
        if (primAge > 5)
        {
            pot += AddChanceOfPrimalIncrease();
        }
        if (primAge > 10)
        {
            pot += AddChanceOfPrimalIncrease();
        }
        if (primAge > 15)
        {
            pot += AddChanceOfPrimalIncrease();
        }
        if (primAge > 20)
        {
            pot += AddChanceOfPrimalIncrease();
        }
        if (primAge > 30)
        {
            pot += AddChanceOfPrimalIncrease();
        }
        if (primAge > 40)
        {
            pot += AddChanceOfPrimalIncrease();
        }
        if (primAge > 50)
        {
            pot += AddChanceOfPrimalIncrease();
        }
        if (primAge > 60)
        {
            pot += AddChanceOfPrimalIncrease();
        }
        if (primAge > 70)
        {
            pot += AddChanceOfPrimalIncrease();
        }
        SetPotency(pot);
    }
    private int AddChanceOfPrimalIncrease()
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
    private void SetBlood()
    {
        int rand = Random.Range(1, 6);
        blood = rand switch
        {
            1 => "Alpha",
            2 => "Challenger",
            3 => "Destroyer",
            4 => "Fox",
            5 => "Monster",
            6 => "Soldier",
            _ => "Soldier"
        };
    }
    private void SetBone()
    {
        int rand = Random.Range(1, 6);
        bone = rand switch
        {
            1 => "Community Organiser",
            2 => "Cub",
            3 => "Guru",
            4 => "Hedonist",
            5 => "Lone Wolf",
            6 => "WallFlower",
            _ => "WallFlower"
        };
    }
    private void SetPriorityByAuspice()
    {
        if (auspice == Auspice.Rahu)
        {
            SetPhysicalPriority();
        }
        else if (auspice == Auspice.Cahalith)
        {
            SetSocialOrPhysicalPriority();
        }
        else if (auspice == Auspice.Elodoth)
        {
            SetSocialPriority();
        }
        else if (auspice == Auspice.Irraka)
        {
            SetMentalOrPhysicalPriority();
        }
        else if (auspice == Auspice.Ithaeur)
        {
            SetMentalPriority();
        }
    }
    #endregion
    #region Getters
    public Auspice GetAuspice()
    {
        return auspice;
    }
    public Tribe GetTribe()
    {
        return tribe;
    }
    public string GetLodge()
    {
        return lodge;
    }
    public string GetBlood()
    {
        return blood;
    }
    public string GetBone()
    {
        return bone;
    }
    #endregion
}
public enum Auspice { Cahalith, Elodoth, Irraka, Ithaeur, Rahu }
public enum Tribe { BloodTalon, BoneShadows, HuntersInDarkness, IronMasters, StormLords, FireTouched, IvoryClaws, PredatorKings, GhostWolves, BaleHounds}
