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
        SetRandomPriority();
        base.CreateCharacter();
        SetRoot();
        SetBloom();
        SetName();
        SetGeist();
        SetPotency();
        AddExperience();
        UpdateCharacter();
        GenerateConcept();
        UIManager.Instance.UpdateGeneralUI(TemplateType.Geist);
    }

    public void AddGeistTraits(int orderNum = 0)
    {
        SetKreweArchetype(orderNum);
        SetBurden();
        SetKrewe();
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
    private void SetRoot()
    {
        int rand = Random.Range(1, 11);
        root = rand switch
        {
            1 => "Advocate",
            2 => "Antihero",
            3 => "Casual",
            4 => "Cowl",
            5 => "Enabler",
            6 => "Gardner",
            7 => "Pollyanna",
            8 => "Saved",
            9 => "Servant",
            10 => "Surrogate",
            _ => "Advocate"
        };
    }
    private void SetBloom()
    {
        int rand = Random.Range(1, 11);
        bloom = rand switch
        {
            1 => "Advocate",
            2 => "Antihero",
            3 => "Casual",
            4 => "Cowl",
            5 => "Enabler",
            6 => "Gardner",
            7 => "Pollyanna",
            8 => "Saved",
            9 => "Servant",
            10 => "Surrogate",
            _ => "Advocate"
        };
        if (root == bloom)
        {
            SetBloom();
        }
    }
    private void SetGeist()
    {
        giestName = Nationality.Instance.GetNameForChar(genderM);
    }
    private void SetKreweArchetype(int archNum)
    {
        kreweArchetype = archNum switch
        {
            1 => KreweArchetype.Furies,
            2 => KreweArchetype.Mourners,
            3 => KreweArchetype.Necropolitans,
            4 => KreweArchetype.Pilgrims,
            5 => KreweArchetype.Undertakers,
            _ => KreweArchetype.Furies
        };
    }
    private void SetKrewe()
    {
        //TODO
    }
    private void SetBurden()
    {
        int rand = Random.Range(1, 6);
        burden = rand switch
        {
            1 => Burden.Abiding,
            2 => Burden.Bereaved,
            3 => Burden.Hungry,
            4 => Burden.Kindly,
            5 => Burden.Vengeful,
            _ => Burden.Abiding
        };
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
    public Burden GetBurden()
    {
        return burden;
    }
    #endregion
}
public enum Burden { Abiding, Bereaved, Hungry, Kindly, Vengeful }
public enum KreweArchetype { Furies, Mourners, Necropolitans, Pilgrims, Undertakers}