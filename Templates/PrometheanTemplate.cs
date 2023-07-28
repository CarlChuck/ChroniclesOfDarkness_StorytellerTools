using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrometheanTemplate : CharTemplate
{
    private string elpis;
    private string torment;
    private string role;
    private Refinement refinement;
    private Lineage lineage;

    public override void CreateCharacter()
    {
        SetRandomPriority();
        base.CreateCharacter();
        SetElpis();
        SetTorment();
        SetName();
        SetPotency();
        AddExperience();
        UpdateCharacter();
        GenerateConcept();
        UIManager.Instance.UpdateGeneralUI(TemplateType.Promethean);
    }

    public void AddPrometheanTraits(int linNum = 0)
    {
        SetLineage(linNum);
        SetRefinement();
        SetRole();
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
    private void SetElpis()
    {
        int rand = Random.Range(1, 11);
        elpis = rand switch
        {
            1 => "Courage",
            2 => "Drive",
            3 => "Empathy",
            4 => "Fear",
            5 => "Fury",
            6 => "Inspiration",
            7 => "Joy",
            8 => "Love",
            9 => "Sorrow",
            10 => "Pain",
            _ => "Courage"
        };
    }
    private void SetTorment()
    {
        int rand = Random.Range(1, 11);
        torment = rand switch
        {
            1 => "Alienated",
            2 => "Awkward",
            3 => "Dejection",
            4 => "Logical",
            5 => "Merciless",
            6 => "Methodical",
            7 => "Obsession",
            8 => "Paranoia",
            9 => "Passion",
            10 => "Naive",
            _ => "Alienated"
        };
    }
    private void SetLineage(int linNum)
    {
        lineage = linNum switch
        {
            1 => Lineage.Frankenstein,
            2 => Lineage.Galateid,
            3 => Lineage.Osiran,
            4 => Lineage.Tammuz,
            5 => Lineage.Ulgan,
            6 => Lineage.Unfleshed,
            7 => Lineage.Extempore,
            _ => Lineage.Frankenstein
        };
    }
    private void SetRefinement()
    {
        int rand = Random.Range(1, 6);
        refinement = rand switch
        {
            1 => Refinement.Aurum,
            2 => Refinement.Cuprum,
            3 => Refinement.Ferrum,
            4 => Refinement.Plumbum,
            5 => Refinement.Stannum,
            _ => Refinement.Aurum
        };
    }
    private void SetRole()
    {
        role = "";
    }
    #endregion
    #region Getters
    public string GetElpis() 
    {
        return elpis;
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