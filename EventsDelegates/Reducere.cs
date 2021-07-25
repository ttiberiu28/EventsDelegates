using System;

namespace EventsDelegates {

    public class Reducere {

        public Reducere(string nume,DateTime data) {

            Nume = nume;
            Data = data;
        }

        public string Nume { get; set; }
        public DateTime Data { get; set; }

        public delegate void Aplica(Produs p);

        public static void SchimbarePret(Produs p) {

            p.Pret.valoare -= 30;
            Console.WriteLine("Se aplica reducere");
        }

        public Aplica schimbareDePret = SchimbarePret;
    }
}
