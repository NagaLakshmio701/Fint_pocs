namespace WebApplication1.Repositories
{
    public interface IStudents
    {
        public Guid GenerateID();
        public List<string> GetStudents();
    }
}
