using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;

namespace Forca
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.Title = "Jogo da forca";
            String[] palavras = { "brasil", "argentina", "chile", "uruguai", "paraguai", "peru", "bolivia", "equador", "colombia", "venezuela", "guiana", "suriname", "haiti", "costa rica", "panama", "nicaragua", "honduras", "belize", "canadá", "méxico", "estados unidos", "austrália", "nova zelândia", "japão", "china", "coreia do sul", "coreia do norte", "india", "rússia", "italia", "espanha" };
            Random rnd = new Random();
            int escolha = rnd.Next(0, (palavras.Length-1));
            int erro = 0;
            string letrasCorretas="";
            string letrasIncorretas = "";
            String palavraescolhida = (palavras[escolha]);
            bool acertou = false;
            bool aux = false;
            string str = "";
            str = str.PadLeft(palavraescolhida.Length, '_');
            char[] linha = str.ToCharArray();
            String tentativa = "";
            
            while (true)
            {
                Console.Clear();
                str = new string(linha);
                acertou = false;
                if (palavraescolhida.Equals(str))
                {
                    Console.WriteLine("Você venceu parabéns");
                    Console.WriteLine($"A palavra correta era: {palavraescolhida} e você acertou");
                    Console.ReadKey();
                    string[] a = null;
                    Main(a);
                }
                
                
                Console.WriteLine(palavraescolhida);
                Console.WriteLine("__________      ");
                Console.WriteLine(" |/      |      ");
                Console.WriteLine(" |       {0}     ",(erro >= 1 ? "O" : " "));
                Console.WriteLine(" |      {0}{1}{2}  ", (erro >= 3 ? "/" : " "), (erro >= 2 ? "X" : " "), (erro >= 3 ? "\\" : " "));
                Console.WriteLine(" |       {0}     ", (erro >= 4 ? "X" : " "));
                Console.WriteLine(" |       {0}     ", (erro >= 5 ? "X" : " "));
                Console.WriteLine(" |              ");
                Console.WriteLine(" |              ");
                Console.WriteLine("_|____          ");
                Console.WriteLine();

                Console.Write($"A palavra secreta é: {str}");
                Console.WriteLine($"\n Letras tentadas {letrasIncorretas}");
                if (aux == true)
                {
                    Console.WriteLine("Letra repetida tente outra");
                }
                aux = false;

                Console.WriteLine();
                if (erro <= 4){
                    Console.WriteLine("Bem vindo ao jogo da forca, para começar digite uma Letra ou 9 para sair");
                    tentativa = Console.ReadLine();
                    if (tentativa == "9")
                    {
                        return;
                    }else
                    {
                        for (int i = 0; i < palavraescolhida.Length; i++)
                        {
                            if (palavraescolhida[i].Equals(char.ToLower(tentativa[0])) && !letrasCorretas.Contains(char.ToLower(tentativa[0])))
                            {
                                linha[i] = tentativa[0];
                                acertou = true;
                            }
                            else
                            {
                                
                                continue;
                            }
                        }
                        if(acertou == true) {
                            letrasCorretas += char.ToLower(tentativa[0]);
                        }
                        else if(!letrasCorretas.Contains(char.ToLower(tentativa[0]))&& !letrasIncorretas.Contains(char.ToLower(tentativa[0])))
                        {
                            letrasIncorretas += char.ToLower(tentativa[0]) + " ";
                            erro++;
                        }
                        else
                        {
                            aux = true;
                        }
                    }
                }else{
                    Console.WriteLine("Você perdeu tente novamente");
                    Console.WriteLine($"A palavra correta era: {palavraescolhida}") ;
                    Console.ReadKey();
                    string[] a = null;
                    Main(a);
                }
            }
        }
    }
}