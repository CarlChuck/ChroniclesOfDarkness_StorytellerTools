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
        int rand = Random.Range(1, 6);
        legend = rand switch
        {
            1 => "Relentless",
            2 => "Seductive",
            3 => "Unexpected",
            4 => "Vicious",
            5 => "Watchful",
            _ => ""
        };
    }
    public void SetLife()
    {
        int rand = Random.Range(1, 6);
        life = rand switch
        {
            1 => "Cautious",
            2 => "Honest",
            3 => "Loyal",
            4 => "Parental",
            5 => "Shy",
            _ => ""
        };
    }
    public void SetFamily(int famNum)
    {
        family = famNum switch
        {
            1 => Family.Anakim,
            2 => Family.Eshmaki,
            3 => Family.Makara,
            4 => Family.Namtaru,
            5 => Family.Ugallu,
            _ => Family.Anakim
        };
    }
    public void SetHunger()
    {
        int rand = Random.Range(1, 6);
        hunger = rand switch
        {
            1 => Hunger.Prey,
            2 => Hunger.Hoard,
            3 => Hunger.Power,
            4 => Hunger.Punishment,
            5 => Hunger.Ruin,
            _ => Hunger.Prey
        };
    }
    public void SetHorror()
    {
        horror = ""; //TODO
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