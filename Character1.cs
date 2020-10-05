using System;
using System.Windows.Forms;

namespace Juandre_POE_TASK1_TESTING
{
    public partial class Form1
    {
        public abstract class Character : Tile
        {
            private int hp;
            private int max_hp;
            private int damage;
            char[,] tileArray;
            string symbol;
            Random r = new Random();

            public Character(int hp, int max_hp, int damage, int xPos, int yPos) : base(xPos, yPos)
            {
                this.hp = hp;
                this.max_hp = max_hp;
                this.damage = damage;
                this.X = xPos;
                this.Y = yPos;
            }

            public int Hp { get => hp; set => hp = value; }
            public int Max_hp { get => max_hp; set => max_hp = value; }
            public int Damage { get => damage; set => damage = value; }

            public enum Movement { NoMovement, Up, Down, Left, Right }

            public void Attack(int damage)
            {
                this.Damage -= damage;                
            }
           
            public bool IsDead()
            {
                bool Isdead = false;
                if (this.Hp <= 0)
                {
                    Isdead = true;
                    MessageBox.Show("Character is Dead");
                }
                return Isdead;
            }

            public virtual bool CheckRange(Character target)
            {
                bool returnVal = true;
                if (tileArray[this.Y + 1, this.X + 1] != ',')
                {
                    MessageBox.Show("Cant move there!");
                    DistanceTo(this.Y + 1, this.X + 1);
                    returnVal = false;                    
                }
                if (tileArray[this.Y - 1, this.X + 1] != ',')
                {
                    MessageBox.Show("Cant move there!");
                    DistanceTo(this.Y - 1, this.X + 1);
                    returnVal = false;
                }
                if (tileArray[this.Y + 1, this.X - 1] != ',')
                {
                    MessageBox.Show("Cant move there!");
                    DistanceTo(this.Y + 1, this.X - 1);
                    returnVal = false;
                }
                if (tileArray[this.Y - 1, this.X - 1] != ',')
                {
                    MessageBox.Show("Cant move there!");
                    DistanceTo(this.Y - 1, this.X - 1);
                    returnVal = false;
                }
                if (tileArray[this.Y, this.X - 1] != ',')
                {
                    MessageBox.Show("Cant move there!");
                    DistanceTo(this.Y, this.X - 1);
                    returnVal = false;
                }
                if (tileArray[this.Y, this.X + 1] != ',')
                {
                    MessageBox.Show("Cant move there!");
                    DistanceTo(this.Y, this.X + 1);
                    returnVal = false;
                }
                if (tileArray[this.Y - 1, this.X] != ',')
                {
                    MessageBox.Show("Cant move there!");
                    DistanceTo(this.Y - 1, this.X);
                    returnVal = false;
                }
                if (tileArray[this.Y + 1, this.X] != ',')
                {
                    MessageBox.Show("Cant move there!");
                    DistanceTo(this.Y + 1, this.X);
                    returnVal = false;
                }
                else 
                {
                    MessageBox.Show("Character free to move.");
                    returnVal = true;
                }
                return returnVal;
            }

            private int DistanceTo(int x, int y)
            {
                int returnVal;
                returnVal = (this.X - x) + (this.Y - y);
                return returnVal;
            }
            
            public void Move(Movement move)
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

            public Movement ReturnMove(Movement move = 0)
            {
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
                return move;
            }

            public  override string ToString()
            {
                return ("Overriding Object");
            }


        }
    }

    
}

