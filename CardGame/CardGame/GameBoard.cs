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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;


namespace CardGame
{
    
    
    public partial class GameBoard : Form
    {

        //Used for Undo. Last location of card
        int cardTopLocation = 0;
        int cardLeftLocation = 0;
        int numberOfUndos = 0;

        //Should the time freeze?
        bool freezeTimer = false;

        int score = 0;

        UndoMove undoMove = new UndoMove();

        //Timer variables
        int sec = 1;
        int min = 0;
        bool startTimer = false;

        int counter = 0;
        Deck deck = new Deck();
        
        //Stacks of column Strings
        
        Stack<string> column1 = new Stack<string>();
        Stack<string> column2 = new Stack<string>();
        Stack<string> column3 = new Stack<string>();
        Stack<string> column4 = new Stack<string>();
        Stack<string> column5 = new Stack<string>();
        Stack<string> column6 = new Stack<string>();
        Stack<string> column7 = new Stack<string>();
        Stack<string> column8 = new Stack<string>();
        Stack<string> column9 = new Stack<string>();
        Stack<string> column10 = new Stack<string>();
        Stack<string> column11 = new Stack<string>();
        Stack<string> column12 = new Stack<string>();
        Stack<string> column13 = new Stack<string>();

        //Stacks of foundation Strings
        Stack<string> foundation1 = new Stack<string>();
        Stack<string> foundation2 = new Stack<string>();
        Stack<string> foundation3 = new Stack<string>();
        Stack<string> foundation4 = new Stack<string>();

        

        //
        //
        //
        //THE START OF PICTUR BOX DRAG DROP
        private bool pb_mouseIsDown;
        private int oX = 0;
        private int oY = 0;
        private int oldCol = 0;
        public PictureBox newP = new PictureBox();

        private void Deal()
        {
            startTimer = false;
            //reset score
            score = 0;
            String scoreS = "Score: ";
            label4.Text = scoreS + Convert.ToString(score);
            
            //Clear the columns and foundations
            for (int i = 0; i < 17; i++)
            {
                Stack<String>[] col = 
                    { column1, column2, column3, column4, column5, column6 ,
                    column7,column8,column9,column10,column11,column12,column13,
                    foundation1,foundation2,foundation3,foundation4
                    };

                col[i].Clear();
            }



            freezeTimer = false;
            numberOfUndos = 0;
            min = 0;
            sec = 0;
            String time = "Timer: ";
            label2.Text = time + Convert.ToString(min) + ":" + Convert.ToString(sec);

            deck.CreateNewDeck();
            deck.shuffleDeck();
            deck.shuffleAceDeck();

            //set counter to zero
            counter = 0;

            string counterString = Convert.ToString(counter);
            label1.Text = "Moves: " + counterString;
            label3.Visible = false;
            pictureBox53.Visible = false;
            int r = 0;
            int p = 0;
            int l = 0;
            

            if (deck.getTotalCards() > 45)
            {
                PictureBox[] cards = 
            {
                pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6,pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12,
                pictureBox13, pictureBox14, pictureBox15, pictureBox16, pictureBox17, pictureBox18,pictureBox19, pictureBox20, pictureBox21, pictureBox22, pictureBox23, pictureBox24,
                pictureBox25, pictureBox26, pictureBox27, pictureBox28, pictureBox29, pictureBox30,pictureBox31, pictureBox32, pictureBox33, pictureBox34, pictureBox35, pictureBox36,
                pictureBox37, pictureBox38, pictureBox39, pictureBox40, pictureBox41, pictureBox42,pictureBox43, pictureBox44, pictureBox45, pictureBox46, pictureBox47, pictureBox48,
                pictureBox49, pictureBox50, pictureBox51, pictureBox52
            };

                Panel[] pan = 
            {
                panel1, panel2, panel3, panel4, panel5, panel6,panel7, panel8, 
                panel9, panel10, panel11, panel12, panel13
            };
                Stack<String>[] columns = 
            { column1, column2, column3, column4, column5, column6 ,
              column7,column8,column9,column10,column11,column12,column13
            };
               
                for (int w = 0; w < 4; w++)
                {
                    Card temp = deck.drawFromAceDeck();
                    cards[r].Image = temp.getImage();
                    cards[r].AccessibleName = temp.toString();
                    cards[r].Bounds = (pan[p].Bounds);
                    cards[r].BringToFront();

                    string name = temp.toString();
                    columns[p].Push(name);
                    p++;
                    r++;

                }
                for (int i = 0; i < 48; i++)
                {
                    Card temp = deck.drawFromDeck();
                    cards[r].Image = temp.getImage();
                    cards[r].AccessibleName = temp.toString();
                    string name = temp.toString();
                    columns[p].Push(name);
                    if (l == 0)
                    {

                        cards[r].Bounds = (pan[p].Bounds);
                        cards[r].BringToFront();


                    }
                    else if (l == 1)
                    {
                        cards[r].Bounds = (pan[p].Bounds);
                        cards[r].Top = cards[r].Top + 20;
                        cards[r].BringToFront();


                    }
                    else if (l == 2)
                    {
                        cards[r].Bounds = (pan[p].Bounds);
                        cards[r].Top = cards[r].Top + 40;
                        cards[r].BringToFront();


                    }
                    else if (l == 3)
                    {
                        cards[r].Bounds = (pan[p].Bounds);
                        cards[r].Top = cards[r].Top + 62;
                        cards[r].BringToFront();


                    }
                    r++;

                    if (p == 12)
                    {
                        p = 0;
                        l++;
                    }
                    else
                        p++;

                }
            }
        }

