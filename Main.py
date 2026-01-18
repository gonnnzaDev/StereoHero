from PyQt5.QtWidgets import QApplication
import Interfaz as it
import sys as s



def main():
    iniciarVentana()



def iniciarVentana():
    app = QApplication(s.argv)
    v = it.Interfaz()
    v.show()
    s.exit(app.exec_())



if __name__ == '__main__':
    main()




