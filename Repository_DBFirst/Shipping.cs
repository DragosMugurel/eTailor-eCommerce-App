//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Repository_DBFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class Shipping
    {
        public int shipping_id { get; set; }
        public int order_id { get; set; }
        public System.DateTime shipping_date { get; set; }
        public string shipping_address { get; set; }
    }
}
