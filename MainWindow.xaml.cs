using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CZD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
           
            InitializeComponent();
        }

        string plaintext; //String variable to store the user input plaintext
        int len; //Variable to store the length of the plaintext

        /// <summary>
        /// Events that happen during the first button click
        /// </summary>
        private void Atbash_Click(object sender, RoutedEventArgs e)
        {
          plaintext = this.Plaintext.Text.ToString(); // The plaintext is taken from the user input in the textbox
          Atbash(plaintext); // The Atbash cipher method is used to encrypt the plaintext
          len = plaintext.Length; // The length of the plaintext is stored in a variable (to be used in another method)
        }

        //A readonly constant array of characters from A-Z. To be used in the second encryption.
        public static readonly char[] a = { 'A', 'B', 'C', 'D', 'E', 'F', 'G',
                                        'H', 'I', 'J', 'K', 'L', 'M', 'N',
                                        'O', 'P', 'Q', 'R', 'S', 'T', 'U',
                                        'V', 'W', 'X', 'Y', 'Z' };
        /// <summary>
        /// Method, which takes the user string input and copies it to a char array
        /// </summary>
        /// <returns>Atbash cipher text</returns>
        public int Atbash(string plaintext)
        {
            IDictionary<char, char> alphabet = new Dictionary<char, char>(); //Empty dictionary created
            alphabet.Add('A', 'Z'); //keys and values added to dictionary
            alphabet.Add('B', 'Y');
            alphabet.Add('C', 'X');
            alphabet.Add('D', 'W');
            alphabet.Add('E', 'V');
            alphabet.Add('F', 'U');
            alphabet.Add('G', 'T');
            alphabet.Add('H', 'S');
            alphabet.Add('I', 'R');
            alphabet.Add('J', 'Q');
            alphabet.Add('K', 'P');
            alphabet.Add('L', 'O');
            alphabet.Add('M', 'N');
            alphabet.Add('N', 'M');
            alphabet.Add('O', 'L');
            alphabet.Add('P', 'K');
            alphabet.Add('Q', 'J');
            alphabet.Add('R', 'I');
            alphabet.Add('S', 'H');
            alphabet.Add('T', 'G');
            alphabet.Add('U', 'F');
            alphabet.Add('V', 'E');
            alphabet.Add('W', 'D');
            alphabet.Add('X', 'C');
            alphabet.Add('Y', 'B');
            alphabet.Add('Z', 'A');

            string temp = plaintext; //User input plaintext is stored in temp
            char[] plaintextChar = temp.ToUpper().ToCharArray(); //Plaintext converted and saved to char array as upper case chars
            char[] cryptotext = new char[plaintextChar.Length]; //New array for the cryptotext with the same length as plaintextChar[]

            StringBuilder sb = new StringBuilder(); //Initializing an instance of a mutable string of chars

            //Every character in the plaintext is compared to the alphabet dictionary and assigned to the cryptotext char array
            for (int i = 0; i < plaintextChar.Length; i++)
            {
                char letter = plaintextChar[i];
                alphabet.TryGetValue(letter, out char key_temp);//Temporary variable to store the dictionary value, which corresponds to the key
                sb.Append(key_temp); //The dictionary value is added to the StringBuilder variable
                
            }
            this.AtbText.Text = sb.ToString(); //Prints the Atbash cryptotext string to the WPF textbox
            return cryptotext.Length;
        }

        /// <summary>
        /// Event that happens during the second button click
        /// </summary>
        private void OTP_Click(object sender, RoutedEventArgs e)
        {
            Encrypt(this.AtbText.Text,GenerateRandomKey(len));
        }

        /// <summary>
        /// Method, which generates a random key
        /// </summary>
        /// <param name="length">Length of the key, which will be created</param>
        /// <returns>Key value</returns>
        public string GenerateRandomKey(int length)
        {
            StringBuilder key = new StringBuilder(); //Initializing an instance of a mutable string of chars
            Random rand = new Random(); //Pseudo-random number generator
            char ch;

            for (int i = 0; i < length; i++)
            {
                double db = rand.NextDouble(); //Returns a double fp number => 0.0 and < 1.0
                int shift = Convert.ToInt32(Math.Floor(db * 25)); //Returns the largest integral value < or = (db*25)
                ch = Convert.ToChar(shift + 65); //Converting to upper case letters 
                key.Append(ch); //Adding the letters to the key string
            }
            this.KeyText.Text = key.ToString(); //Print key string to textbox in WPF form
            return key.ToString();
        }

        /// <summary>
        /// Second encryption
        /// </summary>
        /// <param name="plaintext">Atbash encrypted text</param>
        /// <param name="key">The randomly generated key</param>
        public void Encrypt(string plaintext, string key)
        {
            IDictionary<int, char> numberedAlphabet = new Dictionary<int, char>(); //Empty dictionary created
            numberedAlphabet.Add(0, 'A'); //keys and values added to dictionary
            numberedAlphabet.Add(1, 'B');
            numberedAlphabet.Add(2, 'C');
            numberedAlphabet.Add(3, 'D');
            numberedAlphabet.Add(4, 'E');
            numberedAlphabet.Add(5, 'F');
            numberedAlphabet.Add(6, 'G');
            numberedAlphabet.Add(7, 'H');
            numberedAlphabet.Add(8, 'I');
            numberedAlphabet.Add(9, 'J');
            numberedAlphabet.Add(10, 'K');
            numberedAlphabet.Add(11, 'L');
            numberedAlphabet.Add(12, 'M');
            numberedAlphabet.Add(13, 'N');
            numberedAlphabet.Add(14, 'O');
            numberedAlphabet.Add(15, 'P');
            numberedAlphabet.Add(16, 'Q');
            numberedAlphabet.Add(17, 'R');
            numberedAlphabet.Add(18, 'S');
            numberedAlphabet.Add(19, 'T');
            numberedAlphabet.Add(20, 'U');
            numberedAlphabet.Add(21, 'V');
            numberedAlphabet.Add(22, 'W');
            numberedAlphabet.Add(23, 'X');
            numberedAlphabet.Add(24, 'Y');
            numberedAlphabet.Add(25, 'Z');

            char[] converted_key = key.ToCharArray(); //The key is parsed as an array and stored
            int[] cp = new int[plaintext.Length]; //Temporary char array for the Atbash text
            int[] ck = new int[key.Length]; //Temporary char array for the key
            char[] cryptotext = new char[plaintext.Length]; //Array to store the final cryptotext

            for (int i = 0; i < plaintext.Length; i++)
            {
                int p = plaintext[i] - 64; //Each letter of the text is within the 1-26 range
                cp[i] = p;
            }

            for (int i = 0; i < converted_key.Length; i++)
            {
                int t = converted_key[i] - 64; //Each letter of the text is within the 1-26 range
                ck[i] = t;
            }

            for (int i = 0; i < ck.Length; i++)
            {
                int res = ((ck[i] + cp[i]) % 26); //Sum of each char from the key and the text. Mod26 is applied to the result
                numberedAlphabet.TryGetValue(res, out char ch); //Getting the dictionary value with key "res"
                cryptotext[i] = ch;
            }
            string charsStr = new string(cryptotext); //Storing the array in a string variable
            this.CryptotextText.Text = charsStr; //Print cryptotext to textbox in WPF form
        }
    }
}
