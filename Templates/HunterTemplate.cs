using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterTemplate : CharTemplate
{
    private string cell;
    private Compact compact;
    private Conspiracy conspiracy;
    public override void CreateCharacter()
    {
        base.CreateCharacter();



        UIManager.Instance.UpdateGeneralUI(TemplateType.Hunter);
    }

    public void AddHunterTraits(int orderNum = 0, bool isWoD = false)
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

    public string GetCell()
    {
        return cell;
    }
    public Compact GetCompact()
    {
        return compact;
    }
    public Conspiracy GetConspiracy()
    {
        return conspiracy;
    }


    #endregion
}
public enum Compact { None }
public enum Conspiracy { None }