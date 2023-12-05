using A1PL3Y_HFT2023241.Logic.Interfaces;
using A1PL3Y_HFT2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace A1PL3Y_HFT2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CourStatController : ControllerBase
    {
        ICourseLogic logic;

        public CourStatController(ICourseLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<CourseModel.HowManyInfo> CreditValuePerSubjects()
        {
            return this.logic.CreditValuePerSubjects();
        }
    }
}
