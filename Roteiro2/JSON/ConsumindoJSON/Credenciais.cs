using Newtonsoft.Json;

class Credenciais
{
    public string Email {get; set;}
    [JsonIgnore][JsonRequired][JsonProperty(Required = Required.Always)]
    public string Senha {get; set;}
}