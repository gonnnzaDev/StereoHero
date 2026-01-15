import random

from PyQt5.QtCore import QTimer
from PyQt5.QtGui import QColor, QPainter, QLinearGradient, QIcon
from PyQt5.QtWidgets import QMainWindow, QPushButton, QVBoxLayout, QWidget, QApplication, QHBoxLayout


class Interfaz(QMainWindow):
    temaInterfaz = 0
    color = 0  # esto permite poner un numero random para poner un color rgb como fondo :v

    def __init__(self):
        super().__init__()

        x = 625
        y = 350

        self.setWindowTitle("StereoHero")
        self.setMinimumSize(x, y)
        self.setMaximumSize(x * 2, y * 2)
        self.setGeometry(100, 100, x, y)
        self.cargarWidgets()
        self.fondoEnMovimiento()
        self.setWindowIcon(QIcon("resources\icon.jpg"))

    def cargarWidgets(self):

        # aca poner todos los widgets q quiera

        play = QPushButton(">")
        pause = QPushButton("||")
        stop = QPushButton("#")
        tema = QPushButton("Tema")

        tema.clicked.connect(self.cambiarTema)

        widgets = [play, pause,stop, tema]
        self.mostrarWidgets(widgets)

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

        if self.temaInterfaz == 0:
            for p in range(5):
                x = 0.25 * p
                y = min(255, int((x * 100) + 10))
                gradiente.setColorAt(x, QColor(y, y, y))
        elif self.temaInterfaz == 1:
            for p in range(5):
                x = 0.25 * p
                y = min(255, int((x * 100) + 100))
                gradiente.setColorAt(x, QColor(y, y, y))

        elif self.temaInterfaz == 2:
            intensidad = 180

            if self.color == 1:  # rojo
                c1 = QColor(255, 80, 80)
                c2 = QColor(intensidad, 0, 0)
            elif self.color == 2:  # azul
                c1 = QColor(80, 80, 255)
                c2 = QColor(0, 0, intensidad)
            else:  # verde
                c1 = QColor(0, intensidad, 0)
                c2 = QColor(80, 255, 80)

            gradiente.setColorAt(0.0, c1)
            gradiente.setColorAt(1.0, c2)
        painter.fillRect(self.rect(), gradiente)

    def cambiarTema(self):
        self.temaInterfaz = (self.temaInterfaz + 1) % 3
        self.color = random.randint(1, 3)
        self.update()