        private void RestartCurrentGame()
        {
            min = 0;
            sec = 0;

            //add to score
            score = 0;
            String scoreS = "Score: ";
            label4.Text = scoreS + Convert.ToString(score);

            PictureBox[] boxes = 
            {
                pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6,pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12,
                pictureBox13, pictureBox14, pictureBox15, pictureBox16, pictureBox17, pictureBox18,pictureBox19, pictureBox20, pictureBox21, pictureBox22, pictureBox23, pictureBox24,
                pictureBox25, pictureBox26, pictureBox27, pictureBox28, pictureBox29, pictureBox30,pictureBox31, pictureBox32, pictureBox33, pictureBox34, pictureBox35, pictureBox36,
                pictureBox37, pictureBox38, pictureBox39, pictureBox40, pictureBox41, pictureBox42,pictureBox43, pictureBox44, pictureBox45, pictureBox46, pictureBox47, pictureBox48,
                pictureBox49, pictureBox50, pictureBox51, pictureBox52
            };

            Stack<String>[] col = 
                    { column1, column2, column3, column4, column5, column6 ,
                    column7,column8,column9,column10,column11,column12,column13,
                    foundation1,foundation2,foundation3,foundation4
                    };

            for (int i = numberOfUndos; i > 0; i--)
            {
                col[undoMove.ColumnNumber()].Push(undoMove.cardString());
                col[undoMove.undoPop()].Pop();
                undoMove.undoLast();
                numberOfUndos--;
            }


        }

        
        //Method to test if you WON
        public bool DidYouWin()
        {
            
            bool didYouWin = true;
            Stack<String>[] col1 = 
            { column1, column2, column3, column4, column5, column6 ,
              column7,column8,column9,column10,column11,column12,column13
            };

            for (int y = 0; y < 13; y++)
            {
                if (col1[y].Count != 0)
                {
                    didYouWin = false;
                }
            }
            return didYouWin;

        }

        public void SelectCard(PictureBox pictureBoxX, MouseEventArgs e)
        {
            startTimer = true;
            cardTopLocation = pictureBoxX.Top;
            cardLeftLocation = pictureBoxX.Left;
            
            //Image name of this card
            string imageName = pictureBoxX.AccessibleName;
            bool doIt = false;
            //List of all the Columns witch are Stacks
            Stack<String>[] columnsAndFoundations = 
            { column1, column2, column3, column4, column5, column6 ,
              column7,column8,column9,column10,column11,column12,column13,
              foundation1,foundation2,foundation3,foundation4
            };
            //Look at all columns to see if this card is on top
            for (int n = 0; n < 17; n++)
            {
                //if Stack is not empty 
                if (columnsAndFoundations[n].Count != 0)
                {
                    //set top card to x
                    string x = columnsAndFoundations[n].Peek();

                    //compare this cards string name with top string name x
                    if (imageName.Equals(x, StringComparison.Ordinal))
                    {
                        //if this card is on top set doIt to true
                        doIt = true;
                        oldCol = n;
                        break;
                    }
                }
            }
            //if the card is on top allow move
            if (doIt)
            {
                pb_mouseIsDown = true;
                oX = e.X;
                oY = e.Y;
                //keep record of old bound
                newP.Bounds = pictureBoxX.Bounds;
            }

        }

        public void GetCard(PictureBox pictureBoxX, MouseEventArgs e)
        {
            if (pb_mouseIsDown)
            {
                pictureBoxX.BringToFront();
                pictureBoxX.Left += e.X - oX;
                pictureBoxX.Top += e.Y - oY;
            }
        }

