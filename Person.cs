namespace myapp
{
    class Person
    {
        private System.DateTime _birthdate;
        public System.DateTime Birthdate
        {
            get{ return _birthdate; }
            set
            {
                if(value > new System.DateTime(1970, 1, 1))
                    _birthdate = value;
                else
                    _birthdate = new System.DateTime(1970,1,1);
            }
        }
    }
}    