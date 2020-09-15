using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Serialization;

namespace Juandre_POE_TASK1_TESTING
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }        

        public abstract class Tile
        {
            private int x;
            private int y;

            public int X { get => x; set => x = value; }
            public int Y { get => y; set => y = value; }

            public Tile(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public enum TileType { Hero, Enemy, Gold, Weapon };

            public class Obstacle : Tile
            {
                public Obstacle(int xPos, int yPos) : base(xPos, yPos)
                {
                    Tile currentunit = this;
                }
            }

            public class EmptyTile : Tile
            {
                public EmptyTile(int xPos, int yPos) : base(xPos, yPos)
                {

                }
            }
        }

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

