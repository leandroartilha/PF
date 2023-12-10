public List<PersonalTrainer> FiltrarPersonalTrainersComplexo(double distancia, int experiencia, string especialidade, string nivel)
{
    List<PersonalTrainer> personalFiltrados = new List<PersonalTrainer>();

    foreach (var personal in PersonalTrainers)
    {
        // Filtro baseado na distância
        if (personal.Distancia <= distancia)
        {
            // Filtro baseado no tempo de experiência
            if (personal.ExperienciaAnos >= experiencia)
            {
                // Filtro baseado na especialidade
                if (personal.Especialidade.ToLower() == especialidade.ToLower())
                {
                    // Filtro baseado no nível
                    if (personal.Nivel.ToLower() == nivel.ToLower())
                    {
                        // Caso especial: Se o nível for "Avançado", aplicar filtro adicional
                        if (personal.registro != null)
                        {
                            
             string apiUrl = $"{APICref}/verificar-certificacao?registro={numeroRegistro}";

            // Fazer uma solicitação GET à API do CREF
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            // Verificar se a resposta foi bem-sucedida (código 200 OK)
            if (response.IsSuccessStatusCode)
            {
                // Aqui, você analisaria a resposta da API para determinar se o profissional tem certificação
                // Este é um exemplo simples; a estrutura real dependeria da resposta da API do CREF
                string responseBody = await response.Content.ReadAsStringAsync();

                // Verificar o conteúdo da resposta (isso dependeria da estrutura da resposta real)
                if (responseBody.Contains("certificado"))
                {
                    return true; // O profissional tem certificação
                }
                else
                {
                    return false; // O profissional não tem certificação
                }
            }
            else
            {
                // Se a resposta não for bem-sucedida, você pode lidar com isso conforme necessário
                Console.WriteLine($"Erro na solicitação à API do CREF: {response.StatusCode}");
                return false;
            }
        }
                                personalFiltrados.Add(personal);
                            }
                        }
                        else
                        {
                            // Adiciona o personal à lista de personal trainers filtrados
                            personalFiltrados.Add(personal);

                            // Caso especial: Se o nível for "Intermediário", aplicar filtro adicional
                            if (personal.Nivel.ToLower() == "intermediario" || personal.Nivel.ToLower() == "avancado")
                            {
                                    // Adiciona novamente o personal à lista de personal trainers filtrados
                                    personalFiltrados.Add(personal);
                                
                            }
                        }
                    }
                }
            }
        }
    }