        public void ValidateMove(PictureBox pictureBoxX, MouseEventArgs e)
        {

            
            if (pb_mouseIsDown)
            {
                PictureBox[] boxes = 
            {
                pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6,pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12,
                pictureBox13, pictureBox14, pictureBox15, pictureBox16, pictureBox17, pictureBox18,pictureBox19, pictureBox20, pictureBox21, pictureBox22, pictureBox23, pictureBox24,
                pictureBox25, pictureBox26, pictureBox27, pictureBox28, pictureBox29, pictureBox30,pictureBox31, pictureBox32, pictureBox33, pictureBox34, pictureBox35, pictureBox36,
                pictureBox37, pictureBox38, pictureBox39, pictureBox40, pictureBox41, pictureBox42,pictureBox43, pictureBox44, pictureBox45, pictureBox46, pictureBox47, pictureBox48,
                pictureBox49, pictureBox50, pictureBox51, pictureBox52
            };
                Stack<String>[] col = 
                    { column1, column2, column3, column4, column5, column6 ,
                    column7,column8,column9,column10,column11,column12,column13,
                    foundation1,foundation2,foundation3,foundation4
                    };



                //Foundation Information
                Stack<String>[] foundationStack = 
            { 
                foundation1,foundation2,foundation3,foundation4
            };
                Panel[] foundPan = 
            {
                panel14, panel15, panel16, panel17
            };
                //==========================================================


                //check if card is on a foundation
                //=======================================================================
                bool isOnFoundation = false;



                int foundationNumber = 0;
                for (int n = 0; n < 4; n++)
                {
                    if (pictureBoxX.Bounds.IntersectsWith(foundPan[n].Bounds))
                    {
                        isOnFoundation = true;
                        foundationNumber = n;
                    }
                }
                



                //=============================================================
                

                //imageName holds the Image name
                string imageName = pictureBoxX.AccessibleName;
                //Create a array to hold the imageName of the top cards
                string[] topCards = new string[17];
                //place all the top cards on the array

                for (int u = 0; u <= 16; u++)
                {
                    if (col[u].Count != 0)
                    {
                        topCards[u] = col[u].Peek();
                    }
                }
                bool secondPass = false;
                bool s = true;
                bool inter = false;
                //Copy of image name =============================================
                string firstCharOrString = "";
                string firstCharOrString2 = "";

                //convert the image name strings to two int variables
                string shouldStackThis = pictureBoxX.AccessibleName;
                string secondChar = shouldStackThis.Substring(shouldStackThis.Length - 1);
                int secondNumber = Convert.ToInt16(secondChar);
                if (shouldStackThis.Length == 3)
                {
                    firstCharOrString = shouldStackThis.Substring(1, 1);
                }
                else if (shouldStackThis.Length == 4)
                {
                    firstCharOrString = shouldStackThis.Substring(1, 2);
                }
                int firstNumber = Convert.ToInt16(firstCharOrString);
                //==================================================================

                //Put Ace on foundation
                //=========================================================
                bool aOnFoundation = true;
                string stringOnFoundation = "";
                int numberOfColumns = 12;
                if (isOnFoundation)
                {
                    if (foundationStack[foundationNumber].Count()!= 0)
                    {
                        stringOnFoundation = foundationStack[foundationNumber].Peek().Substring(1, 1);
                    }


                    if ((isOnFoundation) && (firstNumber == 0) && ("0".Equals(stringOnFoundation) != true))
                    {
                       
                       
                        undoMove.addBeforeMove(pictureBoxX, cardTopLocation,cardLeftLocation,oldCol);
                        string st = pictureBoxX.Name;
                        string ss = st.Substring(st.Length - 2);
                        int number = Convert.ToInt16(ss);
                        

                        pictureBoxX.Bounds = foundPan[foundationNumber].Bounds;
                        foundationNumber++;
                        foundationNumber = numberOfColumns + foundationNumber;
                        col[foundationNumber].Push(col[oldCol].Peek());
                        aOnFoundation = false;

                        //add to score
                        score = score + 100;
                        String scoreS = "Score: ";
                        label4.Text = scoreS + Convert.ToString(score);

                        //Place new column number into Undo Class
                        undoMove.addAfterMove(foundationNumber);
                        numberOfUndos++;
                        col[oldCol].Pop();
                        counter++;
                    }

                }
                //======================================================================


                //check if the card that this one is placed over is on top of column
                //========================================================================================
                //===========================================================================================
                if (isOnFoundation == false)
                {
                    for (int i = 0; i < 52; i++)
                    {
                        if ((boxes[i].Bounds.IntersectsWith(pictureBoxX.Bounds)) && ((
                            (boxes[i].AccessibleName.Equals(topCards[0], StringComparison.Ordinal)) ||
                            (boxes[i].AccessibleName.Equals(topCards[2], StringComparison.Ordinal)) ||
                            (boxes[i].AccessibleName.Equals(topCards[3], StringComparison.Ordinal)) ||
                            (boxes[i].AccessibleName.Equals(topCards[4], StringComparison.Ordinal)) ||
                            (boxes[i].AccessibleName.Equals(topCards[5], StringComparison.Ordinal)) ||
                            (boxes[i].AccessibleName.Equals(topCards[6], StringComparison.Ordinal)) ||
                            (boxes[i].AccessibleName.Equals(topCards[7], StringComparison.Ordinal)) ||
                            (boxes[i].AccessibleName.Equals(topCards[8], StringComparison.Ordinal)) ||
                            (boxes[i].AccessibleName.Equals(topCards[9], StringComparison.Ordinal)) ||
                            (boxes[i].AccessibleName.Equals(topCards[10], StringComparison.Ordinal)) ||
                            (boxes[i].AccessibleName.Equals(topCards[11], StringComparison.Ordinal)) ||
                            (boxes[i].AccessibleName.Equals(topCards[1], StringComparison.Ordinal)) ||
                            (boxes[i].AccessibleName.Equals(topCards[12], StringComparison.Ordinal)) ||
                            (boxes[i].AccessibleName.Equals(topCards[13], StringComparison.Ordinal)) ||
                            (boxes[i].AccessibleName.Equals(topCards[14], StringComparison.Ordinal)) ||
                            (boxes[i].AccessibleName.Equals(topCards[15], StringComparison.Ordinal)) ||
                            (boxes[i].AccessibleName.Equals(topCards[16], StringComparison.Ordinal))
                            )))
                        {

                            //If the card was not moved dont do anything
                            if ((pictureBoxX.Bounds != boxes[i].Bounds))
                            {
                                //Copy the  image name of boxes[i] and
                                //convert them to int 
                                //=================================================================
                                string shouldStackThis2 = boxes[i].AccessibleName;
                                string secondChar2 = shouldStackThis2.Substring(shouldStackThis2.Length - 1);
                                int secondNumber2 = Convert.ToInt16(secondChar2);
                                if (shouldStackThis2.Length == 3)
                                {
                                    firstCharOrString2 = shouldStackThis2.Substring(1, 1);
                                }
                                else if (shouldStackThis2.Length == 4)
                                {
                                    firstCharOrString2 = shouldStackThis2.Substring(1, 2);
                                }
                                int firstNumber2 = Convert.ToInt16(firstCharOrString2);

                                //================================================================

                                //If the card that was dropped is not one less than the one on the 
                                //column don't place this one on top
                                //Logic for column drop
                                firstNumber2--;
                                if (firstNumber != firstNumber2)
                                {
                                    secondPass = true;
                                    break;
                                }
                                //==============================================================

                                //put card on top of new column
                                //================================================================
                                //Put information about card before move in Undo Class
                                undoMove.addBeforeMove(pictureBoxX, cardTopLocation, cardLeftLocation, oldCol);

                                pictureBoxX.Bounds = boxes[i].Bounds;
                                pictureBoxX.Top = pictureBoxX.Top + 18;

                                
                                counter++;

                                s = false;
                                inter = true;
                                //Name of old top card image
                                string oldTopCard = boxes[i].AccessibleName;
                                //Look at all columns to see if this card is on top
                                for (int y = 0; y <= 12; y++)
                                {
                                    if (col[y].Count != 0)
                                    {
                                        //set top card to x
                                        string searchedCard = col[y].Peek();

                                        //compare this cards string name with top string name x
                                        if (oldTopCard.Equals(searchedCard, StringComparison.Ordinal))
                                        {
                                            //if this is the old top card of the column
                                            //push the new card to top of stack
                                            col[y].Push(imageName);
                                            //Place new Column number into Undo Class
                                            undoMove.addAfterMove(y);
                                            numberOfUndos++;
                                            //Set to true so col.pop() and break happens
                                            secondPass = true;
                                            break;
                                        }
                                    }
                                }

                                //============================================================

                            }
                            //set to false at first because the card sees its self first when 
                            //moved from right to left
                            if (secondPass)
                            {
                                //Pop card from old column
                                col[oldCol].Pop();
                                break;
                            }
                            //set to true after the first pass
                            secondPass = true;
                        }
                        else if (s == false)
                        {
                            pictureBoxX.Bounds = newP.Bounds;
                            inter = true;
                            break;
                        }
                    }
                }
                //==================================================================================================
                //==================================================================================================

                //check if the card that this one is placed over is on top of column
                //========================================================================================
                //===========================================================================================
                else if ((isOnFoundation) && (aOnFoundation))
                {
                    for (int i = 0; i < 52; i++)
                    {
                        if ((boxes[i].Bounds.IntersectsWith(pictureBoxX.Bounds)) && ((
                            (boxes[i].AccessibleName.Equals(topCards[0], StringComparison.Ordinal)) ||
                            (boxes[i].AccessibleName.Equals(topCards[2], StringComparison.Ordinal)) ||
                            (boxes[i].AccessibleName.Equals(topCards[3], StringComparison.Ordinal)) ||
                            (boxes[i].AccessibleName.Equals(topCards[4], StringComparison.Ordinal)) ||
                            (boxes[i].AccessibleName.Equals(topCards[5], StringComparison.Ordinal)) ||
                            (boxes[i].AccessibleName.Equals(topCards[6], StringComparison.Ordinal)) ||
                            (boxes[i].AccessibleName.Equals(topCards[7], StringComparison.Ordinal)) ||
                            (boxes[i].AccessibleName.Equals(topCards[8], StringComparison.Ordinal)) ||
                            (boxes[i].AccessibleName.Equals(topCards[9], StringComparison.Ordinal)) ||
                            (boxes[i].AccessibleName.Equals(topCards[10], StringComparison.Ordinal)) ||
                            (boxes[i].AccessibleName.Equals(topCards[11], StringComparison.Ordinal)) ||
                            (boxes[i].AccessibleName.Equals(topCards[1], StringComparison.Ordinal)) ||
                            (boxes[i].AccessibleName.Equals(topCards[12], StringComparison.Ordinal)) ||
                            (boxes[i].AccessibleName.Equals(topCards[13], StringComparison.Ordinal)) ||
                            (boxes[i].AccessibleName.Equals(topCards[14], StringComparison.Ordinal)) ||
                            (boxes[i].AccessibleName.Equals(topCards[15], StringComparison.Ordinal)) ||
                            (boxes[i].AccessibleName.Equals(topCards[16], StringComparison.Ordinal))
                            )))
                        {

                            //If the card was not moved dont do anything
                            if ((pictureBoxX.Bounds != boxes[i].Bounds))
                            {
                                //Copy the  image name of boxes[i] and
                                //convert them to int 
                                //=================================================================
                                string shouldStackThis2 = boxes[i].AccessibleName;
                                string secondChar2 = shouldStackThis2.Substring(shouldStackThis2.Length - 1);
                                int secondNumber2 = Convert.ToInt16(secondChar2);
                                if (shouldStackThis2.Length == 3)
                                {
                                    firstCharOrString2 = shouldStackThis2.Substring(1, 1);

                                }
                                else if (shouldStackThis2.Length == 4)
                                {
                                    firstCharOrString2 = shouldStackThis2.Substring(1, 2);
                                }
                                int firstNumber2 = Convert.ToInt16(firstCharOrString2);

                                //put card on top of foundation if it is not empty
                                //=====================================================================
                                firstNumber2++;
                                
                                if ((firstNumber != firstNumber2) || (secondNumber != secondNumber2))
                                {
                                    secondPass = true;
                                    break;
                                }
                                //===========================================================================================

                                //put card on top of new column
                                //================================================================
                                //Put information about card before move in Undo Class
                                undoMove.addBeforeMove(pictureBoxX, cardTopLocation, cardLeftLocation, oldCol);

                                pictureBoxX.Bounds = boxes[i].Bounds;
                                counter++;

                                s = false;
                                inter = true;
                                //Name of old top card image
                                string oldTopCard = boxes[i].AccessibleName;
                                //Look at all columns to see if this card is on top
                                for (int y = 0; y <= 16; y++)
                                {
                                    if (col[y].Count != 0)
                                    {
                                        //set top card to x
                                        string searchedCard = col[y].Peek();

                                        //compare this cards string name with top string name x
                                        if (oldTopCard.Equals(searchedCard, StringComparison.Ordinal))
                                        {
                                            //if this is the old top card of the column
                                            //push the new card to top of stack
                                            col[y].Push(imageName);
                                            //Place new column number into Undo class
                                            undoMove.addAfterMove(y);
                                            numberOfUndos++;

                                            //add to score
                                            score = score + 100;
                                            String scoreS = "Score: ";
                                            label4.Text = scoreS + Convert.ToString(score);

                                            //Set to true so col.pop() and break happens
                                            secondPass = true;
                                            break;
                                        }
                                    }
                                }

                                //============================================================

                            }
                            //set to false at first because the card sees its self first when 
                            //moved from right to left
                            if (secondPass)
                            {
                                //Pop card from old column
                                col[oldCol].Pop();
                                break;
                            }
                            //set to true after the first pass
                            secondPass = true;
                        }
                        else if ((s == false) && (aOnFoundation))
                        {
                            pictureBoxX.Bounds = newP.Bounds;
                            inter = true;
                            break;
                        }
                    }
                }
                //==================================================================================================
                //==================================================================================================


                // If not in bounds of another card send back to location
                if ((inter == false) && (aOnFoundation))
                {
                    for (int o = 0; o < 53; o++)
                    {
                        if ((((boxes[o].Bounds.IntersectsWith(pictureBoxX.Bounds)) && ((
                            (boxes[o].AccessibleName.Equals(topCards[0], StringComparison.Ordinal)) ||
                            (boxes[o].AccessibleName.Equals(topCards[2], StringComparison.Ordinal)) ||
                            (boxes[o].AccessibleName.Equals(topCards[3], StringComparison.Ordinal)) ||
                            (boxes[o].AccessibleName.Equals(topCards[4], StringComparison.Ordinal)) ||
                            (boxes[o].AccessibleName.Equals(topCards[5], StringComparison.Ordinal)) ||
                            (boxes[o].AccessibleName.Equals(topCards[6], StringComparison.Ordinal)) ||
                            (boxes[o].AccessibleName.Equals(topCards[7], StringComparison.Ordinal)) ||
                            (boxes[o].AccessibleName.Equals(topCards[8], StringComparison.Ordinal)) ||
                            (boxes[o].AccessibleName.Equals(topCards[9], StringComparison.Ordinal)) ||
                            (boxes[o].AccessibleName.Equals(topCards[10], StringComparison.Ordinal)) ||
                            (boxes[o].AccessibleName.Equals(topCards[11], StringComparison.Ordinal)) ||
                            (boxes[o].AccessibleName.Equals(topCards[1], StringComparison.Ordinal)) ||
                            (boxes[o].AccessibleName.Equals(topCards[12], StringComparison.Ordinal))
                            ))) == false))
                        {
                            pictureBoxX.Bounds = newP.Bounds;
                            break;
                        }

                    }
                }
            }
            //set this back to false indicating the card is no longer moving
            pb_mouseIsDown = false;
            string counterString = Convert.ToString(counter);
            label1.Text = "Moves: " + counterString;

            if (DidYouWin())
            {
                label3.Visible = true;
                pictureBox53.Visible = true;
                pictureBox53.BringToFront();
            }

        }


