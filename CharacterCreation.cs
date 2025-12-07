using MySql.Data.MySqlClient;
using System;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;

namespace BaseBall
{
    public class UsernameException
    {

        private static Regex usernameRegex = new Regex(@"^[A-Za-z]{4,20}$");

        public static void ValidateUsername(string username)
        {
            MySqlConnection UsernameCon = new MySqlConnection("SERVER=localhost; DATABASE=DITR; UID=root; PASSWORD=acierandresraignruedaandreideseo");
            UsernameCon.Open();
            MySqlCommand sqlCMD = new MySqlCommand("SELECT Character_Name FROM CharacterData", UsernameCon);
            MySqlDataReader readusername = sqlCMD.ExecuteReader();


            while (readusername.Read())
            {
                if (username.Equals(readusername["Character_Name"]))
                {
                    throw new InvalidUsernameException("Username already taken");
                }
            }
            if (!usernameRegex.IsMatch(username))
            {
                throw new InvalidUsernameException("USERNAME MUST BE LETTERS ONLY! 4-20 CHARACTERS(A–Z).");
            }
            username.Clone();
            readusername.Close();
        }
    }


    public class InvalidUsernameException : Exception
    {
        public InvalidUsernameException(string message) : base(message) { }
    }


    public class CharacterCreation : Execute
    {
        SelectionOption Option = new SelectionOption();
        public override void Start()
        {
            runCharacterCreation();
        }

