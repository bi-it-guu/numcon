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
                (key != 'h' && !Regex.IsMatch(input, @"^\d+$")) ||
                (key == 'h' && !Regex.IsMatch(input, @"^(0x)?[0-9a-fA-F]+$")) ||
                (key == 'b' && !Regex.IsMatch(input, @"^[0-1]+$")) ||
                (key == 'o' && !Regex.IsMatch(input, @"^[0-7]+$"))
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
                            int decimalZahl = 0;
                            for (int i = 0; i < wert.Length; i++)
                            {
                                int quadZahl = 2;
                                for (int j = 0; j < i; j++)
                                {
                                    if (i == 0)
                                        quadZahl = 1;
                                    else if (i > 1)
                                        quadZahl *= 2;
                                }
                                if (wert[i] == '1')
                                {
                                    decimalZahl += quadZahl;
                                }
                            }
                            Console.WriteLine(decimalZahl);
                            break;
                        case 'h':
                            
                            break;
                        case 'o':
                           
                            break;
                    }
                    break;
                case 'd':
                    switch (key2)
                    {
                        case 'b':
                            
                            break;
                        case 'd':
                            Console.WriteLine(wert);
                            break;
                        case 'h':
                            
                            break;
                        case 'o':
                            
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
                            Console.WriteLine(wert);
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
                Console.Write("convert from (msb): ");
                char keyWahl1 = Zahlensystem(Console.ReadKey().KeyChar);
                
                if (loopcancel == true)
                {
                    loopcancel = !loop;
                    continue;
                }

                string ersteZahl = Console.ReadLine();

               Check(keyWahl1, ersteZahl);
                if (loopcancel == true)
                {
                    loopcancel = !loop;
                    continue;
                }

                Console.WriteLine("\nconvert to: ");
                char keyWahl2 = Zahlensystem(Console.ReadKey().KeyChar);
                if (loopcancel == true)
                {
                    loopcancel = !loop;
                    continue;
                }
                ConvertTo(keyWahl1, keyWahl2, ersteZahl);

                Console.ReadKey();
            }
        }
    }
}
