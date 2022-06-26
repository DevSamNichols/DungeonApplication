namespace DungeonLibrary
{
    public abstract class Character
    {
        //abstract is being used to show that this class is only meant to act as a parent class of other classes

        //Business property for life
        //Fields
        private int _life;

        //Properties
        public string Name { get; set; }

        public int HitChance { get; set; }

        public int Block { get; set; }

        public int MaxLife { get; set; }

        public int Life
        {

            get { return _life; }
            set
            {
                //Business rule: Life should NOT exceed MaxLife
                if (value <= MaxLife)
                {
                    _life = value;
                }
                else
                {
                    _life = MaxLife;
                }
            }
        }

        //Constructors


        //Methods (To be used for Players & Monsters)
        public virtual int CalcBlock()
        {
            //Set to Virtual so it I can override itinitschildclasses.
            return Block;
        }

        public virtual int CalcHitChance()
        {
            return HitChance;
        }

        public virtual int CalcDamage()
        {
            return 0;
            //Set to return 0 because it will be overwritten initchil classes
        }

    }
}