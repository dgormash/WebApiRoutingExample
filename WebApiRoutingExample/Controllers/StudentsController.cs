using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiRoutingExample.Models;

namespace WebApiRoutingExample.Controllers
{
    public class StudentsController : ApiController
    {
        static readonly List<Student> Students = new List<Student>()
        {
            new Student {Id = 1, Name = "Гормаш Дмитрий"},
            new Student {Id = 2, Name = "Елена Ивлева"},
            new Student{Id = 3, Name = "Иван Пупкин"}
        };

        public IEnumerable<Student> Get()
        {
            return Students;
        }

        public Student Get(int id)
        {
            return Students[id];
        }

        [Route("api/students/{id}/courses")]
        public IEnumerable<string> GetStudentCourses(int id)
        {
            switch (id)
            {
               case 1:
                    return new List<string> {"C#", "ASP.NET", "SQL Server"};
                case 2:
                    return new List<string> { "ASP.NET Core", "jQuery", "SQL Server" };
                case 3:
                    return new List<string> { "Bootstrap", "ASP.NET WebApi", "AngularJs" };
                default:
                    return null;
            }
        }
    }
}
