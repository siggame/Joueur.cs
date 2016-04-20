// This is where you build your AI for the Spiders game.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Joueur.cs.Games.Spiders
{
    /// <summary>
    /// This is where you build your AI for the Spiders game.
    /// </summary>
    class AI : BaseAI
    {
        #region Properties
        #pragma warning disable 0169 // the never assigned warnings between here are incorrect. We set it for you via reflection. So these will remove it from the Error List.
        #pragma warning disable 0649
        /// <summary>
        /// This is the Game object itself, it contains all the information about the current game
        /// </summary>
        public readonly Spiders.Game Game;
        /// <summary>
        /// This is your AI's player. This AI class is not a player, but it should command this Player.
        /// </summary>
        public readonly Spiders.Player Player;
        #pragma warning restore 0169
        #pragma warning restore 0649

        private Random Random = new Random();

        #endregion


        #region Methods
        /// <summary>
        /// This returns your AI's name to the game server. Just replace the string.
        /// </summary>
        /// <returns>string of you AI's name.</returns>
        public override string GetName()
        {
            return "Spiders C# Player"; // REPLACE THIS WITH YOUR TEAM NAME!
        }

        /// <summary>
        /// This is automatically called when the game first starts, once the Game object and all GameObjects have been initialized, but before any players do anything.
        /// </summary>
        /// <remarks>
        /// This is a good place to initialize any variables you add to your AI, or start tracking game objects.
        /// </remarks>
        public override void Start()
        {
            base.Start();
        }

        /// <summary>
        /// This is automatically called every time the game (or anything in it) updates.
        /// </summary>
        /// <remarks>
        /// If a function you call triggers an update this will be called before that function returns.
        /// </remarks>
        public override void GameUpdated()
        {
            base.GameUpdated();
        }

        /// <summary>
        /// This is automatically called when the game ends.
        /// </summary>
        /// <remarks>
        /// You can do any cleanup of you AI here, or do custom logging. After this function returns the application will close.
        /// </remarks>
        /// <param name="won">true if your player won, false otherwise</param>
        /// <param name="reason">a string explaining why you won or lost</param>
        public override void Ended(bool won, string reason)
        {
            base.Ended(won, reason);
        }


        /// <summary>
        /// This is called every time it is this AI.player's turn.
        /// </summary>
        /// <returns>Represents if you want to end your turn. True means end your turn, False means to keep your turn going and re-call this function.</returns>
        public bool RunTurn()
        {
            // This is ShellAI, it is very simple, and demonstrates how to use all the game objects in Spiders

            // Try to do something with a random spider
            int index = this.Random.Next(this.Player.Spiders.Count);
            Spider spider = this.Player.Spiders[index];

            if (spider.GameObjectName == "BroodMother")
            {
                BroodMother broodMother = (BroodMother)spider;

                int choice = this.Random.Next(10);
                if (choice == 0) // 10% of the time try to consume a Spiderling
                {
                    if (broodMother.Nest.Spiders.Count > 1) // let's eat a baby
                    {
                        // pick a random spiderling
                        index = this.Random.Next(broodMother.Nest.Spiders.Count);
                        Spider otherSpider = broodMother.Nest.Spiders[index];

                        if (otherSpider != broodMother) // can't eat yourself
                        {
                            Console.WriteLine("Broodmother #" + broodMother.Id +
                                               " consuming " + otherSpider.GameObjectName + " #" + otherSpider.Id);

                            broodMother.Consume((Spiderling)otherSpider);
                        }
                    }
                }
                else
                {
                    if (broodMother.Eggs > 0) // try to spawn a baby Spiderling
                    {
                        // pick a random spiderling type
                        List<String> spiderlingTypes = new List<String>() { "Cutter", "Weaver", "Spitter" };
                        index = this.Random.Next(spiderlingTypes.Count);
                        String randomSpiderlingType = spiderlingTypes[index];

                        Console.WriteLine("Broodmother #" + broodMother.Id +
                                          " spawning " + randomSpiderlingType);

                        broodMother.Spawn(randomSpiderlingType);
                    }
                }
            }
            else
            {
                Spiderling spiderling = (Spiderling)spider;
                // spiderlings all have two common behaviors: move, attack,
                // plus one behavior specific to their exact type

                // some actions take time. if a spiderling is still doing a thing
                // then they can't do another thing. much like undergrads, they
                // might think they can multitask, but really they can't.
                if (spiderling.Busy == "") // then they are NOT busy
                {
                    int choice = this.Random.Next(3);
                    if (choice == 0) // move
                    {
                        if (spiderling.Nest.Webs.Count > 0)
                        {
                            // pick a random web to move to
                            index = this.Random.Next(spiderling.Nest.Webs.Count);
                            Web web = spiderling.Nest.Webs[index];

                            Console.WriteLine(spiderling.GameObjectName + " #" + spiderling.Id +
                                               " moving on Web #" + web.Id);

                            spiderling.Move(web);
                        }
                    }
                    else if (choice == 1) // attack
                    {
                        if (spiderling.Nest.Spiders.Count > 1)
                        {
                            // pick a random spiderling to attack
                            index = this.Random.Next(spiderling.Nest.Spiders.Count);
                            Spider otherSpider = spiderling.Nest.Spiders[index];

                            // don't attack our own spiders
                            if (otherSpider.Owner != spiderling.Owner)
                            {
                                Console.WriteLine(spiderling.GameObjectName + " #" + spiderling.Id + " attacking " +
                                                   otherSpider.GameObjectName + " #" + otherSpider.Id);

                                spiderling.Attack((Spiderling)otherSpider);
                            }
                        }
                    }
                    else // do the unique behavior
                    {
                        if (spiderling.GameObjectName == "Spitter")
                        {
                            Spitter spitter = (Spitter)spiderling;
                            Nest enemyNest = this.Player.OtherPlayer.BroodMother.Nest;

                            // ensure that the Web from here to there doesn't already exist
                            Web existingWeb = null;
                            foreach(var web in enemyNest.Webs)
                            {
                                if (web.NestA == spitter.Nest || web.NestB == spitter.Nest)
                                {
                                    existingWeb = web;
                                    break;
                                }
                            }

                            if (existingWeb == null) // then there is no Web already!
                            {
                                Console.WriteLine("Spitter #" + spitter.Id +
                                                 " spitting to Nest #" + enemyNest.Id);

                                spitter.Spit(enemyNest);
                            }
                        }
                        else if (spiderling.GameObjectName == "Cutter")
                        {
                            Cutter cutter = (Cutter)spiderling;

                            if (cutter.Nest.Webs.Count > 0) // try to cut one
                            {
                                // pick a random Web
                                index = this.Random.Next(cutter.Nest.Webs.Count);
                                Web web = cutter.Nest.Webs[index];

                                Console.WriteLine("Cutter #" + cutter.Id +
                                                 " cutting Web #" + web.Id);
                                cutter.Cut(web);
                            }
                        }
                        else if (spiderling.GameObjectName == "Weaver")
                        {
                            Weaver weaver = (Weaver)spiderling;

                            if (weaver.Nest.Webs.Count > 0)
                            {
                                // pick a random Web
                                index = this.Random.Next(weaver.Nest.Webs.Count);
                                Web web = weaver.Nest.Webs[index];

                                // randomly decide to strengthen or weaken
                                choice = this.Random.Next(2);
                                if (choice == 0) // strengthen
                                {
                                    Console.WriteLine("Weaver #" + weaver.Id +
                                                      " strengthening Web #" + web.Id);

                                    weaver.Strengthen(web);
                                }
                                else // weaken
                                {
                                    Console.WriteLine("Weaver #" + weaver.Id +
                                                      " weakening Web #" + web.Id);

                                    weaver.Weaken(web);
                                }
                            }
                        }
                    }
                }
            }

            return true; // to signify you are done with your turn
        }

        #endregion
    }
}
