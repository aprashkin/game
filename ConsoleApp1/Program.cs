using metod;

namespace ConsoleApp1;

class Game
{
    static void Main(string[] args)
    {

        Console.Write("Введите количество игроков: ");
        int numberOfCharacters = int.Parse(Console.ReadLine());

        Character[] characters = new Character[numberOfCharacters];

        for (int i = 0; i < numberOfCharacters; i++)
        {
            Console.WriteLine($"Игрок {i + 1}:");

            Console.Write("Введите имя: ");
            string characterName = Console.ReadLine();

            Console.Write("Введите X координату: ");
            int characterX = int.Parse(Console.ReadLine());

            Console.Write("Введите Y координату: ");
            int characterY = int.Parse(Console.ReadLine());

            Console.Write("Является ли другом (true/false): ");
            bool isFriend = bool.Parse(Console.ReadLine());

            Console.Write("Количество здоровья: ");
            int characterHealth = int.Parse(Console.ReadLine());

            Console.Write("Наносимый урон: ");
            int characterDamage = int.Parse(Console.ReadLine());
            Console.WriteLine();

            characters[i] = new Character(characterName, characterX, characterY, isFriend, characterHealth, characterDamage);
        }

        int userChoice;
        do
        {
            Console.WriteLine("1. Вывести информацию об игроке ");
            Console.WriteLine("2. Переместить игрока по горизонтали ");
            Console.WriteLine("3. Переместить игрока по вертикали ");
            Console.WriteLine("4. Уничтожить игрока ");
            Console.WriteLine("5. Нанести урон игроку ");
            Console.WriteLine("6. Лечение игрока ");
            Console.WriteLine("7. Полное восстановление здоровья игрока ");
            Console.WriteLine("8. Изменить лагерь игрока ");
            Console.WriteLine("0. Выход");

            Console.Write("\n Выберите действие: ");
            userChoice = int.Parse(Console.ReadLine());

            int characterIndex;

            switch (userChoice)
            {
                case 1:
                    
                    Console.Write("Введите номер игрока: ");
                    characterIndex = int.Parse(Console.ReadLine()) - 1;
                    if (characterIndex >= 0 && characterIndex < numberOfCharacters)
                    {
                        if (characters[characterIndex].IsAlive())
                        {
                            characters[characterIndex].Info();
                        }
                        else
                        {
                            Console.WriteLine("Игрок уничтожен");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Некорректный номер игрока");
                    }
                    
                    break;
                case 2:
                    Console.Write("Введите номер игрока: ");
                    characterIndex = int.Parse(Console.ReadLine()) - 1;
                    if (characterIndex >= 0 && characterIndex < numberOfCharacters)
                    {
                        Console.Write("Введите координату X: ");
                        int dx = int.Parse(Console.ReadLine());
                        characters[characterIndex].MoveX(dx);
                    }
                    else
                    {
                        Console.WriteLine("Некорректный номер игрока.");
                    }
                    break;
                case 3:
                    Console.Write("Введите номер игрока: ");
                    characterIndex = int.Parse(Console.ReadLine()) - 1;
                    if (characterIndex >= 0 && characterIndex < numberOfCharacters)
                    {
                        Console.Write("Введите координату Y: ");
                        int dy = int.Parse(Console.ReadLine());
                        characters[characterIndex].MoveY(dy);
                    }
                    else
                    {
                        Console.WriteLine("Некорректный номер игрока.");
                    }
                    break;
                case 4:
                    Console.Write("Введите номер игрока: ");
                    characterIndex = int.Parse(Console.ReadLine()) - 1;
                    if (characterIndex >= 0 && characterIndex < numberOfCharacters)
                    {
                        characters[characterIndex].Destroy();
                    }
                    else
                    {
                        Console.WriteLine("Некорректный номер игрока.");
                    }
                    break;
                case 5:
                    Console.Write("Введите номер игрока, наносящего урон: ");
                    int attackerIndex = int.Parse(Console.ReadLine()) - 1;
                    if (attackerIndex >= 0 && attackerIndex < numberOfCharacters && characters[attackerIndex].IsAlive())
                    {
                        Console.Write("Введите номер врага: ");
                        int targetIndex = int.Parse(Console.ReadLine()) - 1;
                        if (targetIndex >= 0 && targetIndex < numberOfCharacters && characters[targetIndex].IsAlive())
                        {
                            characters[attackerIndex].InfoLictDamage(characters[attackerIndex].GetDamage(), characters[targetIndex]);
                        }
                        else
                        {
                            Console.WriteLine("Некорректный номер врага или враг уже уничтожен");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Некорректный номер игрока-атакующего или атакующий уже уничтожен.");
                    }
                    break;
                case 6:
                    Console.Write("Введите номер игрока: ");
                    characterIndex = int.Parse(Console.ReadLine()) - 1;
                    if (characterIndex >= 0 && characterIndex < numberOfCharacters)
                    {
                        Console.Write("Введите количество получаемого лечения: ");
                        int healing = int.Parse(Console.ReadLine());
                        characters[characterIndex].Heal(healing);
                    }
                    else
                    {
                        Console.WriteLine("Некорректный номер игрока.");
                    }
                    break;
                case 7:
                    Console.Write("Введите номер игрока: ");
                    characterIndex = int.Parse(Console.ReadLine()) - 1;
                    if (characterIndex >= 0 && characterIndex < numberOfCharacters)
                    {
                        characters[characterIndex].FullHealAgain();
                    }
                    else
                    {
                        Console.WriteLine("Некорректный номер игрока.");
                    }
                    break;
                case 8:
                    Console.Write("Введите номер игрока: ");
                    characterIndex = int.Parse(Console.ReadLine()) - 1;
                    if (characterIndex >= 0 && characterIndex < numberOfCharacters)
                    {
                        characters[characterIndex].ChangeCamp();
                    }
                    else
                    {
                        Console.WriteLine("Некорректный номер игрока.");
                    }
                    break;
                case 0:
                    Console.WriteLine("Выход из программы.");
                    break;
                default:
                    Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                    break;
            }

        } while (userChoice != 0);
    }
}