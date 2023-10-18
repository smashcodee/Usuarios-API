namespace Usuarios.Data.Dto
{
    public class ReadUsuarioDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool status { get; set; }

        public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
    }
}
