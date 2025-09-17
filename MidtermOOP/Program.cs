using MidtermClassLibrary.Models;
using MidtermClassLibrary.DataStructures;

class Program
{
    static void Main()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("=== Student Record Management System ===");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Delete Student");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Update Student");
            Console.WriteLine("5. Display All Students");
            Console.WriteLine("6. Exit");
            Console.WriteLine("========================================");
            Console.Write("\nChoose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Student s = new Student();

                    // ID
                    while (true)
                    {
                        Console.Write("Enter ID: ");
                        string idInput = Console.ReadLine();
                        if (int.TryParse(idInput, out int id))
                        {
                            if (list.IsDuplicate(id))
                            {
                                Console.WriteLine($"ID {id} already exists.");
                                continue;
                            }
                            s.ID = id;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. ID must be a number.");
                        }
                    }

                    // First Name
                    string firstName = "";
                    while (true)
                    {
                        Console.Write("Enter First Name: ");
                        firstName = Console.ReadLine()?.Trim();

                        if (!string.IsNullOrWhiteSpace(firstName) && firstName.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                            break;

                        Console.WriteLine("Invalid input");
                    }

                    string lastName = "";
                    while (true)
                    {
                        Console.Write("Enter Last Name: ");
                        lastName = Console.ReadLine()?.Trim();

                        if (!string.IsNullOrWhiteSpace(lastName) && lastName.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                            break;

                        Console.WriteLine("Invalid input.");
                    }

                    s.Name = $"{firstName} {lastName}";

                    // Age
                    while (true)
                    {
                        Console.Write("Enter Age: ");
                        if (int.TryParse(Console.ReadLine(), out int age) && age > 0)
                        {
                            s.Age = age;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Age must be a positive number.");
                        }
                    }

                    // Course
                    while (true)
                    {
                        Console.Write("Enter Course: ");
                        string courseInput = Console.ReadLine()?.Trim();
                        if (!string.IsNullOrWhiteSpace(courseInput) && courseInput.All(char.IsLetter))
                        {
                            s.Course = courseInput;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Course must contain letters only.");
                        }
                    }

                    // Year Level
                    while (true)
                    {
                        Console.Write("Enter Year Level (1–5): ");
                        if (int.TryParse(Console.ReadLine(), out int yearLevel))
                        {
                            if (yearLevel >= 1 && yearLevel <= 5)
                            {
                                s.YearLevel = yearLevel;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Year Level must be between 1 and 5.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a number.");
                        }
                    }

                    // GPA
                    while (true)
                    {
                        Console.Write("Enter GPA (1.0–5.0): ");
                        if (double.TryParse(Console.ReadLine(), out double gpa))
                        {
                            if (gpa >= 1.0 && gpa <= 5.0)
                            {
                                s.GPA = gpa;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("GPA must be between 1.0 and 5.0.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a numeric value.");
                        }
                    }

                    // Insert at the beginning, at the end, or at a specified position.
                    string positionChoice = "";
                    int index = 0;

                    Console.WriteLine("Where do you want to insert the student?");
                    Console.WriteLine("(1) Beginning");
                    Console.WriteLine("(2) End");
                    Console.WriteLine("(3) Specific Position");

                    while (true)
                    {
                        Console.Write("Enter your choice (1, 2, or 3): ");
                        string input = Console.ReadLine();

                        if (input == "1")
                        {
                            positionChoice = "beginning";
                            break;
                        }
                        else if (input == "2")
                        {
                            positionChoice = "end";
                            break;
                        }
                        else if (input == "3")
                        {
                            positionChoice = "position";

                            while (true)
                            {
                                Console.Write("Enter specific position (starting from 0): ");
                                string indexInput = Console.ReadLine();

                                if (int.TryParse(indexInput, out index))
                                {
                                    if (index >= 0)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Position must be zero or a positive number.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a number.");
                                }
                            }

                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                        }
                    }

                    list.AddStudent(s, positionChoice, index);
                    Console.ReadKey();
                    break;
                case "2":
                    if (list.IsEmpty())
                    {
                        Console.WriteLine("No student records found. Nothing to delete.");
                        Console.ReadKey();
                        break;
                    }

                    int delId;
                    while (true)
                    {
                        Console.Write("Enter ID to delete: ");
                        string input = Console.ReadLine()?.Trim();

                        if (!string.IsNullOrEmpty(input) && int.TryParse(input, out delId))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid numeric ID.");
                        }
                    }

                    list.DeleteStudent(delId);
                    Console.ReadKey();
                    break;


                case "3":
                    Console.Write("Enter ID or Name to search: ");
                    string key = Console.ReadLine();
                    list.SearchStudent(key);
                    Console.ReadKey();
                    break;

                case "4":
                    int updateId;
                    while (true)
                    {
                        Console.Write("Enter ID to update: ");
                        if (int.TryParse(Console.ReadLine(), out updateId))
                            break;
                        Console.WriteLine("Invalid input. Please enter a numeric ID.");
                    }

                    list.UpdateStudent(updateId);
                    Console.ReadKey();
                    break;

                case "5":
                    list.DisplayAll();
                    Console.ReadKey();
                    break;

                case "6":
                    running = false;
                    Console.WriteLine("Thank you! Goodbye. DA BEST KA SIR!");
                    Console.ReadKey();
                    break;

                default:
                    Console.WriteLine("Invalid option. Please choose between 1-6.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}