using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireTemplate : CharTemplate
{
    private int vitae;
    private bool isWoDcharacter = false;
    private VampireClan vClan;
    private Bloodline vBloodline;
    private Covenant covenant;
    private int embraceAge;
    private int appearedAge;
    private string mask;
    private string dirge;
    
    #region Disciplines
    private CharStat vigor;
    private CharStat celerity;
    private CharStat resilience;

    private CharStat animalism;
    private CharStat obfuscate;

    private CharStat auspex;
    private CharStat dominate;
    private CharStat majesty;
    private CharStat nightmare;
    private CharStat protean;
    #endregion
    #region WoDDiscs
    private CharStat dementation;
    private CharStat durAnKiSorcery;
    private CharStat setiteSorcery;
    private CharStat thaumaturgy;
    private CharStat necromancy;
    private CharStat koldunicSorcery;
    private CharStat taliesin;
    private CharStat vodoun;
    #endregion
    #region BloodlineDiscs
    private CharStat abjurism; //Also WoD
    private CharStat amphivena;
    private CharStat asphyx;
    private CharStat bahumisparsa;
    private CharStat bloodworking;
    private CharStat blutAlchemie;
    private CharStat cachexy;
    private CharStat carrefour;
    private CharStat cattiveria;
    private CharStat constance;
    private CharStat courtoisie;
    private CharStat crochan;
    private CharStat deadSignal;
    private CharStat despond;
    private CharStat domus;
    private CharStat embrocation;
    private CharStat essentiaphagia;
    private CharStat eupraxia;
    private CharStat getsumei;
    private CharStat gildedCage; //Also WoD
    private CharStat gustus;
    private CharStat hypnagogia;
    private CharStat impurity;
    private CharStat insomnium;
    private CharStat institutionalise;
    private CharStat kamen;
    private CharStat kingjan;
    private CharStat licencieux;
    private CharStat linagem;
    private CharStat lithopedia;
    private CharStat mementoMori;
    private CharStat meminisse;
    private CharStat mimetismo; //Also WoD
    private CharStat mortualia;
    private CharStat nahdad;
    private CharStat nburu;
    private CharStat nepenthe;
    private CharStat obtenebration; //Also WoD
    private CharStat ortam;
    private CharStat perfidy;
    private CharStat phagia;
    private CharStat ralab;
    private CharStat saktiPata;
    private CharStat scourge; //Also WoD
    private CharStat serendipity;
    private CharStat shihai;
    private CharStat spiritusSancti;
    private CharStat stigmatica;
    private CharStat sublunario;
    private CharStat suikast;
    private CharStat sunnikuse;
    private CharStat taurobolium;
    private CharStat tenure;
    private CharStat tezcatl;
    private CharStat theShow;
    private CharStat web;
    private CharStat xinyao;
    private CharStat zagovny; //Also WoD
    #endregion
    #region CovenantDiscs
    private CharStat coilsOfTheDragon;
    private CharStat cruacSorcery;
    private CharStat thebanSorcery;
    private CharStat ahraniteSorcery;
    private CharStat thanatology;
    #endregion
    private List<CharStat> listOfAllDisciplines;
    private List<CharStat> listOfCommonDisciplines;
    private List<CharStat> listOfClanDisciplines;
    private List<CharStat> listOfVtRBloodlineDisciplines; //TODO to add vtr bloodlines maybe
    public List<CharStat> listOfCurrentDisciplines;

    public override void CreateCharacter()
    {
        SetPrioritiesByClan();
        InstantiateDisciplines();
        base.CreateCharacter();
        SetStartingVitae();
        SetMask();
        SetDirge();
        AddVampireDisciplines();
        SetName();
        SetVampirePotency();
        AddExperience();
        UpdateCharacter();
        GenerateConcept();
        UIManager.Instance.UpdateGeneralUI(TemplateType.Vampire);
    }
    #region AddVampireStuff
    public void AddVampireTraits(int covNum = 0, bool isWoD = false)
    {
        isWoDcharacter = isWoD;
        SetVampireCovenant(covNum);
        SetVampireClan();
        SetEmbraceAge();
    }
    public void AddVampireDisciplines()
    {
        if (isWoDcharacter == true)
        {
            AddInitialWoDDisciplines();
        }
        else
        {
            AddInitialVtRDisciplines();
        }
    }
    public void AddInitialWoDDisciplines()
    {
        switch (vBloodline)
        {
            case Bloodline.Toreador:
                celerity.AddToStatValue(1);
                vigor.AddToStatValue(1);
                majesty.AddToStatValue(1);
                auspex.AddToStatValue(1);
                listOfCurrentDisciplines.Add(celerity);
                listOfCurrentDisciplines.Add(vigor);
                listOfCurrentDisciplines.Add(majesty);
                listOfCurrentDisciplines.Add(auspex);
                listOfCommonDisciplines.Remove(celerity);
                listOfCommonDisciplines.Remove(vigor);
                listOfClanDisciplines.Remove(majesty);
                listOfClanDisciplines.Remove(auspex);
                break;
            case Bloodline.Kiasyd:
                celerity.AddToStatValue(1);
                vigor.AddToStatValue(1);
                majesty.AddToStatValue(1);
                taliesin.AddToStatValue(1);
                listOfCurrentDisciplines.Add(celerity);
                listOfCurrentDisciplines.Add(vigor);
                listOfCurrentDisciplines.Add(majesty);
                listOfCurrentDisciplines.Add(taliesin);
                listOfCommonDisciplines.Remove(celerity);
                listOfCommonDisciplines.Remove(vigor);
                listOfClanDisciplines.Remove(majesty);
                break;
            case Bloodline.DaughtersOfCacophony:
                celerity.AddToStatValue(1);
                vigor.AddToStatValue(1);
                majesty.AddToStatValue(1);
                mimetismo.AddToStatValue(1);
                listOfCurrentDisciplines.Add(celerity);
                listOfCurrentDisciplines.Add(vigor);
                listOfCurrentDisciplines.Add(majesty);
                listOfCurrentDisciplines.Add(mimetismo);
                listOfCommonDisciplines.Remove(celerity);
                listOfCommonDisciplines.Remove(vigor);
                listOfClanDisciplines.Remove(majesty);
                break;
            case Bloodline.Ventru:
                resilience.AddToStatValue(1);
                majesty.AddToStatValue(1);
                animalism.AddToStatValue(1);
                dominate.AddToStatValue(1);
                listOfCurrentDisciplines.Add(resilience);
                listOfCurrentDisciplines.Add(majesty);
                listOfCurrentDisciplines.Add(animalism);
                listOfCurrentDisciplines.Add(dominate);
                listOfCommonDisciplines.Remove(resilience);
                listOfCommonDisciplines.Remove(animalism);
                listOfClanDisciplines.Remove(dominate);
                listOfClanDisciplines.Remove(majesty);
                break;
            case Bloodline.Giovanni:
                resilience.AddToStatValue(1);
                vigor.AddToStatValue(1);
                animalism.AddToStatValue(1);
                dominate.AddToStatValue(1);
                listOfCurrentDisciplines.Add(resilience);
                listOfCurrentDisciplines.Add(vigor);
                listOfCurrentDisciplines.Add(animalism);
                listOfCurrentDisciplines.Add(dominate);
                listOfCommonDisciplines.Remove(resilience);
                listOfCommonDisciplines.Remove(animalism);
                listOfClanDisciplines.Remove(dominate);
                listOfCommonDisciplines.Remove(vigor);
                break;
            case Bloodline.Lasombra:
                resilience.AddToStatValue(1);
                animalism.AddToStatValue(1);
                dominate.AddToStatValue(1);
                obtenebration.AddToStatValue(1);
                listOfCurrentDisciplines.Add(resilience);
                listOfCurrentDisciplines.Add(animalism);
                listOfCurrentDisciplines.Add(dominate);
                listOfCurrentDisciplines.Add(obtenebration);
                listOfCommonDisciplines.Remove(resilience);
                listOfCommonDisciplines.Remove(animalism);
                listOfClanDisciplines.Remove(dominate);
                break;
            case Bloodline.Gangrel:
                resilience.AddToStatValue(1);
                celerity.AddToStatValue(1);
                animalism.AddToStatValue(1);
                protean.AddToStatValue(1);
                listOfCurrentDisciplines.Add(resilience);
                listOfCurrentDisciplines.Add(animalism);
                listOfCurrentDisciplines.Add(celerity);
                listOfCurrentDisciplines.Add(protean);
                listOfCommonDisciplines.Remove(resilience);
                listOfCommonDisciplines.Remove(animalism);
                listOfClanDisciplines.Remove(protean);
                listOfCommonDisciplines.Remove(celerity);
                break;
            case Bloodline.Bruja:
                resilience.AddToStatValue(1);
                vigor.AddToStatValue(1);
                animalism.AddToStatValue(1);
                protean.AddToStatValue(1);
                listOfCurrentDisciplines.Add(resilience);
                listOfCurrentDisciplines.Add(animalism);
                listOfCurrentDisciplines.Add(vigor);
                listOfCurrentDisciplines.Add(protean);
                listOfCommonDisciplines.Remove(resilience);
                listOfCommonDisciplines.Remove(animalism);
                listOfClanDisciplines.Remove(protean);
                listOfCommonDisciplines.Remove(vigor);
                break;
            case Bloodline.Setite:
                resilience.AddToStatValue(1);
                majesty.AddToStatValue(1);
                animalism.AddToStatValue(1);
                protean.AddToStatValue(1);
                listOfCurrentDisciplines.Add(resilience);
                listOfCurrentDisciplines.Add(animalism);
                listOfCurrentDisciplines.Add(majesty);
                listOfCurrentDisciplines.Add(protean);
                listOfCommonDisciplines.Remove(resilience);
                listOfCommonDisciplines.Remove(animalism);
                listOfClanDisciplines.Remove(protean);
                listOfClanDisciplines.Remove(majesty);
                break;
            case Bloodline.Nicktuku:
                vigor.AddToStatValue(1);
                animalism.AddToStatValue(1);
                obfuscate.AddToStatValue(1);
                nightmare.AddToStatValue(1);
                listOfCurrentDisciplines.Add(animalism);
                listOfCurrentDisciplines.Add(vigor);
                listOfCurrentDisciplines.Add(obfuscate);
                listOfCurrentDisciplines.Add(nightmare);
                listOfCommonDisciplines.Remove(vigor);
                listOfCommonDisciplines.Remove(obfuscate);
                listOfClanDisciplines.Remove(nightmare);
                listOfCommonDisciplines.Remove(animalism);
                break;
            case Bloodline.Baali:
                vigor.AddToStatValue(1);
                obfuscate.AddToStatValue(1);
                nightmare.AddToStatValue(1);
                zagovny.AddToStatValue(1);
                listOfCurrentDisciplines.Add(zagovny);
                listOfCurrentDisciplines.Add(vigor);
                listOfCurrentDisciplines.Add(obfuscate);
                listOfCurrentDisciplines.Add(nightmare);
                listOfCommonDisciplines.Remove(vigor);
                listOfCommonDisciplines.Remove(obfuscate);
                listOfClanDisciplines.Remove(nightmare);
                break;
            case Bloodline.Cappodocian:
                vigor.AddToStatValue(1);
                obfuscate.AddToStatValue(1);
                nightmare.AddToStatValue(1);
                auspex.AddToStatValue(1);
                listOfCurrentDisciplines.Add(auspex);
                listOfCurrentDisciplines.Add(vigor);
                listOfCurrentDisciplines.Add(obfuscate);
                listOfCurrentDisciplines.Add(nightmare);
                listOfCommonDisciplines.Remove(vigor);
                listOfCommonDisciplines.Remove(obfuscate);
                listOfClanDisciplines.Remove(nightmare);
                listOfClanDisciplines.Remove(auspex);
                break;
            case Bloodline.Malkavian:
                celerity.AddToStatValue(1);
                obfuscate.AddToStatValue(1);
                auspex.AddToStatValue(1);
                dementation.AddToStatValue(1);
                listOfCurrentDisciplines.Add(celerity);
                listOfCurrentDisciplines.Add(obfuscate);
                listOfCurrentDisciplines.Add(auspex);
                listOfCurrentDisciplines.Add(dementation);
                listOfCommonDisciplines.Remove(celerity);
                listOfCommonDisciplines.Remove(obfuscate);
                listOfClanDisciplines.Remove(auspex);
                break;
            case Bloodline.Tremere:
                celerity.AddToStatValue(1);
                dominate.AddToStatValue(1);
                obfuscate.AddToStatValue(1);
                auspex.AddToStatValue(1);
                listOfCurrentDisciplines.Add(celerity);
                listOfCurrentDisciplines.Add(dominate);
                listOfCurrentDisciplines.Add(obfuscate);
                listOfCurrentDisciplines.Add(auspex);
                listOfCommonDisciplines.Remove(celerity);
                listOfCommonDisciplines.Remove(obfuscate);
                listOfClanDisciplines.Remove(auspex);
                listOfClanDisciplines.Remove(dominate);
                break;
            case Bloodline.Tzimisce:
                celerity.AddToStatValue(1);
                protean.AddToStatValue(1);
                obfuscate.AddToStatValue(1);
                auspex.AddToStatValue(1);
                listOfCurrentDisciplines.Add(celerity);
                listOfCurrentDisciplines.Add(protean);
                listOfCurrentDisciplines.Add(obfuscate);
                listOfCurrentDisciplines.Add(auspex);
                listOfCommonDisciplines.Remove(celerity);
                listOfCommonDisciplines.Remove(obfuscate);
                listOfClanDisciplines.Remove(auspex);
                listOfClanDisciplines.Remove(protean);
                break;
        }
        if (covenant == Covenant.CircleOfTheCrone)
        {
            cruacSorcery.AddToStatValue(1);
            listOfCurrentDisciplines.Add(cruacSorcery);
        }
        else if (covenant == Covenant.LanceaEtSanctum)
        {
            thebanSorcery.AddToStatValue(1);
            listOfCurrentDisciplines.Add(thebanSorcery);
        }
        else if (covenant == Covenant.OrdoDracul)
        {
            koldunicSorcery.AddToStatValue(1);
            listOfCurrentDisciplines.Add(koldunicSorcery);
        }
        else if (covenant == Covenant.BanuHaqim)
        {
            durAnKiSorcery.AddToStatValue(1);
            listOfCurrentDisciplines.Add(durAnKiSorcery);
        }
        else if (covenant == Covenant.ThePyramid)
        {
            thaumaturgy.AddToStatValue(1);
            listOfCurrentDisciplines.Add(thaumaturgy);
        }
        else if (covenant == Covenant.FollowersOfSet)
        {
            setiteSorcery.AddToStatValue(1);
            listOfCurrentDisciplines.Add(setiteSorcery);
        }
        else if (covenant == Covenant.HarbingersOfSkulls)
        {
            necromancy.AddToStatValue(1);
            listOfCurrentDisciplines.Add(necromancy);
        }
        else
        {
            AddANewDiscDot();
        }
    }
    public void AddInitialVtRDisciplines()
    {
        switch (vClan)
        {
            case VampireClan.Daeva:
                celerity.AddToStatValue(1);
                vigor.AddToStatValue(1);
                majesty.AddToStatValue(1);
                listOfCurrentDisciplines.Add(celerity);
                listOfCurrentDisciplines.Add(vigor);
                listOfCurrentDisciplines.Add(majesty);
                listOfCommonDisciplines.Remove(celerity);
                listOfCommonDisciplines.Remove(vigor);
                listOfClanDisciplines.Remove(majesty);
                break;
            case VampireClan.Gangrel:
                resilience.AddToStatValue(1);
                animalism.AddToStatValue(1);
                protean.AddToStatValue(1);
                listOfCurrentDisciplines.Add(resilience);
                listOfCurrentDisciplines.Add(animalism);
                listOfCurrentDisciplines.Add(protean);
                listOfCommonDisciplines.Remove(resilience);
                listOfCommonDisciplines.Remove(animalism);
                listOfClanDisciplines.Remove(protean);
                break;
            case VampireClan.Mekhet:
                celerity.AddToStatValue(1);
                obfuscate.AddToStatValue(1);
                auspex.AddToStatValue(1);
                listOfCurrentDisciplines.Add(celerity);
                listOfCurrentDisciplines.Add(obfuscate);
                listOfCurrentDisciplines.Add(auspex);
                listOfCommonDisciplines.Remove(celerity);
                listOfCommonDisciplines.Remove(obfuscate);
                listOfClanDisciplines.Remove(auspex);
                break;
            case VampireClan.Nosferatu:
                vigor.AddToStatValue(1);
                obfuscate.AddToStatValue(1);
                nightmare.AddToStatValue(1);
                listOfCurrentDisciplines.Add(vigor);
                listOfCurrentDisciplines.Add(obfuscate);
                listOfCurrentDisciplines.Add(nightmare);
                listOfCommonDisciplines.Remove(vigor);
                listOfCommonDisciplines.Remove(obfuscate);
                listOfClanDisciplines.Remove(nightmare);
                break;
            case VampireClan.Ventrue:
                resilience.AddToStatValue(1);
                animalism.AddToStatValue(1);
                dominate.AddToStatValue(1);
                listOfCurrentDisciplines.Add(resilience);
                listOfCurrentDisciplines.Add(animalism);
                listOfCurrentDisciplines.Add(dominate);
                listOfCommonDisciplines.Remove(resilience);
                listOfCommonDisciplines.Remove(animalism);
                listOfClanDisciplines.Remove(dominate);
                break;
        }
        switch (covenant)
        {
            case Covenant.CircleOfTheCrone:
                cruacSorcery.AddToStatValue(1);
                listOfCurrentDisciplines.Add(cruacSorcery);
                break;
            case Covenant.LanceaEtSanctum:
                thebanSorcery.AddToStatValue(1);
                listOfCurrentDisciplines.Add(thebanSorcery);
                break;
            case Covenant.OrdoDracul:
                coilsOfTheDragon.AddToStatValue(1);
                listOfCurrentDisciplines.Add(coilsOfTheDragon);
                break;
            case Covenant.BelialsBrood:
                int rand = Random.Range(1, 5);
                if (rand == 1)
                {
                    scourge.AddToStatValue(1);
                    listOfCurrentDisciplines.Add(scourge);
                }
                else
                {
                    AddANewDiscDot();
                }
                break;
            default:
                AddANewDiscDot();
                break;
        }
    }
    #endregion
    #region Setting VTRBloodlines
    private void SetDaevaBloodline()
    {
        int rand = Random.Range(1, 23);
        vBloodline = rand switch
        {
            1 => Bloodline.AmaraHavana,
            2 => Bloodline.Anvari,
            3 => Bloodline.TheCarnival,
            4 => Bloodline.ChildrenOfJudas,
            5 => Bloodline.Erzsebet,
            6 => Bloodline.Eupraxus,
            7 => Bloodline.Gulikan,
            8 => Bloodline.Jharana,
            9 => Bloodline.Kallisti,
            10 => Bloodline.Kinnaree,
            11 => Bloodline.Liderc,
            12 => Bloodline.Malintzin,
            13 => Bloodline.Naditu,
            14 => Bloodline.Nelapsi,
            15 => Bloodline.Spina,
            16 => Bloodline.CaliforniaXiao,
            17 => Bloodline.TianpanXiao,
            18 => Bloodline.Zelani,
            19 => Bloodline.Asnam,
            20 => Bloodline.Duchagne,
            21 => Bloodline.Septemi,
            _ => Bloodline.MortifiersOfTheFlesh
        };
    }
    private void SetGangrelBloodline()
    {
        int rand = Random.Range(1, 22);
        vBloodline = rand switch
        {
            1 => Bloodline.Annunaku,
            2 => Bloodline.Barjot,
            3 => Bloodline.Bohagande,
            4 => Bloodline.Carnon,
            5 => Bloodline.ChilderOfTheMorrigan,
            6 => Bloodline.DeadWolves,
            7 => Bloodline.Empusae,
            8 => Bloodline.HoundsOfActaeon,
            9 => Bloodline.Kerberos,
            10 => Bloodline.LesGensLibres,
            11 => Bloodline.Larvae,
            12 => Bloodline.Mabry,
            13 => Bloodline.TheMara,
            14 => Bloodline.Moroi,
            15 => Bloodline.Nepheshim,
            16 => Bloodline.Nosoi,
            17 => Bloodline.Oberlochs,
            18 => Bloodline.Shepherds,
            19 => Bloodline.Taifa,
            20 => Bloodline.Mystikoi,
            _ => Bloodline.Vedma
        };
    }
    private void SetMekhetBloodline()
    {
        int rand = Random.Range(1, 21);
        vBloodline = rand switch
        {
            1 => Bloodline.Agonistes,
            2 => Bloodline.Alucinor,
            3 => Bloodline.Angustri,
            4 => Bloodline.BakRa,
            5 => Bloodline.BrothersOfYpres,
            6 => Bloodline.Csalad,
            7 => Bloodline.Kuufukuji,
            8 => Bloodline.Icelus,
            9 => Bloodline.Iltani,
            10 => Bloodline.Libitinarius,
            11 => Bloodline.Lynx,
            12 => Bloodline.Mnemosyne,
            13 => Bloodline.Morbus,
            14 => Bloodline.Norvegi,
            15 => Bloodline.Players,
            16 => Bloodline.Qedeshah,
            17 => Bloodline.Tismanu,
            18 => Bloodline.Sangiovanni,
            19 => Bloodline.Khaibit,
            _ => Bloodline.Osite
        };
    }
    private void SetNosferatuBloodline()
    {
        int rand = Random.Range(1, 20);
        vBloodline = rand switch
        {
            1 => Bloodline.Azerkatil,
            2 => Bloodline.Burakumin,
            3 => Bloodline.Calacas,
            4 => Bloodline.Cimitiere,
            5 => Bloodline.Caporetti,
            6 => Bloodline.TheCockscombSociety,
            7 => Bloodline.Galloi,
            8 => Bloodline.Gethsemani,
            9 => Bloodline.Lygos,
            10 => Bloodline.Morotrophians,
            11 => Bloodline.OrderOfSirMartin,
            12 => Bloodline.Rakshasa,
            13 => Bloodline.Telamones,
            14 => Bloodline.Usiri,
            15 => Bloodline.Vilseduire,
            16 => Bloodline.Yagnatia,
            17 => Bloodline.Mayarap,
            18 => Bloodline.Adroanzi,
            _ => Bloodline.Baddacelli
        };
    }
    private void SetVentrueBloodline()
    {
        int rand = Random.Range(1, 20);
        vBloodline = rand switch
        {
            1 => Bloodline.Adrestoi,
            2 => Bloodline.Bron,
            3 => Bloodline.CandaBhanu,
            4 => Bloodline.Corajoso,
            5 => Bloodline.Deucalion,
            6 => Bloodline.Dragolescu,
            7 => Bloodline.Geheim,
            8 => Bloodline.Gorgons,
            9 => Bloodline.Icarians,
            10 => Bloodline.Macellarius,
            11 => Bloodline.Malocusians,
            12 => Bloodline.Melissidae,
            13 => Bloodline.Nahualli,
            14 => Bloodline.Rotgrafen,
            15 => Bloodline.Sotoha,
            16 => Bloodline.TheSonsOfCade,
            17 => Bloodline.Vardyvle,
            18 => Bloodline.Apollinaire,
            _ => Bloodline.ArchitectsOfTheMonolith
        };
    }
    #endregion
    #region Merits and Experience
    public override void AddExperience()
    {
        int attributesOrDiscsToAdd = (int)Mathf.Sqrt(embraceAge);
        int skillsToAdd = (int)(Mathf.Sqrt(embraceAge)*1.2);
        int meritsToAdd = (int)(Mathf.Sqrt(embraceAge)*0.5);
        if (attributesOrDiscsToAdd > 0)
        {
            for (int i = 0; i < attributesOrDiscsToAdd; i++)
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
        if (attributesOrDiscsToAdd > 0)
        {
            for (int i = 0; i < attributesOrDiscsToAdd; i++)
            {
                AddARandomDiscDot();
            }
        }
        if (meritsToAdd > 0)
        {
            for (int i = 0; i < meritsToAdd; i++)
            {
                AddMerit();
            }
        }
        int humVariable = (int)(Mathf.Sqrt(embraceAge)/5);
        integrity = Mathf.Clamp(integrity - Random.Range(-1, humVariable), 1, 8);
        willpower = Mathf.Clamp(willpower + Random.Range(humVariable / 2, humVariable * 2), 1, 10);
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
    private void SetPrioritiesByClan()
    {
        if (isWoDcharacter == false)
        {
            switch (vClan)
            {
                case VampireClan.Daeva:
                    SetSocialPriority();
                    break;
                case VampireClan.Gangrel:
                    SetPhysicalPriority();
                    break;
                case VampireClan.Nosferatu:
                    SetMentalPriority();
                    break;
                case VampireClan.Mekhet:
                    SetMentalPriority();
                    break;
                case VampireClan.Ventrue:
                    SetSocialPriority();
                    break;
                default:
                    SetSocialPriority();
                    break;
            }
        }
        else
        {
            switch (vBloodline)
            {
                case Bloodline.Toreador:
                    SetSocialPriority();
                    break;
                case Bloodline.Kiasyd:
                    SetMentalOrSocialPriority();
                    break;
                case Bloodline.DaughtersOfCacophony:
                    SetSocialPriority();
                    break;
                case Bloodline.Gangrel:
                    SetPhysicalPriority();
                    break;
                case Bloodline.Bruja:
                    SetPhysicalPriority();
                    break;
                case Bloodline.Setite:
                    SetRandomPriority();
                    break;
                case Bloodline.Nicktuku:
                    SetRandomPriority();
                    break;
                case Bloodline.Baali:
                    SetMentalPriority();
                    break;
                case Bloodline.Cappodocian:
                    SetMentalPriority();
                    break;
                case Bloodline.Tzimisce:
                    SetRandomPriority();
                    break;
                case Bloodline.Tremere:
                    SetMentalPriority();
                    break;
                case Bloodline.Malkavian:
                    SetRandomPriority();
                    break;
                case Bloodline.Ventru:
                    SetSocialPriority();
                    break;
                case Bloodline.Lasombra:
                    SetMentalOrSocialPriority();
                    break;
                case Bloodline.Giovanni:
                    SetMentalPriority();
                    break;
                default:
                    SetSocialPriority();
                    break;
            }
        }
    }
    private void SetVampireCovenant(int covNum = 0)
    {
        int numberForCovenent = covNum;
        if (covNum == 0)
        {
            numberForCovenent = Random.Range(1, 12);
        }

        if (numberForCovenent == 1)
        {
            covenant = Covenant.Invictus;
        }
        else if (numberForCovenent == 2)
        {
            covenant = Covenant.CarthianMovement;
        }
        else if (numberForCovenent == 3)
        {
            covenant = Covenant.OrdoDracul;
        }
        else if (numberForCovenent == 4)
        {
            covenant = Covenant.LanceaEtSanctum;
        }
        else if (numberForCovenent == 5)
        {
            covenant = Covenant.CircleOfTheCrone;
        }
        else if (numberForCovenent == 6)
        {
            covenant = Covenant.BanuHaqim;
        }
        else if (numberForCovenent == 7)
        {
            covenant = Covenant.ThePyramid;
        }
        else if (numberForCovenent == 8)
        {
            covenant = Covenant.FollowersOfSet;
        }
        else if (numberForCovenent == 9)
        {
            covenant = Covenant.HarbingersOfSkulls;
        }
        else if (numberForCovenent == 10)
        {
            covenant = Covenant.BelialsBrood;
        }
        else if (numberForCovenent == 11)
        {
            covenant = Covenant.VII;
        }
    }

    //VampireClan excluding Bloodlines for non-WoD currently
    private void SetVampireClan()
    {
        if (isWoDcharacter == false)
        {
            int rand = Random.Range(1, 6);
            vClan = rand switch
            {
                1 => VampireClan.Daeva,
                2 => VampireClan.Gangrel,
                3 => VampireClan.Mekhet,
                4 => VampireClan.Nosferatu,
                _ => VampireClan.Ventrue,
            };
            /*
            switch (vClan)
            {
                case VampireClan.Daeva:
                    SetDaevaBloodline();
                    break;
                case VampireClan.Gangrel:
                    SetGangrelBloodline();
                    break;
                case VampireClan.Mekhet:
                    SetMekhetBloodline();
                    break;
                case VampireClan.Nosferatu:
                    SetNosferatuBloodline();
                    break;
                case VampireClan.Ventrue:
                    SetVentrueBloodline();
                    break;
            }
            */
            vBloodline = Bloodline.None;
        }
        else
        {

            if (covenant == Covenant.Invictus || covenant == Covenant.CarthianMovement || covenant == Covenant.LanceaEtSanctum)
            {
                SetWoDRandomClan();
            }
            else if (covenant == Covenant.CircleOfTheCrone)
            {
                charConcept = "";
                int rand = Random.Range(1, 4);
                if (rand < 3)
                {
                    vClan = VampireClan.Gangrel;
                    vBloodline = Bloodline.Gangrel;
                }
                else
                {
                    SetWoDRandomClan();
                }
            }
            else if (covenant == Covenant.OrdoDracul)
            {
                charConcept = "";
                int rand = Random.Range(1, 8);
                if (rand < 6)
                {
                    vClan = VampireClan.Mekhet;
                    vBloodline = Bloodline.Tzimisce;
                }
                else
                {
                    SetWoDRandomClan();
                }
            }
            else if (covenant == Covenant.BanuHaqim)
            {
                SetWoDRandomClan();
            }
            else if (covenant == Covenant.ThePyramid)
            {
                charConcept = "";
                int rand = Random.Range(1, 12);
                if (rand < 11)
                {
                    vClan = VampireClan.Ventrue;
                    vBloodline = Bloodline.Tremere;
                }
                else
                {
                    SetWoDRandomClan();
                }
            }
            else if (covenant == Covenant.FollowersOfSet)
            {
                charConcept = "";
                int rand = Random.Range(1, 12);
                if (rand < 11)
                {
                    vClan = VampireClan.Gangrel;
                    vBloodline = Bloodline.Setite;
                }
                else
                {
                    SetWoDRandomClan();
                }
            }
            else if (covenant == Covenant.HarbingersOfSkulls)
            {
                charConcept = "";
                int rand = Random.Range(1, 12);
                if (rand < 6)
                {
                    vClan = VampireClan.Nosferatu;
                    vBloodline = Bloodline.Cappodocian;
                }
                else if (rand < 11)
                {
                    vClan = VampireClan.Ventrue;
                    vBloodline = Bloodline.Giovanni;
                }
                else
                {
                    SetWoDRandomClan();
                }
            }
            else if (covenant == Covenant.BelialsBrood)
            {
                charConcept = "";
                int rand = Random.Range(1, 14);
                if (rand < 4)
                {
                    vClan = VampireClan.Mekhet;
                    vBloodline = Bloodline.Tzimisce;
                }
                else if (rand < 9)
                {
                    vClan = VampireClan.Ventrue;
                    vBloodline = Bloodline.Lasombra;
                }
                else
                {
                    SetWoDRandomClan();
                }
            }
            else if (covenant == Covenant.VII)
            {
                charConcept = "";
                int rand = Random.Range(1, 20);
                if (rand < 5)
                {
                    vClan = VampireClan.Mekhet;
                    vBloodline = Bloodline.Tzimisce;
                }
                else if (rand < 9)
                {
                    vClan = VampireClan.Ventrue;
                    vBloodline = Bloodline.Lasombra;
                }
                else if (rand < 10)
                {
                    vClan = VampireClan.Ventrue;
                    vBloodline = Bloodline.Giovanni;
                }
                else if (rand < 11)
                {
                    vClan = VampireClan.Mekhet;
                    vBloodline = Bloodline.Cappodocian;
                }
                else
                {
                    SetWoDRandomClan();
                }
            }
        }
    }
    public void SetWoDRandomClan()
    {
        int rand = Random.Range(1, 101);
        if (rand < 21)
        {
            vClan = VampireClan.Daeva;
            vBloodline = Bloodline.Toreador;
        }
        else if (rand < 41)
        {
            vClan = VampireClan.Ventrue;
            vBloodline = Bloodline.Ventru;
        }
        else if (rand < 51)
        {
            vClan = VampireClan.Gangrel;
            vBloodline = Bloodline.Gangrel;
        }
        else if (rand < 71)
        {
            vClan = VampireClan.Gangrel;
            vBloodline = Bloodline.Bruja;
        }
        else if (rand < 85)
        {
            vClan = VampireClan.Nosferatu;
            vBloodline = Bloodline.Nicktuku;
        }
        else if (rand < 97)
        {
            vClan = VampireClan.Mekhet;
            vBloodline = Bloodline.Malkavian;
        }
        else if (rand < 99)
        {
            vClan = VampireClan.Daeva;
            vBloodline = Bloodline.Kiasyd;
        }
        else
        {
            vClan = VampireClan.Daeva;
            vBloodline = Bloodline.DaughtersOfCacophony;
        }
    }

    public override void SetName(string inputName = "")
    {
        if (inputName == "")
        {
            if (vBloodline == Bloodline.Giovanni)
            {
                charName = Nationality.Instance.GetNameForChar(genderM, true);
            }
            else
            {
                charName = Nationality.Instance.GetNameForChar(genderM);
            }
        }
        else
        {
            charName = inputName;
        }

    }
    public override void SetAge()
    {
        base.SetAge();
        appearedAge = age;        
    }
    private void SetEmbraceAge()
    {charConcept = "";
        int rand = Random.Range(1, 100);
        if (rand > 70)
        {
            embraceAge = Random.Range(1, 20);
        }
        else if (rand > 40)
        {
            embraceAge = Random.Range(20, 100);
        }
        else if (rand > 10)
        {
            embraceAge = Random.Range(100, 200);
        }
        else if (rand > 2)
        {
            embraceAge = Random.Range(200, 500);
        }
        else
        {
            embraceAge = Random.Range(500, 4000);
        }
    }
    private void SetVampirePotency()
    {charConcept = "";
        int age = GetEmbraceAge();
        if (age < 20)
        {
            SetPotency(1);
        }
        else if (age < 60)
        {
            SetPotency(2);
        }
        else if (age < 100)
        {
            SetPotency(3);
        }
        else if (age < 200)
        {
            SetPotency(4);
        }
        else if (age < 300)
        {
            SetPotency(5);
        }
        else if (age < 500)
        {
            SetPotency(Random.Range(5, 7));
        }
        else if (age < 1000)
        {
            SetPotency(Random.Range(5, 8));
        }
        else if (age < 1500)
        {
            SetPotency(Random.Range(6, 9));
        }
        else if (age < 2000)
        {
            SetPotency(Random.Range(6, 10));
        }
        else
        {
            SetPotency(Random.Range(7, 11));
        }
    }
    private void SetStartingVitae()
    {
        vitae = Random.Range(1, 11);
    }
    public override void SetSpeed()
    {
        base.SetSpeed();
        speed += vigor.GetStatValue();
    }
    public override void SetDefence()
    {
        base.SetDefence();
        defence += celerity.GetStatValue();
    }
    public override void SetHealth()
    {
        base.SetHealth();
        health += resilience.GetStatValue();
    }
    private void SetMask()
    {
        int rand = Random.Range(1, 28);
        mask = rand switch
        {
            1 => "Authoritarian",
            2 => "Child",
            3 => "Competitor",
            4 => "Conformist",
            5 => "Conspirator",
            6 => "Courtesan",
            7 => "Cult Leader",
            8 => "Deviant",
            9 => "Follower",
            10 => "Guru",
            11 => "Idealist",
            12 => "Jester",
            13 => "Junkie",
            14 => "Martyr",
            15 => "Masochist",
            16 => "Monster",
            17 => "Nomad",
            18 => "Nurturer",
            19 => "Perfectionist",
            20 => "Penitent",
            21 => "Questioner",
            22 => "Rebel",
            23 => "Scholar",
            24 => "Social Chameleon",
            25 => "Spy",
            26 => "Survivor",
            _ => "Visionary",
        };
    }
    private void SetDirge()
    {
        int rand = Random.Range(1, 28);
        dirge = rand switch
        {
            1 => "Authoritarian",
            2 => "Child",
            3 => "Competitor",
            4 => "Conformist",
            5 => "Conspirator",
            6 => "Courtesan",
            7 => "Cult Leader",
            8 => "Deviant",
            9 => "Follower",
            10 => "Guru",
            11 => "Idealist",
            12 => "Jester",
            13 => "Junkie",
            14 => "Martyr",
            15 => "Masochist",
            16 => "Monster",
            17 => "Nomad",
            18 => "Nurturer",
            19 => "Perfectionist",
            20 => "Penitent",
            21 => "Questioner",
            22 => "Rebel",
            23 => "Scholar",
            24 => "Social Chameleon",
            25 => "Spy",
            26 => "Survivor",
            _ => "Visionary",
        };

        if (mask == dirge)
        {
            SetDirge();
        }
    }    
    public override void GenerateConcept()
    {
        int rand = Random.Range(1, 4);

        if (rand == 4)
        {
            rand = Random.Range(1, 26);
            charConcept = rand switch
            {
                1 => "Activist",
                2 => "Artist",
                3 => "Athlete",
                4 => "Caretaker",
                5 => "Criminal",
                6 => "Drifter",
                7 => "Entertainer",
                8 => "Executive",
                9 => "Guardian",
                10 => "Intellectual",
                11 => "Investigator",
                12 => "Kid",
                13 => "Labourer",
                14 => "Mystic",
                15 => "Night-Owl",
                16 => "Outsider",
                17 => "Politician",
                18 => "Professional",
                19 => "Rebel",
                20 => "Reporter",
                21 => "Scenester",
                22 => "Socialite",
                23 => "Soldier",
                24 => "Technician",
                25 => "Warrior",
                _ => "Worker",
            };
        }
        else
        {
            CharStat highestSkill = GetHighestSkill();
            switch (highestSkill.GetStatName())
            {
                case "academics":
                    if (rand == 1)
                    {
                        charConcept = "Librarian";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Anthropologist";
                    }
                    else
                    {
                        charConcept = "Teacher";
                    }
                    break;
                case "computer":
                    if (rand == 1)
                    {
                        charConcept = "Hacker";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Programmer";
                    }
                    else
                    {
                        charConcept = "Data Analyst";
                    }
                    break;
                case "crafts":
                    if (rand == 1)
                    {
                        charConcept = "Tailor";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Smith";
                    }
                    else
                    {
                        charConcept = "Mechanic";
                    }
                    break;
                case "investigation":
                    if (rand == 1)
                    {
                        charConcept = "Detective";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Private Investigator";
                    }
                    else
                    {
                        charConcept = "Lab Tech";
                    }
                    break;
                case "medicine":
                    if (rand == 1)
                    {
                        charConcept = "Doctor";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Psychiatrist";
                    }
                    else
                    {
                        charConcept = "Surgeon";
                    }
                    break;
                case "occult":
                    if (covenant == Covenant.LanceaEtSanctum)
                    {
                        charConcept = "Priest";
                    }
                    else if (covenant == Covenant.CircleOfTheCrone)
                    {
                        charConcept = "Wiccan";
                    }
                    else if (covenant == Covenant.ThePyramid)
                    {
                        charConcept = "Warlock";
                    }
                    else
                    {
                        charConcept = "Professor";
                    }
                    break;
                case "politics":
                    if (rand == 1)
                    {
                        charConcept = "Administrator";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Bureaucrat";
                    }
                    else
                    {
                        charConcept = "Politician";
                    }
                    break;
                case "science":
                    if (rand == 1)
                    {
                        charConcept = "Geneticist";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Chemist";
                    }
                    else
                    {
                        charConcept = "Physicist";
                    }
                    break;
                case "athletics":
                    if (rand == 1)
                    {
                        charConcept = "Swimmer";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Footballer";
                    }
                    else
                    {
                        charConcept = "Athlete";
                    }
                    break;
                case "brawl":
                    if (rand == 1)
                    {
                        charConcept = "Boxer";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "MMA Fighter";
                    }
                    else
                    {
                        charConcept = "Cop";
                    }
                    break;
                case "drive":
                    if (rand == 1)
                    {
                        charConcept = "Taxi Driver";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Racing Driver";
                    }
                    else
                    {
                        charConcept = "Truck Driver";
                    }
                    break;
                case "firearms":
                    if (rand == 1)
                    {
                        charConcept = "Soldier";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Cop";
                    }
                    else
                    {
                        charConcept = "Hunter";
                    }
                    break;
                case "larceny":
                    if (rand == 1)
                    {
                        charConcept = "Burglar";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Locksmith";
                    }
                    else
                    {
                        charConcept = "Security Expert";
                    }
                    break;
                case "stealth":
                    if (rand == 1)
                    {
                        charConcept = "Burglar";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Hunter";
                    }
                    else
                    {
                        charConcept = "Spy";
                    }
                    break;
                case "survival":
                    if (rand == 1)
                    {
                        charConcept = "Survivalist";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Camper";
                    }
                    else
                    {
                        charConcept = "Hunter";
                    }
                    break;
                case "weaponry":
                    if (rand == 1)
                    {
                        charConcept = "Martial Aritst";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Thug";
                    }
                    else
                    {
                        charConcept = "Soldier";
                    }
                    break;
                case "animalKen":
                    if (rand == 1)
                    {
                        charConcept = "Dog Breeder";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Farmer";
                    }
                    else
                    {
                        charConcept = "Herder";
                    }
                    break;
                case "empathy":
                    if (rand == 1)
                    {
                        charConcept = "Nurse";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Therapist";
                    }
                    else
                    {
                        charConcept = "Teacher";
                    }
                    break;
                case "expression":
                    if (rand == 1)
                    {
                        charConcept = "Artist";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Dancer";
                    }
                    else
                    {
                        charConcept = "Musician";
                    }
                    break;
                case "intimidation":
                    if (rand == 1)
                    {
                        charConcept = "Gang Member";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Debt Collector";
                    }
                    else
                    {
                        charConcept = "Security Guard";
                    }
                    break;
                case "persuasion":
                    if (rand == 1)
                    {
                        charConcept = "Diplomat";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Executive";
                    }
                    else
                    {
                        charConcept = "Dilettante";
                    }
                    break;
                case "socialise":
                    if (rand == 1)
                    {
                        charConcept = "Socialite";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Bartender";
                    }
                    else
                    {
                        charConcept = "Dilettante";
                    }
                    break;
                case "streetwise":
                    if (rand == 1)
                    {
                        charConcept = "Gang Member";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Drug Dealer";
                    }
                    else
                    {
                        charConcept = "Cop";
                    }
                    break;
                case "subterfuge":
                    if (rand == 1)
                    {
                        charConcept = "Spy";
                    }
                    else if (rand == 2)
                    {
                        charConcept = "Politician";
                    }
                    else
                    {
                        charConcept = "Con Artist";
                    }
                    break;
            }
        }        
    }

    #endregion
    #region Getters
    public int GetEmbraceAge()
    {
        return embraceAge;
    }
    public float GetEmbraceYear()
    {
        return 2000 - embraceAge;
    }
    public int GetAppearedAge() 
    {
        return appearedAge;
    }
    public VampireClan GetClan()
    {
        return vClan;
    }
    public Bloodline GetBloodline()
    {
        return vBloodline;
    }
    public Covenant GetCovenant()
    {
        return covenant;
    }
    public int GetVitae()
    {
        return vitae;
    }
    public string GetMask()
    {
        return mask;
    }
    public string GetDirge()
    {
        return dirge;
    }
    #endregion
    #region DisciplineList
    private void InstantiateDisciplines()
    {
        vigor = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        celerity = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        resilience = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        animalism = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        obfuscate = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        auspex = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        dominate = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        majesty = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        nightmare = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        protean = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        dementation = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        durAnKiSorcery = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        setiteSorcery = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        thaumaturgy = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        necromancy = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        koldunicSorcery = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        taliesin = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        vodoun = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        coilsOfTheDragon = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        cruacSorcery = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        thebanSorcery = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        ahraniteSorcery = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        thanatology = Instantiate(statPrefab, transform).GetComponent<CharStat>();

        abjurism = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        gildedCage = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        mimetismo = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        obtenebration = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        scourge = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        amphivena = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        asphyx = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        bahumisparsa = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        bloodworking = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        blutAlchemie = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        cachexy = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        carrefour = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        cattiveria = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        constance = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        courtoisie = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        crochan = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        deadSignal = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        despond = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        domus = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        embrocation = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        essentiaphagia = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        eupraxia = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        getsumei = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        gustus = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        hypnagogia = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        impurity = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        insomnium = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        institutionalise = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        kamen = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        kingjan = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        licencieux = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        linagem = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        lithopedia = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        mementoMori = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        meminisse = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        mortualia = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        nahdad = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        nburu = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        nepenthe = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        ortam = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        perfidy = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        phagia = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        ralab = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        saktiPata = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        serendipity = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        shihai = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        spiritusSancti = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        stigmatica = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        sublunario = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        suikast = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        sunnikuse = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        taurobolium = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        tenure = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        tezcatl = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        theShow = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        web = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        xinyao = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        zagovny = Instantiate(statPrefab, transform).GetComponent<CharStat>();
        InitialiseDisciplines();
        PopulateDiscList();
    }
    private void InitialiseDisciplines()
    {
        vigor.InitialiseStat("Vigor");
        celerity.InitialiseStat("Celerity");
        resilience.InitialiseStat("Resilience");
        animalism.InitialiseStat("Animalism");
        obfuscate.InitialiseStat("Obfuscate");
        auspex.InitialiseStat("Auspex");
        dominate.InitialiseStat("Dominate");
        majesty.InitialiseStat("Majesty");
        nightmare.InitialiseStat("Nightmare");
        protean.InitialiseStat("Protean");
        dementation.InitialiseStat("Dementation");
        durAnKiSorcery.InitialiseStat("DurAnKiSorcery");
        setiteSorcery.InitialiseStat("SetiteSorcery");
        thaumaturgy.InitialiseStat("Thaumaturgy");
        necromancy.InitialiseStat("Necromancy");
        koldunicSorcery.InitialiseStat("KoldunicSorcery");
        taliesin.InitialiseStat("Taliesin");
        vodoun.InitialiseStat("Vodoun");
        coilsOfTheDragon.InitialiseStat("CoilsOfTheDragon");
        cruacSorcery.InitialiseStat("CruacSorcery");
        thebanSorcery.InitialiseStat("ThebanSorcery");
        ahraniteSorcery.InitialiseStat("AhraniteSorcery");
        thanatology.InitialiseStat("Thanatology");

        abjurism.InitialiseStat("abjurism");
        gildedCage.InitialiseStat("gildedCage");
        mimetismo.InitialiseStat("mimetismo");
        obtenebration.InitialiseStat("obtenebration");
        scourge.InitialiseStat("scourge");
        amphivena.InitialiseStat("amphivena");
        asphyx.InitialiseStat("asphyx");
        bahumisparsa.InitialiseStat("bahumisparsa");
        bloodworking.InitialiseStat("bloodworking");
        blutAlchemie.InitialiseStat("blutAlchemie");
        cachexy.InitialiseStat("cachexy");
        carrefour.InitialiseStat("carrefour");
        cattiveria.InitialiseStat("cattiveria");
        constance.InitialiseStat("constance");
        courtoisie.InitialiseStat("courtoisie");
        crochan.InitialiseStat("crochan");
        deadSignal.InitialiseStat("deadSignal");
        despond.InitialiseStat("despond");
        domus.InitialiseStat("domus");
        embrocation.InitialiseStat("embrocation");
        essentiaphagia.InitialiseStat("essentiaphagia");
        eupraxia.InitialiseStat("eupraxia");
        getsumei.InitialiseStat("getsumei");
        gustus.InitialiseStat("gustus");
        hypnagogia.InitialiseStat("hypnagogia");
        impurity.InitialiseStat("impurity");
        insomnium.InitialiseStat("insomnium");
        institutionalise.InitialiseStat("institutionalise");
        kamen.InitialiseStat("kamen");
        kingjan.InitialiseStat("kingjan");
        licencieux.InitialiseStat("licencieux");
        linagem.InitialiseStat("linagem");
        lithopedia.InitialiseStat("lithopedia");
        mementoMori.InitialiseStat("mementoMori");
        meminisse.InitialiseStat("meminisse");
        mortualia.InitialiseStat("mortualia");
        nahdad.InitialiseStat("nahdad");
        nburu.InitialiseStat("nburu");
        nepenthe.InitialiseStat("nepenthe");
        ortam.InitialiseStat("ortam");
        perfidy.InitialiseStat("perfidy");
        phagia.InitialiseStat("phagia");
        ralab.InitialiseStat("ralab");
        saktiPata.InitialiseStat("saktiPata");
        serendipity.InitialiseStat("serendipity");
        shihai.InitialiseStat("shihai");
        spiritusSancti.InitialiseStat("spiritusSancti");
        stigmatica.InitialiseStat("stigmatica");
        sublunario.InitialiseStat("sublunario");
        suikast.InitialiseStat("suikast");
        sunnikuse.InitialiseStat("sunnikuse");
        taurobolium.InitialiseStat("taurobolium");
        tenure.InitialiseStat("tenure");
        tezcatl.InitialiseStat("tezcatl");
        theShow.InitialiseStat("theShow");
        web.InitialiseStat("web");
        xinyao.InitialiseStat("xinyao");
        zagovny.InitialiseStat("zagovny");
    }
    private void PopulateDiscList()
    {
        listOfAllDisciplines = new List<CharStat>
        {
            vigor,
            celerity,
            resilience,
            animalism,
            obfuscate,
            auspex,
            dominate,
            majesty,
            nightmare,
            protean,
            dementation,
            durAnKiSorcery,
            setiteSorcery,
            thaumaturgy,
            necromancy,
            koldunicSorcery,
            taliesin,
            vodoun,
            coilsOfTheDragon,
            cruacSorcery,
            thebanSorcery,
            ahraniteSorcery,
            thanatology,
            abjurism,
            gildedCage,
            mimetismo,
            obtenebration,
            scourge,
            amphivena,
            asphyx,
            bahumisparsa,
            bloodworking,
            blutAlchemie,
            cachexy,
            carrefour,
            cattiveria,
            constance,
            courtoisie,
            crochan,
            deadSignal,
            despond,
            domus,
            embrocation,
            essentiaphagia,
            eupraxia,
            getsumei,
            gustus,
            hypnagogia,
            impurity,
            insomnium,
            institutionalise,
            kamen,
            kingjan,
            licencieux,
            linagem,
            lithopedia,
            mementoMori,
            meminisse,
            mortualia,
            nahdad,
            nburu,
            nepenthe,
            ortam,
            perfidy,
            phagia,
            ralab,
            saktiPata,
            serendipity,
            shihai,
            spiritusSancti,
            stigmatica,
            sublunario,
            suikast,
            sunnikuse,
            taurobolium,
            tenure,
            tezcatl,
            theShow,
            web,
            xinyao,
            zagovny
        };
        listOfCommonDisciplines = new List<CharStat>
        {
            vigor,
            celerity,
            resilience,
            animalism,
            obfuscate,
        };
        listOfClanDisciplines = new List<CharStat>
        {            
            auspex,
            dominate,
            majesty,
            nightmare,
            protean
        };
        listOfCurrentDisciplines = new List<CharStat>();
    }
    public CharStat GetDisciplineByName(string nameOfDisc)
    {charConcept = "";
        CharStat statToReturn = null;
        foreach (CharStat stat in listOfAllDisciplines)
        {
            if (stat.GetStatName() == nameOfDisc)
            {
                statToReturn = stat;
            }
        }
        return statToReturn;
    }
    public List<CharStat> GetCurrentDisciplinesList()
    {
        return listOfCurrentDisciplines;
    }
    public void AddARandomDiscDot()
    {charConcept = "";
        int rand = Random.Range(1, 11);
        if (rand > 4) 
        {
            AddAnExistingDiscDot();
        }
        else
        {
            AddANewDiscDot();
        }
    }
    public void AddAnExistingDiscDot()
    {charConcept = "";
        int rand = Random.Range(0,listOfCurrentDisciplines.Count);
        if (listOfCurrentDisciplines[rand].GetStatValue() < maxAttributeSkill)
        {
            listOfCurrentDisciplines[rand].AddToStatValue(1);
        }
        else
        {
            AddANewDiscDot();
        }
    }
    public void AddANewDiscDot()
    {charConcept = "";
        int rand = Random.Range(1, 20);
        if (rand < 18)
        {
            if (listOfCommonDisciplines.Count > 0)
            {
                rand = Random.Range(0, listOfCommonDisciplines.Count);
                CharStat statToAdd = listOfCommonDisciplines[rand];
                statToAdd.AddToStatValue(1);
                listOfCurrentDisciplines.Add(statToAdd);
                listOfCommonDisciplines.Remove(statToAdd);
            }
            else if (listOfClanDisciplines.Count > 0)
            {
                rand = Random.Range(0, listOfClanDisciplines.Count);
                CharStat statToAdd = listOfClanDisciplines[rand];
                statToAdd.AddToStatValue(1);
                listOfClanDisciplines.Add(statToAdd);
                listOfCommonDisciplines.Remove(statToAdd);
            }
            else
            {
                AddAnExistingDiscDot();
            }
        }
        else
        {
            if (listOfClanDisciplines.Count > 0)
            {
                rand = Random.Range(0, listOfClanDisciplines.Count);
                CharStat statToAdd = listOfClanDisciplines[rand];
                statToAdd.AddToStatValue(1);
                listOfClanDisciplines.Add(statToAdd);
                listOfCommonDisciplines.Remove(statToAdd);

            }
            else if (listOfCommonDisciplines.Count > 0)
            {
                rand = Random.Range(0, listOfCommonDisciplines.Count);
                CharStat statToAdd = listOfCommonDisciplines[rand];
                statToAdd.AddToStatValue(1);
                listOfCurrentDisciplines.Add(statToAdd);
                listOfCommonDisciplines.Remove(statToAdd);
            }
            else
            {
                AddAnExistingDiscDot();
            }
        }
    }
    #endregion
}
public enum VampireClan 
{ 
    Daeva, Gangrel, Mekhet, Nosferatu, Ventrue
}
public enum Bloodline 
{
    None,
    //WoD Bloodlines
    //Daeva
    Toreador, Kiasyd, DaughtersOfCacophony,
    //Gangrel
    Gangrel, Bruja, Setite,
    //Mekhet
    Tzimisce, Tremere, Malkavian,
    //Nosferatu
    Nicktuku, Baali, Cappodocian,
    //Ventrue    
    Ventru, Giovanni, Lasombra, 
    //VtR Bloodlines
    //Daeva
    AmaraHavana, Anvari, TheCarnival, ChildrenOfJudas, Erzsebet, Eupraxus, Gulikan, Jharana, Kallisti, Kinnaree, Liderc, Malintzin, Naditu, Nelapsi, Spina, CaliforniaXiao, TianpanXiao, 
    Zelani, Asnam, Duchagne, Septemi, MortifiersOfTheFlesh,
    //Gangrel
    Annunaku, Barjot, Bohagande, Carnon, ChilderOfTheMorrigan, DeadWolves, Empusae, HoundsOfActaeon, Kerberos, LesGensLibres, Larvae, Mabry, TheMara, Moroi, Nepheshim, Nosoi, Oberlochs,
    Shepherds, Taifa, Mystikoi, Vedma,
    //Mekhet
    Agonistes, Alucinor, Angustri, BakRa, BrothersOfYpres, Csalad, Kuufukuji, Icelus, Iltani, Libitinarius, Lynx, Mnemosyne, Morbus, Norvegi, Players, Qedeshah, Tismanu, Sangiovanni,
    Khaibit, Osite,
    //Nosferatu
    Azerkatil, Burakumin, Calacas, Cimitiere, Caporetti, TheCockscombSociety, Galloi, Gethsemani, Lygos, Morotrophians, OrderOfSirMartin, Rakshasa, Telamones, Usiri, Vilseduire, Yagnatia,
    Mayarap, Adroanzi, Baddacelli,
    //Ventrue
    Adrestoi, Bron, CandaBhanu, Corajoso, Deucalion, Dragolescu, Geheim, Gorgons, Icarians, Macellarius, Malocusians, Melissidae, Nahualli, Rotgrafen, Sotoha, TheSonsOfCade, Vardyvle, 
    Apollinaire, ArchitectsOfTheMonolith
}
public enum Covenant 
{ 
    //WoD Homebrew
    BanuHaqim, ThePyramid, FollowersOfSet, HarbingersOfSkulls,
    //VtR Bloodlines
    Invictus, CarthianMovement, BelialsBrood, OrdoDracul, CircleOfTheCrone, LanceaEtSanctum, VII, Harbingers
}