using System;

namespace BaseBall
{
    interface ISelectOption
    {
        public string SelectOption(string prompt, List<string> options);
        public string SelectOption(string prompt);
        public string SelectOption(string prompt, string input, List<string> options);
        public byte GetStat(string prompt, byte stat, ref byte remainingPoints);
        public (bool chosen, byte newValue1, byte newValue2) SelectOption(string prompt, string stat1, string stat2, byte value1, byte value2);
    }


    public class SelectionOption : ISelectOption
    {
        public string SelectOption(string prompt, List<string> options)
        {
            int index = 0;
            ConsoleKey pickedOption;
            do
            {
                Console.Clear();
                Console.WriteLine($"=== {prompt.ToUpper()} ===\n");

                for (int i = 0; i < options.Count; i++)
                {
                    if (i == index)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine($">  {options[i]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"   {options[i]}");
                    }
                }

                pickedOption = Console.ReadKey(true).Key;

                if (pickedOption == ConsoleKey.UpArrow)
                    index = (index == 0) ? options.Count - 1 : index - 1;
                else if (pickedOption == ConsoleKey.DownArrow)
                    index = (index == options.Count - 1) ? 0 : index + 1;

            } while (pickedOption != ConsoleKey.Enter);

            return options[index];
        }

        public string SelectOption(string prompt)
        {
            List<string> options = new List<string> { "Yes", "No" };
            int index = 0;
            ConsoleKey pickedOption;
            do
            {
                Console.Clear();
                Console.WriteLine($"=== {prompt.ToUpper()} ===\n");

                for (int i = 0; i < options.Count; i++)
                {
                    if (i == index)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine($">  {options[i]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"   {options[i]}");
                    }
                }

                pickedOption = Console.ReadKey(true).Key;

                if (pickedOption == ConsoleKey.UpArrow)
                    index = (index == 0) ? options.Count - 1 : index - 1;
                else if (pickedOption == ConsoleKey.DownArrow)
                    index = (index == options.Count - 1) ? 0 : index + 1;

            } while (pickedOption != ConsoleKey.Enter);

            return options[index];
        }

        public (bool chosen, byte newValue1, byte newValue2) SelectOption(string prompt, string stat1, string stat2, byte value1, byte value2)
        {
            Console.Clear();
            List<string> options = new List<string> { "YES", "NO" };

            string choice = SelectOption($"{prompt}: {stat1}={value1} | {stat2}={value2}", options);
            bool isYes = choice == "YES";

            int v1 = value1;
            int v2 = value2;

            if (isYes)
            {
                v1 += 2;
                v2 -= 1;
                Console.WriteLine($"Buffed {stat1}: New value: {v1}\n" +
                                  $"Nerfed {stat2}: New value: {v2}");
                MainMenu.WaitForEnter();
            }
            else
            {
                v1 -= 1;
                v2 += 2;
                Console.WriteLine($"Buffed {stat2}: New value: {v2}\n" +
                                  $"Nerfed {stat1}: New value: {v1}");
                MainMenu.WaitForEnter();
            }

            return (isYes, (byte)v1, (byte)v2);
        }

        public string SelectOption(string prompt, string input, List<string> options)
        {
            for (int i = 0; i < options.Count; i++)
            {
                if (input == options[i])
                {
                    options.Remove(options[i]);
                    options.Add("Cancel");
                }
            }

            string choice = SelectOption($"{prompt} current: {input}", options);

            return choice == "Cancel" ? input : choice;
        }


        public byte GetStat(string prompt, byte stat, ref byte remainingPoints)
        {
            byte maxStat = 50;

            if (remainingPoints == 0)
            {
                Console.Clear();
                Console.WriteLine($"===== {prompt.ToUpper()} =====\n");
                Console.WriteLine("No points left to spend!");
                Console.WriteLine($"Current {prompt}: {stat}");
                MainMenu.WaitForEnter();
                return stat;
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"===== {prompt.ToUpper()} Max:{maxStat} =====\n");
                Console.WriteLine($"Points left: {remainingPoints}");
                Console.WriteLine($"Current stat value: {stat}\n");


                Console.Write("Enter points to spend: ");
                if (!byte.TryParse(Console.ReadLine(), out byte amount))
                {
                    Console.WriteLine("Invalid Input! Please enter a number!");
                    MainMenu.EnterToRetry();
                    continue;
                }

                if (amount <= 0)
                {
                    return stat;
                }

                if (amount > remainingPoints)
                {
                    Console.WriteLine("Not enough points left!");
                    MainMenu.EnterToRetry();
                    continue;
                }

                if (stat + amount > maxStat)
                {
                    Console.WriteLine($"Stat cannot exceed {maxStat}!");
                    MainMenu.EnterToRetry();
                    continue;
                }

                stat += amount;
                remainingPoints -= amount;
                Console.WriteLine($"\n{prompt} set to {stat}. \nPoints left {remainingPoints}");
                MainMenu.WaitForEnter();
                return stat;
            }
        }
    }
}
