using System.Text.RegularExpressions;

namespace numcon
{
    internal class Program
    {
        public static bool loopcancel = false;
        public static void invalid()
        {
            Console.WriteLine("\ninvalid input");
            loopcancel = true;
        }
        public static char zahlensystem(char kennbuchstabe)
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
                    invalid();
                    break;
            }
            return kennbuchstabe;
        }

        public static void check(char key, string input)
        {
            if (
                (key != 'h' && !Regex.IsMatch(input, @"^\d+$")) ||
                (key == 'h' && !Regex.IsMatch(input, @"^(0x)?[0-9a-fA-F]+$")) ||
                (key == 'b' && !Regex.IsMatch(input, @"^[0-1]+$")) ||
                (key == 'o' && !Regex.IsMatch(input, @"^[0-7]+$"))
                )
            {
                invalid();
            }
            else
            {
                Console.WriteLine("valid");
            }
        }

        public static void convertTo(char key1, char key2, string wert)
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
                            Console.WriteLine(Convert.ToInt32(wert, 2));
                            break;
                        case 'h':
                            Console.WriteLine(Convert.ToInt32(wert, 2).ToString("X"));
                            break;
                        case 'o':
                            Console.WriteLine(Convert.ToString(Convert.ToInt32(wert, 2), 8));
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
                            Console.WriteLine(int.Parse(wert).ToString("X"));
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

                            break;
                        case 'd':

                            break;
                        case 'h':

                            break;
                        case 'o':

                            break;
                    }
                    break;
                case 'o':
                    switch (key2)
                    {
                        case 'b':

                            break;
                        case 'd':

                            break;
                        case 'h':

                            break;
                        case 'o':

                            break;
                    }
                    break;
            }
        }

        public static void Main(string[] args)
        {
            bool loop = true;
            string keys = "b=binary d=decimal h=hexadecimal o=octal";

            while (loop)
            {
                Console.Clear();
                Console.WriteLine("Binary Converter\n\n");
                Console.WriteLine(keys);
                Console.Write("convert from: ");
                char keyWahl1 = zahlensystem(Console.ReadKey().KeyChar);
                
                if (loopcancel == true)
                {
                    loopcancel = !loop;
                    continue;
                }

                string ersteZahl = Console.ReadLine();

                check(keyWahl1, ersteZahl);
                if (loopcancel == true)
                {
                    loopcancel = !loop;
                    continue;
                }

                Console.WriteLine("\nconvert to: ");
                char keyWahl2 = zahlensystem(Console.ReadKey().KeyChar);
                if (loopcancel == true)
                {
                    loopcancel = !loop;
                    continue;
                }
                convertTo(keyWahl1, keyWahl2, ersteZahl);

                Console.ReadKey();
            }
        }
    }
}
