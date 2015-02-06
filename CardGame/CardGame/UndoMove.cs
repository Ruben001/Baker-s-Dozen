/*
    Software Engineering Group 4
    Ruben Munive
    James Vice
    Luis Govea
    Jason Denmon
    Brandon Odum
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CardGame
{
    class UndoMove 
    {
        
        Stack<PictureBox> lastPictureBox = new Stack<PictureBox>();
        Stack<int> beforeMoveColumn = new Stack<int>();
        Stack<int> afterMoveColumn = new Stack<int>();
        Stack<int> lastTopNumber = new Stack<int>();
        Stack<int> lastLeftNumber = new Stack<int>();

        public void addBeforeMove(PictureBox pictureBoxX, int topNumber, int leftNumber,int beforeMove)
        {
            
            lastPictureBox.Push(pictureBoxX);
            lastTopNumber.Push(topNumber);
            lastLeftNumber.Push(leftNumber);

            beforeMoveColumn.Push(beforeMove);
            
            
        }

        public void addAfterMove(int afterMove)
        {
            afterMoveColumn.Push(afterMove);
        }

        public void undoLast()
        {
            if (lastPictureBox.Count != 0)
            {
                lastPictureBox.Peek().Location = new System.Drawing.Point(lastLeftNumber.Pop(), lastTopNumber.Pop());
                lastPictureBox.Peek().BringToFront();
                lastPictureBox.Pop();
            }

        }

        public int undoPop()
        {
            int y = 0;
            if (afterMoveColumn.Count != 0)
            {
                y =  afterMoveColumn.Pop();
            }
            return y;

        }

        public int ColumnNumber()
        {
            int y = 0;
            if (beforeMoveColumn.Count != 0)
            {
                y = beforeMoveColumn.Pop();
            }
            return y;
        }

        public string cardString()
        {
            string y = "";
            if (lastPictureBox.Count != 0)
            {
                y = lastPictureBox.Peek().AccessibleName;
            }
            return y;
        }

        
         
    }
}
