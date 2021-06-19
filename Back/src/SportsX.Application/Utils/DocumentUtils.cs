namespace SportsX.Application.Utils
{
    public static class DocumentUtils
    {
        public static bool IsDocumentValid(string document)
        {
            return (IsCPF(document) || IsCNPJ(document));
        }


        /// <summary>
        /// Metodo que faz o calculo do CPF com base na string passada:
        /// - Criado os auxiliadores do tipo array de int
        /// - Primeira verificacao se o CPF possui 11 caracteres
        /// - Verifica se os 11 numeros nao sao iguais entre 1-9. Ex: 11111111111
        /// - Pega os 9 primeiros caracteres do CPF para fazer o calculo
        /// - Pega a soma passando a posicao na string * a posicao do primeiro array auxiliar
        /// - Pega o resto da primeira soma
        /// - Pega a soma passando a posicao na string * a posicao do segundo array auxiliar
        /// - Pega o resto da segunda soma 
        /// - Verifica se o CPF termina com os 2 numeros encontrados no resto
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        private static bool IsCPF(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");

            if (cpf.Length != 11) return false;

            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                    return false;

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;


            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }


        /// <summary>
        /// Metodo para verificar se o CNPJ e valido:
        /// - Criado os auxiliadores para o calculo do tipo array de int
        /// - Realizado a soma com base na multiplicação do valor no CPNJ pelo valor na tabela auxiliar para validar o primeiro dígito depois do '-'
        /// - Retorna o primeiro resto que deve ser validado no CNPJ inserido
        /// - Realiza a segunda soma com o segundo array auxiliar
        /// - Retorna o resto da segunda soma que deve ser validado no CNPJ inserido
        /// - Verifica se o CNPJ inserido termina com a sequencia dos 2 numeros encontrados no calculo
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        private static bool IsCNPJ(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };


            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14) return false;

            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            int resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();

            tempCnpj = tempCnpj + digito;

            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }
    }
}