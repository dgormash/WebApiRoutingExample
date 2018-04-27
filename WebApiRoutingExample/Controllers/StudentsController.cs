using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiRoutingExample.Models;

namespace WebApiRoutingExample.Controllers
{
    [RoutePrefix("api/students")]
    public class StudentsController : ApiController
    {
        static readonly List<Student> Students = new List<Student>()
        {
            new Student {Id = 1, Name = "Jhon"},
            new Student {Id = 2, Name = "Елена"},
            new Student{Id = 3, Name = "Иван"}
        };

        [Route("")]
        public IEnumerable<Student> Get()
        {
            return Students;
        }

        [Route("{id:int}", Name = "GetStudentById")]
        public Student Get(int id)
        {
            return Students.FirstOrDefault(s => s.Id == id);
        }

        [Route("")]
        public HttpResponseMessage Post(Student student)
        {
            Students.Add(student);
            var response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Url.Link("GetStudentById", new {id = student.Id}));
            return response;
        } 

        [Route("{name:alpha}")]
        public Student Get(string name)
        {
            return Students.FirstOrDefault(s => s.Name == name);
        }

        [Route("{id}/courses")]
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

        [Route("~/api/teachers")]
        public IEnumerable<Teacher> GetTeachers()
        {
            List<Teacher> teachers = new List<Teacher>
            {
                new Teacher {Id = 1, Name = "Rob"},
                new Teacher {Id = 2, Name = "Mike"},
                new Teacher {Id = 3, Name = "Mary"}
            };

            return teachers;
        } 
    }
}
