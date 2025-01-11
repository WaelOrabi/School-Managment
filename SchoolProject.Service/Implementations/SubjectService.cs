using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Enums;
using SchoolProject.infrastructure.Abstracts;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Service.Implementations
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<string> AddSubject(Subject subject)
        {
            await _subjectRepository.AddAsync(subject);
            return "Success";
        }


        public async Task<string> EditSubject(Subject subject)
        {
            await _subjectRepository.UpdateAsync(subject);
            return "Success";
        }
        public async Task<string> DeleteSubject(Subject subject)
        {
            await _subjectRepository.DeleteAsync(subject);
            return "Success";
        }

        public async Task<bool> IsNameArExist(string nameAr)
        {
            return await _subjectRepository.GetTableNoTracking().AnyAsync(x => x.SubjectNameAr.Equals(nameAr));
        }

        public async Task<bool> IsNameArExistExcludeSelf(string nameAr, int id)
        {
            return await _subjectRepository.GetTableNoTracking().AnyAsync(x => x.SubjectNameAr.Equals(nameAr) && !x.SubID.Equals(id));

        }

        public async Task<bool> IsNameEnExist(string nameEn)
        {
            return await _subjectRepository.GetTableNoTracking().AnyAsync(x => x.SubjectNameEn.Equals(nameEn));
        }

        public async Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id)
        {
            return await _subjectRepository.GetTableNoTracking().AnyAsync(x => x.SubjectNameEn.Equals(nameEn) && !x.SubID.Equals(id));
        }

        public async Task<bool> IsSubjectIdExist(int id)
        {
            return await _subjectRepository.GetTableNoTracking().AnyAsync(x => x.SubID.Equals(id));
        }

        public async Task<Subject> GetSubjectById(int id)
        {
            var result = await _subjectRepository.GetTableNoTracking()
                                                                //.Include(x => x.StudentsSubjects).ThenInclude(x => x.Student)
                                                                .Include(x => x.DepartmetsSubjects).ThenInclude(x => x.Department)
                                                                .Include(x => x.Ins_Subjects).ThenInclude(x => x.Instructor).FirstOrDefaultAsync(x => x.SubID.Equals(id));
            return result;
        }

        public async Task<List<Subject>> GetSubjectListAsync()
        {
            return await _subjectRepository.GetTableNoTracking().ToListAsync();
        }

        public IQueryable<Subject> FilterSubjectPaginatedQuerable(SubjectOrderingEnum subjectOrderingEnum, string? search)
        {
            var querable = _subjectRepository.GetTableNoTracking().AsQueryable();

            if (search != null)
                querable = querable.Where(x => x.SubjectNameAr.Contains(search) || x.SubjectNameEn.Contains(search) || x.Period.Equals(search) || x.Period.Equals(search));
            switch (subjectOrderingEnum)
            {
                case SubjectOrderingEnum.ID:
                    querable = querable.OrderBy(x => x.SubID);
                    break;
                case SubjectOrderingEnum.Name:
                    querable = querable.OrderBy(x => x.SubjectNameEn);
                    break;
                case SubjectOrderingEnum.Period:
                    querable = querable.OrderBy(x => x.Period);
                    break;

            }
            return querable;
        }

        public async Task<bool> IsIdExist(int id)
        {
            return await _subjectRepository.GetTableNoTracking().AnyAsync(x => x.SubID.Equals(id));
        }
    }
}
