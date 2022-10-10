namespace Pandape.CandidatesManager.Services.Mapping
{
    using AutoMapper;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Domain.Entities.Candidate, Infrastructure.DTOs.CandidateDTO>()
                .ForPath(entity => entity.IdCandidate, opt => opt.MapFrom(response => response.IdCandidate))
                .ForPath(entity => entity.Name, opt => opt.MapFrom(response => response.Name))
                .ForPath(entity => entity.Surename, opt => opt.MapFrom(response => response.Surename))
                .ForPath(entity => entity.Email, opt => opt.MapFrom(response => response.Email))
                .ForPath(entity => entity.Birthdate, opt => opt.MapFrom(response => response.Birthdate))
                .ForPath(entity => entity.InsertDate, opt => opt.MapFrom(response => response.InsertDate))
                .ForPath(entity => entity.ModifyDate, opt => opt.MapFrom(response => response.ModifyDate))
                .ForPath(entity => entity.Experiences, opt => opt.MapFrom(response => response.Experiences));

            this.CreateMap<Infrastructure.DTOs.CandidateDTO, Domain.Entities.Candidate>()
                .ForPath(entity => entity.IdCandidate, opt => opt.MapFrom(response => response.IdCandidate))
                .ForPath(entity => entity.Name, opt => opt.MapFrom(response => response.Name))
                .ForPath(entity => entity.Surename, opt => opt.MapFrom(response => response.Surename))
                .ForPath(entity => entity.Email, opt => opt.MapFrom(response => response.Email))
                .ForPath(entity => entity.Birthdate, opt => opt.MapFrom(response => response.Birthdate))
                .ForPath(entity => entity.InsertDate, opt => opt.MapFrom(response => response.InsertDate))
                .ForPath(entity => entity.ModifyDate, opt => opt.MapFrom(response => response.ModifyDate))
                .ForPath(entity => entity.Experiences, opt => opt.MapFrom(response => response.Experiences));

            this.CreateMap<Domain.Entities.CandidateExperience, Infrastructure.DTOs.CandidateExperienceDTO>()
                .ForPath(entity => entity.IdCandidateExperience, opt => opt.MapFrom(response => response.IdCandidateExperience))
                .ForPath(entity => entity.IdCandidate, opt => opt.MapFrom(response => response.IdCandidate))
                .ForPath(entity => entity.Company, opt => opt.MapFrom(response => response.Company))
                .ForPath(entity => entity.Job, opt => opt.MapFrom(response => response.Job))
                .ForPath(entity => entity.Description, opt => opt.MapFrom(response => response.Description))
                .ForPath(entity => entity.BeginDate, opt => opt.MapFrom(response => response.BeginDate))
                .ForPath(entity => entity.EndDate, opt => opt.MapFrom(response => response.EndDate))
                .ForPath(entity => entity.Salary, opt => opt.MapFrom(response => response.Salary))
                .ForPath(entity => entity.InsertDate, opt => opt.MapFrom(response => response.InsertDate))
                .ForPath(entity => entity.ModifyDate, opt => opt.MapFrom(response => response.ModifyDate));

            this.CreateMap<Infrastructure.DTOs.CandidateExperienceDTO, Domain.Entities.CandidateExperience>()
                .ForPath(entity => entity.IdCandidateExperience, opt => opt.MapFrom(response => response.IdCandidateExperience))
                .ForPath(entity => entity.IdCandidate, opt => opt.MapFrom(response => response.IdCandidate))
                .ForPath(entity => entity.Company, opt => opt.MapFrom(response => response.Company))
                .ForPath(entity => entity.Job, opt => opt.MapFrom(response => response.Job))
                .ForPath(entity => entity.Description, opt => opt.MapFrom(response => response.Description))
                .ForPath(entity => entity.BeginDate, opt => opt.MapFrom(response => response.BeginDate))
                .ForPath(entity => entity.EndDate, opt => opt.MapFrom(response => response.EndDate))
                .ForPath(entity => entity.Salary, opt => opt.MapFrom(response => response.Salary))
                .ForPath(entity => entity.InsertDate, opt => opt.MapFrom(response => response.InsertDate))
                .ForPath(entity => entity.ModifyDate, opt => opt.MapFrom(response => response.ModifyDate));
        }
    }
}
