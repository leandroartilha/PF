public IActionResult CriarTreino(int alunoId, [FromBody] TreinoRequest treinoRequest)
{
    Aluno aluno = _alunos.FirstOrDefault(a => a.Id == alunoId);
    if (aluno == null)
    {
        return NotFound("Aluno não encontrado");
    }
    else
    {
    Treino treino = new Treino
    {
        Nome = treinoRequest.Nome,
        Exercicios = treinoRequest.Exercicios,
        Dia = treinoRequest.Dia,
        Duracao = treinoRequest.Duracao
    };
    aluno.AdicionarTreino(treino);

    _treinos.Add(treino);
    }
    return Ok(treino);
}
