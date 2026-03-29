using Microsoft.EntityFrameworkCore;
using Project.app._bdd_backend;
using Project.app_logic._bdd_backend;



public class Program
{

    public static void Main()
    {

        runNormal(new string[] { });
        //agregarAdatos();
    }

    public static void runNormal(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddRazorPages();


        builder.Services.AddDbContext<ProgramBddContext>(options =>
            //esto es la inyeccion de dependencia .
            options.UseSqlServer(builder.Configuration.GetConnectionString("programBdd"))
        );



        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();

        app.MapRazorPages()
        .WithStaticAssets();

        app.Run();


    }

    
    public static void agregarAdatos()
    {
        ProgramBddContext context = new ProgramBddContext();
        Media_bdd repo = new Media_bdd(context);

            //Media m = new Media();
            
            //repo.Add(m);

        

    }
}


