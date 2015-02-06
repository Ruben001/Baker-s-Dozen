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
using System.Collections;

namespace CardGame
{
    class Deck
    {

        private Card[] cards;
        private Card[] aCards;
        int numberOfCards;
        int numberOfCardsOnDeck = 48;
        int numberOFCardsOnAceDeck = 4;
        Stack<int> randomNumberOfDeckCards = new Stack<int>();
        Stack<int> randomNumberOfAceCards = new Stack<int>();
        Boolean deckIsShuffled = false;
        Boolean aceDeckIsShuffled = false;



        
        public   Deck()
        {

           

        }


        public void CreateNewDeck()
        {

            numberOfCards = 52;

            cards = new Card[48];
            aCards = new Card[4];
            int x = 0;
            int aX = 0;

            for (int a = 0; a <= 3; a++)
            {

                for (int b = 0; b <= 12; b++)
                {
                    if (b == 12)
                    {
                        aCards[aX] = new Card(b, a);
                        aX++;
                    }
                    else
                    {
                        cards[x] = new Card(b, a);
                        x++;
                    }

                }

            }
            
            


        }

        public void shuffleDeck()
        {
            int n = 0;
            int[] tempCardDeck = new int[numberOfCardsOnDeck];
            for (int i = 0; i < numberOfCardsOnDeck; i++)
            {
                tempCardDeck[i] = n;
                n++;
            }

            Random generator = new Random();
            int index = 0;

            for (int i = 0; i < numberOfCardsOnDeck; i++)
            {
                do
                {

                    index = generator.Next(numberOfCardsOnDeck);


                } while (tempCardDeck[index] == -1);

                randomNumberOfDeckCards.Push(index);
                tempCardDeck[index] = -1;
            }

            deckIsShuffled = true;


        }
        public void shuffleAceDeck()
        {
            int n = 0;
            int[] tempCardDeck2 = new int[numberOFCardsOnAceDeck];
            for (int i = 0; i < numberOFCardsOnAceDeck; i++)
            {
                tempCardDeck2[i] = n;
                n++;
            }

            Random generator = new Random();
            int index = 0;

            for (int i = 0; i < numberOFCardsOnAceDeck; i++)
            {
                do
                {

                    index = generator.Next(numberOFCardsOnAceDeck);


                } while (tempCardDeck2[index] == -1);

                randomNumberOfAceCards.Push(index);
                tempCardDeck2[index] = -1;
            }

            aceDeckIsShuffled = true;
        }

        public Card drawFromDeck()
        {

            int index = 0;
            if (deckIsShuffled == true)
            {
                
                index = randomNumberOfDeckCards.Pop();
                numberOfCards--;
            }
            else
            {

            }
            Card temp = cards[index];

            cards[index] = null;

            return temp;

        }
        public Card drawFromAceDeck()
        {

            int index = 0;
            if (aceDeckIsShuffled == true)
            {

                index = randomNumberOfAceCards.Pop();
                numberOfCards--;
            }
            else
            {

            }
            Card temp = aCards[index];

            aCards[index] = null;

            return temp;
        }

        public int getTotalCards()
        {

            return numberOfCards;

        }


    }
}
