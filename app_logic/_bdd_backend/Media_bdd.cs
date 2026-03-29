using Project.app_logic._bdd_backend;

/*exitendo de la padre para poder usar sus metodos y atributos*/

namespace Project.app._bdd_backend
{
    public class Media_bdd : Abstract_bdd<Media>
    {
        public Media_bdd(ProgramBddContext context) : base(context)
        {
        }
    }
}

