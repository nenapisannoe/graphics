from graphics import *
import math



def main():
    # Make graphics window

    a = 0
    b = 250


    win = GraphWin('Target',b-a,b-a)
    win.setCoords(-(b-a/2), -(b-a/2), (b-a/2), (b-a/2))

    #l1 = Line(Point(0,0), Point(500,500))
    #l1.draw(win)

    a = 0
    b = 250
    n = 10

    for x in range(-250, 250-n, n):
        l1 = Line(Point(x, x**2), Point(x+n, (x+n)**2))
        l1.draw(win)


    win.getMouse()
    win.close()





main()