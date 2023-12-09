public IActionResult CriarTreino(int alunoId, [FromBody] TreinoRequest treinoRequest)
        {
            // Verifica se o aluno existe
            Aluno aluno = _alunos.FirstOrDefault(a => a.Id == alunoId);
            if (aluno == null)
            {
                return NotFound("Aluno não encontrado");
            }

            // Cria um novo treino
            Treino treino = new Treino
            {
                Nome = treinoRequest.Nome,
                Exercicios = treinoRequest.Exercicios,
                Dia = treinoRequest.Dia,
                Duracao = treinoRequest.Duracao
            };

            // Atribui o treino ao aluno
            aluno.AdicionarTreino(treino);

            // Salva o treino na lista de treinos (simulando um "banco de dados")
            _treinos.Add(treino);

            // Retorna um status de sucesso com o treino criado
            return Ok(treino);
        }
    }
