using System;
using System.Collections.Generic;

namespace EventsDelegates {

    public class Client {

        public Client(string email,Moneda moneda,List<Guid> produseFavorite) {

            Email = email;
            Moneda = moneda;
            ProduseFavorite = produseFavorite;
        }

        private List<string> _inbox = new List<string>(10);

        public string Email { get; set; }
        public Moneda Moneda { get; set; }
        public List<Guid> ProduseFavorite { get; set; }

        public List<string> Inbox { get => _inbox; set => _inbox = value; }

        public bool Notifica(string mesaj){

            if(Inbox.Count >= 10) {

                throw new OutOfMemoryException("The mail limit has been reached!");
            }

            if(mesaj.Length > 60) {

                return false;

            } else {

                Inbox.Add(mesaj);
                return true;
            }
            
        }


    }
}
