using System;

namespace EventsDelegates {

    public class Produs {//complet

        public Produs(Guid id,string nume,Pret pret,uint stoc,Producator producator) {
            Id = id;
            Nume = nume;
            Pret = pret;
            Stoc = stoc;
            Producator = producator;
        }

        public Guid Id { get; set; }
        public string Nume { get; set; }
        public Pret Pret { get; set; }
        public uint Stoc { get; set; }
        public Producator Producator { get; set; }     

    }
}
