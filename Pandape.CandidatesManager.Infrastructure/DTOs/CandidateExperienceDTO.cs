namespace Pandape.CandidatesManager.Infrastructure.DTOs
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CandidateExperienceDTO
    {
        [Key]
        public int IdCandidateExperience { get; set; }
        public string Company { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? ModifyDate { get; set; }

        [ForeignKey("Candidate")]
        public int IdCandidate { get; set; }
        public virtual CandidateDTO Candidate { get; set; }
    }
}
