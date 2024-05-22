using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ballagas {
    internal class Customer {
        private string name;
        private string phone;
        private int id;

        public Customer(string name, string phone, int id) {
            Name = name;
            Phone = phone;
            Id = id;
        }

        public string Name { get => name; set => name = value; }
        public string Phone { get => phone; set => phone = value; }
        public int Id { get => id; set => id = value; }
    }
}
