using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    // All printable objects should implement this interface
    public interface IPrintable
    {
        // X coordinate
        int X { get; set; }
        
        // Y coordinate
        int Y { get; set; }
        
        // Color of the object
        ConsoleColor Color { get; set; }

        // Printing on the console
        void Print();
    }
}
