using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccessLayer
{
    public static class NewsDAL
    {
        public static List<news> GetAllNews()
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                return DbContext.news.ToList();
            }
        }
        public static news GetNewsById(string newsId)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                return DbContext.news.Where(p => p.id_news == newsId).FirstOrDefault();
            }
        }
        public static bool CreateNewNews(news news)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                bool status;
                try
                {
                    DbContext.news.Add(news);
                    DbContext.SaveChanges();
                    status = true;
                }
                catch (Exception)
                {
                    status = false;
                }
                return status;
            }
        }
        public static bool UpdateNews(news us)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                bool status;
                try
                {
                    news checkNews = DbContext.news.Where(p => p.id_news == us.id_news).FirstOrDefault();
                    if (checkNews != null)
                    {
                        checkNews.id_news = us.id_news;
                        checkNews.header_name = us.header_name;
                        checkNews.user_id = us.user_id;
                        checkNews.contents = us.contents;
                        DbContext.SaveChanges();
                    }
                    status = true;
                }
                catch (Exception)
                {
                    status = false;
                }
                return status;
            }
        }
        public static bool DeleteNews(string id)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                bool status;
                try
                {
                    news checkNews = DbContext.news.Where(p => p.id_news == id).FirstOrDefault();
                    if (checkNews != null)
                    {
                        DbContext.news.Remove(checkNews);
                        DbContext.SaveChanges();
                    }
                    status = true;
                }
                catch (Exception)
                {
                    status = false;
                }
                return status;
            }
        }
    }
}
