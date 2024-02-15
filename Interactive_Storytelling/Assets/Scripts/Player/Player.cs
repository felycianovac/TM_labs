using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player
{
    // Player skills and knowledge variables
    public int EngineeringSkill { get; set; }
    public int CombatSkill { get; set; }
    public int DiplomacySkill { get; set; }
    public bool KnowsBenefactor { get; set; }
    public bool KnowsPirates { get; set; }
    public bool KnowsArtifactLegend { get; set; }

    // Constructor
    public Player()
    {
        EngineeringSkill = 0;
        CombatSkill = 0;
        DiplomacySkill = 0;
        KnowsBenefactor = false;
        KnowsPirates = false;
        KnowsArtifactLegend = false;
    }

    // Add methods to modify the player's skills and knowledge
    public void IncreaseEngineeringSkill(int amount)
    {
        EngineeringSkill += amount;
    }

    public void IncreaseCombatSkill(int amount)
    {
        CombatSkill += amount;
    }

    public void IncreaseDiplomacySkill(int amount)
    {
        DiplomacySkill += amount;
    }

    // Add methods for the player's knowledge
    public void LearnAboutBenefactor()
    {
        KnowsBenefactor = true;
    }

    public void LearnAboutPirates()
    {
        KnowsPirates = true;
    }

    public void LearnAboutArtifactLegend()
    {
        KnowsArtifactLegend = true;
    }

    // Other player-related methods can be added here
}
