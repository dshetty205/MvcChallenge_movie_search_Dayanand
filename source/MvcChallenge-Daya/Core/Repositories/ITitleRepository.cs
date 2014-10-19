using System.Collections.Generic;
using Core.Model;

namespace Core.Repositories
{
    public interface ITitleRepository
    {
        List<TitleSearch> GetTitlesData();
        TitleDetails GetTitleDetails(int titleId);
    }
}
