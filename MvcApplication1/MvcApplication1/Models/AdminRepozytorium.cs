using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MvcApplication1.Models
{
        public class Klasa
        {
            public int ID { get; set; }
            [StringLength(156,ErrorMessage="Za długi")]
            public string tytul { get; set; }
            public string tresc { get; set; }
            [Range(0,1,ErrorMessage="Wartość 0-1")]
            public int status { get; set; }
            public DateTime data_dodania { get; set; }
            public DateTime data_modyfikacji { get; set; }

            [StringLength(50, ErrorMessage = "Za długi")]
            public string keywords { get; set; }
            [StringLength(50, ErrorMessage = "Za długi")]
            public string description { get; set; }
        }

        public interface IAdminRepozytorium
        {
            IEnumerable<post> WyswietlPosty();
            List<post> WyswietlPoDacie(int id);
            List<post> WyswietlPoTagach(string slowo);
            post WyswietlPostPoID(int id);
            void DodajPost(Klasa new_post);
            post EdytujPost(int id);
            void EdytujPost(post new_post);
        }

        public class AdminUslugi : IAdminRepozytorium
        {
            public IEnumerable<post> WyswietlPosty()
            {
                using (LinqBlogDataContext dp = new LinqBlogDataContext())
                {
                    return (from p in dp.posts where p.status == 1 && p.data_dodania.Month == DateTime.Now.Month orderby p.ID descending select p).ToList<post>();
                }
            }

            public List<post> WyswietlPoDacie(int id)
            {
                using (LinqBlogDataContext dp = new LinqBlogDataContext())
                {
                    var PostyPoDacie = from p in dp.posts where p.data_dodania.Month == id select p;
                    return PostyPoDacie.ToList<post>();
                }

            }

            public List<post> WyswietlPoTagach(string slowo)
            {
                using (LinqBlogDataContext dp = new LinqBlogDataContext())
                {
                    var PostyPoSlowie = from p in dp.posts where p.tagi.keywords == slowo select p;
                    return PostyPoSlowie.ToList<post>();
                }

            }

            public List<post> WyswietlTytul(string slowo)
            {
                using (LinqBlogDataContext dp = new LinqBlogDataContext())
                {
                    var PostyT = from p in dp.posts where p.tytul == slowo select p;
                    return PostyT.ToList<post>();
                }

            }

            public post WyswietlPostPoID(int id)
            {
                using(LinqBlogDataContext dp = new LinqBlogDataContext())
                {
                    return dp.posts.Single(p => p.ID == id);
                }
            }

            public void DodajPost(Klasa new_post) 
            {
                using (LinqBlogDataContext dp = new LinqBlogDataContext())
                {
                    var p = new post();
                    p.tytul = new_post.tytul;
                    p.tresc = new_post.tresc;
                    p.status = new_post.status;
                    p.data_dodania = DateTime.Now;
                    dp.posts.InsertOnSubmit(p);
                    dp.SubmitChanges();

                    var t = new tagi();
                    t.id_posta = p.ID;
                    t.keywords = new_post.keywords;
                    t.description = new_post.description;
                    dp.tagis.InsertOnSubmit(t);
                    dp.SubmitChanges();
                    
                }
            }

            public void EdytujPost(post new_post)
            {
                using (LinqBlogDataContext dp = new LinqBlogDataContext())
                {
                    var e = dp.posts.Single(x => x.ID == new_post.ID);
                    e.tytul = new_post.tytul;
                    e.tresc = new_post.tresc;
                    e.status = new_post.status;
                    e.data_modyfikacji = DateTime.Now;
                    dp.SubmitChanges();
                }
            }

            public post EdytujPost(int id)
            {
                using (LinqBlogDataContext dp = new LinqBlogDataContext())
                {
                    try
                    {
                        return dp.posts.Single(p => p.ID == id);
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
        }
}