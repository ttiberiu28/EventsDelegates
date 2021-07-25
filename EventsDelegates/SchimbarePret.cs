using System;

namespace EventsDelegates {

    public class SchimbarePret {

        public void CandSchimbaPret(object source,MyEventArgs args) {

            //Console.WriteLine("Vechiul pret ->" + args.Produs.Pret.valoare + args.Produs.Pret.Moneda);
            //Console.WriteLine("Noul pret ->" + args.PretNou + args.Produs.Pret.Moneda);
            //Console.WriteLine("Pretul a fost schimbat!");

            var s1 = "Vechiul pret -> " + args.Produs.Pret.valoare + args.Produs.Pret.Moneda;
            var s2 = "/Noul pret -> " + args.PretNou + args.Produs.Pret.Moneda;
            var s = "Pretul a fost schimbat : " + s1 + s2;

            args.Client.Inbox.Add(s);//adaug mesajul in inboxul clientului abonat
        }


        //public delegate string CandSchimbaPret(object source,MyEventArgs args);

        //CandSchimbaPret candSchimbaPret = (object source,MyEventArgs args) => {

        //    Console.WriteLine("Vechiul pret ->" + args.Produs.Pret.valoare + args.Produs.Pret.Moneda);
        //    Console.WriteLine("Noul pret ->" + args.PretNou + args.Produs.Pret.Moneda);
        //    return "Pretul a fost schimbat";
        //};?
    }
}
