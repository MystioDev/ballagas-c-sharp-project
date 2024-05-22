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

        public Customer(string name, string phone) {
            Name = name;
            Phone = phone;
        }

        public string Name { get => name; set {
            if (value.Length == 0) throw new Exception("Nem lehet üres a megrendelő neve!");

            name = value;
        } }
        public string Phone { get => phone; set {
            if (value.Length == 0) throw new Exception("Nem lehet üres a megrendelő telefonszáma!");
            phone = value;
        } }
        public int Id { get => id; set => id = value; }
    }
}
