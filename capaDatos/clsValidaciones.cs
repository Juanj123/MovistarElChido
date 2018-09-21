using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace capaDatos
{
    public class clsValidaciones
    {
        public Boolean Nombre(string cadena)
        {
            Regex ex = new Regex("([A-Z ÑÁÉÍÚÓ]?[\\\\.]?[a-zá ñéíóú]+[\\\\s]?)+");
            if (ex.IsMatch(cadena))
            {
                return true;
            }
            else
                return false;
        }

        public void Letras(KeyPressEventArgs v)
        {
            try
            {
                if (char.IsLetter(v.KeyChar))
                {
                    v.Handled = false;

                }
                else if (char.IsControl(v.KeyChar))
                {
                    v.Handled = false;
                }
                else if (char.IsSeparator(v.KeyChar))
                {
                    v.Handled = false;
                }
                else
                {
                    v.Handled = true;
                }

            }
            catch (Exception exc)
            {

            }
        }

        public void Numeros(KeyPressEventArgs v)
        {
            try
            {
                if (char.IsDigit(v.KeyChar))
                {
                    v.Handled = false;

                }
                else if (char.IsControl(v.KeyChar))
                {
                    v.Handled = false;
                }
                else if (char.IsSeparator(v.KeyChar))
                {
                    v.Handled = false;
                }
                else
                {
                    v.Handled = true;
                }

            }
            catch (Exception exc)
            {

            }
        }

        public void Numeros_Letras(KeyPressEventArgs v)
        {
            try
            {
                if (char.IsNumber(v.KeyChar))
                {
                    v.Handled = false;

                }
                else if (char.IsControl(v.KeyChar))
                {
                    v.Handled = false;
                }
                else if (char.IsSeparator(v.KeyChar))
                {
                    v.Handled = false;
                }
                else if (char.IsLetter(v.KeyChar))
                {
                    v.Handled = false;
                }
                else
                {
                    v.Handled = true;
                }

            }
            catch (Exception exc)
            {

            }
        }

        public Boolean email_bien_escrito(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void NumerosDoubles(KeyPressEventArgs v)
        {
            try
            {
                if (char.IsDigit(v.KeyChar))
                {
                    v.Handled = false;

                }
                else if (char.IsControl(v.KeyChar))
                {
                    v.Handled = false;
                }
                else if (char.IsSeparator(v.KeyChar))
                {
                    v.Handled = false;
                }

                else if (v.KeyChar.ToString().Equals("."))
                {
                    v.Handled = false;
                }
                else
                {
                    v.Handled = true;
                }

            }
            catch (Exception exc)
            {

            }
        }

    }
}