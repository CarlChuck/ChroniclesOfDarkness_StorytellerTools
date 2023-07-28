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
        SetRandomPriority();
        base.CreateCharacter();
        SetVirtue();
        SetVice();
        SetName();
        SetPotency();
        AddExperience();
        UpdateCharacter();
        GenerateConcept();
        UIManager.Instance.UpdateGeneralUI(TemplateType.Demon);
    }

    public void AddDemonTraits(int agendaNum = 0)
    {
        SetAgenda(agendaNum);
        SetIncarnation();
        SetCatalyst();
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
    private void SetIncarnation()
    {
        int rand = Random.Range(1, 5);
        incarnation = rand switch
        {
            1 => Incarnation.Destroyer,
            2 => Incarnation.Guardian,
            3 => Incarnation.Messenger,
            4 => Incarnation.Psychopomp,
            _ => Incarnation.Destroyer
        };
    }
    private void SetAgenda(int agendaNum = 0)
    {
        int num = agendaNum;
        if (agendaNum == 0)
        {
            num = Random.Range(1, 5);
        }
        agenda = num switch
        {
            1 => Agenda.Inquisitor,
            2 => Agenda.Integrator,
            3 => Agenda.Saboteur,
            4 => Agenda.Tempter,
            _ => Agenda.Inquisitor
        };
    }
    private void SetCatalyst()
    {
        catalyst = "";
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