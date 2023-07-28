using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastTemplate : CharTemplate
{
    private string legend;
    private string life;
    private Family family;
    private Hunger hunger;
    private string horror;
    public override void CreateCharacter()
    {
        SetRandomPriority();
        base.CreateCharacter();
        SetLife();
        SetLegend();
        SetName();
        SetPotency();
        AddPotency();
        AddExperience();
        UpdateCharacter();
        GenerateConcept();
        UIManager.Instance.UpdateGeneralUI(TemplateType.Beast);
    }

    public void AddBeastTraits(int famNum = 0)
    {
        SetFamily(famNum);
        SetHunger();
        SetHorror();
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
    public void SetLegend()
    {

    }
    public void SetLife()
    {

    }
    public void SetFamily(int famNum)
    {

    }
    public void SetHunger()
    {

    }
    public void SetHorror()
    {

    }
    #endregion
    #region Getters
    public string GetLegend()
    {
        return legend;
    }
    public string GetLife()
    {
        return life;
    }
    public Family GetFamily()
    {
        return family;
    }
    public Hunger GetHunger()
    {
        return hunger;
    }
    public string GetHorror()
    {
        return horror;
    }


    #endregion
    
}
public enum Family { Anakim, Eshmaki, Makara, Namtaru, Ugallu }
public enum Hunger { Prey, Hoard, Power, Punishment, Ruin }