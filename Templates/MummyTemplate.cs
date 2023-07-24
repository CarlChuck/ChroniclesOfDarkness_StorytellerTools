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
        base.CreateCharacter();



        UIManager.Instance.UpdateGeneralUI(TemplateType.Mummy);
    }

    public void AddMummyTraits(int orderNum = 0)
    {

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