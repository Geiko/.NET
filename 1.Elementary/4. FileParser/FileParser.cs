using System;
using System.IO;
using System.Text;

namespace _4.FileParser
{
    class FileParser
    {
        private string pathToFile;

        public string PathToFile
        {
            get { return pathToFile; }
            set
            {
                try
                {
                    if ( string.IsNullOrWhiteSpace ( value ) )
                    {
                        throw new ArgumentNullException ( string.Format ( "Path to the file {0} is null or white space.", value ) );
                    }
                    if ( File.Exists ( value ) == false )
                    {
                        throw new FileNotFoundException ( string.Format ( "This path '{0}' doesn't exist.", value ) );
                    }
                    pathToFile = value;
                }
                catch ( SystemException ex )
                {
                    Console.WriteLine ( ex.Message );
                }
            }
        }



        private string stringForUse;

        public string StringForUse
        {
            get { return stringForUse; }
            set
            {
                try
                {
                    if ( string.IsNullOrEmpty ( value ) )
                    {
                        throw new ArgumentNullException ( string.Format ( "String for use {0} is null or empty.", value ) );
                    }
                    stringForUse = value;
                }
                catch ( ArgumentNullException ex )
                {
                    Console.WriteLine ( ex.Message );
                }
            }
        }



        private string stringForSwap;

        public string StringForSwap
        {
            get { return stringForSwap; }
            set
            {
                try
                {
                    if ( value == null )
                    {
                        throw new ArgumentNullException ( string.Format ( "String for swap {0} is null.", value ) );
                    }
                    stringForSwap = value;
                }
                catch ( ArgumentNullException ex )
                {
                    Console.WriteLine (ex.Message);
                }
            }
        }



        public FileParser ( )
        {
            Console.WriteLine ( File.ReadAllText ( "task.txt", Encoding.UTF8 ));
        }



        public FileParser ( string pathToFile, string stringForUse )
        {
            PathToFile = pathToFile;
            StringForUse = stringForUse;

            /* 
            //Load all data to the memory
            string [ ] array = null;
            try
            {
                array = File.ReadAllLines ( path );

            }
            catch ( FileNotFoundException ex )
            {
                Console.WriteLine ( ex.Message );
            }
            int i = 0;
            foreach ( string str in array )
            {
                if ( str == stringForUse )
                {
                    i++;
                }
                Console.WriteLine ( str );
            }
            Console.WriteLine ( "String \"{0}\" enters in the file - {1} times.", stringForUse, i );
            */


            // If the file is very big we have to read it by one row in order not to load all data to the memory.
            int i = 0;
            try
            {
                using ( System.IO.StreamReader reader = new System.IO.StreamReader ( PathToFile, Encoding.UTF8 ) )
                {
                    while ( !reader.EndOfStream )
                    {
                        string line = reader.ReadLine ( );
                        if ( line == stringForUse )
                        {
                            i++;
                        }
                        Console.WriteLine ( line );
                    }
                }
            }
            catch ( FileNotFoundException ex )
            {
                Console.WriteLine ( ex.Message );
            }
            Console.WriteLine ( "String \"{0}\" enters in the file - {1} times.", stringForUse, i );
        }



        public FileParser ( string pathToFile, string stringForUse, string stringForSwap )
        {
            PathToFile = pathToFile;
            StringForUse = stringForUse;
            StringForSwap = stringForSwap;

            /*
            string [ ] array = null;
            try
            {
                array = File.ReadAllLines ( pathToFile );
            }
            catch ( Exception ex)
            {
                Console.WriteLine (ex);
            }
            for ( int i = 0; i < array.Length; i++ )
            {
                if ( array[i] == stringForUse )
                {
                    array [ i ] = stringForSwap;
                }
            }
            File.WriteAllLines ( pathToFile, array );
            Console.WriteLine (File.ReadAllText(pathToFile));
            */


            const string TEMP_FILE = "temp.txt";
            try
            {
                using ( StreamReader reader = new StreamReader ( pathToFile, Encoding.UTF8 ) )
                {
                    using ( StreamWriter writer = new StreamWriter ( TEMP_FILE ) )
                    {
                        while ( !reader.EndOfStream )
                        {
                            string line = reader.ReadLine ( );
                            if ( line == stringForUse )
                            {
                                writer.WriteLine ( StringForSwap );
                            }
                            else
                            {
                                writer.WriteLine ( line );
                            }
                        }
                    }
                }
                File.WriteAllText ( pathToFile, File.ReadAllText ( TEMP_FILE ) );
                File.Delete ( TEMP_FILE );
            }
            catch ( Exception ex )
            {
                Console.WriteLine ( ex.Message );
            }
            Console.WriteLine ( File.ReadAllText ( pathToFile ) );
        }
    }
}