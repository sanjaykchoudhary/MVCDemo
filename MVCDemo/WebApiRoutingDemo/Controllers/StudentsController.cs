using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiRoutingDemo.Models;

namespace WebApiRoutingDemo.Controllers
{
    [RoutePrefix("api/students")]
    public class StudentsController : ApiController
    {
        static List<Student> students = new List<Student>()
        {
            new Student() {ID = 1, Name = "Tom" },
            new Student() {ID = 2, Name = "Sam" },
            new Student() {ID = 3, Name = "John" }
        };
        [Route("")]
        public IEnumerable<Student> Get()
        {
            return students;
        }
        [Route("{Id:int}")]
        public Student Get(int id)
        {
            return students.FirstOrDefault(s => s.ID == id);
        }
        [Route("{name:alpha}")]
        public Student GetStudentByName(string name)
        {
            return students.FirstOrDefault(s => s.Name.ToLower() == name.ToLower());
        }
        [Route("{Id}/courses")]
        public IEnumerable<string> GetStudentCourses(int id)
        {
            if (id == 1)
                return new List<string>() { "C#", "Asp.Net", "SQL Server" };
            else if (id == 2)
                return new List<string>() { "Asp.Net Web Api", "C#", "SQL Server" };
            else
                return new List<string>() { "Bootstrap", "JQuery", "Angular 2.0" };
        }
        [Route("~/api/teachers")]
        public IEnumerable<Teacher> GetTeachers()
        {
            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher() {ID = 1, Name = "Rob" },
                new Teacher() {ID = 2, Name = "Mike" },
                new Teacher() {ID = 3, Name = "Mary" }
            };
            return teachers;
        }

        public HttpResponseMessage Post(Student student)
        {
            students.Add(student);
            var response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri + "/" + student.ID.ToString());
            return response;
        }
    }

    public class Teacher
    {
        public int ID { get;  set; }
        public string Name { get; set; }
    }
}
