using System;

namespace Böqrîtch_Random_Word_Generator
{
    class ClusterRules
    {
        Letters letters = new Letters();

        string[] stop = {
            "q",
            "b",
            "tch",
            "t"
        };
        string[] fricavtiveA = {
            "l",
            "sh",
            "th",
            "ph"
        };
        string[] fricativeB = {
            "hh",
            "s",
            "n"
        };
        string[] velar = {
            "kh",
            "gh"
        };
        string[] rhotic = {
            "r",
            "rh"
        };

        public bool IsAllowed(string letter1, string letter2)
        {
            if (Array.Exists(letters.vowels, s => s == letter1 || s == letter2)) {
                return true;
            }

            if (letter1 == letter2) {
                return false;
            }

            if (letter1 == "hh") {
                return false;
            }

            if (Array.Exists(rhotic, s => s == letter1) && !Array.Exists(stop, s => s == letter2)) {
                return false;
            }

            if (Array.Exists(stop, s => s == letter2)) {
                if (!Array.Exists(fricativeB, s => s == letter1)) {
                    return false;
                } else if (letter1 == "hh") {
                    return false;
                }
            }

            if (Array.Exists(fricativeB, s => s == letter2) && letter2 != "hh") {
                if ((Array.Exists(velar, s => s == letter1) || letter1 == "l") && letter2 == "s") {
                    return true;
                } else if ((Array.Exists(fricavtiveA, s => s == letter1) && letter1 != "sh") && letter2 == "n") {
                    return true;
                } else {
                    return false;
                }
            }
            if (letter2 == "hh" && !Array.Exists(fricativeB, s => s == letter1)) {
                return false;
            }

            if ((Array.Exists(stop, s => s == letter1) && letter1 != "b") && Array.Exists(velar, s => s == letter2)) {
                return false;
            }

            if (Array.Exists(stop, s => s == letter1) && Array.Exists(stop, s => s == letter2)) {
                return false;
            } else if (Array.Exists(fricavtiveA, s => s == letter1) && Array.Exists(fricavtiveA, s => s == letter2)) {
                return false;
            } else if (Array.Exists(velar, s => s == letter1) && Array.Exists(velar, s => s == letter2)) {
                return false;
            } else if (Array.Exists(rhotic, s => s == letter1) && Array.Exists(rhotic, s => s == letter2)) {
                return false;
            }

            return true;
        }
    }
}