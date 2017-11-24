﻿namespace ContactsWebApi.Models
{
    public class Contact
    {
        public long Id { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Phone { set; get; }
        public int Gender { set; get; }
        public string StreetAddress { set; get; }
        public string City { set; get; }
        public string Avatar { set; get; }

    }
}
