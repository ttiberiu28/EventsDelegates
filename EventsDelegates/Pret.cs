using System;
using System.Collections.Generic;
using System.Threading;

namespace EventsDelegates {

    public class Pret {

        public Pret(Moneda moneda,decimal valoare) {

            Moneda = moneda;
            this.valoare = valoare;
        }

        public static Dictionary<Moneda,decimal> Curs
            = new Dictionary<Moneda,decimal>();

        public Moneda Moneda { get; set; }  
        public decimal valoare;     

        public decimal ValoareCurs(Moneda moneda) {

            decimal valCurs;

            //pentru tipul de moneda primit ca parametru, se va intoarce valoarea cursului
            Curs.TryGetValue(moneda, out valCurs);//obtin valoarea din dictionar

            //returnez valoarea cursului * valoarea produsului in 'LEU'
            return valCurs * valoare;
        }

        //events

        //step1 create event handler
        public delegate void SchimbaPretEventHandler(object source,MyEventArgs args);

        //step2 create event
        public event SchimbaPretEventHandler SchimbaPret;

        //step3 prepare raising the event
        protected virtual void CandSchimbaPret(Produs produs,Client client, decimal pretNou) {

            if(SchimbaPret != null) {

                SchimbaPret(this, new MyEventArgs() {Produs = produs,Client = client, PretNou = pretNou});
            }
        }

        //step3.1 raise the event
        public void InregistreazaPretNou(Produs produs,Client client, decimal pretNou) {

            Console.WriteLine("Schimbare pret...");

            Thread.Sleep(1200);

            CandSchimbaPret(produs,client,pretNou);
            
        }

        //second event
        public delegate void SchimbaStocEventHandler(object source,MyEventArgs args);

        public event SchimbaStocEventHandler SchimbaStoc;

        protected virtual void CandSchimbaStoc(Produs produs,Client client,uint stocNou) {

            if(SchimbaStoc != null) {

                SchimbaStoc(this,new MyEventArgs() {Produs = produs, Client = client, StocNou = stocNou });
            }
        }

        public void InregistreazaStocNou(Produs produs,Client client, uint stocNou) {

            Console.WriteLine("Schimbare stoc...");

            Thread.Sleep(1200);

            CandSchimbaStoc(produs,client,stocNou);
            
        }

    }
}
