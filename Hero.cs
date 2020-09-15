namespace Juandre_POE_TASK1_TESTING
{
    public partial class Main
    {
        public class Hero : Character
        {
            public Hero(int x, int y, int damage, int hp, int max_hp) : base(hp, max_hp, damage, x, y)
            {
                this.X = x;
                this.Y = y;
                this.Hp = 10;
                this.Damage = 2;
            }
            public int returnMove()
            {
                tileArray = new char[this.Y, this.X];
                tileArray[this.Y, this.X] = '.';
                switch (move)
                {
                    case Movement.Up:
                        Y--;
                        break;
                    case Movement.Down:
                        Y++;
                        break;
                    case Movement.Left:
                        X--;
                        break;
                    case Movement.Right:
                        X++;
                        break;
                    default:
                        break;
                }
                tileArray[Y, X] = 'H';
            }

            public override string ToString()
            {
                return ("Player Stats: " + "\nHP: " + this.Hp + " / " + this.Max_hp + "\nDamage: 2");
            }
        }
    }

    
}

