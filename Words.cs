using System;
using System.Collections.Generic;

using NHunspell;

namespace Anygram2
{
    class Words
    {
        public List<string> words { get; private set; }

        public Words(string Letters)
        {
            if (string.IsNullOrEmpty(Letters))
            {
                throw new ArgumentNullException();
            }

            if (Letters.Length < 3)
            {
                throw new ArgumentOutOfRangeException("Requires 3 or more letters");
            }

            GenerateWords(Letters);
        }

        public int Count()
        {
            return words.Count;
        }

        private void GenerateWords(string Letters)
        {
            try
            {
                int ofs1, ofs2, ofs3, ofs4, ofs5, ofs6, ofs7, ofs8, ofs9;
                int numLetters = Letters.Length;
                string word = "";

                words = new List<string>();

                using (Hunspell hspell = new Hunspell("en_us.aff", "en_us.dic"))
                {
              
                    for (ofs1 = 0; ofs1 < numLetters; ofs1++)
                    {
                        for (ofs2 = 0; ofs2 < numLetters; ofs2++)
                        {
                            if (ofs2 != ofs1)
                            {
                                for (ofs3 = 0; ofs3 < numLetters; ofs3++)
                                {
                                    if (ofs3 != ofs2 && ofs3 != ofs1)
                                    {
                                        word = Letters.Substring(ofs1, 1) + Letters.Substring(ofs2, 1) + Letters.Substring(ofs3, 1);
                                        if (hspell.Spell(word) == true)
                                        {
                                            if (words.Contains(word) == false)
                                            {
                                                words.Add(word);
                                            }
                                        }


                                        if (numLetters >=4)
                                        {
                                            for (ofs4 = 0; ofs4 < numLetters; ofs4++)
                                            {
                                                if (ofs4 != ofs3 && ofs4 != ofs2 && ofs4 != ofs1)
                                                {
                                                    word = Letters.Substring(ofs1, 1) + Letters.Substring(ofs2, 1) + Letters.Substring(ofs3, 1) + Letters.Substring(ofs4, 1);
                                                    if (hspell.Spell(word) == true)
                                                    {
                                                        if (words.Contains(word) == false)
                                                        {
                                                            words.Add(word);
                                                        }
                                                    }

                                                    if (numLetters >= 5)
                                                    {
                                                        for (ofs5 = 0; ofs5 < numLetters; ofs5++)
                                                        {
                                                            if (ofs5 != ofs4 && ofs5 != ofs3 && ofs5 != ofs2 && ofs5 != ofs1)
                                                            {
                                                                word = Letters.Substring(ofs1, 1) + Letters.Substring(ofs2, 1) + Letters.Substring(ofs3, 1) + Letters.Substring(ofs4, 1) + Letters.Substring(ofs5, 1);
                                                                if (hspell.Spell(word) == true)
                                                                {
                                                                    if (words.Contains(word) == false)
                                                                    {
                                                                        words.Add(word);
                                                                    }
                                                                }


                                                                if (numLetters >= 6)
                                                                {
                                                                    for (ofs6 = 0; ofs6 < numLetters; ofs6++)
                                                                    {
                                                                        if (ofs6 != ofs5 && ofs6 != ofs4 && ofs6 != ofs3 && ofs6 != ofs2 && ofs6 != ofs1)
                                                                        {
                                                                            word = Letters.Substring(ofs1, 1) + Letters.Substring(ofs2, 1) + Letters.Substring(ofs3, 1) + Letters.Substring(ofs4, 1) + Letters.Substring(ofs5, 1) + Letters.Substring(ofs6, 1);
                                                                            if (hspell.Spell(word) == true)
                                                                            {
                                                                                if (words.Contains(word) == false)
                                                                                {
                                                                                    words.Add(word);
                                                                                }
                                                                            }


                                                                            if(numLetters >=7)
                                                                            {
                                                                                for (ofs7 = 0; ofs7 < numLetters; ofs7++)
                                                                                {
                                                                                    if (ofs7 != ofs6 && ofs7 != ofs5 && ofs7 != ofs4 && ofs7 != ofs3 && ofs7 != ofs2 && ofs7 != ofs1)
                                                                                    {
                                                                                        word = Letters.Substring(ofs1, 1) + Letters.Substring(ofs2, 1) + Letters.Substring(ofs3, 1) + Letters.Substring(ofs4, 1) + Letters.Substring(ofs5, 1) + Letters.Substring(ofs6, 1) + Letters.Substring(ofs7, 1);
                                                                                        if (hspell.Spell(word) == true)
                                                                                        {
                                                                                            if (words.Contains(word) == false)
                                                                                            {
                                                                                                words.Add(word);
                                                                                            }
                                                                                        }


                                                                                        if(numLetters >= 8)
                                                                                        {
                                                                                            for (ofs8 = 0; ofs8 < numLetters; ofs8++)
                                                                                            {
                                                                                                if (ofs8 != ofs7 && ofs8 != ofs6 && ofs8 != ofs5 && ofs8 != ofs4 && ofs8 != ofs3 && ofs8 != ofs2 && ofs8 != ofs1)
                                                                                                {
                                                                                                    word = Letters.Substring(ofs1, 1) + Letters.Substring(ofs2, 1) + Letters.Substring(ofs3, 1) + Letters.Substring(ofs4, 1) + Letters.Substring(ofs5, 1) + Letters.Substring(ofs6, 1) + Letters.Substring(ofs7, 1) + Letters.Substring(ofs8, 1);
                                                                                                    if (hspell.Spell(word) == true)
                                                                                                    {
                                                                                                        if (words.Contains(word) == false)
                                                                                                        {
                                                                                                            words.Add(word);
                                                                                                        }
                                                                                                    }


                                                                                                    if (numLetters >= 9)
                                                                                                    {
                                                                                                        for (ofs9 = 0; ofs9 < numLetters; ofs9++)
                                                                                                        {
                                                                                                            if (ofs9 != ofs8 && ofs9 != ofs7 && ofs9 != ofs6 && ofs9 != ofs5 && ofs9 != ofs4 && ofs9 != ofs3 && ofs9 != ofs2 && ofs9 != ofs1)
                                                                                                            {
                                                                                                                word = Letters.Substring(ofs1, 1) + Letters.Substring(ofs2, 1) + Letters.Substring(ofs3, 1) + Letters.Substring(ofs4, 1) + Letters.Substring(ofs5, 1) + Letters.Substring(ofs6, 1) + Letters.Substring(ofs7, 1) + Letters.Substring(ofs8, 1);
                                                                                                                if (hspell.Spell(word) == true)
                                                                                                                {
                                                                                                                    if (words.Contains(word) == false)
                                                                                                                    {
                                                                                                                        words.Add(word);
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }

                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                }

                words.Sort();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
