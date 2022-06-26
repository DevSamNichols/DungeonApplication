using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {

        //Fields
        private int _minDamage;

        //Properties

        public int MaxDamage { get; set; }

        public string Description { get; set; }

        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                //Shouldn't be more than the MaxDamage
                //Shouldn't be less than 1
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1;
                }
            }
        }

        //Constructors
        public Monster(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description)
        {
            MaxLife = maxLife;
            MaxDamage = maxDamage;
            Name = name;
            Life = life;
            HitChance = hitChance;
            Block = block;
            MinDamage = minDamage;
            Description = description;
        }

        //Default
        public Monster() { }

        //Methods
        public override string ToString()
        {
            //return base.ToString();

            return string.Format("\n******** MONSTER ********\n" +
                "{0}\nLife: {1} of {2}\nHit Chance: {3}\nDamage: {4} to {5}\n" +
                "Block: {6}\nDescription: {7}\n",
                Name,
                Life,
                MaxLife,
                HitChance,
                MinDamage,
                MaxDamage,
                Block,
                Description);
        }

        public override int CalcDamage()
        {

            Random rand = new Random();

            return rand.Next(MinDamage, MaxDamage + 1);
            //+1 because it is exclusive
        }
    }
}
