using System.Collections.Generic;

public class Recipe : IRecipe
{
    public Recipe(string recipeItemName, int strengthBonus, int agilityBonus, int intelligenceBonus, int hitPointsBonus, int damageBonus, IList<string> requiredItems)
    {
        RequiredItems = new List<string>(requiredItems);
        RecipeItemName = recipeItemName;
        StrengthBonus = strengthBonus;
        AgilityBonus = agilityBonus;
        IntelligenceBonus = intelligenceBonus;
        HitPointsBonus = hitPointsBonus;
        DamageBonus = damageBonus;
    }

    public IList<string> RequiredItems { get; set; }
    public string RecipeItemName { get; set; }
    public int StrengthBonus { get; set; }
    public int AgilityBonus { get; set; }
    public int IntelligenceBonus { get; set; }
    public int HitPointsBonus { get; set; }
    public int DamageBonus { get; set; }
}
