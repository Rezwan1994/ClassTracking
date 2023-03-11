using ClassTracking.Domain.Entities;
using ClassTracking.Service.Interface.ClassTracking;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private ITeacherService _service;
        private ITeacherEnrollmentService _serviceEnrollment;
    
        public TeacherController(ITeacherService service, ITeacherEnrollmentService serviceEnrollment)
        {
            _service = service;
            _serviceEnrollment = serviceEnrollment;
        }

        [HttpGet("getallteacher")]
        public Task<IEnumerable<Teacher>> GetAllTeachers()
        {
            return _service.GetAsync(); ;
        }

        [HttpPost("createteacher")]
        public async Task<ActionResult<bool>> CreateTeacher(Teacher teacher)
        {
            try
            {
                if (teacher != null)
                {
                    teacher.TeacherId= Guid.NewGuid();
                    teacher.CreatedDate = DateTime.Now;
                    _service.InsertAsync(teacher);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        [HttpPost("createteachermapping")]
        public async Task<ActionResult<bool>> CreateTeacherMapping(TeacherEnrollment teacherMap)
        {
            try
            {
                if (teacherMap != null)
                {
                    teacherMap.AssignDate = DateTime.Now;
                    _serviceEnrollment.InsertAsync(teacherMap);
                    Teacher teacher = _service.GetTeacherByTeacherId(teacherMap.TeacherId).FirstOrDefault();
                    if (teacher != null)
                    {
                        teacher.IsAssigned = true;
                        _service.UpdateAsync(teacher);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
