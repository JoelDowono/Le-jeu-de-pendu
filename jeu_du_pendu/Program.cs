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
                }
                else
                {
                    Console.WriteLine("Cette lettre n'est pas dans le mot");
                    viesRestantes--;
                    Console.WriteLine("Vies restante : " + viesRestantes);
                }
                Console.WriteLine();
            }
            
            if (viesRestantes == 0)
            {
                Console.WriteLine("PERDU ! Le mot était : " + mot);
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