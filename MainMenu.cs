using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading;

namespace BaseBall
{
    public abstract class Execute
    {
        public abstract void Start();
    }

    public class MainMenu
    {
        static void Main(string[] args)
        {

            Console.Title = "Diamond in the rough";

            SelectionOption Option = new SelectionOption();
            bool running = true;

            while (running)
            {
                Console.Clear();

                string choice = Option.SelectOption("\b\b\b\b________  .__                                  .___   .__         \r\n\\______ \\ |__|____    _____   ____   ____    __| _/   |__| ____   \r\n |    |  \\|  \\__  \\  /     \\ /  _ \\ /    \\  / __ |    |  |/    \\  \r\n |    `   \\  |/ __ \\|  Y Y  (  <_> )   |  \\/ /_/ |    |  |   |  \\ \r\n/_______  /__(____  /__|_|  /\\____/|___|  /\\____ |    |__|___|  / \r\n        \\/        \\/      \\/            \\/      \\/            \\/  \r\n   __  .__                                             .__        \r\n _/  |_|  |__   ____        _______  ____  __ __  ____ |  |__     \r\n \\   __\\  |  \\_/ __ \\       \\_  __ \\/  _ \\|  |  \\_/ ___\\|  |  \\    \r\n  |  | |   Y  \\  ___/        |  | \\(  <_> )  |  / /_/  >   Y  \\   \r\n  |__| |___|  /\\___  >       |__|   \\____/|____/\\___  /|___|  /   \r\n            \\/     \\/                          /_____/      \\/    ", new List<string> { "NEW GAME", "LOAD GAME", "CAMPAIGN MODE", "CREDITS", "EXIT" });

                switch (choice)
                {
                    case "NEW GAME":
                        NewGame newgame = new NewGame();
                        newgame.Start();
                        break;
                    case "LOAD GAME":
                        LoadGame loadgame = new LoadGame();
                        loadgame.Start();
                        break;
                    case "CAMPAIGN MODE":
                        CampaignMode campaign = new CampaignMode();
                        campaign.Start();
                        break;
                    case "CREDITS":
                        Credits credits = new Credits();
                        credits.Start();
                        break;
                    case "EXIT":
                        running = false;
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.Write("INVALID INPUT!");
                        EnterToRetry();
                        break;
                }
            }
        }
        public static void WaitForEnter()
        {
            Console.WriteLine("\nPress ENTER to continue...");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
        }
        public static void EnterToRetry()
        {
            Console.WriteLine("\nPress ENTER to retry...");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
        }

        public static void LoadingScreen()
        {
            char[] icons = { '/', '-', '\\', '|', };
            Console.Write("\nLoading");

            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }

