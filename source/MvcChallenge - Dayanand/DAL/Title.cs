//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Title
    {
        public Title()
        {
            this.Awards = new HashSet<Award>();
            this.OtherNames = new HashSet<OtherName>();
            this.StoryLines = new HashSet<StoryLine>();
            this.TitleGenres = new HashSet<TitleGenre>();
            this.TitleParticipants = new HashSet<TitleParticipant>();
        }
    
        public int TitleId { get; set; }
        public string TitleName { get; set; }
        public string TitleNameSortable { get; set; }
        public Nullable<int> TitleTypeId { get; set; }
        public Nullable<int> ReleaseYear { get; set; }
        public Nullable<System.DateTime> ProcessedDateTimeUTC { get; set; }
    
        public virtual ICollection<Award> Awards { get; set; }
        public virtual ICollection<OtherName> OtherNames { get; set; }
        public virtual ICollection<StoryLine> StoryLines { get; set; }
        public virtual ICollection<TitleGenre> TitleGenres { get; set; }
        public virtual ICollection<TitleParticipant> TitleParticipants { get; set; }
    }
}
