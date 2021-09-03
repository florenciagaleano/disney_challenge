using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIDisney.Validation
{
    public class CheckValidQualification : ValidationAttribute
    {
        public CheckValidQualification()
        {
            ErrorMessage = "La calificacion puede ser del 1 al 5";
        }

        public override bool IsValid(object value)
        {
            int aux = (int)value;
            if (aux < 1 || aux > 5)
            {
                return false;
            }

            return true;
        }
    }
}
