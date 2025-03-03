using WebApplication1.Repositories;
using System.Collections.Generic;

namespace WebApplication1.Repositories

{
    public class Students : IStudents
    {
        Guid ID;
        public Students()
        {
            ID = Guid.NewGuid();
        }
        public Guid GenerateID()
        {
            return ID;
        }

        public List<string> GetStudents()
        {
           List<string> l1= new List<string>();
            l1.Add("Ram");
            l1.Add("lucky");
            l1.Add("Ganesh");
            l1.Add("Gayathri");

            return l1;

        }
    }
}
