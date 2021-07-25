using System;

namespace EventsDelegates {

    public class SchimbareStoc {

        public void CandSchimbaStoc(object source, MyEventArgs args) {

            string s1 = "Produsul este din nou in stoc(>0)!" + args.StocNou;
            string s2 = "Produsul este din nou in stoc(favorit)!";

            if(args.Produs.Stoc == 0) {//daca stocul actual = 0

                if(args.StocNou > 0) {// daca noul stoc > 0

                    args.Client.Inbox.Add(s1);//trimit notificare
                }
            }

            if(args.Client.ProduseFavorite.Contains(args.Produs.Id)) {

                args.Client.Inbox.Add(s2);
            }
        }
    }
}
