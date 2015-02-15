using System;

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
