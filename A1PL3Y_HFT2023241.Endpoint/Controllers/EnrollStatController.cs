using A1PL3Y_HFT2023241.Logic.Interfaces;
using A1PL3Y_HFT2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace A1PL3Y_HFT2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class EnrollStatController : ControllerBase
    {
        IEnrollmentLogic logic;

        public EnrollStatController(IEnrollmentLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<EnrollmentModel.StudentsInfo> GoodStudentToBadStudent()
        {
            return this.logic.GoodStudentToBadStudent();
        }

        [HttpGet]
        public IEnumerable<EnrollmentModel.TitleInfo> SubjectPassAVG()
        {
            return this.logic.SubjectPassAVG();
        }

        [HttpGet]
        public IEnumerable<EnrollmentModel.SubjectInfo> SubjectCount()
        {
            return this.logic.SubjectCount();
        }

        [HttpGet]
        public IEnumerable<EnrollmentModel.YearInfo> YearAVGs()
        {
            return this.logic.YearAVGs();
        }
    }
}
