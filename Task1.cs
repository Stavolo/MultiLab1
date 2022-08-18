using System;
using System.IO;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText(@"text.txt");
            int amountOfWords = 1;

            // подсчитаем общее количество слов
            int i = 0;
        loop_counter:
            if (text[i] == ' ' || text[i] == ',' || text[i] == '.'
            || text[i] == '?' || text[i] == '!' || text[i] == '\n')
                amountOfWords++;
            i++;
            if (i != text.Length)
                goto loop_counter;

            string[] words = new string[amountOfWords];

            // получаем самив слов(без вспомагательных)
            i = 0;
            string currentWord = "";
            int wordCount = 0;
        loop_creatorArray:
            if ((text[i] >= 65) && (text[i] <= 90) || (text[i] >= 97) && (text[i] <= 122) || text[i] == 45)
                currentWord += (text[i] >= 65) && (text[i] <= 90) ? (char)(text[i] + 32) : text[i];
            else
            {
                if (currentWord != "" && currentWord != "-" && currentWord != "no" && currentWord != "from" && currentWord != "the" && currentWord != "by" && currentWord != "and" && currentWord != "i" && currentWord != "in" && currentWord != "or" && currentWord != "any" && currentWord != "for" && currentWord != "to" && currentWord != "\"" && currentWord != "a" && currentWord != "on" && currentWord != "of" && currentWord != "at" && currentWord != "is" && currentWord != "\n" && currentWord != "\r" && currentWord != "\r\n" && currentWord != "\n\r")
                {
                    words[wordCount] = currentWord;
                    wordCount++;
                }
                currentWord = "";
            }
            i++;
            if (i < text.Length)
                goto loop_creatorArray;
            else
            {
                if (currentWord != "" && currentWord != "-" && currentWord != "no" && currentWord != "from" && currentWord != "the" && currentWord != "by" && currentWord != "and" && currentWord != "i" && currentWord != "in" && currentWord != "or" && currentWord != "any" && currentWord != "for" && currentWord != "to" && currentWord != "\"" && currentWord != "a" && currentWord != "on" && currentWord != "of" && currentWord != "at" && currentWord != "is" && currentWord != "\n" && currentWord != "\r" && currentWord != "\r\n" && currentWord != "\n\r")
                {
                    words[wordCount] = currentWord;
                }
            }

            string[] uniqueWords = new string[words.Length];
            int[] uniqueWordsRepeates = new int[words.Length];

            i = 0;

        //ищем и подсчитываем уникальные слова
        loop_outerUniqueCounter:
            if (words[i] == null)
            {
                i++;
                if (i != words.Length)
                    goto loop_outerUniqueCounter;
            }
            else
            {
                currentWord = words[i];
                //words[i] = null;
                int j = 0;
            loop_searchForFreeSpace:
                if (uniqueWords[j] != null)
                {
                    j++;
                    if (j != uniqueWords.Length)
                        goto loop_searchForFreeSpace;
                }
                else
                {
                    bool duplicate = false;
                    int k = 0;
                loop_checkForDuplicate:

                    if (uniqueWords[k] == currentWord)
                    {
                        duplicate = true;
                        uniqueWordsRepeates[k]++;
                    }
                    else
                    {
                        k++;
                        if (k != uniqueWords.Length)
                            goto loop_checkForDuplicate;
                    }


                    if (!duplicate)
                    {
                        uniqueWords[j] = currentWord;
                        uniqueWordsRepeates[j]++;
                    }
                }

                i++;
                if (i != words.Length)
                    goto loop_outerUniqueCounter;
            }

            //Сортировка
            i = 0;
            int z = 0;
        loop_outerBubbleSort:
            if (i < uniqueWords.Length - 1)
            {
            loop_innerBubbleSort:
                if (z < uniqueWords.Length - i - 1)
                {
                    if (uniqueWordsRepeates[z] < uniqueWordsRepeates[z + 1])
                    {
                        string word = uniqueWords[z];
                        int key = uniqueWordsRepeates[z];

                        uniqueWordsRepeates[z] = uniqueWordsRepeates[z + 1];
                        uniqueWords[z] = uniqueWords[z + 1];

                        uniqueWordsRepeates[z + 1] = key;
                        uniqueWords[z + 1] = word;
                    }
                    z++;
                    goto loop_innerBubbleSort;
                }
                i++;
                z = 0;
                goto loop_outerBubbleSort;
            }

            i = 0;
        loop_print:
            if (i < uniqueWords.Length)
            {
                if (uniqueWordsRepeates[i] != 0)
                    Console.WriteLine($"{uniqueWords[i]} - {uniqueWordsRepeates[i]}");
                i++;
                goto loop_print;
            }
        }
    }
}
