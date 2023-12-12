public List<PersonalTrainer> FiltrarPersonalTrainersComplexo(double distancia, int experiencia, string especialidade, string nivel)
{
    List<PersonalTrainer> personalFiltrados = new List<PersonalTrainer>();

    foreach (var personal in PersonalTrainers)
    {
        if (personal.Distancia <= distancia)
        {
            if (personal.ExperienciaAnos >= experiencia)
            {
                if (personal.Especialidade.ToLower() == especialidade.ToLower())
                {
                    if (personal.Nivel.ToLower() == nivel.ToLower())
                    {
                        if (personal.registro != null)
                        {
                         string apiUrl = $"{APICref}/verificar-certificacao?registro={numeroRegistro}";
                         HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                            if (response.IsSuccessStatusCode)
                            {
                                string responseBody = await response.Content.ReadAsStringAsync();
                
                                if (responseBody.Contains("certificado"))
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Erro na solicitação à API do CREF: {response.StatusCode}");
                                return false;
                            }
                        }
                                personalFiltrados.Add(personal);
                            }
                        }
                        else
                        {
                            personalFiltrados.Add(personal);

                            if (personal.Nivel.ToLower() == "intermediario" || personal.Nivel.ToLower() == "avancado")
                            {
                                    personalFiltrados.Add(personal);
                                
                            }
                        }
                    }
                }
            }
        }
    }
