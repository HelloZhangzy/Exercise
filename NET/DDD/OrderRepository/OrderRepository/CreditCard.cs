//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrderRepository
{
    using System;
    using System.Collections.Generic;
    
    public partial class CreditCard
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string HolderName { get; set; }
        public string ExpirationDate { get; set; }
    
        public virtual Customer Customer { get; set; }
    }
}
