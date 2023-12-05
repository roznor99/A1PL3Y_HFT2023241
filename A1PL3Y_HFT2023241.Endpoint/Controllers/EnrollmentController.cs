using A1PL3Y_HFT2023241.Logic.Interfaces;
using A1PL3Y_HFT2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace A1PL3Y_HFT2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        IEnrollmentLogic logic;

        public EnrollmentController(IEnrollmentLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<EnrollmentModel> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public EnrollmentModel Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] EnrollmentModel value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] EnrollmentModel value)
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
