using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyTemplate : CharTemplate
{
    private string balance;
    private string burden;
    private Decree decree;
    private Guild guild;
    private Judge judge;

    public override void CreateCharacter()
    {
        SetRandomPriority();
        base.CreateCharacter();
        SetBalance();
        SetBurden();
        SetName();
        SetPotency();
        AddExperience();
        UpdateCharacter();
        GenerateConcept();
        UIManager.Instance.UpdateGeneralUI(TemplateType.Mummy);
    }

    public void AddMummyTraits(int guildNum = 0)
    {
        SetGuild(guildNum);
        SetJudge();
        SetDecree();
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
    public void SetBalance()
    {
        int rand = Random.Range(1, 14);
        balance = rand switch
        {
            1 => "Courageous",
            2 => "Devoted",
            3 => "Diligent",
            4 => "Faithful",
            5 => "Generous",
            6 => "Introspective",
            7 => "Just",
            8 => "Noble",
            9 => "Peaceful",
            10 => "Resilient",
            11 => "Righteous",
            12 => "Trustworthy",
            13 => "Truthful",
            _ => "Courageous"
        };
    }
    public void SetBurden()
    {
        int rand = Random.Range(1, 14);
        burden = rand switch
        {
            1 => "Accusing",
            2 => "Careless",
            3 => "Chaotic",
            4 => "Cruel",
            5 => "Dominant",
            6 => "Forgetful",
            7 => "Fragile",
            8 => "Hysterical",
            9 => "Isolated",
            10 => "Rageful",
            11 => "Resentful",
            12 => "Selfish",
            13 => "Stagnant",
            _ => "Accusing"
        };
    }
    public void SetDecree()
    {
        int rand = Random.Range(1, 6);
        decree = rand switch
        {
            1 => Decree.Ashem,
            2 => Decree.Deshret,
            3 => Decree.Kheru,
            4 => Decree.Nesrem,
            5 => Decree.Usheb,
            _ => Decree.Ashem
        };
    }
    public void SetGuild(int guildNum)
    {
        guild = guildNum switch
        {
            1 => Guild.MaaKep,
            2 => Guild.MesenNebu,
            3 => Guild.SheshaHebsu,
            4 => Guild.SuMenent,
            5 => Guild.TefAabhi,
            _ => Guild.MaaKep
        };
    }
    public void SetJudge()
    {
        int rand = Random.Range(1, 8);
        judge = rand switch
        {
            1 => Judge.AmKhaibit,
            2 => Judge.AremAbfu,
            3 => Judge.Kenemti,
            4 => Judge.Nebha,
            5 => Judge.NehebKa,
            6 => Judge.UnemBesek,
            7 => Judge.UsekhNemtet,
            _ => Judge.AmKhaibit
        };
    }
    #endregion
    #region Getters
    public string GetBalance()
    {
        return balance;
    }
    public string GetBurden()
    {
        return burden;
    }
    public Decree GetDecree()
    {
        return decree;
    }
    public Guild GetGuild()
    {
        return guild;
    }
    public Judge GetJudge()
    {
        return judge;
    }
    #endregion
}
public enum Decree { Ashem, Deshret, Kheru, Nesrem, Usheb }
public enum Judge { AmKhaibit, AremAbfu, Kenemti, Nebha, NehebKa, UnemBesek, UsekhNemtet }
public enum Guild { MaaKep, MesenNebu, SheshaHebsu, SuMenent, TefAabhi }