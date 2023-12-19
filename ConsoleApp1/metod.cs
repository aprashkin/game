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

        public void Info()
        {
            Console.WriteLine($"Имя: {name}");
            Console.WriteLine($"Координаты: ({x}, {y})");
            Console.WriteLine($"Является другом: {isFriend}");
            Console.WriteLine($"Здоровье: {health}");
            Console.WriteLine($"Урон: {damage}");
        }

        public void MoveX(int dx)
        {
            x += dx;
        }

        public void MoveY(int dy)
        {
            y += dy;
        }

        public void Destroy()
        {
            health = 0;
        }

        public void InfoLictDamage(int damage, Character target)
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

        public void Heal(int amount)
        {
            if (health > 0)
            {
                health += amount;
            }
        }

        public void FullHealAgain()
        {
            health = 100;
        }

        public void ChangeCamp()
        {
            isFriend = !isFriend;
        }

        public bool IsFriend()
        {
            return isFriend;
        }

        public int GetDamage()
        {
            return damage;
        }

        public bool IsAlive()
        {
            return health > 0;
        }
    }

    

}