        public GameBoard()
        {
            InitializeComponent();
            
        
            
        }
        private void DealButton(object sender, EventArgs e)
        {
            Deal();
           
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            RestartCurrentGame();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (startTimer == true)
            {
                sec++;
                if (sec == 60)
                {
                    min++;
                    sec = 1;
                }
                int timeFreezeMin = sec;
                int timeFreezeHours = min;
                if (freezeTimer == false)
                {

                    String time = "Timer: ";
                    label2.Text = time + Convert.ToString(min) + ":" + Convert.ToString(sec);
                }
                else
                {
                    String time = "Timer: ";
                    label2.Text = time + Convert.ToString(timeFreezeHours) + ":" + Convert.ToString(timeFreezeMin);
                }
            }

        }

        private void UndoButton(object sender, EventArgs e)
        {
            PictureBox[] boxes = 
            {
                pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6,pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12,
                pictureBox13, pictureBox14, pictureBox15, pictureBox16, pictureBox17, pictureBox18,pictureBox19, pictureBox20, pictureBox21, pictureBox22, pictureBox23, pictureBox24,
                pictureBox25, pictureBox26, pictureBox27, pictureBox28, pictureBox29, pictureBox30,pictureBox31, pictureBox32, pictureBox33, pictureBox34, pictureBox35, pictureBox36,
                pictureBox37, pictureBox38, pictureBox39, pictureBox40, pictureBox41, pictureBox42,pictureBox43, pictureBox44, pictureBox45, pictureBox46, pictureBox47, pictureBox48,
                pictureBox49, pictureBox50, pictureBox51, pictureBox52
            };

            Stack<String>[] col = 
                    { column1, column2, column3, column4, column5, column6 ,
                    column7,column8,column9,column10,column11,column12,column13,
                    foundation1,foundation2,foundation3,foundation4
                    };

            if (numberOfUndos > 0)
            {
                col[undoMove.ColumnNumber()].Push(undoMove.cardString());
                col[undoMove.undoPop()].Pop();
                undoMove.undoLast();
                numberOfUndos--;

                //add to score
                score = score - 100;
                String scoreS = "Score: ";
                label4.Text = scoreS + Convert.ToString(score);
            }


        }

        

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox1, e);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox1, e);
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox1, e);
        }
        //==============================================================================

       
        //==============================================================================

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox2, e);
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox2, e);
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox2, e);
        }

        //==============================================================================

        private void pictureBox10_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox10, e);
        }

        private void pictureBox10_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox10, e);
        }

        private void pictureBox10_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox10, e);
        }

        //===============================================================================

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox3, e);
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox3, e);
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox3, e);
        }

        //==================================================================================

        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox4, e);
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox4, e);
        }

        private void pictureBox4_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox4, e);
        }

        //=====================================================================================

        private void pictureBox5_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox5, e);
        }

        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox5, e);
        }

        private void pictureBox5_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox5, e);
        }

        //=====================================================================================

        private void pictureBox6_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox6, e);
        }

        private void pictureBox6_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox6, e);
        }

        private void pictureBox6_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox6, e);
        }

        //=======================================================================================
        private void pictureBox7_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox7, e);
        }

        private void pictureBox7_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox7, e);
        }

        private void pictureBox7_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox7, e);
        }

        //================================================================================

        private void pictureBox8_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox8, e);
        }

        private void pictureBox8_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox8, e);
        }

        private void pictureBox8_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox8, e);
        }

        //=====================================================================================

        private void pictureBox9_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox9, e);
        }

        private void pictureBox9_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox9, e);
        }

        private void pictureBox9_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox9, e);
        }





        private void pictureBox52_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox52, e);
           
        }

        private void pictureBox52_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox52, e);
        }

        private void pictureBox52_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox52, e);

        }

        //===================================================================================

        private void pictureBox51_MouseDown(object sender, MouseEventArgs e)
        {

            SelectCard(pictureBox51, e);
           
        }

        private void pictureBox51_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox51, e);
        }

        private void pictureBox51_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox51, e);
            
        }

        //=====================================================================================

        private void pictureBox50_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox50, e);
        }

        private void pictureBox50_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox50, e);
        }

        private void pictureBox50_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox50, e);
        }

        //=====================================================================================

        private void pictureBox38_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox38, e);

        }

        private void pictureBox38_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox38, e);
        }

        private void pictureBox38_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox38, e);
            
        }

        //=====================================================================================

        private void pictureBox39_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox39, e);

        }

        private void pictureBox39_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox39, e);
        }

        private void pictureBox39_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox39, e);
            
        }

        private void pictureBox11_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox11, e);
        }

        private void pictureBox11_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox11, e);
        }

        private void pictureBox11_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox11, e);
        }

        private void pictureBox12_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox12, e);
        }

        private void pictureBox12_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox12, e);
        }

        private void pictureBox12_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox12, e);
        }

        private void pictureBox13_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox13, e);
        }

        private void pictureBox13_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox13, e);
        }

        private void pictureBox13_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox13, e);
        }

        private void pictureBox14_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox14, e);
        }

        private void pictureBox14_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox14, e);
        }

        private void pictureBox14_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox14, e);
        }

        private void pictureBox15_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox15, e);
        }

        private void pictureBox15_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox15, e);
        }

        private void pictureBox15_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox15, e);
        }

        private void pictureBox16_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox16, e);
        }

        private void pictureBox16_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox16, e);
        }

        private void pictureBox16_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox16, e);
        }

        private void pictureBox17_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox17, e);
        }

        private void pictureBox17_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox17, e);
        }

        private void pictureBox17_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox17, e);
        }

        private void pictureBox18_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox18, e);
        }

        private void pictureBox18_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox18, e);
        }

        private void pictureBox18_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox18, e);
        }

        private void pictureBox19_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox19, e);
        }

        private void pictureBox19_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox19, e);
        }

        private void pictureBox19_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox19, e);
        }

        private void pictureBox20_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox20, e);
        }

        private void pictureBox20_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox20, e);
        }

        private void pictureBox20_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox20, e);
        }

        private void pictureBox21_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox21, e);
        }

        private void pictureBox21_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox21, e);
        }

        private void pictureBox21_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox21, e);
        }

        private void pictureBox22_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox22, e);
        }

        private void pictureBox22_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox22, e);
        }

        private void pictureBox22_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox22, e);
        }

        private void pictureBox23_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox23, e);
        }

        private void pictureBox23_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox23, e);

        }

        private void pictureBox23_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox23, e);
        }

        private void pictureBox24_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox24, e);
        }

        private void pictureBox24_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox24, e);
        }

        private void pictureBox24_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox24, e);
        }

        private void pictureBox25_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox25, e);
        }

        private void pictureBox25_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox25, e);
        }

        private void pictureBox25_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox25, e);
        }

        private void pictureBox26_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox26, e);
        }

        private void pictureBox26_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox26, e);
        }

        private void pictureBox26_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox26, e);
        }

        private void pictureBox27_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox27, e);
        }

        private void pictureBox27_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox27, e);
        }

        private void pictureBox27_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox27, e);
        }

        private void pictureBox28_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox28, e);
        }

        private void pictureBox28_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox28, e);
        }

        private void pictureBox28_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox28, e);
        }

        private void pictureBox29_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox29, e);
        }

        private void pictureBox29_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox29, e);
        }

        private void pictureBox29_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox29, e);
        }

        private void pictureBox30_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox30, e);
        }

        private void pictureBox30_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox30, e);
        }

        private void pictureBox30_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox30, e);
        }

        private void pictureBox31_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox31, e);
        }

        private void pictureBox31_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox31, e);
        }

        private void pictureBox31_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox31, e);
        }

        private void pictureBox32_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox32, e);
        }

        private void pictureBox32_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox32, e);
        }

        private void pictureBox32_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox32, e);
        }

        private void pictureBox33_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox33, e);
        }

        private void pictureBox33_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox33, e);
        }

        private void pictureBox33_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox33, e);
        }

        private void pictureBox34_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox34, e);
        }

        private void pictureBox34_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox34, e);
        }

        private void pictureBox34_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox34, e);
        }

        private void pictureBox35_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox35, e);
        }

        private void pictureBox35_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox35, e);
        }

        private void pictureBox35_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox35, e);
        }

        private void pictureBox36_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox36, e);
        }

        private void pictureBox36_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox36, e);
        }

        private void pictureBox36_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox36, e);
        }

        private void pictureBox37_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox37, e);
        }

        private void pictureBox37_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox37, e);
        }

        private void pictureBox37_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox37, e);
        }

        private void pictureBox40_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox40, e);
        }

        private void pictureBox40_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox40, e);
        }

        private void pictureBox40_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox40, e);
        }

        private void pictureBox41_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox41, e);
        }

        private void pictureBox41_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox41, e);
        }

        private void pictureBox41_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox41, e);
        }

        private void pictureBox42_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox42, e);
        }

        private void pictureBox42_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox42, e);
        }

        private void pictureBox42_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox42, e);
        }

        private void pictureBox43_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox43, e);
        }

        private void pictureBox43_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox43, e);
        }

        private void pictureBox43_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox43, e);
        }

        private void pictureBox44_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox44, e);
        }

        private void pictureBox44_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox44, e);
        }

        private void pictureBox44_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox44, e);
        }

        private void pictureBox45_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox45, e);
        }

        private void pictureBox45_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox45, e);
        }

        private void pictureBox45_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox45, e);
        }

        private void pictureBox46_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox46, e);
        }

        private void pictureBox46_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox46, e);
        }

        private void pictureBox46_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox46, e);
        }

        private void pictureBox47_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox47, e);
        }

        private void pictureBox47_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox47, e);
        }

        private void pictureBox47_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox47, e);
        }

        private void pictureBox48_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox48, e);
        }

        private void pictureBox48_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox48, e);
        }

        private void pictureBox48_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox48, e);
        }

        private void pictureBox49_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCard(pictureBox49, e);
        }

        private void pictureBox49_MouseMove(object sender, MouseEventArgs e)
        {
            GetCard(pictureBox49, e);
        }

        private void pictureBox49_MouseUp(object sender, MouseEventArgs e)
        {
            ValidateMove(pictureBox49, e);
        }

        

        

        //=====================================================================================



        

        
        

        
       

        

        

        






    }
}
