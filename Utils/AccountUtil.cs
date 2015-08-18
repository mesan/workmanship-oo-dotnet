
using System;

namespace Utils
{
    public class AccountUtil {
        private static readonly int[] MOD_11_FACTORS = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };

        /** Lengden på gyldig organisasjonsnummer. */
        public static readonly int LEN_ORGNR = 9;

        /** Lengden på gyldig fødselsnummer. */
        public static readonly int LEN_FNR = 11;

        /**
     * Sjekker om kontonummer har gyldig format
     * 
     * @param accountNumber
     * @return
     */
        public static bool ValidAccountNumber(long accountNumber) 
        {
            // Check length
            if (accountNumber < 10000000000L || accountNumber > 99999999999L) 
            {
                return false;
            }

            // Mod11 check
            return Mod11Check(accountNumber);
        }

        private static bool Mod11Check(long accountNumber) 
        {
            int sum = 0;
            int[] digits = ExtractDigits(accountNumber);
            for (int i = 0; i < 10; i++) 
            {
                sum += digits[i] * MOD_11_FACTORS[i];
            }

            return 11 - (sum % 11) == digits[10];
        }

        private static int[] ExtractDigits(long accountNumber) 
        {
            int[] digits = new int[11];
            for (int i = 0; i < 11; i++) 
            {
                digits[i] = (int) ((accountNumber % (long) Math.Pow(10, 11 - i)) / (long) Math.Pow(10, 11 - i - 1));
            }
            return digits;
        }

        /**
     * Sjekker om fødselsnummeret har riktig format.
     * 
     * @param kundenr
     *            Fødselsnummer
     * @return <code>true</code> hvis gyldig format
     */
        public static bool GyldigFnr(string fnrOrg) 
        {
            if (fnrOrg == null || fnrOrg.Trim().Length != LEN_FNR) 
            {
                return false;
            }
            string fnr = fnrOrg.Trim();
            int index = 0;
            int delsum1 = 0;
            int delsum2 = 0;
            int[] faktor1 = new int[] { 3, 7, 6, 1, 8, 9, 4, 5, 2 };
            int[] faktor2 = new int[] { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            while (index < faktor2.Length) 
            {
                int intverdi = fnr.ToCharArray()[index];
                if (index < faktor1.Length) // Siffer 1-8
                { 
                    delsum1 += intverdi * faktor1[index];
                    delsum2 += intverdi * faktor2[index];
                } 
                else // Siffer 10
                {
                    int intmod1 = 11 - (delsum1 % 11);
                    if (!((intmod1 == intverdi) || (intmod1 == 11 && intverdi == 0))) {
                        return false;
                    }
                    delsum2 += intmod1 * faktor2[index];
                }
                index++;
            }
            int intverdi2 = fnr.ToCharArray()[index]; // Siffer 11
        
            int intmod2 = 11 - (delsum2 % 11);
            return ((intmod2 == intverdi2) || (intmod2 == 11 && intverdi2 == 0));
        }
    }
}
