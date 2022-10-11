using Courses_Center.Models;

namespace Courses_Center.ViewModels.Extentsion
{
    public static class Extension
    {

        #region Cours 

        public static Course DTOToCourse(this CourseDTO courseDTO)
        {
            Course course = new Course();
            course.Id = courseDTO.Id;
            course.Name = courseDTO.Name;
            course.Level = courseDTO.Level;
            course.Semester = courseDTO.Semester;
            course.DeptID = courseDTO.DeptID;
            return course;

        }

        public static CourseDTO CourseToDTO(this Course course)
        {
            CourseDTO courseDTO = new CourseDTO();
            courseDTO.Id = course.Id;
            courseDTO.Name = course.Name;
            courseDTO.Level = course.Level;
            courseDTO.Semester = course.Semester;
            courseDTO.DeptID = course.DeptID;
            return courseDTO;

        }
        #endregion

        #region Professor
        public static Professor DTOToProfessor(this ProfessorDTO professorDTO)
        {
            Professor professor = new Professor();
            professor.Name = professorDTO.Name;
            professor.Id = (int)professorDTO.Id;
            return professor;
        }

        public static ProfessorDTO ProfessorToDTO(this Professor professor)
        {
            ProfessorDTO profDTO = new ProfessorDTO();
            profDTO.Name = professor.Name;
            profDTO.Id = professor.Id;
            return profDTO;
        }
        #endregion

        #region Sources
        public static Source DTOToSource(this SourceDto sourceDto)
        {
            Source source = new Source();

            source.Title = sourceDto.Title;
            source.Description = sourceDto.Description;
            source.Price = sourceDto.Price;
            source.Notes = sourceDto.Notes;
            source.CrsID = sourceDto.CrsID;
            source.ProfID = sourceDto.ProfID;
            source.Type = sourceDto.Type;
            return source;

        }

        public static SourceDto SourceToDTO(this Source source)
        {
            SourceDto sourceDto = new SourceDto();
            sourceDto.Id = source.Id;
            sourceDto.Title = source.Title;
            sourceDto.Url = source.Url;
            sourceDto.Description = source.Description;
            sourceDto.Price = source.Price;
            //sourceDto.deptId = department;
            sourceDto.CrsID = source.CrsID;
            sourceDto.ProfID = source.ProfID;
            //sourceDto.uniId = unversity;
            sourceDto.Type = source.Type;
            // sourceDto.colliId = colleges;
            sourceDto.Notes = source.Notes;
            // sourceDto.uniName = uni.Name;
            // sourceDto.collName = college.Name;
            //sourceDto.deptName = dept.Name;

            return sourceDto;

        }
        #endregion
    }
}
