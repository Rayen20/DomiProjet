using Service.Pattern;
using Solution.Data.Infrastructure;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
    public class FichierService : Service<Fichier>, IFichierService
    {
        static IDataBaseFactory factory = new DataBaseFactory();
        static IUnitOfWork utk = new UnitOfWork(factory);
        public FichierService():base(utk)
        {

        }
      

      /*  public IEnumerable<Fichier> GetFilmsByTitle(string title)
        {
            return GetMany(f=>f.Title.Contains(title));
        }*/
    }
}
