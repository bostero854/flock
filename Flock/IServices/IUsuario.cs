namespace Flock.IServices
{
    public interface IUsuario
    {
        Models.Usuario GetUsuario(Models.LoginUsuario loginUsuario);
    }
}
