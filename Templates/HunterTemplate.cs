using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterTemplate : CharTemplate
{
    private string cell;
    private Compact compact;
    private Conspiracy conspiracy;
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
        UIManager.Instance.UpdateGeneralUI(TemplateType.Hunter);
    }

    public void AddHunterTraits(int orderNum = 0)
    {
        SetCell();
        SetCompact(orderNum);
        SetConspiracy(orderNum);
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
    public void SetCell()
    {
        cell = "";
    }
    public void SetCompact(int orderNum)
    {
        compact = orderNum switch
        {
            2 => Compact.LongNight,
            3 => Compact.LoyalistsOfThule,
            4 => Compact.NetworkZero,
            5 => Compact.NineStars,
            6 => Compact.NullMysteriis,
            7 => Compact.SWORN,
            8 => Compact.TheUnion,
            _ => Compact.None
        };
    }
    public void SetConspiracy(int orderNum)
    {
        conspiracy = orderNum switch
        {
            9 => Conspiracy.AscendingOnes,
            10 => Conspiracy.TheCheironGroup,
            11 => Conspiracy.CouncilOfBones,
            12 => Conspiracy.TheLucifuge,
            13 => Conspiracy.MalleusMaleficarum,
            14 => Conspiracy.TaskForceVALKYRIE,
            15 => Conspiracy.VASCU,
            _ => Conspiracy.None
        };
    }
    #endregion
    #region Getters

    public string GetCell()
    {
        return cell;
    }
    public Compact GetCompact()
    {
        return compact;
    }
    public Conspiracy GetConspiracy()
    {
        return conspiracy;
    }
    #endregion
}
public enum Compact { None, LongNight, LoyalistsOfThule, NetworkZero, NineStars, NullMysteriis, SWORN, TheUnion }
public enum Conspiracy { None, AscendingOnes, TheCheironGroup, CouncilOfBones, TheLucifuge, MalleusMaleficarum, TaskForceVALKYRIE, VASCU }