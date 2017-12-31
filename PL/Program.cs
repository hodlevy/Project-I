using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {
            BL.IBL MyBL = new BL.Bl();
            int choice;
            do
            {
                Console.WriteLine("Choose:\n1.Nanny\n2.Mother\n3.Child\n4.Contract\n5.Lists\nExit - 0\n");
                choice = Console.Read();
                switch (choice)
                {
                    case '1':
                        Console.WriteLine("Choose:\n1.Add\n2.Delete\n3.Update\nExit - 0\n");
                        choice = Console.Read();
                        switch (choice)
                        {
                            case '1':
                                break;
                            case '2':
                                Console.WriteLine("Enter ID:");
                                string ID = Console.ReadLine();
                                MyBL.DeleteNanny(ID);
                                break;
                            case '3':
                                break;
                            case '0':
                                break;
                            default:
                                Console.WriteLine("Choose Again!\n");
                                break;
                        }
                        break;
                    case '2':
                        Console.WriteLine("Choose:\n1.Add\n2.Delete\n3.Update\nExit - 0\n");
                        choice = Console.Read();
                        switch (choice)
                        {
                            case '1':
                                break;
                            case '2':
                                Console.WriteLine("Enter ID:");
                                string ID = Console.ReadLine();
                                MyBL.DeleteMother(ID);
                                break;
                            case '3':
                                break;
                            case '0':
                                break;
                            default:
                                Console.WriteLine("Choose Again!\n");
                                break;
                        }
                        break;
                    case '3':
                        Console.WriteLine("Choose:\n1.Add\n2.Delete\n3.Update\nExit - 0\n");
                        choice = Console.Read();
                        switch (choice)
                        {
                            case '1':
                                break;
                            case '2':
                                break;
                            case '3':
                                Console.WriteLine("Enter ID:");
                                string ID = Console.ReadLine();
                                MyBL.DeleteChild(ID);
                                break;
                            case '0':
                                break;
                            default:
                                Console.WriteLine("Choose Again!\n");
                                break;
                        }
                        break;
                    case '4':
                        Console.WriteLine("Choose:\n1.Add\n2.Delete\n3.Update\nExit - 0\n");
                        choice = Console.Read();
                        switch (choice)
                        {
                            case '1':
                                break;
                            case '2':
                                Console.WriteLine("Enter number:");
                                int number = Console.Read();
                                MyBL.DeleteContract(number);
                                break;
                            case '3':
                                break;
                            case '0':
                                break;
                            default:
                                Console.WriteLine("Choose Again!\n");
                                break;
                        }
                        break;
                    case '5':
                        Console.WriteLine("Choose:\n1.Nanny\n2.Mother\n3.Child\n4.Contract\nExit - 0\n");
                        choice = Console.Read();
                        switch (choice)
                        {
                            case '1':
                                MyBL.AllNannys().ToString();
                                break;
                            case '2':
                                MyBL.AllMothers().ToString();
                                break;
                            case '3':
                                MyBL.AllChildren().ToString();
                                break;
                            case '4':
                                MyBL.AllContracts().ToString();
                                break;
                            case '0':
                                break;
                            default:
                                Console.WriteLine("Choose Again!\n");
                                break;
                        }
                        break;
                    case '0':
                        break;
                    default:
                        Console.WriteLine("Choose Again!\n");
                        break;
                }
            } while (choice != '0');
        }
    }
}
