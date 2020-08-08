using System.Collections.Generic;

namespace myapp
{
    class HttpCookie
    {
        public string name { get; set; }
        private readonly Dictionary<string, string> _dictionary;
        public HttpCookie()
        {
            _dictionary = new Dictionary<string, string>();
        }

        public string this[string key]
        {
            get
            {
                return _dictionary[key];
            }
            set
            {
                name = value;
                _dictionary[key] = value;
            }
        }
    }
}