namespace MidtermClassLibrary.Models
{
    public class Student
    {
        public int ID;
        public string Name;
        public int Age;
        public string Course;
        public int YearLevel;
        public double GPA;

        public void Display()
        {
            Console.WriteLine($"Student ID: {ID}, Name: {Name}, Age: {Age}, Course: {Course}, Year Level: {YearLevel}, GPA: {GPA:F2}");
        }
    }
}
