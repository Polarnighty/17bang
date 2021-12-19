using BLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entites;
using Global;

namespace DbFactory
{
    class KeywordFactory
    {
        private KeywordRepository KeywordRepository;
        public KeywordFactory(SqlContext context)
        {
            KeywordRepository = new KeywordRepository(context);
        }
        public void Create()
        {
            var Keywords = new List<Keyword>();
            var Tool = new Keyword { Level = 1, Content = "工具软件",Keywords=new List<Keyword>() };
            var DevLanguage = new Keyword { Level = 1, Content = "编程语言", Keywords = new List<Keyword>() };
            Keywords.Add(Tool);
            Keywords.Add(DevLanguage);
            Tool.Keywords.Add(new Keyword { Level = 2, Content = "VisualStudio" });
            Tool.Keywords.Add(new Keyword { Level = 2, Content = "eclipse" });
            Tool.Keywords.Add(new Keyword { Level = 2, Content = "IDEA" });
            Tool.Keywords.Add(new Keyword { Level = 2, Content = "Excel" });
            Tool.Keywords.Add(new Keyword { Level = 2, Content = "Word" });
            Tool.Keywords.Add(new Keyword { Level = 2, Content = "CAD" });
            Tool.Keywords.Add(new Keyword { Level = 2, Content = "Photoshop" });
            Tool.Keywords.Add(new Keyword { Level = 2, Content = "PowerPoint" });
            DevLanguage.Keywords.Add(new Keyword { Level = 2, Content = "C#" });
            DevLanguage.Keywords.Add(new Keyword { Level = 2, Content = "JAVA" });
            DevLanguage.Keywords.Add(new Keyword { Level = 2, Content = "Javascript" });
            DevLanguage.Keywords.Add(new Keyword { Level = 2, Content = "html" });
            DevLanguage.Keywords.Add(new Keyword { Level = 2, Content = "Python" });
            DevLanguage.Keywords.Add(new Keyword { Level = 2, Content = "SQL" });
            DevLanguage.Keywords.Add(new Keyword { Level = 2, Content = "CSS" });
            DevLanguage.Keywords.Add(new Keyword { Level = 2, Content = "PHP" });
            DevLanguage.Keywords.Add(new Keyword { Level = 2, Content = "C++" });
            DevLanguage.Keywords.Add(new Keyword { Level = 2, Content = "C" });
            
            KeywordRepository.RangeSave(Keywords);
        }
    }
}
