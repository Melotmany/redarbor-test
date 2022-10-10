namespace Pandape.CandidatesManager.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public class Candidate
    {
        public int IdCandidate { get; set; }
        public string Name { get; set; }
        public string Surename { get; set; }
        public DateTime Birthdate { get;set; }
        public string Email { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public List<CandidateExperience> Experiences { get; set; }



    }
}
