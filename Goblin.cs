namespace Juandre_POE_TASK1_TESTING
{
    public partial class Main
    {
        public class Goblin : Enemy
        {
            public Goblin(int x, int y, int damage, int hp, int max_hp) : base(hp, max_hp, damage, x, y)
            {
                this.X = x;
                this.Y = y;
                this.Hp = 10;
                this.Damage = 1;
            }

            public int returnMove(int x, int y)
            {                
                int randX = r.Next(0, X);
                int randY = r.Next(0, Y);
                Tile.tileArry[randY, randX] = "G";
            }
            
        }
    }

    
}

