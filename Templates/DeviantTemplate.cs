using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviantTemplate : CharTemplate
{
    private Clade clade;
    private Origin origin;
    private string form;
    public override void CreateCharacter()
    {
        SetRandomPriority();
        base.CreateCharacter();
        SetName();
        SetPotency();
        AddPotency();
        AddExperience();
        UpdateCharacter();
        GenerateConcept();
        UIManager.Instance.UpdateGeneralUI(TemplateType.Deviant);
    }

    public void AddDeviantTraits(int cladeNum = 0)
    {
        SetClade(cladeNum);
        SetOrigin();
        SetForm();
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
    public void SetClade(int cladeNum)
    {
        clade = cladeNum switch
        {
            1 => Clade.Cephalist,
            2 => Clade.Chimeric,
            3 => Clade.Coactive,
            4 => Clade.Invasive,
            5 => Clade.Mutant,
            _ => Clade.Cephalist
        };
    }
    public void SetOrigin()
    {
        int rand = Random.Range(1, 6);
        origin = rand switch
        {
            1 => Origin.Autourgies,
            2 => Origin.Epimorph,
            3 => Origin.Exomorph,
            4 => Origin.Genotypal,
            5 => Origin.Pathological,
            _ => Origin.Autourgies
        };
    }
    public void SetForm()
    {
        form = "";
    }
    #endregion
    #region Getters
    public Clade GetClade()
    {
        return clade;
    }
    public Origin GetOrigin()
    {
        return origin;
    }
    public string GetForm()
    {
        return form;
    }
    #endregion
}
public enum Origin { Autourgies, Epimorph, Exomorph, Genotypal, Pathological }
public enum Clade { Cephalist, Chimeric, Coactive, Invasive, Mutant }