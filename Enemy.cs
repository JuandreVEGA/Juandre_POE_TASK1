using System;

namespace Juandre_POE_TASK1_TESTING
{
    public partial class Main
    {
        public abstract class Enemy : Character
        {
            protected Random r = new Random();

            public Enemy(int x, int y, int damage, int hp, int max_hp) : base(hp, max_hp, damage, x, y)
            {
                this.X = x;
                this.Y = y;
                this.Damage = damage;
                this.Hp = hp;
                this.Max_hp = max_hp;
            }

            public override string ToString()
            {
                return ("Goblin at [" + this.X + "," + this.Y + "] " + this.Damage);
            }
        }
    }

    
}

