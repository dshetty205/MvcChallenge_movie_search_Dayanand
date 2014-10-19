using System.Collections.Generic;
using System.Linq;
using Core.Model;
using Core.Repositories;

namespace DAL
{
    public class TitlesRepositoryImplementation : ITitleRepository
    {
        #region Methods
        /// <summary>
        /// Titles data for typeahead jquery call
        /// </summary>
        /// <returns></returns>
        public List<TitleSearch> GetTitlesData()
        {
            using (var dbEntities = new TitlesEntities())
            {
                var sr = from p in dbEntities.Titles
                    select new TitleSearch
                    {
                        TitleId = p.TitleId,
                        TitleName = p.TitleName
                    };
                return sr.ToList();
            }
        }

        /// <summary>
        /// Get particular title details 
        /// </summary>
        /// <param name="titleId"></param>
        /// <returns></returns>
        public TitleDetails GetTitleDetails(int titleId)
        {
            using (var dbEntities = new TitlesEntities())
            {
                var plist = new[] {"Director", "Producers", "Actor"};
                var rm = dbEntities.Titles.AsQueryable().Where(t => t.TitleId == titleId)
                    .Select(s => new TitleDetails
                    {
                        TitleName = s.TitleName,
                        ReleaseYear = s.ReleaseYear,
                        ProcessedDateTimeUTC = s.ProcessedDateTimeUTC,
                        GenreName = s.TitleGenres.Select(tg => tg.Genre.Name),
                        ParticipantsList =
                            s.TitleParticipants.Where(p => plist.Contains(p.RoleType))
                                .Select(sp => new PaticipantsValue {RoleType = sp.RoleType, Name = sp.Participant.Name}),
                        AwardsList =
                            s.Awards.Where(a => a.AwardWon == true)
                                .Select(
                                    sa =>
                                        new AwardsValue
                                        {
                                            Award1 = sa.Award1,
                                            AwardCompany = sa.AwardCompany,
                                            AwardYear = sa.AwardYear
                                        }),
                        StoryLinesList =
                            s.StoryLines.Select(i => new StoryLinesValue {Type = i.Type, Description = i.Description})
                    }).FirstOrDefault();

                return rm;
            }
        }
        #endregion
    }
}
