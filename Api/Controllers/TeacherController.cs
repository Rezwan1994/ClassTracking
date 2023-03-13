using ClassTracking.Domain.Common;
using ClassTracking.Domain.Entities;
using ClassTracking.Service.Interface.ClassTracking;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.Emit;

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
            //PaginationModel Params

            //var parmPageIndex = new SqlParameter("@PageIndex", Params.PageIndex) { Direction = ParameterDirection.Input, SqlDbType = SqlDbType.Int };
            //var parmPageSize = new SqlParameter("@PageSize", 100) { Direction = ParameterDirection.Input, SqlDbType = SqlDbType.Int };

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
                    await _service.InsertAsync(teacher);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        [HttpPost("createteachermapping")]
        public async Task<Result> CreateTeacherMapping(TeacherEnrollment teacherMap)
        {
            Result result = new Result();
            try
            {
                if (teacherMap != null)
                {
                    teacherMap.AssignDate = DateTime.Now;
                    TeacherEnrollmentVM existTeacherClassMap = _serviceEnrollment.GetTeacherEnrollmentByClassId(teacherMap.ClassId).FirstOrDefault();
                    if (existTeacherClassMap == null)
                    {
                        TeacherEnrollment existTeacherMap = _serviceEnrollment.GetTeacherEnrollmentByTeacherId(teacherMap.TeacherId).FirstOrDefault();
                        if (existTeacherMap != null)
                        {
                            existTeacherMap.ClassId = teacherMap.ClassId;
                            await _serviceEnrollment.UpdateAsync(existTeacherMap);
                            result.Message = "Updated Successfully";
                            result.Status = true;
                        }
                        else
                        {
                            await _serviceEnrollment.InsertAsync(teacherMap);
                            Teacher teacher = _service.GetTeacherByTeacherId(teacherMap.TeacherId).FirstOrDefault();
                            if (teacher != null)
                            {
                                teacher.IsAssigned = true;
                                await _service.UpdateAsync(teacher);
                            }
                            result.Message = "Saved Successfully";
                            result.Status = true;
                        }
                    }
                    else
                    {
                        result.Message = "Already assigned to "+ existTeacherClassMap.TeacherName;
                        result.Status = false;
                    }
                    
                
                }
                return result;
            }
            catch (Exception ex)
            {
                result.Message = "Internal Error";
                result.Status = false;
                return result;
            }

        }
    }
}
