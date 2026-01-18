
class Cancion:
    nombre = "Desconocido"
    artista = "Desconocido"
    duracion = 0
    direccion = "0"
    imagen = "\resources\no-img.jpeg"

    def __init__(self, nombre, artista, autor, duracion, direccion, imagen):
        self.nombre = nombre
        self.dir    =  direccion
        self.artista = artista
        self.autor = autor
        self.duracion = duracion
        self.imagen = imagen

    @staticmethod
    def descargarCancion(urlCancion):
        return 0