from PyQt5.QtWidgets import QApplication
import Interfaz as i
import sys as s

def main():
    iniciarVentana()

def iniciarVentana():
    app = QApplication(s.argv)
    v = i.Interfaz()
    v.show()
    s.exit(app.exec_())


if __name__ == '__main__':
    main()