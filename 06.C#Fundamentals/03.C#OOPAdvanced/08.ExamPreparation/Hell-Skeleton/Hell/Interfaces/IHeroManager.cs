﻿using System;
using System.Collections.Generic;

public interface IHeroManager
{
    string AddHero(IList<string> arguments);

    string AddItemToHero(IList<string> arguments);

    string AddRecipeToHero(IList<string> arguments);

    string PrintAllHeroes();

    string Inspect(IList<string> arguments);
}