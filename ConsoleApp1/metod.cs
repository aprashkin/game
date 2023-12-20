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
                        
                
                    
                
                
                
            }
        }
        
        
        public enum ActionType
        {
            MoveX, MoveY, InfoLictDamage, Heal, FullHeal, ChangeCamp,Info, Destroy
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

        // public bool IsFriend()
        // {
        //     return isFriend;
        // }

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
