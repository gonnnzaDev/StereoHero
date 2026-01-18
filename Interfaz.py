
from PyQt5.QtCore import QTimer
from PyQt5.QtGui import QColor, QPainter, QLinearGradient, QIcon, QImage
from PyQt5.QtMultimedia import QMediaPlayerControl
from PyQt5.QtWidgets import QMainWindow, QPushButton, QVBoxLayout, QWidget, QApplication, QHBoxLayout, QLabel



class Interfaz(QMainWindow):
    temaInterfaz = False

    def __init__(self):
        super().__init__()

        self.reproduciendo = False
        self.playAndPause = QPushButton()

        x = 625
        y = 350

        self.setWindowTitle("StereoHero")
        self.setMinimumSize(x, y)
        self.setMaximumSize(x * 2, y * 2)
        self.setGeometry(100, 100, x, y)
        self.cargarWidgets()
        self.fondoEnMovimiento()
        self.setWindowIcon(QIcon("resources/icon.png"))

    def cargarWidgets(self):

        # aca poner todos los widgets q quiera

        tema = QPushButton("Tema")
        tema.clicked.connect(self.cambiarTema)

        stop = QPushButton("#") ## Hacer un metodo q saque la cancion al toque

        self.playAndPause = QPushButton(">")

        self.playAndPause.clicked.connect(self.reproducir)

        widgets = [self.playAndPause, stop, tema]

        self.mostrarWidgets(widgets)

    def reproducir(self):
        if self.reproduciendo:
            self.playAndPause.setText(">")
            self.reproduciendo = False
        else:
            self.playAndPause.setText("||")
            self.reproduciendo = True
        self.update()

    def mostrarWidgets(self, widgets):
        central = QWidget(self)
        self.setCentralWidget(central)

        lV = QVBoxLayout(central)
        lV.addStretch()
        lH = QHBoxLayout()

        for widget in widgets:
            lH.addWidget(widget)

        lH.addStretch()
        lV.addLayout(lH)

    def fondoEnMovimiento(self):
        self.offset = 0
        self.timer = QTimer(self)
        self.timer.timeout.connect(self.animar)

        self.timer.start(50)

    def animar(self):
        self.offset += 2
        if self.offset > self.width():
            self.offset = 0
        self.update()

    def paintEvent(self, event):
        painter = QPainter(self)

        gradiente = QLinearGradient(
            self.offset, self.offset,
            self.offset + self.width(), self.offset + self.height()
        )

        if self.temaInterfaz:
            for p in range(5):
                x = 0.25 * p
                y = min(255, int((x * 100) + 10))
                gradiente.setColorAt(x, QColor(y, y, y))

        else:
            for p in range(5):
                x = 0.25 * p
                y = min(255, int((x * 100) + 100))
                gradiente.setColorAt(x, QColor(y, y, y))

        painter.fillRect(self.rect(), gradiente)

    def cambiarTema(self):
        if self.temaInterfaz:
            self.temaInterfaz = False
        else:
            self.temaInterfaz = True

    def lineaDeTiempo(self):
        return 0 # hacer linea de tiempo

    def mostrarImagen(self):
        return 0 # mostrar la imagen

    def biblioteca(self):
        return 0 # ultimoHacerUnaBibliotecaDeCancionesSubidas
