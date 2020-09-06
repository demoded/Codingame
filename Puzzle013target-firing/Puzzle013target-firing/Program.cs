using System;
using System.Collections.Generic;
using System.Linq;
using Serilog;

namespace Puzzle013target_firing
{
    /*
     «Story»
    Your spaceship is under attack by aliens! (It's actually your friend's spaceship, so the situation is even worse) 
    Luckily your spaceship is equipped with an antimatter beam, while the aliens only have cheap (but still dangerous) laser pointers. 
    Can you destroy all alien spaceships safely, or should you flee?

    «Prompt»
    As the AI within the ship's computer, your goal is to determine the optimal order of alien spaceships to destroy such 
    that you leave the encounter with the maximum strength of your shields. Print the remaining strength of the shields, 
    or FLEE if your spaceship is predicted to take more damage than your shields can handle. 
    Your friend will not forgive you if the ship is damaged.

    «Details»
    The encounter can be modeled by turn-based combat. Your spaceship's shields begin with 5000 strength. 
    You are fighting against N alien spaceships of various properties. 
    These properties are:
    TYPE - the type of the spaceship, which can be either FIGHTER or CRUISER,
    HP - the amount of damage the spaceship can receive before being destroyed,
    ARMOR - the damage reduction of the spaceship, and
    DAMAGE - the amount of damage the spaceship deals per turn.

    On each turn, all alien spaceships reduce your ship's shields by DAMAGE as your antimatter beam charges, 
    and then one spaceship takes damage from your antimatter beam. Your beam deals 10 base damage to a spaceship. 
    The actual damage that the spaceship receives is decreased by the spaceship's ARMOR. Luckily, 
    your antimatter beam does double damage to FIGHTER-class spaceships; hence, the damage that FIGHTER-class spaceships receives is 20 - ARMOR. 
    Your antimatter beam always deals at least 1 damage, even if the target spaceship's ARMOR is greater than your beam's damage.
     */
    public class Program
    {
        class Alien
        {
            public string Type { get; set; }
            public int HP { get; set; }
            public int Armor { get; set; }
            public int Damage { get; set; }
            public double HitsToKill { get; set; }

            public void Attack()
            {
                int attackDamage = 0;
                if (Type == "FIGHTER")
                {
                    attackDamage = 20 - Armor;
                }
                else
                {
                    attackDamage = 10 - Armor;
                }

                HP -= attackDamage > 0 ? attackDamage : 1;
            }

            public void updateHitsToKill()
            {
                if (Type == "FIGHTER")
                { HitsToKill = Math.Ceiling(Armor >= 20 ? HP : (double)(HP / (20.0 - Armor))); }
                else
                { HitsToKill = Math.Ceiling(Armor >= 10 ? HP : (double)(HP / (10.0 - Armor))); }
            }
        }

        public static void Main(string[] args)
        {
            List<Alien> alienShips = new List<Alien>();
            int motherShipHP = 5000;

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("..\\..\\..\\consoleapp.log")
                .CreateLogger();

            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                string inTYPE = inputs[0];
                int inHP = int.Parse(inputs[1]);
                int inARMOR = int.Parse(inputs[2]);
                int inDAMAGE = int.Parse(inputs[3]);
                var a = new Alien
                { Type = inTYPE, HP = inHP, Armor = inARMOR, Damage = inDAMAGE };
                a.updateHitsToKill();

                alienShips.Add(a);
            }

            alienShips = alienShips.OrderByDescending(a => a.Damage / a.HitsToKill).ToList();

            while (alienShips.Count() > 0)
            {
                Log.Information("Attack");
                foreach (var a in alienShips)
                {
                    Log.Information($"DEBUG>>>{a.Type} {a.HP, -3} {a.Armor, 3} {a.Damage, -3} {a.HitsToKill, -3} {a.HitsToKill * a.Damage}");
                }

                motherShipHP -= alienShips.Sum(a => a.Damage);
                Log.Information($"DEBUG>>>{motherShipHP}");
                if (motherShipHP <= 0)
                {
                    break;
                }

                var attackAlien = alienShips.First();
                attackAlien.Attack();
                if (attackAlien.HP <= 0)
                {
                    alienShips.Remove(attackAlien);
                }
            }

            Console.WriteLine(motherShipHP < 0 ? "FLEE" : motherShipHP.ToString());
        }
    }
}
