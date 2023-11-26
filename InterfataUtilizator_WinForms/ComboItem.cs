using System;

namespace InterfataUtilizator
{
    public class ComboItem
    {
        public string Text { get; set; }
        public int Value { get; set; }

        public ComboItem(string text, int value)
        {
            Text = text;
            Value = value;
        }
        public override string ToString()
        {
            return Text;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            // verifica daca obiectul primit ca parametru poate fi convertit la un obiect de tip ComboItem
            if (!(obj is ComboItem ci))
            {
                return false;
            }

            // returneaza 'true' daca atat textele cat si valorile celor 2 obiecte sunt identice intre ele
            return (this.Text.Equals(ci.Text) && this.Value == ci.Value);
        }

        public override int GetHashCode()
        {
            return this.Value;
        }
    }
}
