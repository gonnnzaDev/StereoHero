using Project.app_logic.Backend.Class.Exceptions;
using System;

public class Media
{

    public int id { get; set; }
    public required string name { get; set; } = "";
    public required string description { get; set; } = "";
    public required double price { get; set; } = 0;
    public required string produceBy { get; set; } = "";
    public required string image { get; set; } = "";


    public Media(string name, string description, double price, string produceBy, string image)
    {
        if (name == null || price < 0)
        {
            throw new LogicException("Ocurrio un error");

        }
        this.name = name;
        this.description = description;
        this.price = price;
        this.produceBy = produceBy;
        this.image = image;
    }

    public Media()
    {
    }






}