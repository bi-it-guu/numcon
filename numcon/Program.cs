using System.Text.RegularExpressions;

namespace numcon
{
    internal class Program
    {
        public static bool loopcancel = false;
        public static void Invalid()
        {
            Console.WriteLine("\ninvalid input");
            loopcancel = true;
            Console.ReadKey();
        }
        public static char Zahlensystem(char kennbuchstabe)
        {
            switch (kennbuchstabe)
            {
                case 'b':
                    Console.WriteLine("\n\nBinary");
                    break;
                case 'd':
                    Console.WriteLine("\n\nDecimal");
                    break;
                case 'h':
                    Console.WriteLine("\n\nHexadecimal");
                    break;
                case 'o':
                    Console.WriteLine("\n\nOctal");
                    break;
                default:
                    Invalid();
                    break;
            }
            return kennbuchstabe;
        }

        public static void Check(char key, string input)
        {
            if (
                (key == 'h' && !Regex.IsMatch(input, @"^(0x)?[0-9a-fA-F]+$")) ||
                (key == 'b' && !Regex.IsMatch(input, @"^[0-1]+$")) ||
                (key == 'o' && !Regex.IsMatch(input, @"^[0-7]+$")) ||
                (key == 'd' && !Regex.IsMatch(input, @"^-?\d+$"))
                )
            {
                Invalid();
            }
        }

        public static void ConvertTo(char key1, char key2, string wert)
        {
            switch(key1)
            {
                case 'b':
                    switch (key2)
                    {
                        case 'b':
                            Console.WriteLine(wert);
                            break;
                        case 'd':
                            Console.WriteLine(Convert.ToInt64(wert, 2));
                            break;
                        case 'h':
                            Console.WriteLine(Convert.ToString(Convert.ToInt64(wert, 2), 16));
                            break;
                        case 'o':
                            Console.WriteLine(Convert.ToString(Convert.ToInt64(wert, 2), 8));
                            break;
                    }
                    break;
                case 'd':
                    switch (key2)
                    {
                        case 'b':
                            Console.WriteLine(Convert.ToString(int.Parse(wert), 2));
                            break;
                        case 'd':
                            Console.WriteLine(wert);
                            break;
                        case 'h':
                            Console.WriteLine(Convert.ToString(int.Parse(wert), 16));
                            break;
                        case 'o':
                            Console.WriteLine(Convert.ToString(int.Parse(wert), 8));
                            break;
                    }
                    break;
                case 'h':
                    switch (key2)
                    {
                        case 'b':
                            Console.WriteLine(Convert.ToString(Convert.ToInt64(wert, 16), 2));
                            break;
                        case 'd':
                            Console.WriteLine(Convert.ToInt64(wert, 16));
                            break;
                        case 'h':
                            Console.WriteLine(wert.ToUpper());
                            break;
                        case 'o':
                            Console.WriteLine(Convert.ToString(Convert.ToInt64(wert, 16), 8));
                            break;
                    }
                    break;
                case 'o':
                    switch (key2)
                    {
                        case 'b':
                            Console.WriteLine(Convert.ToString(Convert.ToInt64(wert, 8), 2));
                            break;
                        case 'd':
                            Console.WriteLine(Convert.ToInt32(wert, 8));
                            break;
                        case 'h':
                            Console.WriteLine(Convert.ToString(Convert.ToInt64(wert, 8), 16));
                            break;
                        case 'o':
                            Console.WriteLine(wert);
                            break;
                    }
                    break;
            }
        }

        public static void Main(string[] args)
        {
            string keys = "b=binary d=decimal h=hexadecimal o=octal";

            while (true)
            { 
                Console.Clear();
                Console.WriteLine("Zahlenkonvertierung\n\n");
                Console.WriteLine(keys);
                Console.Write("convert from (msb/big_endian): ");
                char keyWahl1 = Zahlensystem(Console.ReadKey().KeyChar);
                if (loopcancel)
                {
                    loopcancel = false;
                    continue;
                }
                string ersteZahl = Console.ReadLine();

                Check(keyWahl1, ersteZahl);
                if (loopcancel)
                {
                    loopcancel = false;
                    continue;
                }
                Console.WriteLine("\nconvert to: ");
                char keyWahl2 = Zahlensystem(Console.ReadKey().KeyChar);
                if (loopcancel)
                {
                    loopcancel = false;
                    continue;
                }
                ConvertTo(keyWahl1, keyWahl2, ersteZahl);

                Console.ReadKey();
            }
        }
    }
}
