using System.Reflection.Metadata;

namespace metod
{
    class Character
    {
        private string name;
        private int x;
        private int y;
        private bool isFriend;
        private int health;
        private int damage;


        public Character(string name, int x, int y, bool isFriend, int health, int damage)
        {
            this.name = name;
            this.x = x;
            this.y = y;
            this.isFriend = isFriend;
            this.health = health;
            this.damage = damage;
        }

        public void PerformAction(ActionType action, object parameter)
        {
            switch (action)
            {
                case ActionType.MoveX:
                    MoveX((int)parameter);

                    break;

                case ActionType.MoveY:
                    MoveY((int)parameter);

                    break;

                case ActionType.InfoLictDamage:
                    if (true)
                    {
                        InfoLictDamage((Character)parameter);
                    }

                    break;

                case ActionType.Heal:
                    Heal((int)parameter);
                    break;
                case ActionType.FullHeal:
                    FullHealAgain();
                    break;
                case ActionType.ChangeCamp:
                    ChangeCamp();
                    break;
                case ActionType.Info:
                    Info();
                    break;
                case ActionType.Destroy:
                    Destroy();
                    break;
                case ActionType.CheckForBattle:
                    CheckForBattle((Character[])parameter);
                    break;







            }
        }


        public enum ActionType
        {
            MoveX,
            MoveY,
            InfoLictDamage,
            Heal,
            FullHeal,
            ChangeCamp,
            Info,
            Destroy,
            CheckForBattle
        }

        private void Info()
        {
            Console.WriteLine($"Имя: {name}");
            Console.WriteLine($"Координаты: ({x}, {y})");
            Console.WriteLine($"Является другом: {isFriend}");
            Console.WriteLine($"Здоровье: {health}");
            Console.WriteLine($"Урон: {damage}");
        }

        private void MoveX(int dx)
        {
            x = dx;
        }

        private void MoveY(int dy)
        {
            y = dy;
        }

        private void Destroy()
        {
            health = 0;
        }

        private void InfoLictDamage(Character target)
        {
            if (isFriend != target.isFriend)
            {
                if (target.health > 0)
                {
                    target.health -= damage;
                    if (target.health < 0)
                    {
                        target.health = 0;
                    }
                }
            }
        }

        private void Heal(int amount)
        {
            if (health > 0)
            {
                health += amount;
            }
        }

        private void FullHealAgain()
        {
            health = 100;
        }

        private void ChangeCamp()
        {
            isFriend = !isFriend;
        }

        private bool IsFriend()
        {
            return isFriend;
        }

        private int GetDamage()
        {
            return damage;
        }

        


        public bool IsAlive()
        {
            return health > 0;
        }

        public void CheckForBattle(Character[] characters)
        {
            for (int i = 0; i < characters.Length; i++)
            {
                for (int j = i + 1; j < characters.Length; j++)
                {
                    if (!characters[i].IsAlive() || !characters[j].IsAlive())
                    {
                        continue;
                    }
                    
                    if (characters[i].x == characters[j].x && characters[i].y == characters[j].y)
                    {
                        if (characters[i].IsFriend() != characters[j].IsFriend())
                        {
                            Console.WriteLine($"Битва начинается между игроком {i + 1} и игроком {j + 1}!");
                            StartBattle(characters[i], characters[j]);
                        }
                    }

                    
                }
            }
        }

        private void StartBattle(Character character1, Character character2)
        {
            
            while (true)
            {
                if (character1.IsFriend != character2.IsFriend)
                {
                    character1.InfoLictDamage(character2);
                    character2.InfoLictDamage(character1);
                    Console.WriteLine($"Игрок 1: Здоровье {character1.health}, Урон {character1.damage}");
                    Console.WriteLine($"Игрок 2: Здоровье {character2.health}, Урон {character2.damage}");
                    if (character2.health <= 0 && character1.health <= 0)
                    {
                        Console.WriteLine("Ничья. Все игроки, учавствовавшие в битве умерли(");
                        break;
                    }
                    else
                    {
                        if (!character1.IsAlive() || !character2.IsAlive())
                        {
                            Console.WriteLine(character1.IsAlive() ? "Игрок 1 победил!" : "Игрок 2 победил!");
                            break;
                        }
                    
                    }
                    Console.WriteLine("Продолжить битву (да/нет)?");
                    string userChoice = Console.ReadLine();
                    if (userChoice.Equals("нет", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Write("Введите координату X для отступления: ");
                        int retreatX = int.Parse(Console.ReadLine());
                        Console.Write("Введите координату Y для отступления: ");
                        int retreatY = int.Parse(Console.ReadLine());
                        character1.MoveX(retreatX);
                        character1.MoveY(retreatY);
                        break;
                    }
                    
                }
            }
        }
    }
}







