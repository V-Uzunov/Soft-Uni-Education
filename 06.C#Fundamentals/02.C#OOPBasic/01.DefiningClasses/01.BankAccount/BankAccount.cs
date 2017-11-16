﻿public class BankAccount
{
    private int id;
    private double balance;
    private double deposit;
    private double withdraw;

    public int ID {
        get { return this.id; }
        set { this.id = value; }
    }
    public double Balance {
        get { return this.balance; }
        set { this.balance = value; }
    }


    public void Deposit (double amount)
    {
        this.balance += amount;
    }

    public void Withdraw(double amount)
    {
        this.balance -= amount;
    }

    public override string ToString()
    {
        return $"Account {this.ID}, balance {this.balance}";
    }
}

