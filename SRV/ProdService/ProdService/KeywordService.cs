using BLL.Entites;
using BLL.Repositories;
using SRV.ViewModel;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SRV.ProdService
{
    public class KeywordService :BaseService
    {
        private KeywordRepository keywordRepository;

        public KeywordService()
        {
            keywordRepository = new KeywordRepository(context);
        }

        public void SaveKeywords<T>(T t, string keywords)
        {
            var Keywords = new List<Keyword>();
            if (keywords != null)
            {
                var keyword = Regex.Split(keywords, "\\s+");
                for (int i = 0; i < keyword.Length; i++)
                {
                    Keywords.Add(new Keyword { Content = keyword[i] });
                }
            }
            keywordRepository.SaveKeywords(t, Keywords);
        }
    }
}
