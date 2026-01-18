from symtable import Class

class Biblioteca:
    canciones = []

    def sumarCancion(self, cancion):
        return self.canciones.__add__(cancion)

    def eliminarCancion(self, cancion):
        return self.canciones.remove(cancion)

    def getcanciones(self): return self.canciones

    def buscarCancion(self, nommbre):
        if self.canciones.__contains__(nommbre):
            return True
        else:
            return False

