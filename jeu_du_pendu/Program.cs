using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void AfficherMot(string mot, List<char> lettres)
        {
            for(int i = 0; i < mot.Length; i++)
            {
                char lettre = mot[i];
                if(lettres.Contains(lettre))
                {
                    Console.Write(lettre + " ");
                }
                else
                {
                    Console.Write("_ ");
                } 
            }
            Console.WriteLine();
        }

        static bool ToutesLettresDevinees(string mot, List<char> lettres)
        {
            foreach(char lettre in lettres)
            {
                mot = mot.Replace(lettre.ToString(), "");
            }
            if(mot.Length == 0)
            {
                return true;
            }
            return false;
        }
        static char DemanderUneLettre()
        {
            while(true)
            {
                Console.Write("Rentrez une Lettre: ");
                string reponse = Console.ReadLine();

                if (reponse.Length == 1)
                {
                    reponse = reponse.ToUpper();
                    return reponse[0];
                }
                Console.WriteLine("Erreur : Vous devez rentrer une lettre");
            }
        }

        static void DevinerMot(string mot)
        {
            var lettreDevinees = new List<char>();
            var lettreExclues = new List<char>();
            const int NB_VIES = 6;
            int viesRestantes = NB_VIES;

            while(viesRestantes > 0)
            {
                AfficherMot(mot, lettreDevinees);
                Console.WriteLine();
                var lettre = DemanderUneLettre();
                Console.Clear();

                if (mot.Contains(lettre))
                {
                    Console.WriteLine("Cette lettre est dans le mot");
                    lettreDevinees.Add(lettre);
                    if(ToutesLettresDevinees(mot, lettreDevinees))
                    {
                        break;
                    }
                }
                else
                {
                    viesRestantes--;
                    lettreExclues.Add(lettre);
                    Console.WriteLine("Vies restante : " + viesRestantes);
                }

                Console.WriteLine("Le mot ne contient pas les lettres : " + String.Join(", ", lettreExclues));
                Console.WriteLine();
            }
            
            if (viesRestantes == 0)
            {
                Console.WriteLine("PERDU ! Le mot était : " + mot);
            }
            else
            {
                AfficherMot(mot, lettreDevinees);
                Console.WriteLine();
                Console.WriteLine("GAGNE !");
            }
        }
        static void Main(string[] args)
        {
            string mot = "ELEPHANT";

            DevinerMot(mot);
            /*char lettre = DemanderUneLettre();
            AfficherMot(mot, new List<char> { lettre });*/

        }
    }
}