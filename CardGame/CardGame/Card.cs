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
using System.Drawing;
using System.Resources;

namespace CardGame
{
   
    class Card
    {

        private int rank, suit;

        private CardImage cardImage;
 

    private static String[] suits = { "hearts", "spades", "diamonds", "clubs" };

    private static String[] ranks  = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

    public Card(int a, int b)

    {
        
        rank = a;

        suit = b;

        cardImage = new CardImage(a,b);


    }
       
        public Image getImage()
        {

            return cardImage.getImage();
        }

        

     public String toString()

    {

        return ("_" + Convert.ToString(rank) + Convert.ToString(suit));
         //return (ranks[rank] + " of " + suits[suit]);

    }

 

    public int getRank() 
    {

         return rank;

    }

 

    public int getSuit() 
    {

        return suit;

    }



 


    }
}
