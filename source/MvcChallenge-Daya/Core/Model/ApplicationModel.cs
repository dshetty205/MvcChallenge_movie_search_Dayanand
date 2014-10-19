using System;
using System.Collections.Generic;

namespace Core.Model
{
    public class TitleDetails
    {
        public string TitleName { get; set; }
        public int? ReleaseYear { get; set; }
        public DateTime? ProcessedDateTimeUTC { get; set; }
        public IEnumerable<string> GenreName { get; set; }
        public IEnumerable<PaticipantsValue> ParticipantsList { get; set; }
        public IEnumerable<AwardsValue> AwardsList { get; set; }
        public IEnumerable<StoryLinesValue> StoryLinesList { get; set; }

    }

    public class AwardsValue
    {
        public string Award1 { get; set; }
        public string AwardCompany { get; set; }
        public int? AwardYear { get; set; }
    }

    public class PaticipantsValue
    {
        public string RoleType { get; set; }
        public string Name { get; set; }
    }

    public class StoryLinesValue
    {
        public string Type { get; set; }
        public string Description { get; set; }
    }
    public class TitleSearch
    {
        public int TitleId { get; set; }
        public string TitleName { get; set; }
    }
}