//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBFirstDemo
{
    using System;
    using System.Collections.Generic;
    
    public partial class pedido
    {
        public int id { get; set; }
        public Nullable<int> cliente_id { get; set; }
        public string item { get; set; }
        public Nullable<float> preco { get; set; }
    
        public virtual cliente cliente { get; set; }
    }
}
