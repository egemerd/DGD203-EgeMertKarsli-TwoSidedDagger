using Final_C_;
using System.Numerics;

internal class Program
{
    public static Places place1 = new Places("Germany", 150, 150);
    public static Places place2 = new Places("Poland", 170, 150);
    public static Places place3 = new Places("Italy", 150, 130);
    public static Places place4 = new Places("France", 130, 150);



    public static Character player = new Character("Player", 16, 5, 100, 0.3);
    public static Character enemy = new Character("Enemy", 12, 8, 120, 0.2);

    static string chosen_location = "";
    static int chosen_coordinate1;
    static int chosen_coordinate2;  
    static int game_point = 0;

    static HashSet<string> visitedLocations = new HashSet<string>();

    

    private static void Main(string[] args)
    {
        IntroGame();
        StartingGame();
        AfterWitchWin();
        
        NumberGuessingGame();

        AfterStrangerWin();
    }
    public static void IntroGame() 
    {
        Console.WriteLine("\nYou are a guy who wants to avenge his father and his brother.");
        Console.WriteLine("Your brother is missing from that day. You trying to find him.\n");
    }
    public static void StartingGame()
    {
        string game_start_or_credits;
        bool game_option_selection = true;
        Console.WriteLine("Welcome To The Game");

        while (game_option_selection == true)
        {
            Console.WriteLine("Press n for new game \nPress c for credits ");
            game_start_or_credits = Console.ReadLine();


            if (game_start_or_credits == "n")
            {
                GameStart();
                game_option_selection = false;
            }
            else if (game_start_or_credits == "c")
            {
                GameCredits();
                game_option_selection = false;
            }
            else if (game_start_or_credits != "n" && game_start_or_credits != "c")
            {
                Console.WriteLine("You chose an invalid answer.");
            }
        }
    }

    
    public static void LocationSelection(Places place4, Places place3, Places place2, Action afterTravelMethod)
    {
        string which_way;

        while (true)
        {
            
            Console.WriteLine("\nWhere do you want to go? West, East or South");

           // if (visitedLocations.Contains(place4.name))
                //Console.WriteLine("You have already visited West (England). You cannot go there again.");
            //if (visitedLocations.Contains(place2.name))
                //Console.WriteLine("You have already visited East (Spain). You cannot go there again.");
            //if (visitedLocations.Contains(place3.name))
                //Console.WriteLine("You have already visited South (Italy). You cannot go there again.");


            which_way = Console.ReadLine()?.ToLower();

            // Kullanıcının gideceği yeri kontrol et
            switch (which_way)
            {
                case "west":
                    if (!visitedLocations.Contains(place4.name))
                    {
                        chosen_location = place4.name;
                        chosen_coordinate1 = place4.location1;
                        chosen_coordinate2 = place4.location2;
                        visitedLocations.Add(place4.name); // Ziyaret edilenler listesine ekle
                        afterTravelMethod();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("You have already visited West.");
                    }
                    break;

                case "east":
                    if (!visitedLocations.Contains(place2.name))
                    {
                        chosen_location = place2.name;
                        chosen_coordinate1 = place2.location1;
                        chosen_coordinate2 = place2.location2;
                        visitedLocations.Add(place2.name); // Ziyaret edilenler listesine ekle
                        afterTravelMethod();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("You have already visited East.");
                    }
                    break;

                case "south":
                    if (!visitedLocations.Contains(place3.name))
                    {
                        chosen_location = place3.name;
                        chosen_coordinate1 = place3.location1;
                        chosen_coordinate2 = place3.location2;
                        visitedLocations.Add(place3.name); // Ziyaret edilenler listesine ekle
                        afterTravelMethod();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("You have already visited South.");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please choose again: West, East or South.");
                    break;
            }
        }
    }

    public static void GameStart()
    {
        Console.WriteLine($"You are now in {place1.name}");
        Console.WriteLine($"The Locations are ({place1.location1},{place1.location2})");
        LocationSelection(place4, place3, place2,FirstTravel);
    }
    public static void FirstTravel()
    {


        Console.WriteLine($"Now you are in {chosen_location} \nLocations are ({chosen_coordinate1},{chosen_coordinate2})");
        Console.WriteLine("\nYou figure out that there is a trap when you entered this city.");
        Console.WriteLine("\nBut you fall for that anyways.");
        Console.WriteLine("There is a witch looking woman tells you that she would save you but in one condition..");
        Console.WriteLine("To beat her in her game.");
        RockPaperScissors();


    }

    public static void RockPaperScissors()
    {
        string[] choices = { "fire", "water", "earth" };
        bool playAgain = true;

        Random random = new Random();

        int witchScore = 0;
        int playerScore = 0;

        while (playAgain)
        {
            Console.Write("\nEnter your choice (fire, water, earth): ");
            string playerChoice = Console.ReadLine()?.ToLower();

            
            if (!Array.Exists(choices, choice => choice == playerChoice))
            {
                Console.WriteLine("Invalid choice. Please choose fire, water, or earth.");
                continue;
            }

            
            
            string witchChoice = choices[random.Next(choices.Length)];

            Console.WriteLine($"The witch chose: {witchChoice}");



            
            if (playerChoice == witchChoice)
            {
                Console.WriteLine("You dare to choose same as me. How pathetic!");

            }
            else if ((playerChoice == "fire" && witchChoice == "earth") ||
                     (playerChoice == "water" && witchChoice == "fire") ||
                     (playerChoice == "earth" && witchChoice == "water"))


            {
                Console.WriteLine("You win against the witch!");
                
                playerScore++;

            }
            else
            {
                Console.WriteLine("The witch wins!");
                
                witchScore++;

            }

            Console.WriteLine($"Witch's score: {witchScore}");
            Console.WriteLine($"Your score: {playerScore}");
            

            if (playerScore == 3)
            {
                Console.WriteLine("\nYou won the game against the witch");
                game_point = game_point + 10;
                playAgain = false;
                
            }
            if (witchScore == 3)
            {
                Console.WriteLine("\nYou lose the game against the witch");
                Console.WriteLine("You're lucky for that she will play that as long as you alive and wanted to win.");
                Console.WriteLine("Because she have never losed");
                Console.WriteLine("The undefeated witch longs for the silence only loss can bring.\n");
                game_point = game_point - 2;
                playerScore = 0;
                witchScore = 0;

            }

            //Console.Write("Do you want to play again? (yes/no): ");
            //string playAgainChoice = Console.ReadLine()?.ToLower();
            //playAgain = (playAgainChoice == "yes");
        }

        
    }

    public static void AfterWitchWin()
    {
        Console.WriteLine("\nThe witch loses againt you. The taste of losing is make her very pleased.\nAnd she puts you back where you started.");
        Console.WriteLine($"Now you have {game_point} life coins.");
        Console.WriteLine("Game Info: This is the money that you can buy things that brings death.");
        Console.WriteLine("\nThe witch sends you where you came from");
        Console.WriteLine($"Now you are in {place1.name}\nYour locations are ({place1.location1},{place1.location2})");

        LocationSelection(place4,place3,place2, SecondTravel);
    }

    public static void SecondTravel() 
    {
        Console.WriteLine($"Now you are in {chosen_location} \nLocations are ({chosen_coordinate1},{chosen_coordinate2})");
        Console.WriteLine("\nIn this city a weird looking stranger finds you like he was looking for you and gives you a paper.");
        Console.WriteLine("In the paper says: If you want to find what you are looking for,you should not use only two eyes.");
        Console.WriteLine("In the back of the paper, there is a game to play.\nA Number guess game.");
        Console.WriteLine("Whom number is close to the number have chosen is wins.");
        
    }

    public static void NumberGuessingGame() 
    { 
        Random random = new Random();
        bool loopChecker=true;
        int playerNumber;
        int strangerNumber;
        int randomNumber;
        int playerDistance;
        int strangerDistance;

        while (loopChecker) 
        {
            strangerNumber = random.Next(1, 101);
            randomNumber = random.Next(1, 101);
            
            Console.WriteLine("Write the number you choose to put your fate in.");
            playerNumber = int.Parse(Console.ReadLine());

            

            playerDistance = Math.Abs(randomNumber - playerNumber);
            strangerDistance = Math.Abs(randomNumber - strangerNumber);

            if (playerDistance < strangerDistance)
            {
                Console.WriteLine($"Your number is {playerNumber}. Strangers number is {strangerNumber}");
                Console.WriteLine("Your fate is not ended here");
                game_point = game_point + 10;
                loopChecker = false;
            }
            else if(playerDistance==strangerDistance)
            {
                Console.WriteLine("It is a draw!");
            }
            else 
            {
                Console.WriteLine($"Your number is {playerNumber}. Strangers number is {strangerNumber}");
                Console.WriteLine("Your fate have abondened you.");
                game_point = game_point -5;
            }

        }
    }

    public static void AfterStrangerWin() 
    {
        Console.WriteLine("When you win against the stranger, your eyes shut down immedeately. \nYou found yourself in the place you have started again.");
        LocationSelection(place4, place3, place2, ThirdTravel);

    }
    public static void ThirdTravel() 
    {
        //Console.WriteLine($"You have {game_point} life coins");
        //Console.WriteLine("You can buy some things");

        Console.WriteLine("You are in a city where is corrupted. Dirty streets, dirty people...");
        Console.WriteLine("But you are looking for something. Don't you forget that.");
        Console.WriteLine("Someone graps you from behind. You try to escape from it.");
        Console.WriteLine("When you escape and turn around you saw a guy with a cover in his face ");
        Console.WriteLine("That's him...!!!");
        Console.WriteLine("You and him immediately started to fight.");
        Battle();
    }

    public static void Battle() 
    {

        

        while (player.isAlive() && enemy.isAlive()) 
        {
            int originalPlayerDefense = 5;
            int originalEnemyDefense = 8;
            Random random = new Random();
            int enemyChoice = random.Next(1, 3);
            Console.WriteLine("\nChoose your action: 1 for Attack 2 for Defend");
            string choice = Console.ReadLine();

            if (choice == "2")
            {
                player.defense += 4;
                Console.WriteLine("Player has defended.");
            }

            if (enemyChoice == 2)
            {
                enemy.defense += 6;
                Console.WriteLine("\nEnemy has defended.");
            }

            

            if (choice == "1")
            {
                player.MakingAttack(enemy);
                
                if (!enemy.isAlive())
                {
                    Console.WriteLine("\nYou defeated the enemy!");
                    
                }
            }
            
            
                       

            if (enemyChoice == 1)
            {
                enemy.MakingAttack(player);
                
            }

            player.defense = originalPlayerDefense;
            enemy.defense = originalEnemyDefense;
            Console.WriteLine($"\nPlayer Health: {player.health} | Enemy health: {enemy.health}");



            if (!player.isAlive())
            {
                Console.WriteLine("You lost.\n");
                StartingGame();
                
            }
            
            if (!enemy.isAlive())
            {
                Console.WriteLine("You win.\n");
                
                GameEnd();
                break;
            }
            
        }
        
    }

    public static void GameEnd()
    {
        Console.WriteLine("When you see what's under that cover, you wish to be blind.");
        Console.WriteLine("Your own brother...");
        Console.WriteLine("Game End.\n");

        Console.WriteLine("Would you like to play again? (yes/no)");
        string playAgain = Console.ReadLine()?.ToLower();

        if (playAgain == "yes")
        {
            StartingGame(); 
        }
        else
        {
            Console.WriteLine("Thank you for playing!");
            Environment.Exit(0);  

        }
    }

    public static void GameCredits()
    {
        Console.WriteLine("Ege Mert Karslı and ChatGPT Cooperation.");
    }


}

