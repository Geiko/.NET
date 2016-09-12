using System;

namespace _2.Envelope
{
    class Program
    {
        static void Main ( string [ ] args )
        {
            try
            {
                new EnvelopeNesting ( );
            }
            catch ( Exception ex)
            {
                Console.WriteLine (ex.Message);
            }            
        }
    }
}
