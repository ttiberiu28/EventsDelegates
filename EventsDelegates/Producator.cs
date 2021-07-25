using System;
using System.Collections.Generic;

namespace EventsDelegates {

    public class Producator {//complet

        public Producator(string nume) {

            Nume = nume;
        }

        public string Nume { get; set; }
        public List<Reducere> Reduceri { get; set; }      

    }
}
