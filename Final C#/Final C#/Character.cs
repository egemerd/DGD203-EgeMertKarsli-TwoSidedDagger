using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Character
{
	public string name { get; set; }
    public int attack { get; set; }
    public int defense { get; set; }
    public int health { get; set; }
    public double crit { get; set; }

    private Random random = new Random();



    public Character(string aName,int aAttack,int aDefense,int aHealth, double aCrit)
	{
		name = aName;
		attack = aAttack;
		defense = aDefense;
		health = aHealth;
		crit = aCrit;

	}

	

	public int MakingAttack(Character enemy)
	{
		int damage = attack - enemy.defense;

		if (damage < 0) damage = 0;
		
		bool isCritical = random.NextDouble() < crit;

		if (isCritical)
		{
			damage *= 2;
            Console.WriteLine($"{name} has attacked.");
            Console.WriteLine($"Critical attack deals {damage} to {enemy.name}");
		}
		else
		{
            Console.WriteLine($"{name} has attacked.");
            Console.WriteLine($"Attack deals {damage} to {enemy.name}");
            
		}

    
        enemy.health -= damage;
		return damage;
		
	}

    public bool isAlive()
    {
        return health > 0;
    }



}


