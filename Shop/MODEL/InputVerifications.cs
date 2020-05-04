using System.Text.RegularExpressions;


namespace Shop {
    public class InputVerifications {

        public static bool IsEmail(string checkedString) {
            // TODO: may be updated
            string regMatchPasswordCriteria = @"^(?=[\w._%+-]+@[\w.-]+.[a-zA-Z])[\w.@]{4,25}$";
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
    

        public static bool IsStreet(string checkedString) {
            string regMatchPasswordCriteria = "^[A-Za-z]{1,14}$";
            Regex reg = new Regex(regMatchPasswordCriteria);
            return reg.IsMatch(checkedString) ? true : false;
        }

        public static bool IsHouseNb(string checkedString) {
            string regMatchPasswordCriteria = "^[\\d]{1,4}$";
            Regex reg = new Regex(regMatchPasswordCriteria);
            return reg.IsMatch(checkedString) ? true : false;
        }

        public static bool IsPostalCode(string checkedString) {
            string regMatchPasswordCriteria = "^[\\d]{5}$";
            Regex reg = new Regex(regMatchPasswordCriteria);
            return reg.IsMatch(checkedString) ? true : false;
        }
    }
}