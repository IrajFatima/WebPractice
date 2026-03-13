using homework1.Models;

namespace homework1.Services
{
    public class StudentService
    {
        List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            students.Add(student);
        }
        public void UpdateStudent(Student student)
        {
            
            var existingStudent = students.FirstOrDefault(s => s.StudentId == student.StudentId);
            if (existingStudent != null)
            {
                existingStudent.Name = student.Name;
                existingStudent.Email = student.Email;
                existingStudent.Department = student.Department;
                existingStudent.CGPA = student.CGPA;
                existingStudent.IsActive = student.IsActive;
            }
        }
        public List<Student> GetStudents() { return students.Where(s=> s.IsActive == true ).ToList(); }
        public Student GetStudentById(int id) { return students.FirstOrDefault(s => s.StudentId == id && s.IsActive == true); }

        public void DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.StudentId == id);
            if(student != null)
            {
                student.IsActive = false;
            }
        }
    }
}
