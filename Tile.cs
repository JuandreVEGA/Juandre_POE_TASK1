namespace Juandre_POE_TASK1_TESTING
{
    public partial class Main
    {
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
    }

    
}

