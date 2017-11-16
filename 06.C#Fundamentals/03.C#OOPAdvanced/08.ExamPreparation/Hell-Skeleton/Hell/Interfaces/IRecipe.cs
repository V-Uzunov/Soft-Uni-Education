﻿using System.Collections.Generic;

public interface IRecipe
{
    IList<string> RequiredItems { get; set; }
    string RecipeItemName { get; set; }
    int StrengthBonus { get; set; }
    int AgilityBonus { get; set; }
    int IntelligenceBonus { get; set; }
    int HitPointsBonus { get; set; }
    int DamageBonus { get; set; }
}