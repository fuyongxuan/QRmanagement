using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QrMgr
{
    [Serializable]
    public class zipcommand
    {
        public string isbn;
        public string pos;
        public int seq;
        public string url;
      public zipcommand(String isbn, String pos, int seq, String url)
        {
            this.isbn = isbn;
            this.pos = pos;
            this.seq = seq;
            this.url = url;
        }

    }
}