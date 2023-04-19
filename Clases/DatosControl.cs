using ApiValhalla.Context;

namespace ApiValhalla.Clases
{
    public class DatosControl
    {
        private readonly AppDbContext _context;

        public DatosControl(AppDbContext context)
        {
            this._context = context;
        }

        public Models.PreparacionModel datosprepa(int idprep)
        {
            Models.PreparacionModel datos = new Models.PreparacionModel();
            var result = from prepa in _context.Preparacion
                         where idprep.Equals(idprep)
                         select prepa;
            return (Models.PreparacionModel)result;


        }
    }
}