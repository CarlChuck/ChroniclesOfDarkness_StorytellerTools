using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WerewolfTemplate : CharTemplate
{
    private Auspice auspice;
    private Tribe tribe;
    private Lodge lodge;
    private string blood;
    private string bone;

    public override void CreateCharacter()
    {
        base.CreateCharacter();



        UIManager.Instance.UpdateGeneralUI(TemplateType.Werewolf);
    }

    public void AddWerewolfTraits(int orderNum = 0)
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
    public Auspice GetAuspice()
    {
        return auspice;
    }
    public Tribe GetTribe()
    {
        return tribe;
    }
    public Lodge GetLodge()
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
public enum Auspice { }
public enum Tribe { }
public enum Lodge { }