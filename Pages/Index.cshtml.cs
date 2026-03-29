using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.app._bdd_backend;
using Project.app_logic._bdd_backend;
using Project.app_logic.Backend.MercadoPagoApi;

namespace Project.Pages
{

    //esto me permite mostrar Los productos
    public class IndexModel : PageModel
    {

        public List<_MediaView> Products { get; private set; } = new List<_MediaView>();

        public async Task OnGetAsync()
        {
            ProgramBddContext context = new ProgramBddContext();
            Media_bdd repo = new Media_bdd(context);
            var mediaList = repo.ToList();
            Products = new List<_MediaView>();

            //cargo los products en la lista de los ProductView para poder mostrarlos con el boton

            foreach (var p in mediaList)
            {
                var initPoint = await MercadoPagoAPi.createObjectRequestAsync(p);
                Products.Add(new _MediaView
                {
                    id = p.id,
                    description = p.description,
                    name = p.name,
                    produceBy = p.produceBy,
                    price = p.price,
                    image = p.image,
                    InitPoint = initPoint // esta lista pasa al index con el producto + elinitpoint o url de pago
                });
            }
        }
    }
}
