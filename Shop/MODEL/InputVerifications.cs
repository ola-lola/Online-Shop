using System.Text.RegularExpressions;


namespace Shop {
    public class InputVerifications {

        public static bool IsEmail(string checkedString) {
            // TODO: may be updated
            string regMatchPasswordCriteria = "^(?=.*[A-Za-z\\d])(?=.*[@])(?=.*[a-z])(?=.*[.])(?=.+[a-z])[A-Za-z@.\\d]{0,25}$";
            Regex reg = new Regex(regMatchPasswordCriteria);
            return reg.IsMatch(checkedString) ? true : false;
        }

        public static bool IsTelephone(string checkedString) {
            // verify only numeric values + length exactly equal to 9
            string regMatchPasswordCriteria = "^[\\d]{9}$";
            Regex reg = new Regex(regMatchPasswordCriteria);
            return reg.IsMatch(checkedString) ? true : false;
        }

        public static bool IsCreditCardNo(string checkedString) {
            // verify only numeric values + length exactly equal to 16
            string regMatchPasswordCriteria = "^[\\d]{16}$";
            Regex reg = new Regex(regMatchPasswordCriteria);
            return reg.IsMatch(checkedString) ? true : false;
        }
    }
}