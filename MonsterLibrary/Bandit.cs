using DungeonLibrary;

namespace MonsterLibrary
{
    public class Bandit : Monster
    {

        //Constructors
        public Bandit(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description)
            : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        { }

        //Methods
        public Bandit()
        {
            //SET MAX values FIRST
            MaxLife = 15;
            MaxDamage = 4;
            Name = "Bandit";
            Life = 15;
            HitChance = 20;
            Block = 15;
            MinDamage = 1;
            Description = "A wilderness outlaw.";
        }

    }
}