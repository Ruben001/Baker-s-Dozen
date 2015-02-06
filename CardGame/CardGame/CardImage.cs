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
    class CardImage
    {

        private Image cardImage;

        public Image getImage()
        {
            return cardImage;
        }
        

        public CardImage(int a, int b)
        
        {

            if (a == 0 && b == 0)
            {
                cardImage = global::CardGame.Properties.Resources._00;

            }
            else if (a == 0 && b == 1)
            {
                cardImage = global::CardGame.Properties.Resources._01;

            }
            else if (a == 0 && b == 2)
            {
                cardImage = global::CardGame.Properties.Resources._02;

            }
            else if (a == 0 && b == 3)
            {
                cardImage = global::CardGame.Properties.Resources._03;

            }
            else if (a == 1 && b == 0)
            {
                cardImage = global::CardGame.Properties.Resources._10;

            }
            else if (a == 1 && b == 1)
            {
                cardImage = global::CardGame.Properties.Resources._11;

            }
            else if (a == 1 && b == 2)
            {
                cardImage = global::CardGame.Properties.Resources._12;

            }
            else if (a == 1 && b == 3)
            {
                cardImage = global::CardGame.Properties.Resources._13;

            }
            else if (a == 2 && b == 0)
            {
                cardImage = global::CardGame.Properties.Resources._20;

            }
            else if (a == 2 && b == 1)
            {
                cardImage = global::CardGame.Properties.Resources._21;

            }
            else if (a == 2 && b == 2)
            {
                cardImage = global::CardGame.Properties.Resources._22;

            }
            else if (a == 2 && b == 3)
            {
                cardImage = global::CardGame.Properties.Resources._23;

            }
            else if (a == 3 && b == 0)
            {
                cardImage = global::CardGame.Properties.Resources._30;

            }
            else if (a == 3 && b == 1)
            {
                cardImage = global::CardGame.Properties.Resources._31;

            }
            else if (a == 3 && b == 2)
            {
                cardImage = global::CardGame.Properties.Resources._32;

            }
            else if (a == 3 && b == 3)
            {
                cardImage = global::CardGame.Properties.Resources._33;

            }
            else if (a == 4 && b == 0)
            {
                cardImage = global::CardGame.Properties.Resources._40;

            }
            else if (a == 4 && b == 1)
            {
                cardImage = global::CardGame.Properties.Resources._41;

            }
            else if (a == 4 && b == 2)
            {
                cardImage = global::CardGame.Properties.Resources._42;

            }
            else if (a == 4 && b == 3)
            {
                cardImage = global::CardGame.Properties.Resources._43;

            }
            else if (a == 5 && b == 0)
            {
                cardImage = global::CardGame.Properties.Resources._50;

            }
            else if (a == 5 && b == 1)
            {
                cardImage = global::CardGame.Properties.Resources._51;
            }

            else if (a == 5 && b == 2)
            {
                cardImage = global::CardGame.Properties.Resources._52;

            }
            else if (a == 5 && b == 3)
            {
                cardImage = global::CardGame.Properties.Resources._53;

            }
            else if (a == 6 && b == 0)
            {
               cardImage = global::CardGame.Properties.Resources._60;

            }
            else if (a == 6 && b == 1)
            {
                cardImage = global::CardGame.Properties.Resources._61;

            }
            else if (a == 6 && b == 2)
            {
                cardImage = global::CardGame.Properties.Resources._62;

            }
            else if (a == 6 && b == 3)
            {
                cardImage = global::CardGame.Properties.Resources._63;

            }
            else if (a == 7 && b == 0)
            {
                cardImage = global::CardGame.Properties.Resources._70;

            }
            else if (a == 7 && b == 1)
            {
                cardImage = global::CardGame.Properties.Resources._71;

            }
            else if (a == 7 && b == 2)
            {
                cardImage = global::CardGame.Properties.Resources._72;

            }
            else if (a == 7 && b == 3)
            {
                cardImage = global::CardGame.Properties.Resources._73;

            }
            else if (a == 8 && b == 0)
            {
                cardImage = global::CardGame.Properties.Resources._80;

            }
            else if (a == 8 && b == 1)
            {
                cardImage = global::CardGame.Properties.Resources._81;

            }
            else if (a == 8 && b == 2)
            {
                cardImage = global::CardGame.Properties.Resources._82;

            }
            else if (a == 8 && b == 3)
            {
                cardImage = global::CardGame.Properties.Resources._83;

            }
            else if (a == 9 && b == 0)
            {
                cardImage = global::CardGame.Properties.Resources._90;

            }
            else if (a == 9 && b == 1)
            {
                cardImage = global::CardGame.Properties.Resources._91;

            }
            else if (a == 9 && b == 2)
            {
                cardImage = global::CardGame.Properties.Resources._92;

            }
            else if (a == 9 && b == 3)
            {
                cardImage = global::CardGame.Properties.Resources._93;

            }
            else if (a == 10 && b == 0)
            {
                cardImage = global::CardGame.Properties.Resources._100;

            }
            else if (a == 10 && b == 1)
            {
                cardImage = global::CardGame.Properties.Resources._101;

            }
            else if (a == 10 && b == 2)
            {
                cardImage = global::CardGame.Properties.Resources._102;

            }
            else if (a == 10 && b == 3)
            {
                cardImage = global::CardGame.Properties.Resources._103;

            }
            else if (a == 11 && b == 0)
            {
                cardImage = global::CardGame.Properties.Resources._110;

            }
            else if (a == 11 && b == 1)
            {
                cardImage = global::CardGame.Properties.Resources._111;

            }
            else if (a == 11 && b == 2)
            {
                cardImage = global::CardGame.Properties.Resources._112;

            }
            else if (a == 11 && b == 3)
            {
                cardImage = global::CardGame.Properties.Resources._113;

            }
            else if (a == 12 && b == 0)
            {
                cardImage = global::CardGame.Properties.Resources._120;

            }
            else if (a == 12 && b == 1)
            {
                cardImage = global::CardGame.Properties.Resources._121;

            }
            else if (a == 12 && b == 2)
            {
                cardImage = global::CardGame.Properties.Resources._122;

            }
            else if (a == 12 && b == 3)
            {
                cardImage = global::CardGame.Properties.Resources._123;

            }
            


            }





        

    }
}

