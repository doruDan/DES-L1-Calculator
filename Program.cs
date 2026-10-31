using DES_L1_Calculator.HelperMethods;

Console.InputEncoding = System.Text.Encoding.UTF8;
Console.OutputEncoding = System.Text.Encoding.UTF8;
bool run = true;

while (run){
    DESHelpers.PrintIPTable(); //prints the IP table used

    Console.WriteLine("Alegeți o opțiune:");
    Console.WriteLine("1. Mesaj propriu");
    Console.WriteLine("2. Mesaj generat");
    Console.WriteLine("0. Ieșire");
    int userChoice = InputHelpers.ValidatingUserChoice();

    string input = "";
    switch(userChoice)
    {
        case 1:
            Console.WriteLine("Introduceți un mesaj de 8 caractere:");
            input = InputHelpers.ValidatingUserInput();
            break;
        case 2:
            input = InputHelpers.RandomStringGenerator(8);
            Console.WriteLine($"Mesajul generat: {input}");
            break;
        case 0:
            run = false;
            break;
    }

    if (run)
    {
        Console.WriteLine("--- Pasul 1: Conversia caracterelor în binar ---");
        List<string> binaryChars = new List<string>();

        foreach (char character in input)
        {
            int charASCIINumber = (int)character;
            string charToBinary = Convert.ToString(charASCIINumber, 2).PadLeft(8, '0');

            binaryChars.Add(charToBinary);
            Console.WriteLine($"{character} în ASCII: {charASCIINumber}, în binar: {charToBinary}");
        }

        string binaryInput = string.Join("", binaryChars);
        Console.WriteLine($"\nBlocul inițial de 64 biți:\n{binaryInput}\n");

        Console.WriteLine("--- Pasul 2: Aplicarea Permutării Inițiale ---");
        string permutedChars = DESHelpers.ApplyInitialPermutation(binaryInput);
        Console.WriteLine($"Blocul permutat de 64 biți:\n{permutedChars}\n");

        Console.WriteLine("--- Pasul 3: Împărțirea în L0 și R0 pentru a afla L1 ---");
        string L0 = permutedChars.Substring(0, 32);
        string R0 = permutedChars.Substring(32, 32);

        Console.WriteLine($"L0 (32 biți din stânga):  {L0}");
        Console.WriteLine($"R0 (32 biți din dreapta): {R0}\n");

        string L1 = R0;
        Console.WriteLine("Conform algoritmului DES: L1 = R0");
        Console.WriteLine($"L1 Final: {L1}\n");
    }
}