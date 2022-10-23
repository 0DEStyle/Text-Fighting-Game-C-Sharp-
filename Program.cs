using System;

int milliseconds = 2000;

Fighter fighter1 = new Fighter("Lew", 10, 2);
Fighter fighter2 = new Fighter("Harry", 5, 4);
string firstAttacker = "Lew";
string winner = "";

Console.WriteLine("FirstAttacker is " + firstAttacker);
Console.WriteLine("Fighter 1:" + fighter1.Name + " Health:" + fighter1.Health + " DamagePerAttack:" + fighter1.DamagePerAttack);
Console.WriteLine("Fighter 2:" + fighter2.Name + " Health:" + fighter2.Health + " DamagePerAttack:" + fighter2.DamagePerAttack + "\n\n");

while (!(fighter1.Health <= 0) && !(fighter2.Health <= 0))
{
    if (firstAttacker == fighter1.Name)
    {
        fighter2.Health = epicBattleLog.PrintLog(firstAttacker, fighter2.Name, fighter2.Health, fighter1.DamagePerAttack);
        firstAttacker = fighter2.Name;
    }
    else
    {
        fighter1.Health = epicBattleLog.PrintLog(fighter2.Name, fighter1.Name, fighter1.Health, fighter2.DamagePerAttack);
        firstAttacker = fighter1.Name;
    }
    if (fighter1.Health <= 0)
        winner = fighter2.Name;
    else if (fighter2.Health <= 0)
        winner = fighter1.Name;
    Thread.Sleep(milliseconds);
}



//print stuff, return health left
public class epicBattleLog
{
    public string Name { get; set; }
    public static int PrintLog(string attacker, string defender, int defenderHealth, int attackerDamage)
    {
        int healthLeft = defenderHealth - attackerDamage;
        if (healthLeft > 0)
        {
            Console.WriteLine(attacker + " attacks " + defender + "; " + defender + " now has " + healthLeft + " health.");
        }
        else
        {
            Console.WriteLine(attacker + " attacks " + defender + "; " + defender + " now has " + healthLeft + " health and is dead. " + attacker + " wins.");
        }
        return healthLeft;
    }
}

public class Fighter
{
    public string Name;
    public int Health, DamagePerAttack;
    public Fighter(string name, int health, int damagePerAttack)
    {
        this.Name = name;
        this.Health = health;
        this.DamagePerAttack = damagePerAttack;
    }
}