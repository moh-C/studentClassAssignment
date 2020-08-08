namespace myapp
{
    class Person
    {
        //private System.DateTime _birthdate;
        public Person(System.DateTime dateTime)
        {
            if(dateTime > new System.DateTime(1970, 1, 1))
                Birthdate = dateTime;
            else
                Birthdate = new System.DateTime(1970,1,1);
        }
        public System.DateTime Birthdate { get; private set; }
        public int Age
        {
            get
            {
                var timespan = System.DateTime.Today - Birthdate;
                int age = timespan.Days / 365;
                return age;
            }
        }
    }
}    