        private void runCharacterCreation() // method ni Character selection
        {
            Console.Clear();
            Console.Write("\x1b[3J");

            var baseStats = new Stats(5, 5, 5, 5);
            var customChar = new CustomizeableCharacter("Player", baseStats);


            while (true)
            {
                try
                {
                    Console.WriteLine("=== CREATE YOUR CHARACTER ===\n");


                    Console.Write("Enter Username (Letters only, 4–20 chars): ");
                    string tempName = Console.ReadLine();

                    UsernameException.ValidateUsername(tempName);

                    customChar.Username = tempName;
                    break;
                }
                catch (InvalidUsernameException e)
                {
                    Console.Clear();
                    Console.WriteLine($"!!ERROR!!: {e.Message} !!ERROR!!");
                    MainMenu.EnterToRetry();
                    Console.Clear();
                }
            }


            void Customization()
            {
                customChar.Gender = Option.SelectOption("Choose character Gender", customChar.Gender, new List<string> { "Male", "Female" });

                customChar.BodyType = Option.SelectOption("Choose character Body Type", customChar.BodyType, new List<string> { "Slim", "Lean", "Muscular", "Athletic", "Endomorph", "Stocky" });

                customChar.SkinColor = Option.SelectOption("Choose character Skin Color", customChar.SkinColor, new List<string> { "Fair", "Medium", "Deep", "Neon", "Pastel", "Rainbow" });

                customChar.HairColor = Option.SelectOption("Choose character Hair Color", customChar.HairColor, new List<string> { "Black", "Brown", "Blue", "Red", "White", "Green",
                                                                                                                                   "Orange", "Purple", "Violet", "Yellow", "Neon" });

                customChar.EyeColor = Option.SelectOption("Choose Eye Color", customChar.EyeColor, new List<string> { "Black", "Brown", "Red", "Blue", "White",
                                                                                                                      "Green", "Orange", "Purple", "Violet", "Yellow" });

                customChar.EyebrowThickness = Option.SelectOption("Choose Eyebrow Thickness", customChar.EyebrowThickness, new List<string> { "Thick", "Thin", "No eyebrows", "Pointed eyebrows", "Wavy eyebrows", "Monobrow" });

                customChar.BaseballBatTexture = Option.SelectOption("Choose Baseball Bat Texture", customChar.BaseballBatTexture, new List<string> { "Metallic", "Wood", "Plastic", "Alloy", "Carbon", "Cake" });

                customChar.BaseballBatDesign = Option.SelectOption("Choose Baseball Bat Design", customChar.BaseballBatDesign, new List<string> { "Punk", "Apocalyptic", "Glitch pop", "Blaze", "Reaver", "Zedd X" });

                customChar.Shoes = Option.SelectOption("Choose Shoes", customChar.Shoes, new List<string> { "Jollibee boots", "Sneakers", "Black shoes", "Terraspark Boots", "Military boots", "Crocs" });

                customChar.ShirtDesign = Option.SelectOption("Choose Shirt Design", customChar.ShirtDesign, new List<string> { "Novice shirt", "Leather jacket", "Vintage",
                                                                                                                               "Animal print", "Military", "Tactical" });

                customChar.PantsDesign = Option.SelectOption("Choose Pants Design", customChar.PantsDesign, new List<string> { "Novice pants", "Biker pants", "Vintage pants",
                                                                                                                               "Animal print pants", "Military pants", "Tactical pants" });

                customChar.Accessories = Option.SelectOption("Choose accessories", customChar.Accessories, new List<string> { "Glasses", "Earrings", "Headbands", "Piercings",
                                                                                                                              "Masks", "Necklace", "Watch", "Arm bands" });

                customChar.Cap = Option.SelectOption("Choose Cap (Headwear)", customChar.Cap, new List<string> { "Novice cap", "Reversed Cap", "Cat ears", "Dog ears", "Knight helmet", "Biker helmet",
                                                                                                                               "Military helmet", "Crown", "Bonnet" });

                customChar.Socks = Option.SelectOption("Choose Socks", customChar.Socks, new List<string> { "Programming socks", "Unicorn socks", "Binary socks", "Camouflage socks", "Tactical socks", "Military Socks" });

                customChar.PreferredPosition = Option.SelectOption("Choose Preferred Position", customChar.PreferredPosition, new List<string> { "Pitcher", "Umpire", "Infielder", "Left fielder", "Right fielder",
                                                                                                                                                 "Center fielder", "Outfielder", "Shortstop", "First baseman", "Second baseman",
                                                                                                                                                 "Pinch hitter", "Pinch runner", "Designated hitter", "Spike planter", "Summoner" });

                customChar.TeamMascot = Option.SelectOption("Choose Team Mascot", customChar.TeamMascot, new List<string> { "Jollibee", "Ronald McDonald", "Wendy", "Doraemon", "Spiderman", "KFC" });


                bool noPerksYet = true;
                string confirmPerkSelection = "";
                do
                {
                    customChar.Perks = Option.SelectOption("Choose Perks", customChar.Perks, new List<string> { "Berserker", "Charge up speed!", "Wally West", "Paranoia",
                                                                                                            "Drunk", "Isolation", "Locked in", "Subdue pitcher", "Hyperfixation" });

                    switch (customChar.Perks)
                    {
                        case "Berserker":
                            confirmPerkSelection = Option.SelectOption("Berserker ===\n\nDescription\nWhen adrenaline kicks in, your power dramatically increases for a short burst after making contact with the ball.\n\"GRIFFITHHHHHHH!!!\"\n\n=== Confirm?");
                            noPerksYet = (confirmPerkSelection == "Yes") ? false : true;
                            break;
                        case "Charge up speed!":
                            confirmPerkSelection = Option.SelectOption("Charge Up Speed! ===\n\nDescription\nYour speed ramps up the longer you run, allowing you to reach maximum velocity after a few steps.\n\n=== Confirm?");
                            noPerksYet = (confirmPerkSelection == "Yes") ? false : true;
                            break;
                        case "Wally West":
                            confirmPerkSelection = Option.SelectOption("Wally West ===\n\nDescription\nMove with lightning-fast acceleration and unmatched agility, reacting quicker than any normal athlete.\n\"My Ordinary Life\"\n\n=== Confirm?");
                            noPerksYet = (confirmPerkSelection == "Yes") ? false : true;
                            break;
                        case "Paranoia":
                            confirmPerkSelection = Option.SelectOption("Paranoia ===\n\nDescription\nWhen the ball is hit, your instincts spike—granting heightened awareness and reaction speed, but with unstable control.\n\n=== Confirm?");
                            noPerksYet = (confirmPerkSelection == "Yes") ? false : true;
                            break;
                        case "Drunk":
                            confirmPerkSelection = Option.SelectOption("Drunk ===\n\nDescription\nOccasionally lose balance and behave unpredictably, but random bursts of strength or luck occur when least expected.\n\"Definitely drinkin' and drivin'\n\n=== Confirm?");
                            noPerksYet = (confirmPerkSelection == "Yes") ? false : true;
                            break;
                        case "Isolation":
                            confirmPerkSelection = Option.SelectOption("Isolation ===\n\nDescription\nUpon ball contact, your focus locks onto a single opposing player, reducing their effectiveness temporarily.\n\n=== Confirm?");
                            noPerksYet = (confirmPerkSelection == "Yes") ? false : true;
                            break;
                        case "Locked in":
                            confirmPerkSelection = Option.SelectOption("Locked In ===\n\nDescription\nTime seems to slow down right before you swing, granting near-perfect timing and increased contact accuracy.\n\"Time to lock in foo\"\n\n=== Confirm?");
                            noPerksYet = (confirmPerkSelection == "Yes") ? false : true;
                            break;
                        case "Subdue pitcher":
                            confirmPerkSelection = Option.SelectOption("Subdue Pitcher ===\n\nDescription\nYour presence disrupts the opposing pitcher, reducing their accuracy and confidence when facing you.\n\"Aura farming much?\"\n\n=== Confirm?");
                            noPerksYet = (confirmPerkSelection == "Yes") ? false : true;
                            break;
                        case "Hyperfixation":
                            confirmPerkSelection = Option.SelectOption("Hyperfixation ===\n\nDescription\nWhen the enemy hits the ball, your attention locks onto its movement, increasing tracking and catching precision.\n\n=== Confirm?");
                            noPerksYet = (confirmPerkSelection == "Yes") ? false : true;
                            break;
                    }
                } while (noPerksYet);

            }

            void SetStats()
            {
                byte statPoints = 10;
                baseStats.Strength = 5;
                baseStats.Speed = 5;
                baseStats.Stamina = 5;
                baseStats.Accuracy = 5;
                Console.WriteLine($"=== Stat points available: {statPoints} ===\n" +
                    $"Strength default: {baseStats.Strength}\n" +
                    $"Speed default: {baseStats.Speed}\n" +
                    $"Stamina default: {baseStats.Stamina}\n" +
                    $"Accuracy default: {baseStats.Accuracy}\n");
                MainMenu.WaitForEnter();

                while (statPoints > 0)
                {
                    baseStats.Strength = Option.GetStat("Strength", baseStats.Strength, ref statPoints);
                    baseStats.Speed = Option.GetStat("Speed", baseStats.Speed, ref statPoints);
                    baseStats.Stamina = Option.GetStat("Stamina", baseStats.Stamina, ref statPoints);
                    baseStats.Accuracy = Option.GetStat("Accuracy", baseStats.Accuracy, ref statPoints);

                    if (statPoints > 0)
                    {
                        Console.Clear();
                        Console.WriteLine($"Points left: {statPoints}\nPlease use all points!");
                        MainMenu.WaitForEnter();
                    }
                }

                (customChar.IsAthletic, baseStats.Strength, baseStats.Speed) = Option.SelectOption($"Is your character Athletic? ===\n=== Buffed/Nerfed stats", "STR", "SPD", baseStats.Strength, baseStats.Speed);
                (customChar.IsAgile, baseStats.Speed, baseStats.Stamina) = Option.SelectOption("Is your character Agile? ===\n=== Buffed/Nerfed stats", "SPD", "STA", baseStats.Speed, baseStats.Stamina);
                (customChar.IsTenacious, baseStats.Stamina, baseStats.Accuracy) = Option.SelectOption("Is your character Tenacious? ===\n=== Buffed/Nerfed stats", "STA", "ACC", baseStats.Stamina, baseStats.Accuracy);
                (customChar.IsSharp, baseStats.Accuracy, baseStats.Strength) = Option.SelectOption("Is your character Sharp? ===\n=== Buffed/Nerfed stats", "ACC", "STR", baseStats.Accuracy, baseStats.Strength);

                customChar.Stats = baseStats;
                Console.Clear();
            }

            // start customize
            Customization();
            SetStats();

            bool editing = true;
            while (editing)
            {
                Console.Clear();
                customChar.ShowInfo();
                MainMenu.WaitForEnter();
                MainMenu.LoadingScreen();

                string choice = Option.SelectOption("Do you want to edit your character?", new List<string> { "Edit Character", "Edit Stats", "Finish" });

                switch (choice)
                {
                    case "Edit Character":
                        Customization();
                        break;
                    case "Edit Stats":
                        SetStats();
                        break;
                    case "Finish":
                        editing = false;

                        MySqlConnection sqlCon = new MySqlConnection("SERVER=localhost; DATABASE=DITR; UID=root; PASSWORD=acierandresraignruedaandreideseo");
                        try
                        {
                            sqlCon.Open();

                            string sqlQuery = "INSERT INTO CharacterData\nVALUES ('" + customChar.Username + "'," +
                                "'" + customChar.Gender + "'," +
                                "'" + customChar.BodyType + "'," +
                                "'" + customChar.SkinColor + "'," +
                                "'" + customChar.HairColor + "'," +
                                "'" + customChar.EyeColor + "'," +
                                "'" + customChar.EyebrowThickness + "'," +
                                "'" + customChar.BaseballBatTexture + "'," +
                                "'" + customChar.BaseballBatDesign + "'," +
                                "'" + customChar.Shoes + "'," +
                                "'" + customChar.ShirtDesign + "'," +
                                "'" + customChar.PantsDesign + "'," +
                                "'" + customChar.Accessories + "'," +
                                "'" + customChar.Cap + "'," +
                                "'" + customChar.Socks + "'," +
                                "'" + customChar.PreferredPosition + "'," +
                                "'" + customChar.TeamMascot + "'," +
                                "'" + customChar.Perks + "'," +
                                "" + customChar.IsAthletic + "," +
                                "" + customChar.IsAgile + "," +
                                "" + customChar.IsTenacious + "," +
                                "" + customChar.IsSharp + "," +
                                "" + baseStats.Strength + "," +
                                "" + baseStats.Speed + "," +
                                "" + baseStats.Stamina + "," +
                                "" + baseStats.Accuracy + ");";
                            MySqlCommand sqlCMD = new MySqlCommand(sqlQuery, sqlCon);
                            sqlCMD.ExecuteNonQuery();
                            Console.WriteLine("Data stored!");
                            MainMenu.WaitForEnter();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("An error has occured(INSERT INTO)");
                            MainMenu.WaitForEnter();
                        }
                        finally
                        {
                            sqlCon.Close();
                        }
                        break;
                }
            }

            Console.Clear();
            customChar.ShowInfo();
            MainMenu.WaitForEnter();
        }
    }
}

