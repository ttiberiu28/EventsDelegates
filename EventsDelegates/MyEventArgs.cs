using System;

namespace EventsDelegates {
    
    public class MyEventArgs : EventArgs {

        public Produs Produs { get; set; }
        public Client Client { get; set; }
        public decimal PretNou { get; set; }
        public uint StocNou { get; set; }
    }
}
