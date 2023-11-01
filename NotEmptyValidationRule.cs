using Login_and_2048_game;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MaterialDesignDemo.Domain
{


public class NotEmptyValidationRule : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        string password = (value ?? "").ToString();
        if (password?.Length == 0) return new ValidationResult(false, "Field is required");
        if (password?.Length <= 8) return new ValidationResult(false, "At least 8 digits");
        return ValidationResult.ValidResult;
    }
}

public class PasswordValidateRule : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        MainWindow.errors.Clear();
        string password = (value ?? "").ToString();
        bool isValidationFalse = false;
        if (password?.Length == 0) { isValidationFalse = true; MainWindow.errors.Add("Field is required"); }
        if (password?.Length <= 8) { isValidationFalse = true; MainWindow.errors.Add("At least 8 digits"); }
        bool ContBigLetter = false;
        bool ContSmallLetter = false;
        bool ContNumber = false;
        bool ContSpace = false;
            foreach (var item in password ?? "")
        {
            if (ContBigLetter && ContSmallLetter && ContNumber && ContSpace) break;
            
            if (item == 32) ContSpace = true;
            if (item >= 48 && item <= 57)
            {
                ContNumber = true;
            }
            if (item >= 65 && item <= 90)
            {
                ContBigLetter = true;
            }
            else if (item >= 97 && item <= 122)
            {
                ContSmallLetter = true;
            }
        }
        if (!ContBigLetter) { isValidationFalse = true; MainWindow.errors.Add("Need to contain a big letter"); }
            if (!ContSmallLetter) { isValidationFalse = true; MainWindow.errors.Add("Need to contain a smoll letter"); }
            if (!ContNumber) { isValidationFalse = true; MainWindow.errors.Add("Need to contain a number"); }
            if (ContSpace) { isValidationFalse = true; MainWindow.errors.Add("White spaces is not allower"); }

            if (isValidationFalse)
            {
                return new ValidationResult(false,"");
            }
            return ValidationResult.ValidResult;
    }
}
}