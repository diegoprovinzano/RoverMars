using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverMars
{
    public class Rover : Commands
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string O { get; set; }

        public Square S;

        public bool Move(string o)
        {
            bool result = true;
            switch (o)
            {
                case "L":
                    this.TurnLeft();
                    break;

                case "R":
                    this.TurnRight();
                    break;

                case "A":
                    result = this.Advance();                    
                    break;
            }
            return result;
        }

        public Rover(int x, int y, string o, Square s)
        {
            X = x;
            Y = y;
            O = o;
            S = s;
        }

        public bool Advance()
        {
            bool result = true;
            switch (O)
            {
                case "N":
                    if (Y == S.Y) { result = false; break; } else { Y += 1; }
                    break;
                case "S":
                    if (Y == 0) { result = false; break; } else { Y -= 1; }

                    break;
                case "E":
                    if (X == S.X) { result = false; break; } else { X += 1; }
                    break;
                case "W":
                    if (X == 0) { result = false; break; } else { X -= 1; }
                    break;
            }
            return result;
        }

        public void TurnLeft()
        {
            switch (O)
            {
                case "N": O = "W"; break;
                case "S": O = "E"; break;
                case "E": O = "N"; break;
                case "W": O = "S"; break;
            }
        }
        public void TurnRight()
        {
            switch (O)
            {
                case "N": O = "E"; break;
                case "S": O = "W"; break;
                case "E": O = "S"; break;
                case "W": O = "N"; break;
            }
        }

    public override string ToString()
        {
            return "valid: True, Orientation: " + O.ToString() + ", (x, y): (" + X.ToString() + ", " + Y.ToString() + ")";
        }
    }
}
