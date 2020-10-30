using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human
{
    class Program
    {
        //Story
        static Kvinde StartPhase()
        {
            //First glance at Kvinde
            Kvinde kvinde = new Kvinde("null", "null", 0, "null", "null");
            string Meeting;
            do
            {
                Meeting = CoincidentalMeeting();
                kvinde = GetNewKvinde();
                wannabePhoneBook[KvinderMet] = kvinde;
                if (Restart)
                    Console.WriteLine("You have decided to come back to the bar, and glance upon a Kvinde at the " + Meeting + ", looking kind of like a " + kvinde.Presentation());
                else
                    Console.WriteLine("You decide to come to the bar, and glance upon a Kvinde at the " + Meeting + ", looking kind of like a " + kvinde.Presentation());

                for (int x = 0; x < 3; x++)
                    Console.WriteLine();
                Console.WriteLine("Do you feel the interest to interact with the Kvinde being?");
                Choice = Console.ReadLine().ToLower();

                if (Choice == "yes")
                    Loop = false;
                else if (Choice == "custom")
                    kvinde = kvinde.Custom();
                else
                {
                    Loop = true;
                    Restart = true;
                }
                Console.Clear();
            } while (Loop); //Meet new Kvinde loop

            do //How to approach Kvinde
            {
                //Likeness: 10
                Console.WriteLine("You decide to approach the Kvinde, but panic about how to correctly approach her.");
                for (int x = 0; x < 3; x++)
                    Console.WriteLine();
                Console.WriteLine("How will you approach her?");
                Console.WriteLine();
                if (Meeting == "bar counter")
                {
                    Console.WriteLine("[1]: Compliment looks along with \"Can I buy you a drink?\"");
                    Console.WriteLine("[2]: \"What brings someone like you here?\"");
                    Console.WriteLine("[3]: \"Do you have any cigarettes?\"");
                    Console.WriteLine("[4]: Bail.");
                    Console.WriteLine();
                    Choice = Console.ReadLine().ToLower();

                    Console.WriteLine();

                    if (Choice == "1" || Choice == "compliment" || Choice == "compliment looks along with can i buy you a drink?" || Choice == "compliment looks along with \" can i buy you a drink?\"")
                    {
                        do //What to compliment Kvinde
                        {
                            Loop = false;
                            Console.WriteLine("How would you like to compliment her?");
                            Console.WriteLine("[1]: Face");
                            Console.WriteLine("[2]: Clothes");
                            Console.WriteLine("[3]: Boobs");
                            Console.WriteLine("[4]: Ass");
                            Console.WriteLine();
                            Choice = Console.ReadLine().ToLower();
                            Console.ForegroundColor = ConsoleColor.Yellow;

                            Console.Clear();

                            Console.Write("*You approach the Kvinde and compliment ");
                            if (Choice == "1" || Choice == "face")
                                Console.WriteLine("a facial feature.*");
                            else if (Choice == "2" || Choice == "clothes")
                                Console.WriteLine("her clothing fashion.*");
                            else if (Choice == "3" || Choice == "boobs")
                                Console.WriteLine("her boobs.*");
                            else if (Choice == "4" || Choice == "ass")
                                Console.WriteLine("her ass.*");
                            else
                            {
                                Loop = true;
                                Console.Clear();
                            }
                        } while (Loop);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(player.Playername + ": \"Can I buy you a drink?\"");

                        if (kvinde.Formal == "Stoner")
                        {
                            if (kvinde.BMI > 30)
                            {
                                Console.WriteLine("Kvinde: \"Can you not compliment me? I know you don't mean it.\"");
                                kvinde.LikenessMeter -= 7;
                                System.Threading.Thread.Sleep(2000);
                                Console.WriteLine("Kvinde: \"But sure man - free drinks? xD\"");
                                kvinde.LikenessMeter += 3;
                                //Likeness 6
                            }
                            else
                            {
                                Console.WriteLine("Kvinde: \"Why thank you! And sure - I wouldn't mind a drink. :)\"");
                                kvinde.LikenessMeter += 5;
                                //Likeness 15
                            }

                            //Buys drink
                            int drink = rand.Next(50, 200);
                            player.Money -= drink;

                            if (drink < 100)
                                kvinde.LikenessMeter -= 2;
                            else if (drink > 150)
                                kvinde.LikenessMeter += 5;

                            Console.ReadKey();
                            Console.Clear();
                            do //What happens after the drink?
                            {
                                Loop = false;
                                Console.WriteLine("You buy the Kvinde a drink, and speculate what to say next");
                                Console.WriteLine();
                                Console.WriteLine("[1]: Ask what she thinks of the drink.");
                                Console.WriteLine("[2]: Ask why she's here.");
                                if (kvinde.LikenessMeter == 15)
                                    Console.WriteLine("[3]: Compliment her open mind.");
                                else
                                    Console.WriteLine("[3]: Apologize about the approach, but express you meant the compliment.");

                                Choice = Console.ReadLine().ToLower();
                                Console.Clear();

                                //If BMI, Likeness: 6
                                //else, Likeness: 15

                                if (Choice == "1" || Choice == "ask what" || Choice == "ask what she thinks of the drink")
                                {
                                    Console.WriteLine(player.Playername + ": \"So what do you think of the drink?\"");
                                    System.Threading.Thread.Sleep(3000);
                                    int goodDrinkYesQuestionmarkOwO = rand.Next(0, 4);
                                    if (goodDrinkYesQuestionmarkOwO == 1)
                                    {
                                        Console.WriteLine("Kvinde: \"I don't really like it, to be honest...\"");
                                        kvinde.LikenessMeter -= 4;
                                        // If BMI < 30, Likeness: 2
                                        // else Likeness: 11

                                        if (kvinde.LikenessMeter == 2)
                                        {
                                            System.Threading.Thread.Sleep(3000);
                                            for (int x = 0; x < 4; x++)
                                                Console.WriteLine();
                                            KvindeLeaving(kvinde, false, "Hey sorry, I have to go - but it was nice of you to buy me the drink", 5);
                                        }
                                    }
                                    else if (goodDrinkYesQuestionmarkOwO == 2)
                                    {
                                        Console.Write("Kvinde: \"It's pretty good\" ");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("*ok_hand*");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        kvinde.LikenessMeter += 3;
                                        //If BMI < 30, Likeness: 9
                                        //else Likeness: 18
                                    }
                                    else if (goodDrinkYesQuestionmarkOwO == 3)
                                    {
                                        Console.Write("Kvinde: \"It's surprisingly not too bad!\" ");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("*Nods*");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        kvinde.LikenessMeter += 5;
                                        //If BMI < 30, Likeness: 11
                                        //else Likeness: 20
                                    }
                                    else
                                    {
                                        Console.WriteLine("Kvinde: \"It's alright I guess\"");
                                        kvinde.LikenessMeter += 1;
                                        //If BMI < 30, Likeness: 7
                                        //else Likeness: 16
                                    }

                                    Console.ReadKey();
                                    Console.Clear();

                                    if (kvinde.LikenessMeter > 5 && kvinde.LikenessMeter < 15)
                                    {
                                        do //Forgeting the drinks
                                        {
                                            Loop = false;
                                            System.Threading.Thread.Sleep(1000);
                                            Console.WriteLine("Forgetting the drinks, we're here to get something going...");
                                            Console.WriteLine();
                                            Console.WriteLine("[1]: Apologize for the terrible start");
                                            Console.WriteLine("[2]: Ask into her life.");
                                            Console.WriteLine("[3]: Bail");

                                            Choice = Console.ReadLine().ToLower();
                                            Console.Clear();

                                            if (Choice == "1" || Choice == "apologize" || Choice == "apologize for the terrible start")
                                            {
                                                Console.WriteLine(player.Playername + ": \"Hey, I'm sorry for the terrible start...\"");
                                                Console.WriteLine("Kvinde: \"It's fine - afterall I can't complain, since you DID buy me the drink...");
                                                System.Threading.Thread.Sleep(1500);
                                                Console.WriteLine("Kvinde: \"But hey, maybe you can make up for it by telling me your name?");
                                                Console.WriteLine();
                                                Console.WriteLine(player.Playername + ": \"My name is " + player.Playername + ". What about yours?\"");
                                                Console.WriteLine(player.Playername + ": \"If you don't mind me asking?\"");
                                                Console.WriteLine();
                                                do //Player reacting to Kvinde.Hobby
                                                {
                                                    Loop = false;
                                                    Console.WriteLine("Kvinde: \"My name is " + kvinde.Name + ", I would usually spend my time just " + kvinde.Hobby + ", but I felt like coming out here...\"");
                                                    Console.WriteLine();


                                                    Console.WriteLine("[1]: \"That's cool!\"");
                                                    Console.WriteLine("[2]: \"Oh unfortunately I'm not very into that myself\"");
                                                    Console.WriteLine("[3]: \"Meh I was hoping you'd be a little more interesting?\"");

                                                    Choice = Console.ReadLine().ToLower();
                                                    /* else & dont like tbh, Likeness: 11
                                                     * If BMI & pretty good, Likeness: 9
                                                     * If BMI & not too bad, Likeness: 11
                                                     * If BMI & alrigt ig, Likeness: 7 */

                                                    if (Choice == "1" || Choice == "that's" || Choice == "that's cool!")
                                                    {
                                                        Console.WriteLine(player.Playername + ": \"Cool! I usually do " + player.Hobby + " whenever I have time. But today I felt like meeting new people to socialize more.\"");
                                                        kvinde.LikenessMeter += 5;
                                                        /* else & dont like tbh, Likeness: 16
                                                         * If BMI & pretty good, Likeness: 14
                                                         * If BMI & not too bad, Likeness: 16                                    
                                                         * If BMI & alrigt ig, Likeness: 12 */
                                                    }
                                                    else if (Choice == "2" || Choice == "oh" || Choice == "oh unfortunately i'm not very into that myself")
                                                    {
                                                        Console.WriteLine(player.Playername + ": \"Oh... Unfortunately I'm not very into that myself...\"");
                                                        if (kvinde.LikenessMeter > 9)
                                                        {
                                                            Console.WriteLine(kvinde.Name + ": \"Oh that's okay...\"");
                                                            kvinde.LikenessMeter -= 3;
                                                            /* else & dont like tbh, Likeness: 8
                                                             * If BMI & pretty good, Likeness: 6
                                                             * If BMI & not too bad, Likeness: 8
                                                             * If BMI & alrigt ig, Likeness: 4 */
                                                            if (kvinde.LikenessMeter < 5)
                                                            {
                                                                KvindeLeaving(kvinde, true, "Hey sorry, but I have to go - thank you for the talk and the drink though!", 2);
                                                            } //If Kvinde doesn't like Player
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine(kvinde.Name + ": \"Ah, no - that's fine. We're all different people anyway.\"");
                                                            kvinde.LikenessMeter -= 1;
                                                            /* else & dont like tbh, Likeness: 10
                                                             * If BMI & pretty good, Likeness: 8
                                                             * If BMI & not too bad, Likeness: 10
                                                             * If BMI & alrigt ig, Likeness: 6 */
                                                        }
                                                    }
                                                    else if (Choice == "3" || Choice == "meh" || Choice == "meh i was hoping you'd be a little more interesting?")
                                                    {
                                                        Console.WriteLine(player.Playername + ": \"Meh - I was hoping you'd be a liiittle more interesting?\"");
                                                        System.Threading.Thread.Sleep(3000);
                                                        kvinde.LikenessMeter -= 5;
                                                        /* else & dont like tbh, Likeness: 6
                                                         * If BMI & pretty good, Likeness: 4
                                                         * If BMI & not too bad, Likeness: 6
                                                         * If BMI & alrigt ig, Likeness: 2 */

                                                        if (kvinde.LikenessMeter < 5)
                                                            KvindeLeaving(kvinde, true, "I uh, I think it's time for me to go...", 6);
                                                    }
                                                    else
                                                    {
                                                        Loop = true;
                                                        Console.Clear();
                                                    }
                                                } while (Loop);

                                                Console.Clear();
                                                Console.WriteLine(player.Playername + ": \"What about job?\"");
                                                System.Threading.Thread.Sleep(1500);
                                                do //Kvinde.Occupation reaction
                                                {
                                                    Loop = false;
                                                    Console.WriteLine(kvinde.Name + ": \"Well I'm a " + kvinde.Occupation + " one - it's kinda okay.\"");
                                                    Console.WriteLine();
                                                    Console.WriteLine("[1]: \"What do you mean by \"It's kinda okay?\"\"");
                                                    Console.WriteLine("[2]: \"Oh well that's fine\"");
                                                    Console.WriteLine("[3]: Bail");
                                                    Choice = Console.ReadLine().ToLower();
                                                    Console.Clear();

                                                    if (Choice == "1" || Choice == "what" || Choice == "what do you mean by it's kinda okay?")
                                                    {
                                                        Console.WriteLine(player.Playername + ": \"What do you mean by that?\"");
                                                        kvinde.LikenessMeter += 3;
                                                        /* else & dont like tbh & Cool I usually, Likeness: 19
                                                         * If BMI & pretty good & Cool I usually, Likeness: 17
                                                         * If BMI & not too bad Cool I usually, Likeness: 19
                                                         * If BMI & alrigt ig Cool I usually, Likeness: 15
                                                         * else & dont like tbh & Oh unfortunately, Likeness: 11
                                                         * If BMI & pretty good & Oh unfortunately, Likeness: 9
                                                         * If BMI & not too bad & Oh unfortunately, Likeness: 11
                                                         * else & dont like tbh & meh, Likeness: 9
                                                         * If BMI & not too bad & meh, Likeness: 9*/
                                                        System.Threading.Thread.Sleep(2000);

                                                        do //Things have just become a lot more difficult lately
                                                        {
                                                            Console.WriteLine(kvinde.Name + ": \"Things have just become a lot more difficult lately...\"");
                                                            Console.WriteLine();
                                                            Console.WriteLine("[1]: \"I hope things get better\"");
                                                            Console.WriteLine("[2]: \"Do you need another drink?\"");
                                                            Console.WriteLine("[3]: \"Is there anything I can do for you?\"");
                                                            Console.WriteLine("[4]: Bail");
                                                            Choice = Console.ReadLine().ToLower();

                                                            if (Choice == "1" || Choice == "i" || Choice == "i hope things get better")
                                                            {
                                                                Console.WriteLine(player.Playername + ": \"I hope things get better for you.\"");
                                                                System.Threading.Thread.Sleep(3000);
                                                                Console.WriteLine(kvinde.Name + ": \"Thanks.\"");
                                                                kvinde.LikenessMeter -= 5;
                                                                /* else & dont like tbh & Cool I usually, Likeness: 14
                                                                 * If BMI & pretty good & Cool I usually, Likeness: 12
                                                                 * If BMI & not too bad Cool I usually, Likeness: 14
                                                                 * If BMI & alrigt ig Cool I usually, Likeness: 10
                                                                 * else & dont like tbh & Oh unfortunately, Likeness: 6
                                                                 * If BMI & pretty good & Oh unfortunately, Likeness: 4
                                                                 * If BMI & not too bad & Oh unfortunately, Likeness: 6
                                                                 * else & dont like tbh & meh, Likeness: 4
                                                                 * If BMI & not too bad & meh, Likeness: 4*/

                                                                if (kvinde.LikenessMeter <= 5)
                                                                    KvindeLeaving(kvinde, true, "I'm gonna go - thank you for tonight...", 8);
                                                            }
                                                            else if (Choice == "2" || Choice == "do" || Choice == "do you need another drink?")
                                                            {
                                                                Console.WriteLine(player.Playername + ": \"So do you need another drink?\"");
                                                                System.Threading.Thread.Sleep(2000);
                                                                Choice = rand.Next(1, 10).ToString();
                                                                if (int.Parse(Choice) <= 5)
                                                                {
                                                                    Console.WriteLine(kvinde.Name + ": \"Honestly? Yeah I could use another one...\"");
                                                                    kvinde.LikenessMeter += 3;
                                                                    /* else & dont like tbh & Cool I usually & wdym, Likeness: 21
                                                                     * If BMI & pretty good & Cool I usually & wdym, Likeness: 20
                                                                     * If BMI & not too bad Cool I usually & wdym, Likeness: 21
                                                                     * If BMI & alrigt ig Cool I usually & wdym, Likeness: 18
                                                                     * else & dont like tbh & Oh unfortunately & wdym, Likeness: 14
                                                                     * If BMI & pretty good & Oh unfortunately & wdym, Likeness: 11
                                                                     * If BMI & not too bad & Oh unfortunately & wdym, Likeness: 14
                                                                     * else & dont like tbh & meh & wdym, Likeness: 12
                                                                     * If BMI & not too bad & meh & wdym, Likeness: 12*/
                                                                    drink = rand.Next(100, 1000);
                                                                    player.Money -= drink;
                                                                    kvinde.LikenessMeter += drink / 100;
                                                                    //Not doing every single one here :I
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine(kvinde.Name + ": \"No thank you - I've had enough drinks...\"");
                                                                    kvinde.LikenessMeter += 2;
                                                                    /* else & dont like tbh & Cool I usually & wdym, Likeness: 21
                                                                     * If BMI & pretty good & Cool I usually & wdym, Likeness: 19
                                                                     * If BMI & not too bad Cool I usually & wdym, Likeness: 21
                                                                     * If BMI & alrigt ig Cool I usually & wdym, Likeness: 17
                                                                     * else & dont like tbh & Oh unfortunately & wdym, Likeness: 13
                                                                     * If BMI & pretty good & Oh unfortunately & wdym, Likeness: 11
                                                                     * If BMI & not too bad & Oh unfortunately & wdym, Likeness: 13
                                                                     * else & dont like tbh & meh & wdym, Likeness: 11
                                                                     * If BMI & not too bad & meh & wdym, Likeness: 11*/
                                                                }
                                                            }
                                                            else if (Choice == "3" || Choice == "is" || Choice == "is there anything i can do for you?")
                                                            {
                                                                Console.WriteLine(player.Playername + ": \"Is there anything I can do for you?\"");
                                                                kvinde.LikenessMeter += 2;
                                                                /* else & dont like tbh & Cool I usually, Likeness: 21
                                                                 * If BMI & pretty good & Cool I usually, Likeness: 19
                                                                 * If BMI & not too bad Cool I usually, Likeness: 21
                                                                 * If BMI & alrigt ig Cool I usually, Likeness: 17
                                                                 * else & dont like tbh & Oh unfortunately, Likeness: 13
                                                                 * If BMI & pretty good & Oh unfortunately, Likeness: 11
                                                                 * If BMI & not too bad & Oh unfortunately, Likeness: 13
                                                                 * else & dont like tbh & meh, Likeness: 11
                                                                 * If BMI & not too bad & meh, Likeness: 11*/

                                                                if (kvinde.LikenessMeter <= 14)
                                                                    KvindeLeaving(kvinde, true, "No, thank you. But I should be leaving, so thank you for the chat.", 2);
                                                            }
                                                            else if (Choice == "4" || Choice == "bail")
                                                            {
                                                                Console.WriteLine(player.Playername + ": \"Anyways, I should be going - bye!\"");
                                                                Restart = true;
                                                                KvinderMet++;
                                                            }
                                                            else
                                                                Loop = true;
                                                        } while (Loop);
                                                    }
                                                    else if (Choice == "2" || Choice == "oh" || Choice == "oh well that's fine")
                                                    {
                                                        Console.WriteLine(player.Playername + ": \"Oh well that's fine.\"");
                                                        System.Threading.Thread.Sleep(1000);
                                                        do
                                                        {
                                                            Loop = false;
                                                            Console.WriteLine(kvinde.Name + ": \"Is there something wrong with that?\"");
                                                            Console.WriteLine();
                                                            Console.WriteLine("[1]: \"Idk, I just find that weird, I guess...\"");
                                                            Console.WriteLine("[2]: \"Nono, nothing wrong with that at all...\"");
                                                            Choice = Console.ReadLine().ToLower();

                                                            Console.Clear();

                                                            if (Choice == "1" || Choice == "idk" || Choice == "idk, i just find that weird, i guess")
                                                            {
                                                                Console.WriteLine(player.Playername + ": \"I don't know - I just find that weird, I guess?\"");
                                                                kvinde.LikenessMeter -= 8;
                                                                Console.WriteLine(kvinde.Name + ": \"What's wrong with it??\"");
                                                                Console.WriteLine(player.Playername + ": \"" + Console.ReadLine() + "\"");
                                                                kvinde.LikenessMeter -= 10;
                                                                KvindeLeaving(kvinde, true, "You know what ? Fuck you! Leave me alone!", 10);
                                                            }
                                                            else if (Choice == "2" || Choice == "nono" || Choice == "nono, nothing wrong with that at all...")
                                                            {
                                                                Console.WriteLine(player.Playername + ": \"Nono, nothing wrong with that at all!\"");
                                                                Console.Write(kvinde.Name + ": \"Hmph...\"");
                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.WriteLine("*rolls eyes*");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                kvinde.LikenessMeter -= 5;
                                                                System.Threading.Thread.Sleep(2000);
                                                            }
                                                            else
                                                                Loop = true;
                                                        } while (Loop);
                                                    }
                                                    else if (Choice == "3" || Choice == "Bail")
                                                    {
                                                        Console.WriteLine(player.Playername + ": \"Yeah totally okay- uhm I have to go now so see ya later!\"");
                                                        kvinde.LikenessMeter -= 8;
                                                        Restart = true;
                                                    }
                                                    else
                                                        Loop = true;
                                                } while (Loop);
                                            }
                                            else if (Choice == "2" || Choice == "ask" || Choice == "ask into her life")
                                            {
                                                Console.WriteLine(player.Playername + ": \"So uh what do you do for a living?\"");
                                                System.Threading.Thread.Sleep(1000);
                                                do
                                                {
                                                    Loop = false;
                                                    Console.WriteLine("Kvinde: \"Oh uhm well I'm a " + kvinde.Occupation + " person.\"");
                                                    Console.WriteLine("Kvinde: \"Off-work I usually do " + kvinde.Hobby + ".\"");
                                                    Console.WriteLine("Kvinde: \"What about you?\"");
                                                    Console.WriteLine();
                                                    Console.WriteLine("[1]: Tell occupation & hobby");
                                                    Console.WriteLine("[2]: Lie about occupation & hobby");
                                                    Choice = Console.ReadLine().ToLower();

                                                    if (Choice == "1" || Choice == "tell" || Choice == "tell occupation & hobby")
                                                    {
                                                        Console.WriteLine(player.Playername + ": \"I'm a " + player.Occupation + ", and usually do " + player.Hobby + " when I have time.\"");
                                                        kvinde.LikenessMeter += 2;
                                                        /* else & dont like tbh, Likeness: 13
                                                         * If BMI & pretty good, Likeness: 11
                                                         * If BMI & not too bad, Likeness: 13
                                                         * If BMI & alrigt ig, Likeness: 9 */
                                                    }
                                                    else if (Choice == "2" || Choice == "lie" || Choice == "lie about occupation & hobby")
                                                    {
                                                        Console.WriteLine(player.Playername + ": \"I'm a " + Console.ReadLine() + ", and usually do " + Console.ReadLine() + " when I have time.\"");
                                                        kvinde.LikenessMeter -= 2;
                                                        /* else & dont like tbh, Likeness: 9
                                                         * If BMI & pretty good, Likeness: 7
                                                         * If BMI & not too bad, Likeness: 9
                                                         * If BMI & alrigt ig, Likeness: 5 */
                                                        player.SinMeter += 5;

                                                        if (kvinde.LikenessMeter <= 5)
                                                            KvindeLeaving(kvinde, true, "Well, anyways - it's getting late... Thanks for the chat.", 6);
                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        Loop = true;
                                                    }
                                                } while (Loop);
                                            }
                                            else if (Choice == "3" || Choice == "bail")
                                            {
                                                Console.WriteLine(player.Playername + ": \"Anyways I need to do something personal - enjoy the drink!\"");
                                                Restart = true;
                                            }
                                            else
                                            {
                                                Loop = true;
                                                Console.Clear();
                                            }
                                        } while (Loop);
                                    }
                                    else
                                    {
                                        do
                                        {
                                            Loop = false;
                                            Console.WriteLine("This is going smoothly! Now what to do next?");
                                            for(int x = 0; x < 3; x++)
                                                Console.WriteLine();
                                            Console.WriteLine("[1]: Introduce yourself");
                                            Console.WriteLine("[2]: Ask into the Kvinde");
                                            Console.WriteLine("[3]: Bail");

                                            Choice = Console.ReadLine().ToLower();
                                            Console.Clear();

                                            if (Choice == "1" || Choice == "introduce" || Choice == "introduce yourself")
                                            {
                                                Console.WriteLine(player.Playername + ": \"I'm " + player.Playername + " by the way - Nice to meet you ");
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine(":)");
                                                Console.ForegroundColor = ConsoleColor.White;

                                            }
                                            else if (Choice == "2" || Choice == "ask" || Choice == "ask into the kvinde")
                                            {

                                            }
                                            else if (Choice == "3" || Choice == "bail")
                                            {

                                            }
                                            else
                                                Loop = true;

                                        } while (Loop);
                                    }
                                }
                                else if (Choice == "2" || Choice == "ask why" || Choice == "ask why she's here")
                                {
                                    Console.WriteLine(player.Playername + ": \"So why are you here?\"");
                                    System.Threading.Thread.Sleep(1200);
                                    int reason = rand.Next(1, 4);
                                    if (reason == 1) //Just chilling
                                    {
                                        Console.WriteLine("Kvinde: \"I just came by to chill man - nothing special\"");
                                    }
                                    else if(reason == 2) //Breakup
                                    {
                                        
                                    }
                                    else if(reason == 3) //Drink stuff
                                    {

                                    }
                                    else //Meet someone to talk to
                                    {
                                        
                                    }
                                }
                                else if (Choice == "3" && kvinde.LikenessMeter == 15 || Choice == "compliment" && kvinde.LikenessMeter == 15 || Choice == "compliment her open mind" && kvinde.LikenessMeter == 15)
                                {

                                }
                                else if (Choice == "3" && kvinde.LikenessMeter != 15 || Choice == "compliment" && kvinde.LikenessMeter != 15 || Choice == "compliment her open mind" && kvinde.LikenessMeter != 15)
                                {

                                }
                                else
                                    Loop = true;
                            } while (Loop);
                            if (kvinde.LikenessMeter <= 15)
                            {
                                Console.WriteLine(kvinde.Name + ": \"You should poke me again sometime - I'd love to talk to you again!\"");
                                System.Threading.Thread.Sleep(1000);
                                KvindeLeaving(kvinde, true, "Anyways thank you for the support! Talk to you later!", -10);
                                Restart = false;
                            } //Was Start Phase successful?
                        }
                        else if (kvinde.Formal == "Bad Girl")
                        {

                        }
                        else if (kvinde.Formal == "Tomgirl")
                        {

                        }
                        else if (kvinde.Formal == "Innocent")
                        {

                        }
                        else if (kvinde.Formal == "Oblivious")
                        {

                        }
                        else //Sofisticated
                        {

                        }
                    }
                    else if(Choice == "2" || Choice == "what" || Choice == "what brings someone like you here?")
                    {

                    }
                    else if(Choice == "3" || Choice == "do" || Choice == "do you have any cigarettes?")
                    {

                    }
                    else if(Choice == "4" || Choice == "bail")
                    {
                        Restart = true;
                        Console.Clear();
                    }
                    else
                    {
                        Loop = true;
                        Console.Clear();
                    }
                }
                else if (Meeting == "dancefloor")
                {
                    Console.WriteLine("[1]: \"I love this song! I see you do too?\"");
                    Console.WriteLine("[2]: \"I'm glad you like the song! I made this in my studio.\"");
                    Console.WriteLine("[3]: \"I love those moves you've got!\"");
                    Console.WriteLine("[4]: Bail.");
                }
                else if (Meeting == "bar table")
                {
                    Console.WriteLine("[1]: \"Are you waiting for someone?\"");
                    Console.WriteLine("[2]: \"How come a beautiful girl like you sits all alone in a place like this?\"");
                    Console.WriteLine("[3]: \"Can I bring you anything, miss...?\"");
                    Console.WriteLine("[4]: Bail.");
                }
                else //Smoking area
                {
                    Console.WriteLine("[1]: \"Hey, can I borrow a cigarette and some light from you, miss...?\"");
                    Console.WriteLine("[2]: \"How do you like the party?\"");
                    Console.WriteLine("[3]: \"How come a pretty one like you would be such a place like this?\"");
                    Console.WriteLine("[4]: Bail.");
                }
            } while (Loop); //Start Phase initialization

            Console.ReadKey();
            return kvinde;
        }
        //Local variables & Helper methods
        static string Choice = "";
        static bool Loop = false;
        static bool Restart = false;
        static readonly Random rand = new Random();
        static Player player;
        static Player PNDefinition()
        {
            //Needs to return Player class, so we make a "null" instance of the class
            Player player = new Player("null", 0, "null", "null");

            //User will go through loop at least once, and if information is incorrect, it will loop, otherwise it will break loop
            do
            {
                //Personal information is needed to create the true Player class
                Console.Write("Name: ");
                string PN = Console.ReadLine();
                int Age = 0;
                try
                {
                    Console.Write("Age: ");
                    Age = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Loop = true;
                }
                Console.Write("Occupation: ");
                string Occupation = Console.ReadLine();
                Console.Write("Hobby: ");
                string Hobby = Console.ReadLine();

                //Is User satisfied with the entered information?
                for (int x = 0; x < 3; x++)
                    Console.WriteLine();
                Console.WriteLine("Are you satisfied with the entered information?");
                Choice = Console.ReadLine().ToLower();

                //If User is satisfied, run them through the Player creation process, otherwise do the Loop
                if (Choice == "yes")
                {
                    Console.Clear();

                    /*Is the entered information valid for the player class?
                    If try succeeds, loop will be false (incase they made a mistake at first), and player will be created.
                    If try fails, Loop will be true, and the do/while-loop will loop until the required information is met.*/

                    try
                    {
                        player = new Player(PN, Age, Occupation, Hobby);
                        Loop = false;
                    }
                    catch
                    {
                        Console.WriteLine("The entered information doesn't match up to its requirements. Please try again.");
                        Console.ReadKey();
                        Loop = true;
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("Please enter your information");
                    Console.ReadKey();
                    Loop = true;
                    Console.Clear();
                }
            } while (Loop);
            player.Money = player.GetStarterMoney();
            player.Loneliness = 10;
            return player;
        }
        static readonly Kvinde[] wannabePhoneBook = new Kvinde[4];
        static int KvinderMet = 0;
        static Kvinde GetNewKvinde()
        {
            string[] Names = { "Sophia", "Emma", "Olivia", "Emily", "Sarah", "Alice", "Amelia", "Ruby", "Chloe" };
            string[] Months = { "Janurary", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            string[] occupation = { "Unemployed", "Student", "Selfemployed", "Casheer", "McD Employee", "Manager" };
            string[] hobby = { "Drawing", "Skating", "Chilling", "Outgoing", "Work", "Singing", "Social Media" };

            Random rand = new Random();

            string Name = Names[rand.Next(0, 8)];

            int Day = rand.Next(1, 28);
            string month = Months[rand.Next(0, 11)];
            int Year = rand.Next(1990, 2001);
            string Birthday = Day + "-" + month + "-" + Year;

            int Age = 2019 - Year;

            string Occupation = occupation[rand.Next(0, 5)];

            string Hobby = hobby[rand.Next(0, 6)];

            Kvinde kvinde = new Kvinde(Name, Birthday, Age, Occupation, Hobby);
            return kvinde;
        }
        static bool KvindeLeaving(Kvinde kvinde, bool knownName, string excuse, int lonelinessAmount)
        {
            if (knownName)
                Console.Write(kvinde.Name + ": \"");
            else
                Console.Write("Kvinde: \"");
            Console.Write(excuse);
            Console.WriteLine("\"");
            Console.Write(player.Playername + ":\"");
            Console.Read();
            Console.WriteLine("\"");
            Console.WriteLine(kvinde.Name + ": \"Bye!\"");
            player.Loneliness += lonelinessAmount;
            Restart = true;
            return Restart;
        }
        static string CoincidentalMeeting()
        {
            string[] Meetings = { "bar counter", "dancefloor", "bar table", "smoking area" };
            Random rand = new Random();
            return Meetings[rand.Next(0, 3)];
        }

        static void Main()
        {
            player = PNDefinition();

            bool exitGame = false;
            while (!exitGame)
            {
                StartPhase();
            }
        }
    }
}