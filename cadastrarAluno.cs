public static void CadastrarAluno(Aluno aluno)
    {
        if (!ValidarCPF(aluno.CPF))
        {
            Console.WriteLine("CPF inválido. Por favor, insira um CPF válido.");
            return NotFound();
        }

        if (!ValidarEndereco(aluno.Endereco))
        {
            Console.WriteLine("Endereço inválido. Por favor, insira um endereço válido.");
            return NotFound();
        }

        Aluno novoAluno = new Aluno
        {
            Nome = aluno.Nome,
            Endereco = aluno.Endereco,
            CPF = aluno.cpf,
            MedidasCorporais = aluno.Medidas,
            ObservacaoSaude = aluno.obs,
            DataNascimento = aluno.DataNascimento,
            Objetivo = aluno.objetivo
        };
        _context.Alunos.Add(aluno);
        return Ok("Aluno cadastrado com sucesso!");
    }
