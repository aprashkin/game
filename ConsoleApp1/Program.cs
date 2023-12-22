using metod;
using System;

namespace ConsoleApp1
{
    class  Game
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество игроков: ");
            int numberOfCharacters = ReadInt();
            Character[] characters = new Character[numberOfCharacters];
            
            
            for (int i = 0; i < numberOfCharacters; i++)
            {
                Console.WriteLine($"Игрок {i + 1}:");
                Console.Write("Введите имя: ");
                string characterName = Console.ReadLine();
                Console.Write("Введите X координату: ");
                int characterX = ReadInt();
                Console.Write("Введите Y координату: ");
                int characterY = ReadInt();
                
                Console.Write("Является ли другом (true/false): ");
                bool isFriend = ReadBool();
                Console.Write("Количество здоровья: ");
                int characterHealth = ReadInt();
                Console.Write("Наносимый урон: ");
                int characterDamage = ReadInt();
                Console.WriteLine();
                characters[i] = new Character(characterName, characterX, characterY, isFriend, characterHealth, characterDamage);
            }



            int selectedCharacterIndex = -1;
            while (true)
            {
                Console.WriteLine("\nВыберите персонажа (номер от 1 до " + numberOfCharacters + ") или 0 для выхода:");
                selectedCharacterIndex = ReadInt() - 1;

                characters[selectedCharacterIndex].PerformAction(Character.ActionType.CheckForBattle, characters);

                if (selectedCharacterIndex == -1)
                {
                    break;
                }

                if (selectedCharacterIndex >= 0 && selectedCharacterIndex < numberOfCharacters && characters[selectedCharacterIndex].IsAlive())
                {
                    int actionChoice;
                    do
                    {
                        Console.WriteLine("\nВыберите действие для персонажа " + (selectedCharacterIndex + 1) + ":");
                        Console.WriteLine("1. Вывести информацию об игроке");
                        Console.WriteLine("2. Переместить игрока по горизонтали");
                        Console.WriteLine("3. Переместить игрока по вертикали");
                        Console.WriteLine("4. Уничтожить игрока");
                        Console.WriteLine("5. Лечение игрока");
                        Console.WriteLine("6. Полное восстановление здоровья игрока");
                        Console.WriteLine("7. Изменить лагерь игрока");
                        Console.WriteLine("0. Выход");

                        Console.Write("\nВаш выбор: ");
                        actionChoice = ReadInt();

                        switch (actionChoice)
                        {
                            case 1:
                                characters[selectedCharacterIndex].PerformAction(Character.ActionType.Info, null);
                                break;
                            case 2:
                                Console.Write("Введите координату X: ");
                                int dx = ReadInt();
                                characters[selectedCharacterIndex].PerformAction(Character.ActionType.MoveX, dx);
                                characters[selectedCharacterIndex].PerformAction(Character.ActionType.CheckForBattle, characters);
                                break;

                            case 3:
                                Console.Write("Введите координату Y: ");
                                int dy = ReadInt();
                                characters[selectedCharacterIndex].PerformAction(Character.ActionType.MoveY, dy);
                                characters[selectedCharacterIndex].PerformAction(Character.ActionType.CheckForBattle, characters);
                                break;
                            case 4:
                                characters[selectedCharacterIndex].PerformAction(Character.ActionType.Destroy, null);
                                break;
                            case 5:
                                Console.Write("Введите количество здоровья для лечения: ");
                                int healAmount = ReadInt(); characters[selectedCharacterIndex].PerformAction(Character.ActionType.Heal, healAmount);
                                characters[selectedCharacterIndex].PerformAction(Character.ActionType.CheckForBattle, characters);
                                break;
                            case 6:
                                characters[selectedCharacterIndex].PerformAction(Character.ActionType.FullHeal, null);
                                characters[selectedCharacterIndex].PerformAction(Character.ActionType.CheckForBattle, characters);
                                break;
                            case 7:
                                characters[selectedCharacterIndex].PerformAction(Character.ActionType.ChangeCamp, null);
                                characters[selectedCharacterIndex].PerformAction(Character.ActionType.CheckForBattle, characters);
                                break;
                            case 8:
                                characters[selectedCharacterIndex].PerformAction(Character.ActionType.CheckForBattle, characters);
                                break;
                        }
                    } while (actionChoice != 0);
                }
                else
                {
                    Console.WriteLine("Некорректный номер персонажа или персонаж умер. Выберите другого персонажа");
                }
                characters[selectedCharacterIndex].PerformAction(Character.ActionType.CheckForBattle, characters);
            }
        }

        private static int ReadInt()
        {
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите число.");
            }
            return result;
        }

        private static bool ReadBool()
        {
            bool result;
            while (!bool.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Некорректный ввод. Введите 'true' или 'false'.");
            }
            return result;
        }
    }
}

