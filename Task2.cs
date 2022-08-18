using System;
using System.IO;

namespace Lab1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText(@"text.txt");
            int lengthOfText = text.Length;
            int i = 0;

            string currentWord = "";
            string[] wordsArr = new string[100000];
            string[,] pagesWordsArr = new string[10000, 10000];

            int amountOfWords = 0;
            int amountOfRows = 0;
            int amountOfPages = 0;
            int amountOfWordsOnPage = 0;

        loop_counter:
            if ((text[i] >= 65) && (text[i] <= 90) || (text[i] >= 97) && (text[i] <= 122)
                || text[i] == 45 || text[i] == 234 || text[i] == 225 || text[i] == 224)
            {
                if ((text[i] >= 65) && (text[i] <= 90))
                    currentWord += (char)(text[i] + 32);
                else
                    currentWord += text[i];
            }
            else
            {
                if (text[i] == '\n')
                    amountOfRows++;
                if (amountOfRows > 45)
                {
                    amountOfPages++;
                    amountOfWordsOnPage = 0;
                    amountOfRows = 0;
                }
                if (currentWord != "" && currentWord != null && currentWord != "-"
                    && currentWord != "no" && currentWord != "from" && currentWord != "the"
                    && currentWord != "by" && currentWord != "and" && currentWord != "i"
                    && currentWord != "in" && currentWord != "or" && currentWord != "any"
                    && currentWord != "for" && currentWord != "to" && currentWord != "\""
                    && currentWord != "a" && currentWord != "on" && currentWord != "of"
                    && currentWord != "at" && currentWord != "is" && currentWord != "\n"
                    && currentWord != "\r" && currentWord != "\r\n" && currentWord != "\n\r")
                {

                    wordsArr[amountOfWords] = currentWord;
                    amountOfWords++;
                    pagesWordsArr[amountOfPages, amountOfWordsOnPage] = currentWord;
                    amountOfWordsOnPage++;
                }
                currentWord = "";
            }
            i++;
            if (i < lengthOfText)
                goto loop_counter;
            else
            {
                if (currentWord != "" && currentWord != null && currentWord != "-"
                    && currentWord != "no" && currentWord != "from" && currentWord != "the"
                    && currentWord != "by" && currentWord != "and" && currentWord != "i"
                    && currentWord != "in" && currentWord != "or" && currentWord != "any"
                    && currentWord != "for" && currentWord != "to" && currentWord != "\""
                    && currentWord != "a" && currentWord != "on" && currentWord != "of"
                    && currentWord != "at" && currentWord != "is" && currentWord != "\n"
                    && currentWord != "\r" && currentWord != "\r\n" && currentWord != "\n\r")
                {
                    wordsArr[amountOfWords] = currentWord;
                    amountOfWords++;
                }
            }
            string[] wordsOnlyOnceArr = new string[100000];
            int[] wordsOnceCountArr = new int[100000];
            int amount_of_words = wordsArr.Length;
            i = 0;
            int insertPos = 0;
            int j = 0;
            int dubs = 0;

        loop_outerCounter:
            insertPos = 0;
            int current_length = wordsOnlyOnceArr.Length;
            j = 0;
        loop_inerCounter:
            if (j < current_length && wordsOnlyOnceArr[j] != null)
            {
                if (wordsOnlyOnceArr[j] == wordsArr[i])
                {
                    insertPos = j;
                    goto loop_endCounter;
                }
                j++;
                goto loop_inerCounter;
            }
        loop_endCounter:
            if (insertPos == 0)
            {
                wordsOnlyOnceArr[i - dubs] = wordsArr[i];
                wordsOnceCountArr[i - dubs] = 1;
            }
            else
            {
                wordsOnceCountArr[insertPos] += 1;
                dubs++;
            }
            i++;
            if (i < amount_of_words && wordsArr[i] != null)
                goto loop_outerCounter;

            int length = wordsOnceCountArr.Length;
            int k = 0;
            string[] wordsOnlyOnceArrLessThan100 = new string[100000];
            int LastInsert = 0;
        loop_lessThan100:
            if (k < length && wordsOnlyOnceArr[k] != null)
            {
                if (wordsOnceCountArr[k] <= 100)
                {
                    wordsOnlyOnceArrLessThan100[LastInsert] = wordsOnlyOnceArr[k];
                    LastInsert++;
                }
                k++;
                goto loop_lessThan100;
            }

            int write = 0;
            int sort = 0;
            bool toSwapWords = false;
            int counter = 0;
            int wordLenthCurren = 0;
            int wordLenthNext = 0;
        loop_outerBubbleSort:
            if (write < wordsOnlyOnceArrLessThan100.Length && wordsOnlyOnceArrLessThan100[write] != null)
            {
                sort = 0;
            loop_innerBubbleSort:
                if (sort < wordsOnlyOnceArrLessThan100.Length - write - 1 && wordsOnlyOnceArrLessThan100[sort + 1] != null)
                {
                    wordLenthCurren = wordsOnlyOnceArrLessThan100[sort].Length;
                    wordLenthNext = wordsOnlyOnceArrLessThan100[sort + 1].Length;

                    int compareLenth = wordLenthCurren > wordLenthNext ? wordLenthNext : wordLenthCurren;

                    toSwapWords = false;
                    counter = 0;
                check_alphabet:

                    if (wordsOnlyOnceArrLessThan100[sort][counter] > wordsOnlyOnceArrLessThan100[sort + 1][counter])
                    {
                        toSwapWords = true;
                        goto loop_checkAlphabetEnd;
                    }
                    if (wordsOnlyOnceArrLessThan100[sort][counter] < wordsOnlyOnceArrLessThan100[sort + 1][counter])
                        goto loop_checkAlphabetEnd;
                    counter++;
                    if (counter < compareLenth)
                        goto check_alphabet;
                    loop_checkAlphabetEnd:
                    if (toSwapWords)
                    {
                        string temp = wordsOnlyOnceArrLessThan100[sort];
                        wordsOnlyOnceArrLessThan100[sort] = wordsOnlyOnceArrLessThan100[sort + 1];
                        wordsOnlyOnceArrLessThan100[sort + 1] = temp;
                    }
                    sort++;
                    goto loop_innerBubbleSort;
                }
                write++;
                goto loop_outerBubbleSort;
            }
            k = 0;
            int less_than_100_length = wordsOnlyOnceArrLessThan100.Length;
        loop_print:
            if (k < less_than_100_length && wordsOnlyOnceArrLessThan100[k] != null)
            {
                Console.Write("{0} - ", wordsOnlyOnceArrLessThan100[k]);
                int firstDim = 0;
                int secondDim = 0;
                int[] wordPages = new int[100];
                int pageInsert = 0;

            loop_checkPage:
                if (firstDim < 10000 && pagesWordsArr[firstDim, 0] != null)
                {
                    secondDim = 0;
                loop_checkPageWord:
                    if (secondDim < 10000 && pagesWordsArr[firstDim, secondDim] != null)
                    {
                        if (pagesWordsArr[firstDim, secondDim] == wordsOnlyOnceArrLessThan100[k])
                        {
                            wordPages[pageInsert] = firstDim + 1;
                            pageInsert++;
                            firstDim++;
                            goto loop_checkPage;
                        }
                        secondDim++;
                        goto loop_checkPageWord;
                    }

                    firstDim++;
                    goto loop_checkPage;
                }
                int tiredCounte = 0;
            loop_pagination:
                if (tiredCounte < 100 && wordPages[tiredCounte] != 0)
                {
                    if (tiredCounte != 99 && wordPages[tiredCounte + 1] != 0)
                        Console.Write("{0}, ", wordPages[tiredCounte]);
                    else
                        Console.Write("{0}", wordPages[tiredCounte]);
                    tiredCounte++;
                    goto loop_pagination;
                }
                Console.WriteLine();
                k++;
                goto loop_print;
            }
        }
    }
}
