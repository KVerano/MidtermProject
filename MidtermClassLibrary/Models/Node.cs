namespace MidtermClassLibrary.Models
{
    public class Node
    {
        public Student Data;
        public Node Prev;
        public Node Next;

        public Node(Student student)
        {
            Data = student;
            Prev = null;
            Next = null;
        }
    }
}