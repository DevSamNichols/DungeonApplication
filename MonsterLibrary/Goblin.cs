using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DungeonLibrary;

namespace MonsterLibrary
{
    public class Goblin : Monster
    {

        //Constructors
        public Goblin(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description)
            : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        { }

        public Goblin()
        {
            //SET MAX values FIRST
            MaxLife = 10;
            MaxDamage = 3;
            Name = "Goblin";
            Life = 10;
            HitChance = 20;
            Block = 10;
            MinDamage = 1;
            Description = "An ugly green creature.";
        }

    }
}
