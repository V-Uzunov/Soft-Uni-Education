using _02.CodeFirst;
using _02.CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Validation;
using System.Text;

class Program
{
    static void Main()
    {
        WizardDeposit dumbledore = new WizardDeposit()
        {
            FirstName = "Albus",
            LastName = "Dumbledore",
            Age = 150,
            MagicWandCreator = "Antioch Peverell",
            MagicWandSize = 15,
            DepositStartDate = new DateTime(2016, 10, 20),
            DepositExpirationDate = new DateTime(2020, 10, 20),
            DepositAmount = 20000.24m,
            DepositCharge = 0.2m,
            IsDepositExpired = false,
        };
        var context = new WizardDepositsContext();

    }
}