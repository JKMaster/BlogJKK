using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcApplication1.Models
{
    public class Komentarze
    {
        public int ID { get; set; }
        public int id_posta { get; set; }
        [Required(ErrorMessage="To pole nie może pozostać puste")]
        [StringLength(404,ErrorMessage="Za długie.")]
        public string tresc { get; set; }
        [Required(ErrorMessage = "Podpisz się")]
        [StringLength(20, ErrorMessage = "Za długie.")]
        public string autor { get; set; }
        public DateTime data_dodania { get; set; }
        public int status { get; set; }
    }

    public interface IKomentarze
    {
        IEnumerable<komentarz> WyswietlKomentarze(int i);
        void DodajKomentarz(int id, Komentarze k);
    }

    public class KomentarzeUslugi : IKomentarze
    {
        LinqBlogDataContext dp = new LinqBlogDataContext();

        public IEnumerable<komentarz> WyswietlKomentarze(int id)
        {
            using (dp)
            {
                return (from k in dp.komentarzs where k.id_posta == id orderby k.ID descending select k).ToList<komentarz>();
            }
        }

        public void DodajKomentarz(int id, Komentarze new_komentarz)
        {
            using (dp)
            {
                var k = new komentarz();
                k.id_posta = id;
                k.tresc = new_komentarz.tresc;
                k.autor = new_komentarz.autor;
                k.data_dodania = DateTime.Now;
                k.status = 1;
                dp.komentarzs.InsertOnSubmit(k);
                dp.SubmitChanges();
            }
        }
    }
}