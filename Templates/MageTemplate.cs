using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageTemplate : CharTemplate
{
    private int mana;
    private bool isWoDcharacter = false;
    private MagePath mPath;
    private MageLegacy mLegacy;
    private MageOrder mOrder;

    #region Spheres
    public CharStat death;
    public CharStat fate;
    public CharStat forces;
    public CharStat life;
    public CharStat matter;
    public CharStat mind;
    public CharStat prime;
    public CharStat space;
    public CharStat spirit;
    public CharStat time;
    private List<CharStat> sphereList;
    #endregion


    public override void CreateCharacter()
    {
        SetPrioritiesByPath();
        InitialiseArcanaSpheres();
        base.CreateCharacter();
        SetMageGnosis();
        SetArcanaMaxesAndStart();
        SetStartingMageArcanaSpheres();
        SetStartingMana();
        SetName();
        SetVirtue();
        SetVice();
        AddExperience();
        GenerateConcept();
        UpdateCharacter();
        UIManager.Instance.UpdateGeneralUI(TemplateType.Mage);
    }
    #region AddMageStuff
    public void AddMageTraits(int orderNum = 0, bool isWoD = false)
    {
        isWoDcharacter = isWoD;
        SetMageOrder(orderNum);
        SetMagePath();
    }

    #endregion
    #region Merits and Experience
    public override void AddExperience()
    {
        int experienceAge = age - 15;
        int attributesOrSphereToAdd = (Mathf.Clamp((int)(Mathf.Sqrt(experienceAge) * 1.5), 0, 15));
        int skillsToAdd = (int)(Mathf.Sqrt(experienceAge) * 3);
        int meritsToAdd = (int)(Mathf.Sqrt(experienceAge) * 1);
        
        if (attributesOrSphereToAdd > 0)
        {
            for (int i = 0; i < attributesOrSphereToAdd; i++)
            {
                AddSingleAttribute();
            }
        }
        if (skillsToAdd > 0)
        {
            for (int i = 0; i < skillsToAdd; i++)
            {
                AddSingleSkill();
            }
        }
        if (attributesOrSphereToAdd > 0)
        {
            for (int i = 0; i < attributesOrSphereToAdd; i++)
            {
                AddARandomArcana();
            }
        }
        if (meritsToAdd > 0)
        {
            for (int i = 0; i < meritsToAdd; i++)
            {
                AddMerit();
            }
        }
        int humVariable = (int)(Mathf.Sqrt(experienceAge) / 2);
        integrity = Mathf.Clamp(integrity - Random.Range(-1, humVariable), 1, 8);
        willpower = Mathf.Clamp(willpower + Random.Range(0, humVariable * 2), 1, 10);
        if (mOrder == MageOrder.TheRapt)
        {
            integrity = 0;
        }
    }
    public override void AddMerit()
    {

    }
    #endregion
    #region Update
    public override void UpdateCharacter()
    {
        base.UpdateCharacter();
    }
    #endregion
    #region Setters
    private void SetMageOrder(int orderNum)
    {
        mOrder = orderNum switch
        {
            1 => MageOrder.AdamantineArrow,
            2 => MageOrder.GuardiansOfTheVeil,
            3 => MageOrder.Mysterium,
            4 => MageOrder.SilverLadder,
            5 => MageOrder.FreeCouncil,
            6 => MageOrder.SeersOfTheThrone,
            7 => MageOrder.Banishers,
            8 => MageOrder.TheRapt,
            9 => MageOrder.MinistryOfTheThrone,
            10 => MageOrder.Bataa,
            11 => MageOrder.SistersOfHippolyta,
            12 => MageOrder.HollowOnes,
            13 => MageOrder.TemplarKnights,
            14 => MageOrder.Scelesti,
            _ => MageOrder.AdamantineArrow,
        };
    }
    private void SetMagePath()
    {
        int rand;
        if (isWoDcharacter == false)
        {
            rand = Random.Range(1, 6);
            mPath = rand switch
            {
                1 => MagePath.Acanthus,
                2 => MagePath.Mastigos,
                3 => MagePath.Moros,
                4 => MagePath.Obrimos,
                5 => MagePath.Thyrsus,
                _ => MagePath.Acanthus
            };
            mLegacy = MageLegacy.None;
        }
        else
        {

            if (mOrder == MageOrder.AdamantineArrow)
            {
                rand = Random.Range(1, 6); 
                switch (rand)
                {
                    case 1:
                        mPath = MagePath.Obrimos;
                        mLegacy = MageLegacy.OrderOfHermes;
                        break;
                    case 2:
                        mPath = MagePath.Mastigos;
                        mLegacy = MageLegacy.AkashicBrotherhood;
                        break;
                    case 3:
                        mPath = MagePath.Acanthus;
                        mLegacy = MageLegacy.CultOfEcstacy;
                        break;
                    case 4:
                        mPath = MagePath.Mastigos;
                        mLegacy = MageLegacy.BrotherhoodOfTheDemonWind;
                        break;
                    case 5:
                        mPath = MagePath.Moros;
                        mLegacy = MageLegacy.TamerOfStone;
                        break;
                    default:
                        mPath = MagePath.Obrimos;
                        mLegacy = MageLegacy.OrderOfHermes;
                        break;
                }
            }
            else if(mOrder == MageOrder.GuardiansOfTheVeil)
            {
                rand = Random.Range(1, 7);
                switch (rand)
                {
                    case 1:
                        mPath = MagePath.Obrimos;
                        mLegacy = MageLegacy.OrderOfHermes;
                        break;
                    case 2:
                        mPath = MagePath.Acanthus;
                        mLegacy = MageLegacy.CultOfEcstacy;
                        break;
                    case 3:
                        mPath = MagePath.Acanthus;
                        mLegacy = MageLegacy.Euthanatos;
                        break;
                    case 4:
                        mPath = MagePath.Acanthus;
                        mLegacy = MageLegacy.Austere;
                        break;
                    case 5:
                        mPath = MagePath.Thyrsus;
                        mLegacy = MageLegacy.EleventhQuestion;
                        break;
                    case 6:
                        mPath = MagePath.Moros;
                        mLegacy = MageLegacy.TamerOfStone;
                        break;
                    default:
                        mPath = MagePath.Obrimos;
                        mLegacy = MageLegacy.OrderOfHermes;
                        break;
                }
            }
            else if (mOrder == MageOrder.Mysterium)
            {
                rand = Random.Range(1, 9);
                switch (rand)
                {
                    case 1:
                        mPath = MagePath.Obrimos;
                        mLegacy = MageLegacy.OrderOfHermes;
                        break;
                    case 2:
                        mPath = MagePath.Moros;
                        mLegacy = MageLegacy.SonsOfEther;
                        break;
                    case 3:
                        mPath = MagePath.Acanthus;
                        mLegacy = MageLegacy.CultOfEcstacy;
                        break;
                    case 4:
                        mPath = MagePath.Thyrsus;
                        mLegacy = MageLegacy.Dreamspeakers;
                        break;
                    case 5:
                        mPath = MagePath.Thyrsus;
                        mLegacy = MageLegacy.Verbena;
                        break;
                    case 6:
                        mPath = MagePath.Acanthus;
                        mLegacy = MageLegacy.WalkersInTheMist;
                        break;
                    case 7:
                        mPath = MagePath.Moros;
                        mLegacy = MageLegacy.StoneScribes;
                        break;
                    case 8:
                        mPath = MagePath.Moros;
                        mLegacy = MageLegacy.TamerOfStone;
                        break;
                    default:
                        mPath = MagePath.Obrimos;
                        mLegacy = MageLegacy.OrderOfHermes;
                        break;
                }
            }
            else if (mOrder == MageOrder.SilverLadder)
            {
                rand = Random.Range(1, 9);
                switch (rand)
                {
                    case 1:
                        mPath = MagePath.Obrimos;
                        mLegacy = MageLegacy.OrderOfHermes;
                        break;
                    case 2:
                        mPath = MagePath.Obrimos;
                        mLegacy = MageLegacy.CelestialChorus;
                        break;
                    case 3:
                        mPath = MagePath.Acanthus;
                        mLegacy = MageLegacy.CultOfEcstacy;
                        break;
                    case 4:
                        mPath = MagePath.Thyrsus;
                        mLegacy = MageLegacy.Verbena;
                        break;
                    case 5:
                        mPath = MagePath.Moros;
                        mLegacy = MageLegacy.TamerOfStone;
                        break;
                    case 6:
                        mPath = MagePath.Obrimos;
                        mLegacy = MageLegacy.StewardsOfTheCelestialOrrery;
                        break;
                    case 7:
                        mPath = MagePath.Thyrsus;
                        mLegacy = MageLegacy.KeepersCovenant;
                        break;
                    case 8:
                        mPath = MagePath.Mastigos;
                        mLegacy = MageLegacy.BeneAshmedai;
                        break;
                    default:
                        mPath = MagePath.Obrimos;
                        mLegacy = MageLegacy.OrderOfHermes;
                        break;
                }
            }
            else if (mOrder == MageOrder.FreeCouncil)
            {
                rand = Random.Range(1, 11);
                switch (rand)
                {
                    case 1:
                        mPath = MagePath.Obrimos;
                        mLegacy = MageLegacy.OrderOfHermes;
                        break;
                    case 2:
                        mPath = MagePath.Moros;
                        mLegacy = MageLegacy.SonsOfEther;
                        break;
                    case 3:
                        mPath = MagePath.Mastigos;
                        mLegacy = MageLegacy.AkashicBrotherhood;
                        break;
                    case 4:
                        mPath = MagePath.Obrimos;
                        mLegacy = MageLegacy.CelestialChorus;
                        break;
                    case 5:
                        mPath = MagePath.Acanthus;
                        mLegacy = MageLegacy.CultOfEcstacy;
                        break;
                    case 6:
                        mPath = MagePath.Thyrsus;
                        mLegacy = MageLegacy.Dreamspeakers;
                        break;
                    case 7:
                        mPath = MagePath.Acanthus;
                        mLegacy = MageLegacy.Euthanatos;
                        break;
                    case 8:
                        mPath = MagePath.Thyrsus;
                        mLegacy = MageLegacy.Verbena;
                        break;
                    case 9:
                        mPath = MagePath.Mastigos;
                        mLegacy = MageLegacy.VirtualAdepts;
                        break;
                    case 10:
                        mPath = MagePath.Moros;
                        mLegacy = MageLegacy.TamerOfStone;
                        break;
                    default:
                        mPath = MagePath.Obrimos;
                        mLegacy = MageLegacy.OrderOfHermes;
                        break;
                }
            }
            else if (mOrder == MageOrder.SeersOfTheThrone)
            {
                rand = Random.Range(1, 10);
                switch (rand)
                {
                    case 1:
                        mPath = MagePath.Obrimos;
                        mLegacy = MageLegacy.OrderOfHermes;
                        break;
                    case 2:
                        mPath = MagePath.Moros;
                        mLegacy = MageLegacy.SonsOfEther;
                        break;
                    case 3:
                        mPath = MagePath.Mastigos;
                        mLegacy = MageLegacy.AkashicBrotherhood;
                        break;
                    case 4:
                        mPath = MagePath.Obrimos;
                        mLegacy = MageLegacy.CelestialChorus;
                        break;
                    case 5:
                        mPath = MagePath.Acanthus;
                        mLegacy = MageLegacy.CultOfEcstacy;
                        break;
                    case 6:
                        mPath = MagePath.Thyrsus;
                        mLegacy = MageLegacy.Dreamspeakers;
                        break;
                    case 7:
                        mPath = MagePath.Acanthus;
                        mLegacy = MageLegacy.Euthanatos;
                        break;
                    case 8:
                        mPath = MagePath.Thyrsus;
                        mLegacy = MageLegacy.Verbena;
                        break;
                    case 9:
                        mPath = MagePath.Moros;
                        mLegacy = MageLegacy.TamerOfStone;
                        break;
                    default:
                        mPath = MagePath.Obrimos;
                        mLegacy = MageLegacy.OrderOfHermes;
                        break;
                }
            }
            else if (mOrder == MageOrder.MinistryOfTheThrone)
            {
                rand = Random.Range(1, 7);
                switch (rand)
                {
                    case 1:
                        mPath = MagePath.Mastigos;
                        mLegacy = MageLegacy.Syndicate;
                        break;
                    case 2:
                        mPath = MagePath.Thyrsus;
                        mLegacy = MageLegacy.Progenitors;
                        break;
                    case 3:
                        mPath = MagePath.Mastigos;
                        mLegacy = MageLegacy.NewWorldOrder;
                        break;
                    case 4:
                        mPath = MagePath.Moros;
                        mLegacy = MageLegacy.IterationX;
                        break;
                    case 5:
                        mPath = MagePath.Thyrsus;
                        mLegacy = MageLegacy.VoidEngineers;
                        break;
                    case 6:
                        mPath = MagePath.Mastigos;
                        mLegacy = MageLegacy.VirtualAdepts;
                        break;
                    default:
                        mPath = MagePath.Obrimos;
                        mLegacy = MageLegacy.OrderOfHermes;
                        break;
                }
            }
            else if (mOrder == MageOrder.Bataa)
            {
                mPath = MagePath.Thyrsus;
                mLegacy = MageLegacy.Bataa;
            }
            else if (mOrder == MageOrder.SistersOfHippolyta)
            {
                mPath = MagePath.Acanthus;
                mLegacy = MageLegacy.SistersOfHippolyta;
            }
            else if (mOrder == MageOrder.HollowOnes)
            {
                mPath = MagePath.Moros;
                mLegacy = MageLegacy.HollowOnes;
            }
            else if (mOrder == MageOrder.TemplarKnights)
            {
                mPath = MagePath.Obrimos;
                mLegacy = MageLegacy.TemplarKnights;
            }
            else if (mOrder == MageOrder.Banishers)
            {
                mPath = MagePath.Mastigos;
                mLegacy = MageLegacy.Timori;
            }
            else if (mOrder == MageOrder.Scelesti)
            {
                mPath = MagePath.Obrimos;
                mLegacy = MageLegacy.TemplarKnights;
            }
            else
            {
                rand = Random.Range(1, 6);
                mPath = rand switch
                {
                    1 => MagePath.Acanthus,
                    2 => MagePath.Mastigos,
                    3 => MagePath.Moros,
                    4 => MagePath.Obrimos,
                    5 => MagePath.Thyrsus,
                    _ => MagePath.Acanthus
                }; 
                mLegacy = MageLegacy.None;
            }
        }
    }
    private void SetPrioritiesByPath()
    {
        int rand = Random.Range(1, 101);
        if (mLegacy == MageLegacy.AkashicBrotherhood)
        {
            if (rand > 65)
            {
                physicalAttributes = State.Primary;
                physicalSkills = State.Primary;
                socialAttributes = State.Tertiary;
                socialSkills = State.Tertiary;
                mentalAttributes = State.Secondary;
                mentalSkills = State.Secondary;
            }
            else if (rand > 30)
            {
                physicalAttributes = State.Secondary;
                physicalSkills = State.Secondary;
                socialAttributes = State.Tertiary;
                socialSkills = State.Tertiary;
                mentalAttributes = State.Primary;
                mentalSkills = State.Primary;
            }
            else if (rand > 20)
            {
                physicalAttributes = State.Tertiary;
                physicalSkills = State.Tertiary;
                socialAttributes = State.Primary;
                socialSkills = State.Primary;
                mentalAttributes = State.Secondary;
                mentalSkills = State.Secondary;
            }
            else
            {
                physicalAttributes = State.Tertiary;
                physicalSkills = State.Tertiary;
                socialAttributes = State.Secondary;
                socialSkills = State.Secondary;
                mentalAttributes = State.Primary;
                mentalSkills = State.Primary;
            }
        }
        else
        {
            SetMentalPriority();
        }
    }
    public override void SetAge()
    {
        int rand = Random.Range(1, 101);
        if (rand > 50)
        {
            age = Random.Range(20, 40);
        }
        else if (rand > 20)
        {
            age = Random.Range(18, 60);
        }
        else if (rand > 3)
        {
            age = Random.Range(18, 80);
        }
        else
        {
            age = Random.Range(18, 200);
        }
    }
    private void SetMageGnosis()
    {
        int gnosisAge = GetAge() - 15;
        if (gnosisAge < 5)
        {
            SetPotency(1);
        }
        else if (gnosisAge < 10)
        {
            SetPotency(2);
        }
        else if (gnosisAge < 20)
        {
            SetPotency(3);
        }
        else if (gnosisAge < 40)
        {
            SetPotency(4);
        }
        else if (gnosisAge < 80)
        {
            SetPotency(5);
        }
        else if (gnosisAge < 140)
        {
            SetPotency(6);
        }
        else if (gnosisAge < 180)
        {
            SetPotency(7);
        }
        else
        {
            SetPotency(8);
        }
    }
    public override void GenerateConcept()
    {
        base.GenerateConcept();
    }
    private void SetStartingMana()
    {
        mana = Random.Range(1, 11);
    }
    #endregion
    #region Getters

    public MagePath GetMagePath()
    {
        return mPath;
    }
    public MageLegacy GetMageLegacy()
    {
        return mLegacy;
    }
    public MageOrder GetMageOrder()
    {
        return mOrder;
    }
    #endregion
    #region Arcane Spheres
    private void InitialiseArcanaSpheres()
    {
        death = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        fate = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        forces = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        life = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        matter = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        mind = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        prime = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        space = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        spirit = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        time = Instantiate(statPrefab, transform).GetComponent<CharStat>();

        death.InitialiseStat("Death");
        fate.InitialiseStat("Fate");
        forces.InitialiseStat("Force");
        life.InitialiseStat("Life");
        matter.InitialiseStat("Matter");
        mind.InitialiseStat("Mind");
        prime.InitialiseStat("Prime");
        space.InitialiseStat("Space");
        spirit.InitialiseStat("Spirit");
        time.InitialiseStat("Time");

        sphereList = new();
        sphereList.Add(death);
        sphereList.Add(fate);
        sphereList.Add(forces);
        sphereList.Add(life);
        sphereList.Add(matter);
        sphereList.Add(mind);
        sphereList.Add(prime);
        sphereList.Add(space);
        sphereList.Add(spirit);
        sphereList.Add(time);
    }
    private void SetArcanaMaxesAndStart()
    {
        int rulingMax;
        int otherMax;
        int inferiorMax;
        if (potency == 1)
        {
            rulingMax = 3;
            otherMax = 2;
            inferiorMax = 2;
        }
        else if (potency == 2)
        {
            rulingMax = 3;
            otherMax = 3;
            inferiorMax = 2;
        }
        else if (potency == 3)
        {
            rulingMax = 4;
            otherMax = 3;
            inferiorMax = 2;
        }
        else if (potency == 4)
        {
            rulingMax = 4;
            otherMax = 4;
            inferiorMax = 3;
        }
        else if (potency == 5)
        {
            rulingMax = 5;
            otherMax = 4;
            inferiorMax = 3;
        }
        else
        {
            rulingMax = 5;
            otherMax = 5;
            inferiorMax = 4;
        }

        foreach (CharStat sphere in sphereList)
        {
            sphere.SetMaxValue(otherMax);
        }

        if (mPath == MagePath.Acanthus)
        {
            time.SetMaxValue(rulingMax);
            fate.SetMaxValue(rulingMax);
            forces.SetMaxValue(inferiorMax);
            time.SetStatValue(1);
            fate.SetStatValue(1);
        }
        else if (mPath == MagePath.Mastigos)
        {
            space.SetMaxValue(rulingMax);
            mind.SetMaxValue(rulingMax);
            matter.SetMaxValue(inferiorMax);
            space.SetStatValue(1);
            mind.SetStatValue(1);
        }
        else if (mPath == MagePath.Moros)
        {
            matter.SetMaxValue(rulingMax);
            death.SetMaxValue(rulingMax);
            spirit.SetMaxValue(inferiorMax);
            matter.SetStatValue(1);
            death.SetStatValue(1);
        }
        else if (mPath == MagePath.Obrimos)
        {
            forces.SetMaxValue(rulingMax);
            prime.SetMaxValue(rulingMax);
            death.SetMaxValue(inferiorMax);
            forces.SetStatValue(1);
            prime.SetStatValue(1);
        }
        else if (mPath == MagePath.Thyrsus)
        {
            life.SetMaxValue(rulingMax);
            spirit.SetMaxValue(rulingMax);
            mind.SetMaxValue(inferiorMax);
            life.SetStatValue(1);
            spirit.SetStatValue(1);
        }

        switch (mLegacy)
        {
            case MageLegacy.CultOfEcstacy:
                mind.SetMaxValue(rulingMax);
                mind.SetStatValue(1);
                break;
            case MageLegacy.Euthanatos:
                death.SetMaxValue(rulingMax);
                death.SetStatValue(1);
                break;
            case MageLegacy.SistersOfHippolyta:
                life.SetMaxValue(rulingMax);
                life.SetStatValue(1);
                break;
            case MageLegacy.KopaLoei:
                spirit.SetMaxValue(rulingMax);
                spirit.SetStatValue(1);
                break;
            case MageLegacy.Ngoma:
                prime.SetMaxValue(rulingMax);
                prime.SetStatValue(1);
                break;
            case MageLegacy.WalkersInTheMist:
                space.SetMaxValue(rulingMax);
                space.SetStatValue(1);
                break;
            case MageLegacy.Austere:
                matter.SetMaxValue(rulingMax);
                matter.SetStatValue(1);
                break;
            case MageLegacy.VirtualAdepts:
                forces.SetMaxValue(rulingMax);
                forces.SetStatValue(1);
                break;
            case MageLegacy.AkashicBrotherhood:
                life.SetMaxValue(rulingMax);
                life.SetStatValue(1);
                break;
            case MageLegacy.NewWorldOrder:
                fate.SetMaxValue(rulingMax);
                fate.SetStatValue(1);
                break;
            case MageLegacy.Syndicate:
                death.SetMaxValue(rulingMax);
                death.SetStatValue(1);
                break;
            case MageLegacy.Timori:
                prime.SetMaxValue(rulingMax);
                prime.SetStatValue(1);
                break;
            case MageLegacy.BrotherhoodOfTheDemonWind:
                time.SetMaxValue(rulingMax);
                time.SetStatValue(1);
                break;
            case MageLegacy.BeneAshmedai:
                spirit.SetMaxValue(rulingMax);
                spirit.SetStatValue(1);
                break;
            case MageLegacy.SonsOfEther:
                forces.SetMaxValue(rulingMax);
                forces.SetStatValue(1);
                break;
            case MageLegacy.HollowOnes:
                life.SetMaxValue(rulingMax);
                life.SetStatValue(1);
                break;
            case MageLegacy.IterationX:
                time.SetMaxValue(rulingMax);
                time.SetStatValue(1);
                break;
            case MageLegacy.Soloficati:
                prime.SetMaxValue(rulingMax);
                prime.SetStatValue(1);
                break;
            case MageLegacy.StoneScribes:
                fate.SetMaxValue(rulingMax);
                fate.SetStatValue(1);
                break;
            case MageLegacy.TamerOfStone:
                space.SetMaxValue(rulingMax);
                space.SetStatValue(1);
                break;
            case MageLegacy.CelestialChorus:
                spirit.SetMaxValue(rulingMax);
                spirit.SetStatValue(1);
                break;
            case MageLegacy.OrderOfHermes:
                matter.SetMaxValue(rulingMax);
                matter.SetStatValue(1);
                break;
            case MageLegacy.TemplarKnights:
                mind.SetMaxValue(rulingMax);
                mind.SetStatValue(1);
                break;
            case MageLegacy.AlIBatin:
                space.SetMaxValue(rulingMax);
                space.SetStatValue(1);
                break;
            case MageLegacy.WuLung:
                life.SetMaxValue(rulingMax);
                life.SetStatValue(1);
                break;
            case MageLegacy.StewardsOfTheCelestialOrrery:
                time.SetMaxValue(rulingMax);
                time.SetStatValue(1);
                break;
            case MageLegacy.Scelesti:
                fate.SetMaxValue(rulingMax);
                fate.SetStatValue(1);
                break;
            case MageLegacy.Verbena:
                forces.SetMaxValue(rulingMax);
                forces.SetStatValue(1);
                break;
            case MageLegacy.Dreamspeakers:
                matter.SetMaxValue(rulingMax);
                matter.SetStatValue(1);
                break;
            case MageLegacy.Progenitors:
                prime.SetMaxValue(rulingMax);
                prime.SetStatValue(1);
                break;
            case MageLegacy.VoidEngineers:
                space.SetMaxValue(rulingMax);
                space.SetStatValue(1);
                break;
            case MageLegacy.Bataa:
                fate.SetMaxValue(rulingMax);
                fate.SetStatValue(1);
                break;
            case MageLegacy.EleventhQuestion:
                time.SetMaxValue(rulingMax);
                time.SetStatValue(1);
                break;
            case MageLegacy.KeepersCovenant:
                fate.SetMaxValue(rulingMax);
                fate.SetStatValue(1);
                break;
        }
    }
    private void SetStartingMageArcanaSpheres()
    {
        switch (mPath)
        {
            case MagePath.Acanthus:
                AddAnArcana(forces);
                AddAnArcana(forces);
                break;
            case MagePath.Mastigos:
                AddAnArcana(matter);
                AddAnArcana(matter);
                break;
            case MagePath.Moros:
                AddAnArcana(spirit);
                AddAnArcana(spirit);
                break;
            case MagePath.Obrimos:
                AddAnArcana(death);
                AddAnArcana(death);
                break;
            case MagePath.Thyrsus:
                AddAnArcana(mind);
                AddAnArcana(mind);
                break;
        }

        if (mLegacy == MageLegacy.None)
        {
            AddARandomArcana();
        }
    }
    private void AddAnArcana(CharStat weakArcana)
    {
        int rand = Random.Range(0, sphereList.Count);
        if (sphereList[rand] == weakArcana)
        {
            AddAnArcana(weakArcana);
        }
        else if (sphereList[rand].GetMaxValue() > sphereList[rand].GetStatValue())
        {
            sphereList[rand].AddToStatValue(1);
        }
        else
        {
            AddARandomArcana();
        }
    }
    private void AddARandomArcana()
    {
        int rand = Random.Range(0, sphereList.Count);
        if (sphereList[rand].GetMaxValue() > sphereList[rand].GetStatValue())
        {
            sphereList[rand].AddToStatValue(1);
        }
        else
        {
            AddARandomArcana();
        }
    }
    public List<CharStat> GetArcanaList()
    {
        return sphereList;
    }
    #endregion
}
public enum MagePath 
{
    Acanthus, Mastigos, Moros, Obrimos, Thyrsus 
}
public enum MageLegacy 
{ 
    None,
    //WoD Legacies
    CultOfEcstacy, Euthanatos, SistersOfHippolyta, KopaLoei, Ngoma, WalkersInTheMist, Austere,
    VirtualAdepts, AkashicBrotherhood, NewWorldOrder, Syndicate, Timori, BrotherhoodOfTheDemonWind, BeneAshmedai,
    SonsOfEther, HollowOnes, IterationX, Soloficati, Tremere, StoneScribes, TamerOfStone,
    CelestialChorus, OrderOfHermes, TemplarKnights, AlIBatin, WuLung, StewardsOfTheCelestialOrrery, Scelesti,
    Verbena, Dreamspeakers, Progenitors, VoidEngineers, Bataa, EleventhQuestion, KeepersCovenant
}
public enum MageOrder
{ 
    AdamantineArrow, GuardiansOfTheVeil, Mysterium, SilverLadder, FreeCouncil, SeersOfTheThrone, Banishers, TheRapt,
    //WoD Orders
    MinistryOfTheThrone, Bataa, SistersOfHippolyta, HollowOnes, TemplarKnights, Scelesti
}