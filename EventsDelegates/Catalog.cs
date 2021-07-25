using System;
using System.Collections.Generic;

namespace EventsDelegates {

    public class Catalog : List<Produs> {//complet

        //DateTime de tip nullable = DateTime?
        public DateTime? PerioadaStart { get; set; } = new DateTime(2021,08,10);
        public DateTime? PerioadaStop { get; set; } = new DateTime(2021,08,25);
        public List<Reducere> Reduceri { get; set; }
        public List<Client> ListaClienti = new List<Client>();

        public void Aboneaza(Produs produs,SchimbarePret schimbarePret,Client client) {

            decimal newPrice = produs.Pret.valoare - 20;
            produs.Pret.SchimbaPret += schimbarePret.CandSchimbaPret;// abonare
            produs.Pret.InregistreazaPretNou(produs,client,newPrice);//schimbare pret produs + abonare client

            if(ListaClienti.Contains(client)) {

                Console.WriteLine("Clientul " + client.Email + " este deja abonat!");
            } else {
                ListaClienti.Add(client);//adaug client la lista abonati daca nu este abonat deja
            }
            

        }

        public void Dezaboneaza(Produs produs,Client client, SchimbarePret schimbarePret) {

            produs.Pret.SchimbaPret -= schimbarePret.CandSchimbaPret;

            if(ListaClienti.Count == 0) {

                throw new ArgumentNullException("Niciun abonat gasit!");

            } else {

                ListaClienti.Remove(client);
            }        
        }

        private void MetodaPrivata(Produs produs,Client client,SchimbareStoc schimbareStoc) {
            
            uint stocNou = 60;

            produs.Pret.SchimbaStoc += schimbareStoc.CandSchimbaStoc;

            if(ListaClienti.Contains(client)) {//daca clientul este in lista de clienti

                produs.Pret.InregistreazaStocNou(produs,client,stocNou);

            } else {

                throw new Exception("Clientul nu este abonat!");
            }

        }


        public void ModificaStoc(Produs produs,Client client,SchimbareStoc schimbareStoc) {

            MetodaPrivata(produs,client,schimbareStoc);
        }

        public bool MyDateTimeExtension(DateTime dt) {

            DateTime? dtNullable = dt;

            if(PerioadaStart <= dtNullable && dtNullable <= PerioadaStop) {
            //transform dateTime in longs si compar
                return true;

            } else {

                return false;
            }
            
        }

        private void AplicaReduceriProducator(Produs produs,Reducere reducere,Delegate aplica = null) {

            if(aplica == null) {

                produs.Pret.valoare -= 15;

            } else {

                reducere.schimbareDePret(produs);
            }
            
            
            if(produs.Pret.valoare < 10 && produs.Stoc == 0) {

                produs.Stoc += 100;
            }
        }

        public void AplicaReduceriProducatorPub(Produs produs,Reducere reducere, Delegate aplica = null) {

            AplicaReduceriProducator(produs,reducere,aplica);
        }

    }

}
