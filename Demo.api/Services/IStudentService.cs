namespace Demo.api.Services;

public interface IStudentService
{
    IEnumerable<Student> GetAll();
    Student? Get(int id);
    Student Add(Student student);
    bool Update(int id, Student student);
    bool Delete(int id);
}
