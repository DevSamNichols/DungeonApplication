using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DungeonLibrary;
using MonsterLibrary;
using WeaponsLibrary;

namespace DungeonApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Old School Room Escape";
            Console.WriteLine("Your journey begins...\n");

            int score = 0;

            Build equippedBuild = (Build)(new Random()).Next(0, 8);//Selects random build from Builds enum                        

            Weapon gMaul = new Weapon(1, 15, "Granite Maul", 15, true);

            //Plan on adding a Weapons Library that allows different true/false properties depending on what random build is selected per weapon.

            Player player = new Player("Sam Nichols", 70, 20, 70,
                75, gMaul, equippedBuild);

            bool exit = false;

            do
            {
                Console.WriteLine(GetRoom());

                LesserDemon ld1 = new LesserDemon();

                Goblin g1 = new Goblin();

                Bandit b1 = new Bandit();

                Monster[] monsters = { ld1, b1, b1, g1, g1, g1 };

                Random rand = new Random();

                int randomNbr = rand.Next(monsters.Length);

                Monster monster = monsters[randomNbr];

                Console.WriteLine("\nIn this room you encounter a " + monster.Name);

                bool reload = false;

                do
                {

                    #region MENU

                    Console.Write("\nPlease choose an action:\n" +
                    "A) Attack\n" +
                    "R) Run Away\n" +
                    "P) Player Info\n" +
                    "M) Monster Info\n" +
                    "X) Exit");

                    ConsoleKey userChoice = Console.ReadKey(true).Key;
                    Console.Clear();

                    switch (userChoice)
                    {

                        //Attack
                        case ConsoleKey.A:
                            Combat.DoBattle(player, monster);

                            if (monster.Life <= 0)
                            {
                                //The monster is dead
                                //You could put logic here to have the player get items, recover some life, or some other similar bonus for defeating the monster.

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYou killed {0}!\n", monster.Name);
                                Console.ResetColor();
                                reload = true;
                                //Get a new room, exit the menu loop and return to the top of the gameplay loop.
                                score++;
                            }

                            break;

                        //Run Away

                        case ConsoleKey.R:

                            Console.WriteLine("Run Away!");

                            Console.WriteLine($"{monster.Name} attacks you as you flee!");
                            Combat.DoAttack(monster, player); //Attack of opportunity
                            Console.WriteLine();
                            reload = true;

                            break;

                        //Player Info
                        case ConsoleKey.P:

                            Console.WriteLine("Player Info");

                            Console.WriteLine(player);

                            Console.WriteLine("You've defeated " + score + " monster" + ((score == 1) ? "" : "s ") + "so far.");

                            break;

                        //Monster Info

                        case ConsoleKey.M:

                            Console.WriteLine("Monster Info");
                            Console.WriteLine(monster);

                            break;

                        //Exit
                        case ConsoleKey.X:
                        case ConsoleKey.E:

                            Console.WriteLine("I hope being a chicken keeps you up at night");

                            exit = true;
                            break;

                        default:

                            Console.WriteLine("Unknown User Input");

                            break;
                    }

                    #endregion

                    if (player.Life <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("YOU ARE DEAD");
                        Console.ResetColor();
                        exit = true;
                    }

                } while (!reload && !exit);

            } while (!exit);

            //Output the players final score
            Console.WriteLine("You defeated " + score + " monster" + ((score == 1) ? "." : "s."));

        }//end Main()

        //Creating GetRoom()
        private static string GetRoom()
        {

            string[] rooms =
            {
                "Many small desks with high-backed chairs stand in three long rows in this room. Each desk has an inkwell, book stand, and a partially melted candle in a rusting tin candleholder. Everything is covered with dust.",

                "A pungent, earthy odor greets you as you pull open the door and peer into this room. Mushrooms grow in clusters of hundreds all over the floor. Looking into the room is like looking down on a forest. Tall tangles of fungus resemble forested hills, the barren floor looks like a plain between the woods, and even a trickle of water and a puddle of water that pools in a low spot bears a resemblance to a river and lake, respectively.",

                "Neither light nor darkvision can penetrate the gloom in this chamber. An unnatural shade fills it, and the room's farthest reaches are barely visible. Near the room's center, you can just barely perceive a lump about the size of a human lying on the floor. (It might be a dead body, a pile of rags, or a sleeping monster that can take advantage of the room's darkness.)",

                "The burble of water reaches your ears after you open the door to this room. You see the source of the noise in the far wall: a large fountain artfully carved to look like a seashell with the figure of a seacat spewing clear water into its basin",

                "When looking into this chamber, you're confronted by a thousand reflections of yourself looking back. Mirrored walls set at different angles fill the room. A path seems to wind through the mirrors, although you can't tell where it leads.",

                "You peer into this room and spot the white orb of a skull lying on the floor. Suddenly a stone falls from the ceiling and smashes the skull to pieces. An instant later, another stone from the ceiling drops to strike the floor and shatter. You hear a low rumbling and cracking noise.",

                "This short hall leads to another door. On either side of the hall, niches are set into the wall within which stand clay urns. One of the urns has been shattered, and its contents have spilled onto its shelf and the floor. Amid the ash it held, you see blackened chunks of something that might be bone.",

                "You open the door, and the room comes alive with light and music. A sourceless, warm glow suffuses the chamber, and a harp you cannot see plays soothing sounds. Unfortunately, the rest of the chamber isn't so inviting. The floor is strewn with the smashed remains of rotting furniture. It looks like the room once held a bed, a desk, a chest, and a chair.",

                "A stone throne stands on a foot-high circular dais in the center of this cold chamber. The throne and dais bear the simple adornments of patterns of crossed lines -- a pattern also employed around each door to the room.",

                "This small chamber is a bloody mess. The corpse of a minotaur lies on the floor, its belly carved out. The creature's innards are largely missing, and yet you detect no other wounds. Bloody, froglike footprints track away from the corpse and out an open door.",
            };

            Random rand = new Random();

            int indexNbr = rand.Next(rooms.Length);

            string room = rooms[indexNbr];

            return room;

        }//END GetRoom()

    }//end class

}//end namespace