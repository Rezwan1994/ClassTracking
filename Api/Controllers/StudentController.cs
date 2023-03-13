using ClassTracking.Domain.BusinessModel;
using ClassTracking.Domain.Entities;
using ClassTracking.Service.Interface.ClassTracking;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private IStudentService _service;
        private IClassService _classService;
        private ITeacherService _teacherService;
        private IStudentClassMapService _classMapService;
        public StudentController(IStudentService service, IClassService classService, IStudentClassMapService classMapService, ITeacherService teacherService)
        {
            _service = service;
            _classService = classService;
            _classMapService = classMapService;
            _teacherService = teacherService;

        }
      
        [HttpPost("createstudent")]
        public async Task<ActionResult<bool>> CreateStudent(StudentModel student)
        {

            try
            {
                if (student != null)
                {
                    Student stu = new Student();
                    stu.StudentId = Guid.NewGuid();
                    stu.Name = student.Name;
                    stu.FatherName = student.FatherName;
                    stu.MotherName = student.MotherName;
                    stu.SessionYear = student.SessionYear;
                    stu.EnrollDate = student.EnrollDate;
                    stu.Nationality = student.Nationality;
                  
                    await _service.InsertAsync(stu);
                    if(student.ClassId != Guid.Empty)
                    {
                        StudentClassMap sMap = new StudentClassMap(); ;
                        sMap.ClassId = student.ClassId;
                        sMap.StudentId = stu.StudentId;
                        _classMapService.InsertAsync(sMap);
                    }
                }
              
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }


        [HttpGet("getallclass")]
        public Task<IEnumerable<Class>> GetAllClass()
        {
            return _classService.GetAsync(); ;
        }

        [HttpGet("getallstudents")]
        public  List<ClassModel> GetAllStudent()
        {
            List<ClassModel> classModelList = new List<ClassModel>();
            List<Class> classList = _classService.GetAsync().Result.ToList();
            List<Student> studentList = new List<Student>();
            Teacher teacher = new Teacher();
            if(classList != null)
            {
                foreach(var item in classList)
                {
                    teacher = _teacherService.GetTeacherByClassId(item.ClassId);
                    studentList = _service.GetAllStudentByClassId(item.ClassId);
                    ClassModel model = new ClassModel();
                    model.classobj = item;
                    model.teacherobj = teacher;
                    model.studentList = studentList;
                    classModelList.Add(model);
                }
            }
            return  classModelList;
        }
    }
}
