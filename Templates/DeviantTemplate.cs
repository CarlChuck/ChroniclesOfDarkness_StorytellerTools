using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviantTemplate : CharTemplate
{
    private Clade clade;
    private Origin origin;
    private string getForm;
    public override void CreateCharacter()
    {
        base.CreateCharacter();



        UIManager.Instance.UpdateGeneralUI(TemplateType.Deviant);
    }

    public void AddDeviantTraits(int orderNum = 0, bool isWoD = false)
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
        return getForm;
    }


    #endregion
}
public enum Origin { Autourgies, Epimorph, Exomorph, Genotypal, Pathological }
public enum Clade { Cephalist, Chimeric, Coactive, Invasive, Mutant }