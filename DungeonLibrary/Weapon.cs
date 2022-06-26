using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon
    {

        //Fields
        private int _minDamage;

        //Properties
        public int MaxDamage { get; set; }

        public string Name { get; set; }

        public int BonusHitChance { get; set; }

        public bool IsRelevantToBuild { get; set; }

        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                //Shouldn't be more than the MaxDamage or less than 1
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

        //Constructors (FQCTOR)
        public Weapon(int minDamage, int maxDamage, string name, int bonusHitChance, bool isRelevantToBuild)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Name = name;
            BonusHitChance = bonusHitChance;
            IsRelevantToBuild = isRelevantToBuild;
        }

        //Methods
        public override string ToString()
        {
            //return base.ToString();

            return string.Format("{0}\n{1} to {2} Damage\n" +
                "Bonus Hit: {3}%\nRelevant to Your Build? {4}.",
                Name,
                MinDamage,
                MaxDamage,
                BonusHitChance,
                IsRelevantToBuild ? "Yes" : "No");
        }

        public virtual int CalcMaxDamage()
        {
            int calculatedMaxDamage = MaxDamage;
            if (IsRelevantToBuild)
            {
                //If the weapon is relevant to your build, you gain maxDamage * 2
                calculatedMaxDamage += calculatedMaxDamage * 2;
            }
            return calculatedMaxDamage;
        }

    }
}
