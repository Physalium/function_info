from matplotlib import pyplot as plt
import numpy as np
import numexpr as ne
import sys
import os
currentDir = os.path.dirname(os.path.realpath(__file__))
def graph(formula:str, leftBound,rightBound):
    if formula=="test":  
        test_file=open(currentDir+"\Test.txt",mode='w+')
        test_file.write("test")
        return
    
    x = np.array(range(int(leftBound),int(rightBound)+1))  
    y = ne.evaluate(formula)
    plt.plot(x, y)
    plt.xlabel(x)
    plt.ylabel(formula)
    plt.savefig('graph.png')

if __name__ == "__main__":
    if(len(sys.argv)==4):
        graph(sys.argv[1],sys.argv[2],sys.argv[3])