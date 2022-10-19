using System;

namespace Böqrîtch_Random_Word_Generator
{
    class Generator
    {
        Random rnd = new Random();
        Letters letters = new Letters();
        ClusterRules clusterRules = new ClusterRules();

        public string Generate(int characters)
        {
            bool cluster = false;
            bool vowel = false;
            bool verb = false;
            string word = "";
            string verbAdditionalConsonant = "";
            string verbVowel = "";
            int verbChance = rnd.Next(0, 4);

            if (verbChance < 1) {
                verb = true;

                if (characters != 1) {
                    characters -= 2;
                }
            }

            string[] listOfCharacters = new string[characters];

            for (int i = 0; i < characters; i++) {
                string letter;

                if (vowel) {
                    cluster = false;
                    letter = letters.vowels[rnd.Next(0, 5)];
                } else {
                    letter = letters.consonants[rnd.Next(0, 14)];

                    if (letter == "hh" && i == characters - 1) {
                        do {
                            letter = letters.consonants[rnd.Next(0, 14)];
                        } while (letter == "hh");
                    }

                    if (i >= 2 && !cluster) {
                        int clusterChance = rnd.Next(0, 99);

                        if (i == characters - 2) {
                            if (clusterChance < 10) {
                                cluster = true;
                            }
                        } else if (i == characters - 1) {
                            cluster = false;
                        } else {
                            if (clusterChance < 25) {
                                cluster = true;
                            }
                        }
                    }
                }

                listOfCharacters[i] = letter;

                if (i >= 2 && cluster) {
                    if (listOfCharacters[i - 1] == "hh") {
                        cluster = false;
                    }
                }

                if (i >= 2 && cluster) {
                    if (!clusterRules.IsAllowed(listOfCharacters[i - 1], listOfCharacters[i])) {
                        do {
                            letter = letters.consonants[rnd.Next(0, 14)];
                            listOfCharacters[i] = letter;
                        } while (!clusterRules.IsAllowed(listOfCharacters[i - 1], listOfCharacters[i]));
                    } else if (i == characters - 1 && !(Array.Exists(letters.consonants, s => s == listOfCharacters[i - 1]) && (listOfCharacters[i] == "r" || listOfCharacters[i] == "rh"))) {
                        do {
                            letter = letters.consonants[rnd.Next(0, 14)];
                            listOfCharacters[i] = letter;
                        } while (letter == "r" || letter == "rh");
                    } else {
                        vowel = !vowel;
                    }
                }
                word = word + letter;
                vowel = !vowel;
            }

            if (verb) {
                if (Array.Exists(letters.vowels, s => s == listOfCharacters[characters - 1])) {
                    string letter = letters.consonants[rnd.Next(0, 14)];
                    word += letter;
                    verbAdditionalConsonant = letter + "\n";
                }

                int chooseVerbVowel = rnd.Next(0, 3);

                switch (chooseVerbVowel) {
                    case 0:
                    verbVowel = "î";
                    break;
                    case 1:
                    verbVowel = "u";
                    break;
                    case 2:
                    verbVowel = "ö";
                    break;
                    default:
                    break;
                }

                word = word + verbVowel + "r";
            }

            return word;
        }
    }
}