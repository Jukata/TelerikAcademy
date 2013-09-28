using Students.Services.Models;
using Students.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Students.Services.Controllers
{
    public class StudentsController : ApiController
    {
        private IRepository<Student> repository;

        public StudentsController()
        {
            this.repository = new FakeStudentRepository();
        }

        // GET api/students
        public IEnumerable<Student> Get()
        {
            return this.repository.GetAll();
            //.Select(st => StudentModel.CreateModelFromEntity(st));
        }

        // GET api/students/5
        public Student Get(int id)
        {
            return this.repository.GetById(id);
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]Student item)
        {
            Student entity = this.repository.Add(item);

            StudentModel model = StudentModel.CreateModelFromEntity(entity);

            HttpResponseMessage response =
                this.Request.CreateResponse(HttpStatusCode.Created, model);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = model.StudentId }));

            return response;
        }

        //GET Marks
        [ActionName("Marks")]
        public IEnumerable<Mark> GetMarks(int id)
        {
            var student =  this.repository.GetById(id);
            var marks = student.Marks;
            return marks;
        }
    }
}