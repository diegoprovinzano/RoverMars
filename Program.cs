using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverMars
{
    class Program
    {
        static void Main(string[] args)
        {
            int result;

            Console.Write("ENTER DATA of SQUARE [X , Y]: ");
            string dataSquare = Console.ReadLine();
            var _A_dataSquare = dataSquare.Split(',');
            if (_A_dataSquare.Length != 2)
            {
                Console.WriteLine("Error entering values for square");
            }
            else
            {
                bool _isInt = int.TryParse(_A_dataSquare[0], out result);
                if (!_isInt || result <= 0)
                {
                    Console.WriteLine("Error entering values for X square");
                }
                _isInt = int.TryParse(_A_dataSquare[1], out result);
                if (!_isInt || result <= 0)
                {
                    Console.WriteLine("Error entering values for Y square");
                }
            }

            Console.Write("ENTER ROVER positionn [Xrover , Yrover , Orover (N,S,E,W)]: ");
            string dataRover = Console.ReadLine();
            var _A_dataRover = dataRover.Split(',');
            if (_A_dataRover.Length != 3)
            {
                Console.WriteLine("Error entering values for rover");
            }
            else
            {
                bool _isInt = int.TryParse(_A_dataRover[0], out result);
                if (!_isInt || result < 0)
                {
                    Console.WriteLine("Error entering values for X rover");
                }
                _isInt = int.TryParse(_A_dataRover[1], out result);
                if (!_isInt || result < 0)
                {
                    Console.WriteLine("Error entering values for Y rover");
                }

                if (_A_dataRover[2].Length != 1 || (!_A_dataRover[2].ToUpper().Contains("N") && !_A_dataRover[2].ToUpper().Contains("S") && !_A_dataRover[2].ToUpper().Contains("E") && !_A_dataRover[2].ToUpper().Contains("W")))
                {
                    Console.WriteLine("Error entering values for Orientation rover");
                }
            }

            
            Rover r = new Rover(Convert.ToInt32(_A_dataRover[0]), Convert.ToInt32(_A_dataRover[1]), _A_dataRover[2].ToUpper().ToString());
            Square s = new Square(Convert.ToInt32(_A_dataSquare[0]), Convert.ToInt32(_A_dataSquare[1]));
            r.s = s;
            while (EnterCommand(r));


        }

        private static bool EnterCommand(Rover r)
        {
            Console.Write("Enter command string: [X - End]: ");
            string command = Console.ReadLine();
            if (command.ToUpper() == "X") return false;
            if (!command.ToUpper().Contains("A") && !command.ToUpper().Contains("L") && !command.ToUpper().Contains("R")) return false;

            bool res = r.Move(command.ToUpper());
            if (!res)
            {
                Console.WriteLine("Command not valid out of boundaries"); 
            }

            Console.WriteLine(r.ToString());
            return true;
        }
    }
}
