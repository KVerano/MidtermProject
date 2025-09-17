using MidtermClassLibrary.Models;

namespace MidtermClassLibrary.DataStructures
{
    public class DoublyLinkedList
    {
        private Node head;

        public bool IsDuplicate(int id)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data.ID == id)
                    return true;
                current = current.Next;
            }
            return false;
        }

        // Add Student
        public void AddStudent(Student student, string position, int index = 0)
        {
            Node newNode = new Node(student);

            if (head == null)
            {
                head = newNode;
                Console.WriteLine("Student added successfully.");
                return;
            }

            position = position.ToLower();

            if (position == "beginning")
            {
                newNode.Next = head;
                head.Prev = newNode;
                head = newNode;
            }
            else if (position == "end")
            {
                Node current = head;
                while (current.Next != null)
                    current = current.Next;

                current.Next = newNode;
                newNode.Prev = current;
            }
            else if (position == "position")
            {
                if (index == 0)
                {
                    AddStudent(student, "beginning");
                    return;
                }

                Node current = head;
                int count = 0;

                while (current != null && count < index - 1)
                {
                    current = current.Next;
                    count++;
                }

                if (current == null)
                {
                    Console.WriteLine("Invalid position. Student not added.");
                    return;
                }

                newNode.Next = current.Next;
                newNode.Prev = current;

                if (current.Next != null)
                    current.Next.Prev = newNode;

                current.Next = newNode;
            }

            Console.WriteLine("Student added successfully.");
        }

        // Delete Student
        public bool IsEmpty()
        {
            return head == null;
        }
        public void DeleteStudent(int id)
        {
            if (head == null)
            {
                Console.WriteLine("No students to delete.");
                return;
            }

            if (head.Data.ID == id)
            {
                head = head.Next;
                if (head != null)
                    head.Prev = null;
                Console.WriteLine("Student deleted successfully.");
                return;
            }

            Node current = head;
            while (current != null && current.Data.ID != id)
                current = current.Next;

            if (current == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            if (current.Prev != null)
                current.Prev.Next = current.Next;

            if (current.Next != null)
                current.Next.Prev = current.Prev;

            Console.WriteLine("Student deleted successfully.");
        }

        // Search Student
        public void SearchStudent(string key)
        {
            Node current = head;
            bool found = false;

            while (current != null)
            {
                string idStr = current.Data.ID.ToString();
                string[] nameParts = current.Data.Name.Split(' ');

                string firstName = nameParts.Length > 0 ? nameParts[0] : "";
                string lastName = nameParts.Length > 1 ? nameParts[1] : "";

                if (idStr == key ||
                    firstName.Equals(key, StringComparison.OrdinalIgnoreCase) ||
                    lastName.Equals(key, StringComparison.OrdinalIgnoreCase))
                {
                    current.Data.Display();
                    found = true;
                }

                current = current.Next;
            }

            if (!found)
            {
                Console.WriteLine("Student not found.");
            }
        }

        // Update Student
        public void UpdateStudent(int id)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data.ID == id)
                {
                    Console.WriteLine("Student found. Please enter new details.");

                    string firstName;
                    while (true)
                    {
                        Console.Write("First Name: ");
                        firstName = Console.ReadLine()?.Trim();
                        if (!string.IsNullOrWhiteSpace(firstName)) break;
                        Console.WriteLine("First name is required.");
                    }

                    string lastName;
                    while (true)
                    {
                        Console.Write("Last Name: ");
                        lastName = Console.ReadLine()?.Trim();
                        if (!string.IsNullOrWhiteSpace(lastName)) break;
                        Console.WriteLine("Last name is required.");
                    }

                    current.Data.Name = $"{firstName} {lastName}";

                    int age;
                    while (true)
                    {
                        Console.Write("Age: ");
                        if (int.TryParse(Console.ReadLine(), out age) && age > 0)
                            break;
                        Console.WriteLine("Invalid input. Age must be a positive number.");
                    }
                    current.Data.Age = age;

                    string course;
                    while (true)
                    {
                        Console.Write("Course: ");
                        course = Console.ReadLine()?.Trim();
                        if (!string.IsNullOrWhiteSpace(course) && course.All(char.IsLetter))
                            break;
                        Console.WriteLine("Invalid input. Course must contain letters only.");
                    }
                    current.Data.Course = course;

                    int yearLevel;
                    while (true)
                    {
                        Console.Write("Year Level (1–5): ");
                        if (int.TryParse(Console.ReadLine(), out yearLevel) && yearLevel >= 1 && yearLevel <= 5)
                            break;
                        Console.WriteLine("Year level must be between 1 and 5.");
                    }
                    current.Data.YearLevel = yearLevel;

                    double gpa;
                    while (true)
                    {
                        Console.Write("GPA (1.0–5.0): ");
                        if (double.TryParse(Console.ReadLine(), out gpa) && gpa >= 1.0 && gpa <= 5.0)
                            break;
                        Console.WriteLine("GPA must be between 1.0 and 5.0.");
                    }
                    current.Data.GPA = gpa;

                    Console.WriteLine("Student updated successfully.");
                    return;
                }

                current = current.Next;
            }

            Console.WriteLine("Student not found.");
        }

        // Display Students
        public void DisplayAll()
        {
            if (head == null)
            {
                Console.WriteLine("No student records found.");
                return;
            }

            Node current = head;

            while (true)
            {
                Console.Clear();
                string prevID = current.Prev != null ? current.Prev.Data.ID.ToString() : "null";
                string nextID = current.Next != null ? current.Next.Data.ID.ToString() : "null";

                Console.WriteLine($"[Prev: {prevID}] <- [Current Student] -> [Next: {nextID}]");
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine($"ID         : {current.Data.ID}");
                Console.WriteLine($"Name       : {current.Data.Name}");
                Console.WriteLine($"Age        : {current.Data.Age}");
                Console.WriteLine($"Course     : {current.Data.Course}");
                Console.WriteLine($"Year Level : {current.Data.YearLevel}");
                Console.WriteLine($"GPA        : {current.Data.GPA:F2}");
                Console.WriteLine("-----------------------------------------------------------");

                Console.WriteLine("\nOptions:");
                Console.WriteLine("N - Next");
                Console.WriteLine("P - Previous");
                Console.WriteLine("E - Exit");

                Console.Write("\nChoose an option: ");
                string input = Console.ReadLine()?.Trim().ToUpper();

                if (input == "N")
                {
                    if (current.Next != null)
                        current = current.Next;
                    else
                    {
                        Console.WriteLine("You are at the end of the list. Press any key to continue.");
                        Console.ReadKey();
                    }
                }
                else if (input == "P")
                {
                    if (current.Prev != null)
                        current = current.Prev;
                    else
                    {
                        Console.WriteLine("You are at the beginning of the list. Press any key to continue.");
                        Console.ReadKey();
                    }
                }
                else if (input == "E")
                {
                    Console.WriteLine("Exiting.");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please choose N, P, or E.");
                    Console.ReadKey();
                }
            }
        }
    }
}
