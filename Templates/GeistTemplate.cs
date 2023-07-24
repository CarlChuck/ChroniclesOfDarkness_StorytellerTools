using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeistTemplate : CharTemplate
{
    private string root;
    private string bloom;
    private string giestName;
    private string krewe;
    private Burden burden;
    private KreweArchetype kreweArchetype;

    public override void CreateCharacter()
    {
        base.CreateCharacter();



        UIManager.Instance.UpdateGeneralUI(TemplateType.Geist);
    }

    public void AddGeistTraits(int orderNum = 0)
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
    public string GetRoot()
    {
        return root;
    }
    public string GetBloom()
    {
        return bloom;
    }
    public string GetGeist()
    {
        return giestName;
    }
    public KreweArchetype GetKreweArchetype()
    {
        return kreweArchetype;
    }
    public string GetKrewe()
    {
        return krewe;
    }
    #endregion
}
public enum Burden { Abiding, Bereaved, Hungry, Kindly, Vengeful }
public enum KreweArchetype { Furies, Mourners, Necropolitans, Pilgrims, Undertakers}