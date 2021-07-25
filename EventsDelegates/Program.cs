using System;
using System.Collections.Generic;

namespace EventsDelegates {

    public enum Moneda {LEU, EUR, USD};

    class MainClass {

        public static void Main(string[] args) {

            //1.a
            //creez lista producatori
            var producatori = new List<Producator>();

            //creez producatori
            var p1 = new Producator("Bitdefender");
            var p2 = new Producator("Microsoft");
            var p3 = new Producator("Apple");

            //adaug producatori
            producatori.Add(p1);
            producatori.Add(p2);
            producatori.Add(p3);

            var random = new Random();
            var month = 8;

            //iterez prin lista de producatori
            foreach(var x in producatori) {

                //creez 3 zile random
                int day1 = random.Next(1,32);
                int day2 = random.Next(1,32);
                int day3 = random.Next(1,32);

                //creez 3 date(mm.dd.yyyy - 12:00:00 AM) folosind zilele random
                var d1 = new DateTime(2021,month,day1);
                var d2 = new DateTime(2021,month,day2);
                var d3 = new DateTime(2021,month,day3);

                month++;//trec la urmatoarea luna

                //creez o lista de reduceri pt fiecare producator
                x.Reduceri = new List<Reducere>();

                //creez 3 reduceri
                var r1 = new Reducere("Discount",d1);
                var r2 = new Reducere("Discount",d2);
                var r3 = new Reducere("Discount",d3);

                //adaug reducerile in lista
                x.Reduceri.Add(r1);
                x.Reduceri.Add(r2);
                x.Reduceri.Add(r3);

                //printez reducerile
                //foreach(var y in x.Reduceri) {

                //    Console.WriteLine(y.Data);
                //}
            }

            //1.b
            //instantiere catalog
            var catalog = new Catalog();

            var pret1 = new Pret(Moneda.LEU,100);
            var pret2 = new Pret(Moneda.EUR,900);
            var pret3 = new Pret(Moneda.USD,400);

            var produs1 = new Produs(Guid.NewGuid(),
                "Bitdefender Antivirus PRO",pret1,400,p1);

            var produs2 = new Produs(Guid.NewGuid(),
                "Microsoft Surface",pret2,0,p2);

            var produs3 = new Produs(Guid.NewGuid(),
                "Apple Watch Series 6",pret3,130,p3);

            //adaug produse in catalog
            catalog.Add(produs1);
            catalog.Add(produs2);
            catalog.Add(produs3);

            //1.c
            //adaug cursul valutar in dictionarul static pt fiecare moneda
            Pret.Curs.Add(Moneda.LEU,1);
            Pret.Curs.Add(Moneda.EUR,4.9241m);
            Pret.Curs.Add(Moneda.USD,4.1740m);

            //1.d
            var clienti = new List<Client>();
            var produseFavorite = new List<Guid>();

            foreach(var x in catalog) {
                //adaug id produse din catalog
                produseFavorite.Add(x.Id);
            }

            //produs care nu e in catalog
            produseFavorite.Add(Guid.NewGuid());//random id


            var c1 = new Client("andrei.popescu@yahoo.com",Moneda.LEU,produseFavorite);
            var c2 = new Client("mihai.popescu@yahoo.com",Moneda.EUR,produseFavorite);
            var c3 = new Client("ionut.popescu@yahoo.com",Moneda.USD,produseFavorite);

            clienti.Add(c1);
            clienti.Add(c2);
            clienti.Add(c3);

            //2.0 && 3.0 checks

          
            //produs1.Pret -> publisher
            var schimbarePret = new SchimbarePret();// -> reciever
            var schimbareStoc = new SchimbareStoc();// -> reciever

            catalog.Aboneaza(produs1,schimbarePret,c1);
            catalog.Aboneaza(produs2,schimbarePret,c2);
            catalog.Aboneaza(produs3,schimbarePret,c2);

            catalog.ModificaStoc(produs2,c2,schimbareStoc);
            //catalog.ModificaStoc(produs2,c3,schimbareStoc); -> arunca exceptie

            //Console.WriteLine("Numar clienti abonati: " + catalog.ListaClienti.Count);


            //Console.WriteLine(c2.Inbox.Count);//verific cate inboxuri are c2

            //4.0
            
            foreach(var x in catalog) {//iterez prin lista produse

                foreach(var y in producatori) {//iterez prin lista de producatori

                    foreach(var z in y.Reduceri) {//iterez prin lista de reduceri

                        if(catalog.MyDateTimeExtension(z.Data) == true) {//verific perioada

                            
                            Console.WriteLine("Pret inainte reducere: " + x.Pret.valoare + x.Pret.Moneda);

                            //catalog.AplicaReduceriProducatorPub(x,z);//fara delegate ca parametru
                            catalog.AplicaReduceriProducatorPub(x,z,z.schimbareDePret);//cu delegate ca paramteru

                            Console.WriteLine("Pret dupa reducere: " + x.Pret.valoare + x.Pret.Moneda);


                        }


                    }
                }
            }


            //8.0
            foreach(var x in clienti) {

                Console.WriteLine("Email: " + x.Email);

                Console.WriteLine("Produse favorite: ");

                int count = 1;

                foreach(var y in x.ProduseFavorite) {

                    Console.WriteLine("Produs " + count + " " + y);
                    count++;
                }

                Console.WriteLine("Inbox: ");

                count = 1;

                foreach(var z in x.Inbox) {

                    Console.WriteLine("Mesaj " + count + " " + z);
                    count++;
                }
            }

        }
    }
}
