using Project.app_logic._bdd_backend;
using Project.app_logic.Backend.Class.Exceptions;

namespace Project.app._bdd_backend
{

    /*esta clase abstracta va a ser la encargarda
    de comunicarse con la bdd y la hago generica
    y abstracta par q sea el molde de las clases hijas
    y generica para q pueda usar cualquier tipo de dato*/

    public abstract class Abstract_bdd<T> where T : class
    {

        protected readonly ProgramBddContext _context;

        /*aca pasamos "la bdd(el contexto)"*/

        public Abstract_bdd(ProgramBddContext context)
        {
            _context = context;
        }

        /*realizamos todas las operaciones con la bdd
         como agregar, hacer una lista, buscar , remover, y bueno actulizar
        realizamos un crud pero con */

        public T Add(T t)
        {
            _context.Set<T>().Add(t);
            _context.SaveChanges();
            return t;
        }

        /*con el .set<T> vamos a dejar setear la lista 
          * con el tipo de dato correspondiente*/

        public List<T> ToList()
        {

            return _context.Set<T>().ToList();
        }

        public T Search(string t)
        {

            var search = _context.Set<T>().Find(t);
            if (search == null)
            {
                throw new LogicException("No se encontró el objeto");
            }
            return search;


        }
        public void remove(int id)
        {
            var c = _context.Set<T>().Find(id);
            if (c != null)
            {
                _context.Set<T>().Remove(c);
                _context.SaveChanges();
            }
        }

        public void Update(T p)
        {
            _context.Set<T>().Update(p);
            _context.SaveChanges();
        }

    }
}
