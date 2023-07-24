using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrometheanTemplate : CharTemplate
{
    private string elips;
    private string torment;
    private string role;
    private Refinement refinement;
    private Lineage lineage;

    public override void CreateCharacter()
    {
        base.CreateCharacter();



        UIManager.Instance.UpdateGeneralUI(TemplateType.Promethean);
    }

    public void AddPrometheanTraits(int orderNum = 0)
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
    public string GetElips() 
    {
        return elips;
    }
    public string GetTorment() 
    {
        return torment;
    }
    public Lineage GetLineage() 
    {
        return lineage;
    }
    public Refinement GetRefinement() 
    {
        return refinement;
    }
    public string GetRole()
    {
        return role;
    }


    #endregion
}
public enum Lineage { Frankenstein, Galateid, Osiran, Tammuz, Ulgan, Unfleshed, Extempore}
public enum Refinement { Aurum, Cuprum, Ferrum, Plumbum, Stannum }