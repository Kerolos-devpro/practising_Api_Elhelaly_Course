
namespace Demo.api.Services;

public class StudentService : IStudentService
{
    private static readonly List<Student> _students = [
           new()
           {
              Id = 1,
              Name= "Kerolos Monir",
              Grade=3.796
           },
           new()
           {
              Id = 2,
              Name= "Pasaa",
              Grade= 4
           },  new()
           {
              Id = 3,
              Name= "Kerolos Monir",
              Grade=3.96
           },


        ];
    public IEnumerable<Student> GetAll() => _students;
    

    public Student? Get(int id) => GetAll().SingleOrDefault(x => x.Id == id);   
    
    
    public Student Add(Student student)
    {
        student.Id = _students.Count + 1;
        _students.Add(student);
        return student;
    }

    public bool Update(int id, Student student)
    {
        var currentStudent = Get(id);
        if (currentStudent is null)
            return false;

        currentStudent.Name = student.Name;
        currentStudent.Grade = student.Grade;

        return true;
    }

    public bool Delete(int id)
    {
        var student = Get(id);
        if (student is null)
            return false;

        _students.Remove(student);
        return true;
    }

   
}
