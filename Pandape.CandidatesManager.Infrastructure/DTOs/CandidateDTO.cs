namespace Pandape.CandidatesManager.Infrastructure.DTOs
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CandidateDTO
    {
        [Key]
        public int IdCandidate { get; set; }
        public string Name { get; set; }
        public string Surename { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public List<CandidateExperienceDTO> Experiences { get; set; }
    }
}
