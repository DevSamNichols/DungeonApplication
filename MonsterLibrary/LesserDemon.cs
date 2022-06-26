using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DungeonLibrary;

namespace MonsterLibrary
{
    public class LesserDemon : Monster
    {

        //Constructors
        public LesserDemon(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description)
            : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        { }

        public LesserDemon()
        {
            //SET MAX values FIRST
            MaxLife = 50;
            MaxDamage = 3;
            Name = "Lesser Demon";
            Life = 49;
            HitChance = 40;
            Block = 10;
            MinDamage = 1;
            Description = "Lesser, but still pretty big.";
        }

    }
}
