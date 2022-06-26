using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Player : Character
    {

        //Properties
        public Weapon EquippedWeapon { get; set; }
        public Build EquippedBuild { get; set; }

        //Constructors (Fully-Qualified)

        public Player(string name, int hitChance, int block, int life, int maxLife, Weapon equippedWeapon, Build equippedBuild)
        {
            MaxLife = maxLife;
            Name = name;
            HitChance = hitChance;
            Block = block;
            Life = life;
            EquippedWeapon = equippedWeapon;
            EquippedBuild = equippedBuild;
        }


        //Methods
        public override string ToString()
        {
            string description = "";

            switch (EquippedBuild)
            {
                case DungeonLibrary.Build.FreeToPlay:
                    description = "Free To Play Account";
                    break;
                case DungeonLibrary.Build.MaxedMain:
                    description = "Maxed Main";
                    break;
                case DungeonLibrary.Build.OneDefensePure:
                    description = "One Defense Pure";
                    break;
                case DungeonLibrary.Build.Void:
                    description = "Void";
                    break;
                case DungeonLibrary.Build.Zerker:
                    description = "Zerker";
                    break;
                case DungeonLibrary.Build.Skiller:
                    description = "Skiller";
                    break;
                case DungeonLibrary.Build.RangedTank:
                    description = "Ranged Tank";
                    break;
                case DungeonLibrary.Build.Melee:
                    description = "Melee";
                    break;
                case DungeonLibrary.Build.Mage:
                    description = "Mage";
                    break;
            }//END SWITCH

            return string.Format("-=-= {0} =-=-\n" +
                "Life: {1} of {2}\nHitChance: {3}%\n" +
                "Weapon: {4}\nBlock: {5}\nBuild: {6}",
                Name,
                Life,
                MaxLife,
                CalcHitChance(),
                EquippedWeapon,
                Block,
                description);

        }//END ToString()

        public override int CalcDamage()
        {
            //Weapon will be the basis for how our player deals damage
            //Weapon has MinDamage and MaxDamage properties. Lets use a Random object to randomly select how much damage our Weapon can do with any given attack.

            Random rand = new Random();

            //Determine the range of potential damage
            int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);

            //Return damage
            return damage;
        }

        public override int CalcHitChance()
        {
            //return base.CalcHitChance();

            return base.CalcHitChance() + EquippedWeapon.BonusHitChance;
        }

    }
}
