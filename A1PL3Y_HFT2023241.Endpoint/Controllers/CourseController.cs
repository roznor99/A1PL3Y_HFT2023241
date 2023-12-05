using A1PL3Y_HFT2023241.Logic.Interfaces;
using A1PL3Y_HFT2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace A1PL3Y_HFT2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        ICourseLogic logic;

        public CourseController(ICourseLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<CourseModel> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public CourseModel Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] CourseModel value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] CourseModel value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
