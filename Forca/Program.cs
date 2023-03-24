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
            int erro;
            string letrasCorretas, letrasIncorretas, palavraescolhida, str, tentativa;
            bool acertou, aux;
            char[] linha;
            Declaracao(palavras, out erro, out letrasCorretas, out letrasIncorretas, out palavraescolhida, out acertou, out aux, out str, out linha, out tentativa);
            Execucao(ref erro, ref letrasCorretas, ref letrasIncorretas, palavraescolhida, out str, out tentativa, out acertou, ref aux, linha);
        }

        static void Execucao(ref int erro, ref string letrasCorretas, ref string letrasIncorretas, string palavraescolhida, out string str, out string tentativa, out bool acertou, ref bool aux, char[] linha)
        {
            while (true)
            {
                Console.Clear();
                Forca(erro, letrasIncorretas, palavraescolhida, out str, out acertou, linha);
                if (aux == true)
                {
                    Console.WriteLine("Letra repetida tente outra");
                }
                aux = false;

                Console.WriteLine();
                if (erro <= 4)
                {
                    Console.WriteLine("Bem vindo ao jogo da forca, para começar digite uma Letra ou 9 para sair");
                    tentativa = Console.ReadLine();
                    if (tentativa == "9")
                    {
                        return;
                    }
                    else
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
                        if (acertou == true)
                        {
                            letrasCorretas += char.ToLower(tentativa[0]);
                        }
                        else if (!letrasCorretas.Contains(char.ToLower(tentativa[0])) && !letrasIncorretas.Contains(char.ToLower(tentativa[0])))
                        {
                            letrasIncorretas += char.ToLower(tentativa[0]) + " ";
                            erro++;
                        }
                        else
                        {
                            aux = true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Você perdeu tente novamente");
                    Console.WriteLine($"A palavra correta era: {palavraescolhida}");
                    Console.ReadKey();
                    string[] a = null;
                    Main(a);
                }
            }
        }

        static void Forca(int erro, string letrasIncorretas, string palavraescolhida, out string str, out bool acertou, char[] linha)
        {
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


            Console.WriteLine("__________      ");
            Console.WriteLine(" |/      |      ");
            Console.WriteLine(" |       {0}     ", (erro >= 1 ? "O" : " "));
            Console.WriteLine(" |      {0}{1}{2}  ", (erro >= 3 ? "/" : " "), (erro >= 2 ? "X" : " "), (erro >= 3 ? "\\" : " "));
            Console.WriteLine(" |       {0}     ", (erro >= 4 ? "X" : " "));
            Console.WriteLine(" |       {0}     ", (erro >= 5 ? "X" : " "));
            Console.WriteLine(" |              ");
            Console.WriteLine(" |              ");
            Console.WriteLine("_|____          ");
            Console.WriteLine();

            Console.Write($"A palavra secreta é: {str}");
            Console.WriteLine($"\n Letras tentadas {letrasIncorretas}");
        }

        static void Declaracao(string[] palavras, out int erro, out string letrasCorretas, out string letrasIncorretas, out string palavraescolhida, out bool acertou, out bool aux, out string str, out char[] linha, out string tentativa)
        {
            Random rnd = new Random();
            int escolha = rnd.Next(0, (palavras.Length - 1));
            erro = 0;
            letrasCorretas = "";
            letrasIncorretas = "";
            palavraescolhida = (palavras[escolha]);
            acertou = false;
            aux = false;
            str = "";
            str = str.PadLeft(palavraescolhida.Length, '_');
            linha = str.ToCharArray();
            tentativa = "";
        }
    }
}