            for (int i = 0; i < 12; i++)
            {
                char current = icons[i % icons.Length];
                Console.Write(current);
                Thread.Sleep(150);
                Console.Write("\b");
            }

            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }
    }

    //==================================================================================================

    //<NewGame class>
    public class NewGame : Execute
    {
        public override void Start()
        {
            runNewGame();
        }
        private void runNewGame()
        {
            Console.Clear();
            Console.WriteLine("===== NEW GAME =====\nWelcome! Let's create your character!\n");

            MainMenu.LoadingScreen();

            CharacterCreation charCreate = new CharacterCreation();
            charCreate.Start();
        }
    }
    //</NewGame class>

    //==================================================================================================

    //<CampaignMode class>
    public class CampaignMode : Execute
    {
        public override void Start()
        {
            runCampagignMode();
        }
        private void runCampagignMode()
        {
            Console.Clear();
            Console.WriteLine("   ===== CAMPAIGN MODE =====   ");
            Console.WriteLine("-- Press ANY KEY to Continue --");

            string[] story =
            {
                "\nIn a serene and tranquil suburbs is a boy who has a passion for sports, particularly baseball.",
                "His name is Charles, an energetic, resilient and playful child.",
                "Charles' first experience with sports was on his 7th birthday, his parents took him to see a famed team known to baseball.",
                "On that day, as he watched the players sprint across the field and the crowd erupt with every hit, something inside him lit up. ",
                "From then on, Charles practiced with a worn-out bat in his backyard every afternoon, imagining himself as part of that legendary team.\n",

                "After a few years, Charles is now 14 years old and his fiery passion for baseball hasn't burned out. ",
                "The school year is about to begin and he has taken the first steps into his highschool years.",
                "He was very estatic to learn that their school was holding tryouts for baseball.",
                "Charles hasted to sign up, no time to spare!",
                "Charles was always practicing whenever he has the time after school so he was very certain to pass the tryouts. ",
                "Weeks had gone by and the results was posted on the school board.",
                "It was flocking with students left and right!",
                "Charles had to squeeze in to have a closer look.",
                "His hands shaking, mind racing as he searches for his name on the board, his heart races as he scans closer to the end with no sign of his name.",
                "He almost lost hope until... he found his name, Charles jumped with excitement along with a smile on his face.\n",

                "With Charles now a part of a baseball team, his dreams to make it into a team has finaly came true. ",
                "The schools extramurals is coming around the corner, Charles and his team have been getting ready to compete and take the trophy in the name of their school and for themselves. ",
                "A few days had gone by non stop practice and hard training Charles and his team has endured, on the day of the extramurals they are about to reap their reward. ",
                "The event venue was a big stadium able to fit thousands of people, Charles was in awe at the sight. ",
                "Charles is the designated hitter of the team time and time again, he was able to hit the ball with perfect accuracy but something was troubling him. ",
                "His heart is racing, his hands starts to shake insanely as he gets ready to bat. It was the crowd, the pressure of not letting down his team, their coach, and their school. ",
                "The weight and the pressure got to him, causing his swing to miss to the strike of three. ",
                "In distraught he ran to the lockers room, his chest beating loudly and anxiety setting in, he needed something to calm himself down inside the locker room.\n"
            };

            foreach (string line in story)
            {
                Console.WriteLine(line);
                while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
            }

            MainMenu.LoadingScreen();
            Console.Clear();
            Console.WriteLine("\x1b[3J");
        }
    }

    //==================================================================================================

    //<LoadGame class>
    public class LoadGame : Execute
    {
        SelectionOption Option = new SelectionOption();
        MySqlConnection sqlConn = new MySqlConnection("SERVER=LOCALHOST; DATABASE=DITR; UID=root; PASSWORD=acierandresraignruedaandreideseo");
        string loadedCharacter = "None";
        string Done = "No";
        List<string> loadingCharacterUsernames = new List<string>();

        public override void Start()
        {
            runLoadGame();
        }
        private void runLoadGame()
        {
            try
            {
                sqlConn.Open();
                MySqlCommand sqlCMD = new MySqlCommand("SELECT * FROM CharacterData", sqlConn);
                MySqlDataReader reader = sqlCMD.ExecuteReader();

                //Insert data base character names data into list
                while (reader.Read())
                {
                    loadingCharacterUsernames.Add(reader["Character_Name"].ToString());
                }
                loadingCharacterUsernames.Add("Return");
                reader.Close();
                sqlConn.Close();
                //Insert data base character names data into list

                bool repeatLoadOrDeleteBlock = true;
                do
                {
                    string loadOrDelete = Option.SelectOption("Load Character saves", new List<string> { "Load Save", "Delete Save", "Return" });
                    loadOrDeleteBlock(loadOrDelete, ref repeatLoadOrDeleteBlock);
                } while (repeatLoadOrDeleteBlock);
            }
            catch (Exception e)
            {
                Console.WriteLine("An error has occured(LOAD CHARACTER)");
                MainMenu.WaitForEnter();
            }
        }
        private string CharacterDetails()
        {
            try
            {
                sqlConn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error has occured(LOAD CHARACTER DETAILS)");
                MainMenu.WaitForEnter();
            }
            MySqlCommand sqlCMD = new MySqlCommand($"SELECT * FROM CharacterData WHERE Character_Name = \"{loadedCharacter}\"", sqlConn);
            MySqlDataReader reader = sqlCMD.ExecuteReader();
            string fullcharacterdata = "";
            try
            {
                while (reader.Read())
                {
                    string athle = reader["IsAtlethic"].ToString();
                    string agile = reader["IsAgile"].ToString();
                    string tenac = reader["IsTenacious"].ToString();
                    string acc = reader["IsSharp"].ToString();

                    fullcharacterdata = $"{loadedCharacter} ===" +
                        $"\nGENDER: {reader["Gender"]}\n" +
                        $"BODY TYPE: {reader["BodyType"]}\n" +
                        $"SKIN COLOR: {reader["SkinColor"]}\n" +
                        $"HAIR COLOR: {reader["HairColor"]}\n" +
                        $"EYE COLOR: {reader["EyeColor"]}\n" +
                        $"EYEBROW THICKNESS: {reader["EyebrowThickness"]}\n" +
                        $"BAT TEXTURE: {reader["BaseballBatTexture"]}\n" +
                        $"BAT DESIGN: {reader["BaseballBatDesign"]}\n" +
                        $"SHOES: {reader["Shoes"]}\n" +
                        $"SHIRT DESIGN: {reader["ShirtDesgin"]}\n" +
                        $"PANTS DESIGN: {reader["PantsDesign"]}\n" +
                        $"ACCESSORIES: {reader["Accessories"]}\n" +
                        $"CAP (HEADWEAR): {reader["Cap"]}\n" +
                        $"SOCKS: {reader["Socks"]}\n" +
                        $"PREFERRED POSITION: {reader["PreferredPosition"]}\n" +
                        $"TEAM MASCOT: {reader["TeamMascot"]}\n" +
                        $"PERKS: {reader["Perks"]}\n" +
                        $"TRAITS: ATHELETIC = {athle} | AGILE = {agile} | TENACIOUS = {tenac} | SHARP = {acc}\n" +
                        $"STATS: STR = {reader["Strength"]} SPD = {reader["Speed"]} | STA = {reader["Stamina"]} | ACC = {reader["Accuracy"]}\n" +
                        "=== LOAD CHARACTER?";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error has (DATABASE LOAD DETAILS)");
                MainMenu.WaitForEnter();
            }
            finally
            {
                sqlConn.Close();
            }
            return fullcharacterdata;
        }
        private void loadOrDeleteBlock(string loadOrDelete, ref bool exit)
        {
            switch (loadOrDelete)
            {
                case "Load Save":
                    do
                    {
                        loadedCharacter = Option.SelectOption("Load Character", loadingCharacterUsernames);

                        if (loadedCharacter != "Return")
                        {
                            Done = Option.SelectOption(CharacterDetails());
                            MainMenu.WaitForEnter();
                            if (Done == "Yes") { exit = false; }
                        }
                        else
                        {
                            break;
                        }
                    } while (Done == "No");
                    break;
                case "Delete Save":
                    bool notSureToDeleteYet = true;
                    sqlConn.Open();
                    do
                    {

                        loadedCharacter = Option.SelectOption("Delete Character", loadingCharacterUsernames);
                        if (loadedCharacter == "Return") { break; }

                        notSureToDeleteYet = Option.SelectOption($"Delete Character {loadedCharacter}?") == "Yes" ? false : true;
                        if (notSureToDeleteYet != true)
                        {
                            loadingCharacterUsernames.Remove(loadedCharacter);

                            MySqlCommand sqlCMD = new MySqlCommand($"DELETE FROM CharacterData WHERE Character_Name = \"{loadedCharacter}\";", sqlConn);
                            try
                            {
                                sqlCMD.ExecuteNonQuery();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("An error has occured(DATABASE DELETE)");
                            }
                            finally
                            {
                                Console.WriteLine("Character successfully deleted!"); MainMenu.LoadingScreen();
                            }
                        }

                    } while (notSureToDeleteYet);
                    sqlConn.Close();
                    break;
                case "Return":
                    exit = false;
                    break;
            }
        }
    }

    //==================================================================================================

    //<Credits class>
    public class Credits : Execute
    {
        public override void Start()
        {
            runCredits();
        }
        private void runCredits()
        {
            Console.Clear();
            Console.WriteLine("===== CREDITS =====" +
                "\nRaign Rueda - Siya gumawa ng database para sa laro." +
                "\nAndrei Deseo - Tumulong sa pag-code at pag-setup ng database." +
                "\nAcier Andres - Bumuo ng buong idea, gameplay concept, at overall flow ng code." +
                "\n\nPress ANY KEY to return");
            Console.ReadKey();
            MainMenu.LoadingScreen();
        }
    }
    //</Credits class>
}
