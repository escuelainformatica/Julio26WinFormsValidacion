namespace Ejercicio_21072021.BD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pedido")]
    public partial class Pedido
    {
        [Key]
        public int IdPedido { get; set; }

        [StringLength(maximumLength:20,ErrorMessage ="El rut no puede ser mas de 20 caracteres")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="El rut tiene que existir")]
        public string RutCliente { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El producto tiene que seleccionarse")]
        [RegularExpression("(.*[1-9].*)|(.*[.].*[1-9].*)",ErrorMessage ="El producto es necesario")]
        public int? IdProducto { get; set; }

        [Range(minimum: 0,maximum: 200,ErrorMessage = "La cantidad tiene que estar entre 0 y 200")]
        public int? Cantidad { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
