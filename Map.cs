using System;

namespace Juandre_POE_TASK1_TESTING
{
    public partial class Main
    {
        class Map
        {
            int width, height;
            char[,] map;
            int heroX, heroY;
            char[,] enemy;
            Random r = new Random(0);         

            enum Movement { UP, DOWN, LEFT, RIGHT };

            public Map(int min_width, int max_width, int min_height, int max_height)
            {
                int finwidth = r.Next(min_width, max_width);
                int finheight = r.Next(min_height, max_height);

                string[,] newmap;
                newmap = new string[finheight, finwidth];
                for (int k = 0; k < finheight; k++)
                {
                    for (int j = 0; j < finwidth; j++)
                    {
                        newmap[k, j] = " . ";
                    }
                }
                Create();

            }

            public void Create()
            {
                Hero John = new Hero(10, 10, 1, 10, 10);
            }

            public void UpdateVision()
            {
                string mapRepresentation = "";

                for (int i = 0; i < this.height; i++)
                {
                    for (int j = 0; j < this.width; j++)
                    {
                        mapRepresentation += map[i, j];
                    }
                    mapRepresentation += "\n";
                }

                lblMap.Text = mapRepresentation;
            }

            public void SetValues(int maxWidth, int maxHeight)
            {
                width = r.Next(0, maxWidth);
                height = r.Next(0, maxHeight);
                map = new char[height, width];
                InitialiseMap();
            }

            private void InitialiseMap()
            {
                heroX = r.Next(0, width);
                heroY = r.Next(0, height);

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        map[i, j] = '.';
                    }
                }
                map[heroY, heroX] = 'H';
                Redraw();
            }

            private void buttonUp_Click(object sender, EventArgs e)
            {
                Move(Movement.UP);
                Redraw();
            }

            private void buttonRight_Click(object sender, EventArgs e)
            {
                Move(Movement.RIGHT);
                Redraw();
            }

            private void buttonDown_Click(object sender, EventArgs e)
            {
                Move(Movement.DOWN);
                Redraw();
            }

            private void buttonLeft_Click(object sender, EventArgs e)
            {
                Move(Movement.LEFT);
                Redraw();
            }

            private void Move(Movement move)
            {
                map[heroY, heroX] = '.';
                switch (move)
                {
                    case Movement.UP:
                        heroY--;
                        break;
                    case Movement.DOWN:
                        heroY++;
                        break;
                    case Movement.LEFT:
                        heroX--;
                        break;
                    case Movement.RIGHT:
                        heroX++;
                        break;
                    default:
                        break;
                }
                map[heroY, heroX] = 'H';
            }

            public void Redraw()
            {
                string mapRepresentation = "";

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        mapRepresentation += map[i, j];
                    }
                    mapRepresentation += "\n";
                }

                lblMap.Text = mapRepresentation;
            }
        }
    }

    
}

