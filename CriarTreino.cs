public IActionResult CriarTreino(int alunoId, [FromBody] TreinoRequest treinoRequest)
{
    // Ponto 1: Verifica se o aluno existe
    Aluno aluno = _alunos.FirstOrDefault(a => a.Id == alunoId);
    if (aluno == null)
    {
        // Ponto 2: Retorna NotFound se o aluno não existir
        return NotFound("Aluno não encontrado");
    }

    // Ponto 3: Cria um novo treino
    Treino treino = new Treino
    {
        Nome = treinoRequest.Nome,
        Exercicios = treinoRequest.Exercicios,
        Dia = treinoRequest.Dia,
        Duracao = treinoRequest.Duracao
    };

    // Ponto 4: Atribui o treino ao aluno
    aluno.AdicionarTreino(treino);

    // Ponto 5: Salva o treino na lista de treinos
    _treinos.Add(treino);

    // Ponto 6: Retorna Ok com o treino criado
    return Ok(treino);
}
