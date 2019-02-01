using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverMars
{
    public class Rover
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string O { get; set; }

        public Square s;

        public bool Move(string o)
        {
            bool result = true;
            switch (o)
            {
                case "L":
                    switch (O)
                    {
                        case "N": O = "W"; break;
                        case "S": O = "E"; break;
                        case "E": O = "N"; break;
                        case "W": O = "S"; break;
                    }
                    break;

                case "R":
                    switch (O)
                    {
                        case "N": O = "E"; break;
                        case "S": O = "W"; break;
                        case "E": O = "S"; break;
                        case "W": O = "N"; break;
                    }
                    break;

                case "A":
                    switch (O)
                    {
                        case "N":
                            if (Y == s.Y) { result = false; break; } else { Y += 1; }
                            break;
                        case "S":
                            if (Y == 0) { result = false; break; } else { Y -= 1; }
                            break;
                        case "E":
                            if (X == s.X) { result = false; break; } else { X += 1; }
                            break;
                        case "W":
                            if (X == 0) { result = false; break; } else { X -= 1; }
                            break;
                    }
                    break;
            }
            return result;
        }

        public Rover(int x, int y, string o)
        {
            X = x;
            Y = y;
            O = o;
        }

        public override string ToString()
        {
            return "Orientation: " + O.ToString() + " x, y: (" + X.ToString() + ", " + Y.ToString() + ")";
        }
    }
}
