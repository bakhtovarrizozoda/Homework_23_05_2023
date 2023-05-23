using Dapper;
using Npgsql;

public class StudentService
{
    string connectionString = "Server =localhost;Port=5432;User id=postgres; Database=EgzaminSql;Password=23022002;";
    public StudentService()
    {

    }
    public List<StudentDto> GetStudents()
    {
        using   (var conn = new NpgsqlConnection(connectionString))
        {
            var sql = "select firs_name FirstName, last_name LastName, date_of_birth BirthDate, email_address Email, student_id Id from students";
            var result = conn.Query<StudentDto>(sql);
            return result.ToList();
        }
    }


    //Get By Id
    public StudentDto GetStudentsById(int Id)
    {
        using   (var conn = new NpgsqlConnection(connectionString))
        {
            var sql = $"select firs_name FirstName, last_name LastName, date_of_birth BirthDate, email_address Email, student_id Id from students where student_id = {Id}";
            var result = conn.QuerySingle<StudentDto>(sql);
            return result;
        }
    }



    // Insert
    public StudentDto AddStudents(StudentDto student)
    {
        using   (var conn = new NpgsqlConnection(connectionString))
        {
            var sql = $"insert into students (firs_name, last_name, date_of_birth, email_address, student_id) values (@FirstName, @LastName, @BirthDate, @Email, @Id);";
            var result = conn.Execute(sql, student);
            return student;
        }
    }

    //Delete
    public int DeleteStudentsById(int Id)
    {
        using   (var conn = new NpgsqlConnection(connectionString))
        {
            var sql = $"delete from students where student_id = {Id}";
            var result = conn.Execute(sql);
            return result;
        }
    }

    //Update
    public int UpdateStudents(string FirstName, int Id)
    {
        using   (var conn = new NpgsqlConnection(connectionString))
        {
            var sql = $"Update  students set firs_name = '{FirstName}' where student_id = {Id}";
            var result = conn.Execute(sql);
            return result;
        }
    }


}