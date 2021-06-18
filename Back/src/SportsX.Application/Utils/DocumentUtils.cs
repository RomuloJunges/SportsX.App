namespace SportsX.Application.Utils
{
    public static class DocumentUtils
    {
        public static bool IsDocumentValid(string document)
        {
            return (IsCPF(document) || IsCNPJ(document));
        }

        private static bool IsCPF(string cpf)
        {
            // Auxiliador para o calculo do CPF
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            //Removendo os caracteres da string
            cpf = cpf.Trim().Replace(".", "").Replace("-", "");

            //Se o CPF não conter 11 caracteres retorna falso
            if (cpf.Length != 11) return false;

            //Verifica se o CPF não é 11 números iguais entre 1-9. Ex: 11111111111
            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                    return false;

            //Pega os 9 primeiros caracteres do CPF
            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            //Realiza a soma passando a posição do número na string multiplicado pela posição no array auxiliar
            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            //Retorna o primeiro dígito após o '-' com base no cálculo
            string digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;

            //Realiza a soma passando a posição do número na string multiplicado pela posição no array auxiliar
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            //Retorna o segundo dígito após o '-' com base no cálculo
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            //Monta o valor que deve ser retornado depois do '-' e se for igual então o CPF é válido
            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }

        private static bool IsCNPJ(string cnpj)
        {
            // Auxiliador para o calculo do CNPJ
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };


            // Remove os caracteres da string
            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14) return false;

            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;

            //Realizado a soma com base na multiplicação do valor no CPNJ pelo valor na tabela auxiliar para validar o primeiro dígito depois do '-'
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            int resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            //Retorna o primeiro valor que deve ser validado no CNPJ
            string digito = resto.ToString();

            tempCnpj = tempCnpj + digito;

            soma = 0;


            //Realizado a soma com base na multiplicação do valor no CPNJ pelo valor na tabela auxiliar para validar o segundo dígito depois do '-'
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);

            //Retorna o segundo valor que deve ser validado no CNPJ
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            //Monta o final do CPNJ que deve ser igual ao que foi informado
            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }
    }
}