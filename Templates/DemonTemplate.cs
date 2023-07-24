using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonTemplate : CharTemplate
{
    private Incarnation incarnation;
    private Agenda agenda;
    private string catalyst; //Reason For Falling

    public override void CreateCharacter()
    {
        base.CreateCharacter();



        UIManager.Instance.UpdateGeneralUI(TemplateType.Demon);
    }

    public void AddDemonTraits(int orderNum = 0)
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
    public Incarnation GetIncarnation()
    {
        return incarnation;
    }
    public Agenda GetAgenda()
    {
        return agenda;
    }
    public string GetCatalyst()
    {
        return catalyst;
    }
    #endregion
}
public enum Incarnation { Destroyer, Guardian, Messenger, Psychopomp }
public enum Agenda { None, Inquisitor, Integrator, Saboteur, Tempter }