using System;
using System.Collections.Generic;
using System.Text;

namespace RequisicoesWeb
{
    class Token
    {
        public string access_token { get; set; }
        public string api_domain { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
    }
}
