using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ballagas {
    internal class Order {
        private string schoolName;
        private string className;
        private string classYears;
        private string message;
        private string status;
        private int pieces;
        private int customerId;
        private int id;

        public Order(string schoolName, string className, string classYears, string message, string status, int pieces, int customerId, int id) {
            SchoolName = schoolName;
            ClassName = className;
            ClassYears = classYears;
            Message = message;
            Status = status;
            Pieces = pieces;
            CustomerId = customerId;
            Id = id;
        }

        public Order(string schoolName, string className, string classYears, string message, int pieces) {
            SchoolName = schoolName;
            ClassName = className;
            ClassYears = classYears;
            Message = message;
            Pieces = pieces;
        }

        public string SchoolName { get => schoolName; set {
            if (value.Length == 0) throw new Exception("Üres név!");

            schoolName = value;
        } }
        public string ClassName { get => className; set {
            if (value.Length == 0) throw new Exception("Üres osztálynév!");

            className = value;
        } }
        public string ClassYears { get => classYears; set {
            if (value.Length == 0) throw new Exception("Üres osztályév!");

            classYears = value;
        } }
        public string Message { get => message; set {
            if (value.Length == 0) throw new Exception("Üres üzenet!");

            message = value;
        } }

        public int Pieces { get => pieces; set {
            if (value <= 0) throw new Exception("Csak pozitív érték lehet!");

            pieces = value;
        } }

        public string Status { get => status; set => status = value; }
        public int CustomerId { get => customerId; set => customerId = value; }
        public int Id { get => id; set => id = value; }
    }
}
